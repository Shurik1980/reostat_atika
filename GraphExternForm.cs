using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using ZedGraph;


namespace reostat
{
    public partial class GraphExternForm : Form
    {
        private myclass[] dataOpen;
        private ExtData extData;
        private bool flagReload;
        private int countMes1;
        private int countMes2;
        private int countMes3;
        private XmlNodeList iMax;
        private XmlNodeList countPoint;
        private int offset = 0;
        private bool flagExtHarPaint=false;

        //private int countExtGraph=0;
        PointPairList listCurrent = new PointPairList();
        System.Windows.Forms.Timer externTimer = new System.Windows.Forms.Timer();

        public GraphExternForm()
        {
            flagReload = false;
            extData = new ExtData();
            dataOpen = new myclass[11];
            int i = 0;
            while (i != 11)
            {
                dataOpen[i] = new myclass();
                i++;
            }
            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.ReloadWork);

            if (!externTimer.Enabled)
            {
                externTimer.Tick += new EventHandler(timer_extern); //подписываемся на события Tick
                externTimer.Interval = 1000;
                externTimer.Start();
            }
            InitializeComponent();
        }

        void ReloadWork(myclass[] param)
        {
            flagReload = true;
            dataOpen = param;
        }

        void timer_extern(object sender, EventArgs e)
        {
            AnalogVoltage.Value = (double)dataOpen[10].Voltage;
            AnalogCur.Value = (double)dataOpen[10].Current;
            pozReostatControl.Text = dataOpen[10].PozReostat.ToString();
            pozDGUControl.Text = dataOpen[10].PozDGU.ToString();
            lxLedControl1.Text = dataOpen[10].TempWater.ToString().Replace(',', '.');
            lxLedControl2.Text = dataOpen[10].TempOil.ToString().Replace(',', '.');
            lxLedControl3.Text = dataOpen[10].PressOil.ToString().Replace(',', '.');
            if (dataOpen[10].FlagValid == false)
                ExtValid.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            if ((dataOpen[10].PozDGU == 8)&&(dataOpen[10].FlagValid==true))
            {
                switch (dataOpen[10].PozReostat)
                {
                    case 0:
                        break;

                    case 1:
                        countMes1++;
                        extData.ExtCurrent[0] = extData.ExtCurrent[0]+dataOpen[8].Current;
                        extData.ExtVoltage[0] = extData.ExtVoltage[0] + dataOpen[8].Voltage;
                        if (countMes1 == 8)
                        {
                            extData.ExtCurrent[0] = extData.ExtCurrent[0] / 8;
                            extData.ExtVoltage[0] = extData.ExtVoltage[0] / 8;
                            dataOpen[10].ExtDataPoint.ExtCurrent[0] = extData.ExtCurrent[0];
                            dataOpen[10].ExtDataPoint.ExtVoltage[0] = extData.ExtVoltage[0];
                        }                      
                        if (countMes1>8)
                            ExtValid.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                        break;

                    case 2:
                        countMes2++;
                        extData.ExtCurrent[1] = extData.ExtCurrent[1] + dataOpen[8].Current;
                        extData.ExtVoltage[1] = extData.ExtVoltage[1] + dataOpen[8].Voltage;
                        if (countMes2 == 8)
                        {
                            extData.ExtCurrent[1] = extData.ExtCurrent[1] / 8;
                            extData.ExtVoltage[1] = extData.ExtVoltage[1] / 8;
                            dataOpen[10].ExtDataPoint.ExtCurrent[1] = extData.ExtCurrent[1];
                            dataOpen[10].ExtDataPoint.ExtVoltage[1] = extData.ExtVoltage[1];
                        }                      
                        if (countMes2 > 8)
                            ExtValid.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                        break;

                    case 3:
                        countMes3++;
                        extData.ExtCurrent[2] = extData.ExtCurrent[2] + dataOpen[8].Current;
                        extData.ExtVoltage[2] = extData.ExtVoltage[2] + dataOpen[8].Voltage;
                        if (countMes3 == 8)
                        {
                            extData.ExtCurrent[2] = extData.ExtCurrent[2] / 8;
                            extData.ExtVoltage[2] = extData.ExtVoltage[2] / 8;
                            dataOpen[10].ExtDataPoint.ExtCurrent[2] = extData.ExtCurrent[2];
                            dataOpen[10].ExtDataPoint.ExtVoltage[2] = extData.ExtVoltage[2];
                        }                      
                        if (countMes3 > 8)
                            ExtValid.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
                        break;
                }
                if ((dataOpen[10].ExtDataPoint.ExtCurrent[0] > 0) && (dataOpen[10].ExtDataPoint.ExtCurrent[1] > 0) && (dataOpen[10].ExtDataPoint.ExtCurrent[2] > 0))
                {
                    if ((countMes1 > 8) && (countMes2 > 8) && (countMes3 > 8)&&(flagExtHarPaint==false))
                    {
                        flagExtHarPaint = true;

                        typeLocWork.Text = dataOpen[10].TypeLoc;
                        numberLocWork.Text = dataOpen[10].NumberLoc;
                        GraphPane pane = zedGraphExtern.GraphPane;
                        pane.Title.Text = "Внешняя характеристика ДГУ";
                        pane.XAxis.Title.Text = "Ток ТГ, А";
                        pane.YAxis.Title.Text = "Напряжение ТГ, В";
                        PointPairList listUp = new PointPairList();
                        PointPairList listDown = new PointPairList();

                        XmlDocument doc = new XmlDocument();
                        try
                        {
                            doc.Load(@".\rangeExt.xml");
                        }
                        catch
                        {
                            MessageBox.Show("Файл отсутсвует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        XmlNodeList type = doc.GetElementsByTagName("name_loc");
                        countPoint = doc.GetElementsByTagName("count_point");
                        XmlNodeList iMin = doc.GetElementsByTagName("i_min");
                        iMax = doc.GetElementsByTagName("i_max");
                        XmlNodeList uMin = doc.GetElementsByTagName("u_min");
                        XmlNodeList uMax = doc.GetElementsByTagName("u_max");

                        bool flagPresensePoint = false;
                        for (int j = 0; j != type.Count; j++)
                        {
                            if (type[j].InnerText == dataOpen[10].TypeLoc)
                            {
                                flagPresensePoint = true;
                                for (int i = 0; i != Convert.ToInt32(countPoint[j].InnerText); i++)
                                {
                                    listUp.Add(Convert.ToInt32(iMax[i + offset].InnerText), Convert.ToInt32(uMax[i + offset].InnerText));
                                    listDown.Add(Convert.ToInt32(iMin[i + offset].InnerText), Convert.ToInt32(uMin[i + offset].InnerText));
                                    if ((dataOpen[10].ExtDataPoint.ExtCurrent[0] > 0) && (dataOpen[10].ExtDataPoint.ExtCurrent[1] > 0) && (dataOpen[10].ExtDataPoint.ExtCurrent[2] > 0))
                                    {
                                        paintCubicSpline(iMax, i, offset);
                                    }
                                }
                            }
                            else
                                offset = offset + Convert.ToInt32(countPoint[j].InnerText);
                        }

                        if (flagPresensePoint == false)
                        {
                            MessageBox.Show("Локомотив отсутсвует в справочнике!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        //LineItem myCurve1 = pane.AddCurve("Верхняя норма", listUp, Color.Black, SymbolType.None);
                        //LineItem myCurve2 = pane.AddCurve("Нижняя норма", listDown, Color.Black, SymbolType.None);
                        //LineItem myCurve3 = pane.AddCurve("Текущее значение", listCurrent, Color.Red, SymbolType.None);
                        //myCurve3.Line.Width = 4;

                        zedGraphExtern.AxisChange();
                        // Обновляем график
                        zedGraphExtern.Invalidate();


                        Clipboard.Clear();
                        zedGraphExtern.Copy(false);
                        Image pic;
                        pic = Clipboard.GetImage();
                        pic.Save(@".\extGraph.jpg");
                    }
                }
                //CallBackMy.callbackEventHandlerExtPoint(extData);
            }
        }


        private void prevTask_Click(object sender, EventArgs e)
        {
            GraphPowerForm powerForm = new GraphPowerForm();
            this.Hide();
            powerForm.Show();
        }


        private void GraphExternForm_Load(object sender, EventArgs e)
        {
            while (flagReload == false) ;
            flagReload = false;
            while (flagReload == false) ;
            typeLocWork.Text = dataOpen[10].TypeLoc;
            numberLocWork.Text = dataOpen[10].NumberLoc;
            GraphPane pane = zedGraphExtern.GraphPane;
            pane.Title.Text = "Внешняя характеристика ДГУ";
            pane.XAxis.Title.Text = "Ток ТГ, А";
            pane.YAxis.Title.Text = "Напряжение ТГ, В";
            PointPairList listUp = new PointPairList();
            PointPairList listDown = new PointPairList();           

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(@".\rangeExt.xml");
            }
            catch
            {
                MessageBox.Show("Файл отсутсвует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            XmlNodeList type = doc.GetElementsByTagName("name_loc");
            countPoint = doc.GetElementsByTagName("count_point");
            XmlNodeList iMin = doc.GetElementsByTagName("i_min");
            iMax = doc.GetElementsByTagName("i_max");
            XmlNodeList uMin = doc.GetElementsByTagName("u_min");
            XmlNodeList uMax = doc.GetElementsByTagName("u_max");

            bool flagPresensePoint = false;
            for (int j = 0; j != type.Count; j++)
            {
                if (type[j].InnerText == dataOpen[10].TypeLoc)
                {
                    flagPresensePoint = true;
                    for (int i = 0; i != Convert.ToInt32(countPoint[j].InnerText); i++)
                    {
                        listUp.Add(Convert.ToInt32(iMax[i + offset].InnerText), Convert.ToInt32(uMax[i + offset].InnerText));
                        listDown.Add(Convert.ToInt32(iMin[i + offset].InnerText), Convert.ToInt32(uMin[i + offset].InnerText));
                        if ((dataOpen[10].ExtDataPoint.ExtCurrent[0] > 0) && (dataOpen[10].ExtDataPoint.ExtCurrent[1] > 0) && (dataOpen[10].ExtDataPoint.ExtCurrent[2] > 0))
                        {
                            paintCubicSpline(iMax, i, offset);
                        }
                    }
                }
                else
                    offset = offset + Convert.ToInt32(countPoint[j].InnerText) ;
            }

            if (flagPresensePoint == false)
            {
                MessageBox.Show("Локомотив отсутсвует в справочнике!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            LineItem myCurve1 = pane.AddCurve("Верхняя норма", listUp, Color.Black, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("Нижняя норма", listDown, Color.Black, SymbolType.None);
            LineItem myCurve3 = pane.AddCurve("Текущее значение", listCurrent, Color.Red, SymbolType.None);
            myCurve3.Line.Width = 4;

            zedGraphExtern.AxisChange();
            // Обновляем график
            zedGraphExtern.Invalidate();

            Clipboard.Clear();
            zedGraphExtern.Copy(false);
            Image pic;
            pic = Clipboard.GetImage();
            pic.Save(@".\extGraph.jpg");
        }


        private void upPozReostatButton_Click(object sender, EventArgs e)
        {
            int poz = dataOpen[10].PozReostat;
            if (dataOpen[10].Power < 20)
            {
                poz++;
                if (poz > 3)
                    poz = 3;
                CallBackMy.callbackEventHandlerPozReostat(poz);
            }
            else
            {
                MessageBox.Show("Необходимо сбросить нагрузку!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void downPozReostatButton_Click(object sender, EventArgs e)
        {
            int poz = dataOpen[10].PozReostat;
            if (dataOpen[10].Power < 20)
            {
                poz--;
                if (poz < 0)
                    poz = 0;
                CallBackMy.callbackEventHandlerPozReostat(poz);
            }
            else
            {
                MessageBox.Show("Необходимо сбросить нагрузку!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void paintCubicSpline(XmlNodeList iMax, int i, int offset)
        {
            CubicSpline extCur = new CubicSpline();
            double[] pointX = new double[3];
            double[] pointY = new double[3];
            //сортировка
            int[] arrayCurrent = new int[3];
            arrayCurrent[0] = dataOpen[10].ExtDataPoint.ExtCurrent[0];
            arrayCurrent[1] = dataOpen[10].ExtDataPoint.ExtCurrent[1];
            arrayCurrent[2] = dataOpen[10].ExtDataPoint.ExtCurrent[2];
            int[] arrayVoltage = new int[3];
            Array.Sort(arrayCurrent);

            for (int j = 0; j != 3; j++)
            {
                if (dataOpen[10].ExtDataPoint.ExtCurrent[j] == arrayCurrent[0])
                {
                    arrayVoltage[0] = dataOpen[10].ExtDataPoint.ExtVoltage[j];
                }
                if (dataOpen[10].ExtDataPoint.ExtCurrent[j] == arrayCurrent[1])
                {
                    arrayVoltage[1] = dataOpen[10].ExtDataPoint.ExtVoltage[j];
                }
                if (dataOpen[10].ExtDataPoint.ExtCurrent[j] == arrayCurrent[2])
                {
                    arrayVoltage[2] = dataOpen[10].ExtDataPoint.ExtVoltage[j];
                }
            }
            for (int j = 0; j != 3; j++)
            {
                pointX[j] = arrayCurrent[j];
                pointY[j] = arrayVoltage[j];
            }
            extCur.BuildSpline(pointX, pointY, 3);
            listCurrent.Add(Convert.ToInt32(iMax[i+offset].InnerText), Convert.ToInt32(extCur.Func(Convert.ToInt32(iMax[i+offset].InnerText))));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
    }
}
