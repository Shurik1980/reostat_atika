using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Net;
using System.Net.Sockets;
using System.Text;

//модуль ICP 0x02   нап333ряжение и темп борта
//модуль реле 0x03
//модуль power 0x04  ток генератора
//модуль частоты оборотов 0x08
//модуль входных реле 0x06
//модуль ADC 0x05  термопар 7-12, давление
//модуль термопар 1-6, температура воды масла 0x07

namespace reostat
{
    static class Program
    {
        private static int pozReostat=0;
        private static string typeLoc ="";
        private static string numberLoc = "";
        private static bool checkTimer = false;
        private static bool checkSecund = false;
        private static int countTimer = 0;
        private static ExtData extData = new ExtData();
        private static bool preStateRP1 = false;
        private static bool preStateRP2 = false;
        private static myclass[] dataClass;
        private static Thread myThread;
        private static Thread myThreadClient;
        private static string data = null;
        private static webserver web;
        private static System.Threading.Timer time;
        private static System.Threading.TimerCallback cb;
        private static int owtemp=0;
        private static int pozExt = 0;
        private static bool flagExt = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            myThread = new Thread(func); //Создаем новый объект потока (Thread)
            myThreadClient = new Thread(funcClient); //Создаем новый объект потока (Thread)
            
            cb = new System.Threading.TimerCallback (ProcessTimerEvent);
            time = new System.Threading.Timer(cb, null, 0, 1000);


            System.IO.File.Delete(@".\report.xml");
            System.IO.File.Delete(@".\powerGraph.jpg");
            System.IO.File.Delete(@".\extGraph.jpg");

            myThread.Start(); //запускаем поток
            myThreadClient.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new openForm());
            web.stop();
            myThread.Abort();
            myThreadClient.Abort();
            
        }

       
        static void ProcessTimerEvent(Object myObject)
        {
            
            countTimer++;
            if (countTimer > 5)
            {
                checkTimer = true;
                checkSecund = true;
                dataClass[10].FlagValid = true;
            }
        }


        static void func()
        {

            CallBackMy.callbackEventHandlerPozReostat = new CallBackMy.callbackEventPozReostat(ReloadPoz);
            CallBackMy.callbackEventHandlerPozKM = new CallBackMy.callbackEventPozKM(ReloadPozKM);
            CallBackMy.callbackEventHandlerTypeLoc = new CallBackMy.callbackEventTypeLoc(ReloadTypeLoc);
            CallBackMy.callbackEventHandlerNumberLoc = new CallBackMy.callbackEventNumberLoc(ReloadNumberLoc);
            CallBackMy.callbackEventHandlerExtPoint = new CallBackMy.callbackEventExtPoint(ReloadExtPoint);
            CallBackMy.callbackEventHandlerNew = new CallBackMy.callbackEventNew(ReloadData);

            int pozTeplovozPrev = 0;
            int pozTeplovoz = 0;
            pozReostat = 0; 
            dataClass = new myclass[11];
            int i=0;
            while (i != 11)
            {
                dataClass[i] = new myclass();
                i++;
            }

            CRC crc = new CRC();
            DefPoz def = new DefPoz();
            PowerData[] powerData = new PowerData[9];
            i = 0;
            while (i != 9)
            {
                powerData[i] = new PowerData();
                i++;
            }

            web = new webserver();
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            web.start(ipAddress, 80, 5, @".\");

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ip = IPAddress.Any;
            IPEndPoint ipe = new IPEndPoint(ip, 128);
            s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            s.Bind(ipe);
            byte[] buffer = new byte[1024];
            IPAddress ipRem = IPAddress.Any;
            int portRem = 128;
            IPEndPoint Rem = new IPEndPoint(ipRem, portRem);
            EndPoint EndRem = (EndPoint)Rem;
            XmlDocument parserXml = new XmlDocument();
            string error;
            Thread.Sleep(200);
            
            for (; ; )
            {
                Thread.Sleep(200);

                if (s.Available > 0)
                {
                    s.ReceiveFrom(buffer, ref EndRem);
                    data = Encoding.ASCII.GetString(buffer);
                    data.IndexOf("<EOF>");
                    data = data.Remove(data.IndexOf("<EOF>"), 5);
                    try
                    {
                        parserXml.LoadXml(data);
                    }
                    catch (Exception e)
                    {
                        error = e.ToString();
                    }
                    XmlNodeList xml;

                    xml = parserXml.GetElementsByTagName("owtemp");
                    if (xml.Count > 0)
                        owtemp = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("current");
                    if(xml.Count>0)
                        dataClass[10].Current = (int)(Math.Abs(Convert.ToInt32(xml[0].InnerText) * 1500 / 4095));
                    xml = parserXml.GetElementsByTagName("voltage");
                    if (xml.Count > 0)
                    dataClass[10].Voltage = (int)(Math.Abs(Convert.ToInt32(xml[0].InnerText) * 1000 / 4095));
                    xml = parserXml.GetElementsByTagName("voltagebort");
                    if (xml.Count > 0)
                    dataClass[10].VoltageBort = (int)(Convert.ToInt32(xml[0].InnerText));
                    xml = parserXml.GetElementsByTagName("tempbort");
                    if (xml.Count > 0)
                    dataClass[10].TempBort = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempgas1");
                    if (xml.Count > 0)
                    dataClass[10].TempCil1 = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempgas2");
                    if (xml.Count > 0)
                    dataClass[10].TempCil2 = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempgas3");
                    if (xml.Count > 0)
                    dataClass[10].TempCil3 = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempgas4");
                    if (xml.Count > 0)
                    dataClass[10].TempCil4 = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempgas5");
                    if (xml.Count > 0)
                    dataClass[10].TempCil5 = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempgas6");
                    if (xml.Count > 0)
                    dataClass[10].TempCil6 = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("rpm");
                    if (xml.Count > 0)
                    dataClass[10].RpmDGU = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempwater");
                    if (xml.Count > 0)
                    dataClass[10].TempWater = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("tempoil");
                    if (xml.Count > 0)
                    dataClass[10].TempOil = Convert.ToInt32(xml[0].InnerText);
                    xml = parserXml.GetElementsByTagName("pressoil");
                    if (xml.Count > 0)
                        dataClass[10].PressGas = Convert.ToInt32(xml[0].InnerText) / 100.0 ;
                    xml = parserXml.GetElementsByTagName("pressgas");
                    if (xml.Count > 0)
                        dataClass[10].PressOil = Convert.ToInt32(xml[0].InnerText) / 100.0;


                    xml = parserXml.GetElementsByTagName("pozteplovoz");
                    if (xml.Count > 0)
                    {
                        def.DefinitionPoz(xml[0].InnerText, typeLoc);
                        if (flagExt == false)
                            dataClass[10].PozDGU = def.PozDGU;//рабочее
                        else
                            dataClass[10].PozDGU = pozExt;
                        pozTeplovoz = dataClass[10].PozDGU;
                        dataClass[10].StateVSH1 = def.StateVSH1;
                        dataClass[10].StateVSH2 = def.StateVSH2;
                    }
                }

                if (flagExt == true)
                {
                    dataClass[10].PozDGU = pozExt;
                    pozTeplovoz = dataClass[10].PozDGU;
                }

                if (pozTeplovoz != pozTeplovozPrev)
                    {
                        pozTeplovozPrev = pozTeplovoz;
                        checkTimer = false;
                        countTimer = 0;
                        dataClass[10].FlagValid = false;
                    }
                if ((pozTeplovoz == 8) && (dataClass[10].Current > 300))
                    dataClass[10].Power = (int)(((dataClass[10].Current * dataClass[10].Voltage) / 1000) + (dataClass[10].TempBort - 20));
                else
                    dataClass[10].Power = (dataClass[10].Current * dataClass[10].Voltage) / 1000;
                dataClass[10].TypeLoc = typeLoc;
                dataClass[10].NumberLoc = numberLoc;
                dataClass[10].PozReostat = pozReostat;

                if ((checkTimer == true) && (checkSecund == true))
                {
                    checkSecund = false;
                    string htmTeg;
                    string text = System.IO.File.ReadAllText(@".\index.html");
                    htmTeg = "<!--current-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].Current.ToString());
                    htmTeg = "<!--voltage-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].Voltage.ToString());
                    htmTeg = "<!--voltagebort-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].VoltageBort.ToString());
                    htmTeg = "<!--power-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].Power.ToString());
                    htmTeg = "<!--rpmdgu-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].RpmDGU.ToString());
                    htmTeg = "<!--tempwater-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempWater.ToString());
                    htmTeg = "<!--tempoil-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempOil.ToString());
                    htmTeg = "<!--pressoil-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].PressOil.ToString());
                    htmTeg = "<!--tempgas1-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempCil1.ToString());
                    htmTeg = "<!--tempgas2-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempCil2.ToString());
                    htmTeg = "<!--tempgas3-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempCil3.ToString());
                    htmTeg = "<!--tempgas4-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempCil4.ToString());
                    htmTeg = "<!--tempgas5-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempCil5.ToString());
                    htmTeg = "<!--tempgas6-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempCil6.ToString());
                    htmTeg = "<!--tempbort-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].TempBort.ToString());
                    htmTeg = "<!--pozteplovoz-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].PozDGU.ToString());
                    htmTeg = "<!--pozreostat-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, dataClass[10].PozReostat.ToString());
                    htmTeg = "<!--owtemp-->";
                    text = text.Insert(text.IndexOf(htmTeg) + htmTeg.Length, owtemp.ToString());
                    web.stringHtml(text);

                    if ((dataClass[10].Current > 20) && (dataClass[10].Voltage > 20)&&(pozTeplovoz > 0))
                    {
                        dataClass[pozTeplovoz].Current = dataClass[10].Current;
                        dataClass[pozTeplovoz].Voltage = dataClass[10].Voltage;
                        dataClass[pozTeplovoz].TempOil = dataClass[10].TempOil;
                        dataClass[pozTeplovoz].TempWater = dataClass[10].TempWater;
                        dataClass[pozTeplovoz].TempCil1 = dataClass[10].TempCil1;
                        dataClass[pozTeplovoz].TempCil2 = dataClass[10].TempCil2;
                        dataClass[pozTeplovoz].TempCil3 = dataClass[10].TempCil3;
                        dataClass[pozTeplovoz].TempCil4 = dataClass[10].TempCil4;
                        dataClass[pozTeplovoz].TempCil5 = dataClass[10].TempCil5;
                        dataClass[pozTeplovoz].TempCil6 = dataClass[10].TempCil6;
                        dataClass[pozTeplovoz].Power = dataClass[10].Power;
                        dataClass[pozTeplovoz].PozDGU = pozTeplovoz;
                        dataClass[pozTeplovoz].PressGas = dataClass[10].PressGas;
                        dataClass[pozTeplovoz].PressOil = dataClass[10].PressOil;
                        dataClass[pozTeplovoz].RpmDGU = dataClass[10].RpmDGU;
                        dataClass[pozTeplovoz].Time++;
                        dataClass[pozTeplovoz].VoltageBort = dataClass[10].VoltageBort;

                        if (pozTeplovoz<9)
                            if (powerData[pozTeplovoz].pushData(dataClass[10].Power) == true)
                                {
                                dataClass[pozTeplovoz].PowerDGU = powerData[pozTeplovoz].ResultPower();
                                }
                    }
                    else
                    {
                        if (pozTeplovoz == 0)
                        {
                            dataClass[pozTeplovoz].Current = dataClass[10].Current;
                            dataClass[pozTeplovoz].Voltage = dataClass[10].Voltage;
                            dataClass[pozTeplovoz].TempOil = dataClass[10].TempOil;
                            dataClass[pozTeplovoz].TempWater = dataClass[10].TempWater;
                            dataClass[pozTeplovoz].TempCil1 = dataClass[10].TempCil1;
                            dataClass[pozTeplovoz].TempCil2 = dataClass[10].TempCil2;
                            dataClass[pozTeplovoz].TempCil3 = dataClass[10].TempCil3;
                            dataClass[pozTeplovoz].TempCil4 = dataClass[10].TempCil4;
                            dataClass[pozTeplovoz].TempCil5 = dataClass[10].TempCil5;
                            dataClass[pozTeplovoz].TempCil6 = dataClass[10].TempCil6;
                            dataClass[pozTeplovoz].Power = 0;
                            dataClass[pozTeplovoz].PozDGU = 0;
                            dataClass[pozTeplovoz].PressGas = dataClass[10].PressGas;
                            dataClass[pozTeplovoz].PressOil = dataClass[10].PressOil;
                            dataClass[pozTeplovoz].RpmDGU = dataClass[10].RpmDGU;
                            dataClass[pozTeplovoz].Time++;
                            dataClass[pozTeplovoz].VoltageBort = dataClass[10].VoltageBort;
                            
                        }
                    }

                    dataClass[10].Time++;
                    dataClass[10].ExtDataPoint = extData;
                }
              
                if (dataClass[10].StateVSH1 != preStateRP1)
                {
                    if (dataClass[10].StateVSH1 == true)
                    {
                        if (dataClass[10].SwitchRelePoint.RP1_ON_current == 0)
                        {
                            dataClass[10].SwitchRelePoint.RP1_ON_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP1_ON_voltage = dataClass[10].Voltage;
                        }
                        else
                        {
                            dataClass[10].SwitchRelePoint.RP1_ON_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP1_ON_voltage = dataClass[10].Voltage;
                        }
                    }
                    else
                    {
                        if (dataClass[10].SwitchRelePoint.RP1_OFF_current == 0)
                        {
                            dataClass[10].SwitchRelePoint.RP1_OFF_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP1_OFF_voltage = dataClass[10].Voltage;
                        }
                        else
                        {
                            dataClass[10].SwitchRelePoint.RP1_OFF_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP1_OFF_voltage = dataClass[10].Voltage;
                        }
                    }
                }

                if (dataClass[10].StateVSH2 != preStateRP2)
                {
                    if (dataClass[10].StateVSH2 == true)
                    {
                        if (dataClass[10].SwitchRelePoint.RP2_ON_current == 0)
                        {
                            dataClass[10].SwitchRelePoint.RP2_ON_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP2_ON_voltage = dataClass[10].Voltage;
                        }
                        else
                        {
                            dataClass[10].SwitchRelePoint.RP2_ON_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP2_ON_voltage = dataClass[10].Voltage;
                        }
                    }
                    else
                    {
                        if (dataClass[10].SwitchRelePoint.RP2_OFF_current == 0)
                        {
                            dataClass[10].SwitchRelePoint.RP2_OFF_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP2_OFF_voltage = dataClass[10].Voltage;
                        }
                        else
                        {
                            dataClass[10].SwitchRelePoint.RP2_OFF_current = dataClass[10].Current;
                            dataClass[10].SwitchRelePoint.RP2_OFF_voltage = dataClass[10].Voltage;
                        }
                    }
                }

                preStateRP1 = dataClass[10].StateVSH1;
                preStateRP2 = dataClass[10].StateVSH2;

                if (pozReostat != 0)
                    {
                        dataClass[10].FlagWork = true;
                    }

                CallBackMy.callbackEventHandler(dataClass);

                /*temp***************************************/
                /*dataClass[10].Current = 1256;
                dataClass[10].Voltage = 356;
                dataClass[10].TempOil = 78;
                dataClass[10].TempWater = 67;
                dataClass[10].TempCil1 = 567;
                dataClass[10].TempCil2 = 456;
                dataClass[10].TempCil3 = 45;
                dataClass[10].TempCil4 = 567;
                dataClass[10].TempCil5 = 656;
                dataClass[10].TempCil6 = 34;
                dataClass[10].PozDGU = 3;
                dataClass[10].PressGas = 0.53;
                dataClass[10].PressOil = 2.56;
                dataClass[10].RpmDGU = 430;
                dataClass[10].VoltageBort = 75;*/
                /****************************************/
            }
        }


        static void ReloadPoz(int param)
        {
            pozReostat = param;
            
            
        }

        static void ReloadTypeLoc(string param)
        {
            typeLoc = param;
        }

        static void ReloadNumberLoc(string param)
        {
            numberLoc = param;
        }

        static void ReloadPozKM(int param, bool flag)
        {
            pozExt = param;
            flagExt = flag;
        }

        static void ReloadExtPoint(ExtData ext)
        {
            extData = ext;
        }

        static void ReloadData(myclass[] what)
        {
            dataClass = what;
            extData = dataClass[10].ExtDataPoint;
        }

        /*
        VS2, VS5   - 1
        VS1        - 2
        VS3        - 3
        VS4        - 4
        VS6        - 5
        VS7        - 6
        */
        static void funcClient()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //вводим необходимые параметры для удаленного сокета 
            IPAddress ip = IPAddress.Parse("192.168.2.20");
            IPEndPoint ipe = new IPEndPoint(ip, 128);
            //разрешение широковещательного адреса 
            s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            byte[] bytes;
            byte crc;
            for (; ; )
            {
                Thread.Sleep(1000);
                bytes = new byte[16];
                bytes[0] = 0x7E;
                bytes[1] = 0x00;
                bytes[2] = 0x0C;
                bytes[3] = 0xB0;
                bytes[4] = 0xC0;
                bytes[5] = 0xA8;
                bytes[6] = 0x02;
                bytes[7] = 0x14;
                bytes[8] = 0x00;
                bytes[9] = 0x80;
                bytes[10] = 0x00;
                bytes[11] = 0x80;
                bytes[12] = 0x00;
                bytes[13] = 0x00;
                if ((dataClass[10].TypeLoc.IndexOf("ТЭМ2", 0) >= 0) || (dataClass[10].TypeLoc.IndexOf("ТЭМ18", 0) >= 0))
                    {
                    switch (pozReostat)
                        {
                        case 0: bytes[14] = 0;
                        break;
                        case 1: bytes[14] = 0x01;
                        break;
                        case 2: bytes[14] = 0x02;
                        break;
                        case 3: bytes[14] = 0x04;
                        break;
                        }
                    }
                if (dataClass[10].TypeLoc.IndexOf("ЧМЭ3", 0) >= 0)
                {
                    switch (pozReostat)
                    {
                        case 0: bytes[14] = 0;
                            break;
                        case 1: bytes[14] = 0x1D;
                            break;
                        case 2: bytes[14] = 0x0D;
                            break;
                        case 3: bytes[14] = 0x2D;
                            break;
                    }
                }
                int ind = 3;
                crc = 0;
                while (ind != 15)
                {
                    crc = (byte)(crc + bytes[ind]);
                    ind++;
                }
                crc = (byte)(0xFF - crc);
                bytes[15] = crc;

                try
                {
                    s.SendTo(bytes, ipe);
                    
                }
                catch 
                {
                    s.Close();
                    s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    //вводим необходимые параметры для удаленного сокета 
                    ip = IPAddress.Parse("192.168.2.20");
                    ipe = new IPEndPoint(ip, 128);
                    //разрешение широковещательного адреса 
                    s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                }
                
            }
        }

    }

    public static class CallBackMy
    {
        public delegate void callbackEventNew(myclass[] what);
        public static callbackEventNew callbackEventHandlerNew;

        public delegate void callbackEvent(myclass[] what);
        public static callbackEvent callbackEventHandler;

        public delegate void callbackEventExtPoint(ExtData what);
        public static callbackEventExtPoint callbackEventHandlerExtPoint;

        public delegate void callbackEventPozReostat(int poz);
        public static callbackEventPozReostat callbackEventHandlerPozReostat;

        public delegate void callbackEventPozKM(int pozKM, bool flag);
        public static callbackEventPozKM callbackEventHandlerPozKM;

        public delegate void callbackEventTypeLoc(string type);
        public static callbackEventTypeLoc callbackEventHandlerTypeLoc;

        public delegate void callbackEventNumberLoc(string type);
        public static callbackEventNumberLoc callbackEventHandlerNumberLoc;

        public delegate void callbackEventFIO(string type);
        public static callbackEventFIO callbackEventHandlerFIO;

        public delegate void callbackEventComment(string type);
        public static callbackEventComment callbackEventHandlerComment;

        public delegate void callbackEventCheck(bool type);
        public static callbackEventCheck callbackEventHandlerCheck;

    }

}


