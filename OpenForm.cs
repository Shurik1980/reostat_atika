using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using CrystalDecisions.CrystalReports.Engine;

namespace reostat
{
    public partial class openForm : Form
    {
        private myclass[] dataOpen;
        private int selNumber;
        private int seltype;
        private bool flagReload=false;
        private string fio_operator = "";
        private string text_comment = "";
        private bool checkSaveReport = false;
        System.Windows.Forms.Timer openTimer = new System.Windows.Forms.Timer();

        public Point ShowLocation { get; set; }

        public openForm()
        {
            
            dataOpen = new myclass[11];
            int i = 0;
            while (i != 11)
            {
                dataOpen[i] = new myclass();
                i++;
            }
            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.Reload);
            CallBackMy.callbackEventHandlerFIO = new CallBackMy.callbackEventFIO(this.ReloadFio);
            CallBackMy.callbackEventHandlerComment = new CallBackMy.callbackEventComment(this.ReloadComment);
            CallBackMy.callbackEventHandlerCheck = new CallBackMy.callbackEventCheck(this.ReloadCheck);

            if (!openTimer.Enabled)
            {
                openTimer.Tick += new EventHandler(timer_open); //подписываемся на события Tick
                openTimer.Interval = 200;
                openTimer.Start();
            }
            
            InitializeComponent();
            ToolTip help = new ToolTip();
            help.SetToolTip(nextWorkForm, "Переход на измерительное окно");
            help.SetToolTip(Exit, "Выход из программы без сохранения данных");
            help.SetToolTip(saveReport, "Сохранение данных испытания на диске");
            help.SetToolTip(printReport, "Предомсотр и печать отчета");
            help.SetToolTip(listReport, "Список отчетов за все время по выбранному тепловозу");
            help.SetToolTip(newLocButton, "Внесение в базу данных нового локомотива");
        }


        void timer_open(object sender, EventArgs e)
        {
            //File.AppendAllText(@".\log.txt", "timer_open\r\n");
            typeLocOpenForm.Text = dataOpen[10].TypeLoc;
            numberLocOpenForm.Text = dataOpen[10].NumberLoc;
        }


        void Reload(myclass[] param)
        {
            flagReload = true;
            dataOpen = param;
        }

        void ReloadFio(string tx)
        {
            fio_operator = tx;
        }

        void ReloadComment(string tx)
        {
            text_comment = tx;
        }

        void ReloadCheck(bool tx)
        {
            checkSaveReport = tx;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void printReport_Click(object sender, EventArgs e)
        {

        }

        private void saveReport_Click(object sender, EventArgs e)
        {

        }

        private void typeLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            selNumberLoc.Items.Clear();
            listReport.Items.Clear();
            seltype = selTypeLoc.SelectedIndex;
            string tx = selTypeLoc.Items[selTypeLoc.SelectedIndex].ToString();
            CallBackMy.callbackEventHandlerTypeLoc(tx);
            string path = @".\Baza\";
            path = path + tx;
            string[] sd = Directory.GetDirectories(path);
            int a = sd.Length;
            while (a != 0)
            {
                a--;
                sd[a] = sd[a].Remove(0, 7);
                sd[a] = sd[a].Remove(0, sd[a].IndexOf('\\') + 1);
                selNumberLoc.Items.Add(sd[a]);
            }  
        }

        private void openForm_Load(object sender, EventArgs e)
        {
            while (flagReload == false)
            {
                Thread.Sleep(200);
            }
            typeLocOpenForm.Text = dataOpen[10].TypeLoc;
            numberLocOpenForm.Text = dataOpen[10].NumberLoc;
            string[] sd = Directory.GetDirectories(@".\Baza");
            int a = sd.Length;
            while (a != 0)
            {
                a--;
                sd[a] = sd[a].Remove(0, 7);
                selTypeLoc.Items.Add(sd[a]);
            }

            selTypeLoc.Text = typeLocOpenForm.Text;
            selNumberLoc.Text = numberLocOpenForm.Text;

        }

        private void selNumberLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            listReport.Items.Clear();
            selNumber = selNumberLoc.SelectedIndex;
            string tx = selNumberLoc.Items[selNumberLoc.SelectedIndex].ToString();
            CallBackMy.callbackEventHandlerNumberLoc(tx);
            string path = @".\Baza\";
            path = path + selTypeLoc.Items[selTypeLoc.SelectedIndex].ToString();
            path = path + @"\";
            path = path + tx;
            string[] sd = Directory.GetFiles(path);
            int a = sd.Length;
            while (a != 0)
            {
                a--;
                sd[a] = sd[a].Remove(0, 7);
                sd[a] = sd[a].Remove(sd[a].IndexOf('.'), 4);
                listReport.Items.Add(sd[a]);
            }
     
        }

        private void nextWorkForm_Click(object sender, EventArgs e)
        {
            if ((dataOpen[10].TypeLoc == "") || (dataOpen[10].NumberLoc == ""))
            {
                MessageBox.Show("Не выбран тепловоз!", "Внимание",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                WorkForm workForm = new WorkForm();
                this.Hide();
                workForm.Show();
            }
        }

        private void newLocButton_Click(object sender, EventArgs e)
        {
            if (newTypeLocText.Text == "")
            {
                MessageBox.Show("Не указан тип тепловоза!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                if (newNumberLoc.Text == "")
                {
                    MessageBox.Show("Не указан номер тепловоза!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string path = @".\Baza\";
                    path = path + newTypeLocText.Text;
                    path = path + @"\" + newNumberLoc.Text;
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    MessageBox.Show("Создан тепловоз №" + newNumberLoc.Text, "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    selTypeLoc.Items.Add(newTypeLocText.Text);
                }
            }
           
        }


        private void upPozButton_Click(object sender, EventArgs e)
        {
            dataOpen[10].PozDGU = dataOpen[10].PozDGU + 1;
        }


        private void downPozButton_Click(object sender, EventArgs e)
        {
            dataOpen[10].PozDGU = dataOpen[10].PozDGU - 1;
        }


        private void listReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rep = listReport.Text;
            XmlDocument doc = new XmlDocument();
            rep = @".\Baza\\" + rep;
            rep = rep + ".xml";

            try
            {
                doc.Load(rep);
                MessageBox.Show("Отчет открыт!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Отчет не найден! Попробуйте еще.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            FileInfo fn = new FileInfo(rep);
            fn.CopyTo(@".\report.xml", true);

            
            XmlNodeList time = doc.GetElementsByTagName("time");
            for (int i = 0; i != time.Count; i++)
            {
                dataOpen[i].Time = Convert.ToInt32(time[i].InnerText)*60;
            }
            XmlNodeList power = doc.GetElementsByTagName("power");
            for (int i = 0; i != power.Count; i++)
            {
                dataOpen[i].Power = Convert.ToInt32(power[i].InnerText);
            }
            XmlNodeList pozdgu = doc.GetElementsByTagName("id_poz");
            for (int i = 0; i != pozdgu.Count; i++)
            {
                dataOpen[i].PozDGU = Convert.ToInt32(pozdgu[i].InnerText);
            }
            XmlNodeList voltage = doc.GetElementsByTagName("voltage");
            for (int i = 0; i != voltage.Count; i++)
            {
                dataOpen[i].Voltage = Convert.ToInt32(voltage[i].InnerText);
            }
            XmlNodeList current = doc.GetElementsByTagName("current");
            for (int i = 0; i != current.Count; i++)
            {
                dataOpen[i].Current = Convert.ToInt32(current[i].InnerText);
            }
            XmlNodeList rpm = doc.GetElementsByTagName("rpm");
            for (int i = 0; i != rpm.Count; i++)
            {
                dataOpen[i].RpmDGU = Convert.ToInt32(rpm[i].InnerText);
            }
            XmlNodeList pressoil = doc.GetElementsByTagName("press_oil");
            for (int i = 0; i != pressoil.Count; i++)
            {
                dataOpen[i].PressOil = Convert.ToDouble(pressoil[i].InnerText.Replace('.',','));
            }
            XmlNodeList pressgas = doc.GetElementsByTagName("press_gas");
            for (int i = 0; i != pressgas.Count; i++)
            {
                dataOpen[i].PressGas = Convert.ToDouble(pressgas[i].InnerText.Replace('.', ','));
            }
            XmlNodeList tempoil = doc.GetElementsByTagName("temp_oil");
            for (int i = 0; i != tempoil.Count; i++)
            {
                dataOpen[i].TempOil = Convert.ToDouble(tempoil[i].InnerText.Replace('.', ','));
            }
            XmlNodeList tempwater = doc.GetElementsByTagName("temp_water");
            for (int i = 0; i != tempwater.Count; i++)
            {
                dataOpen[i].TempWater = Convert.ToDouble(tempwater[i].InnerText.Replace('.', ','));
            }
            XmlNodeList tempbort = doc.GetElementsByTagName("temp_bort");
            for (int i = 0; i != tempbort.Count; i++)
            {
                dataOpen[i].TempBort = Convert.ToDouble(tempbort[i].InnerText.Replace('.', ','));
            }
            XmlNodeList tempcil1 = doc.GetElementsByTagName("temp_cil1");
            XmlNodeList tempcil2 = doc.GetElementsByTagName("temp_cil2");
            XmlNodeList tempcil3 = doc.GetElementsByTagName("temp_cil3");
            XmlNodeList tempcil4 = doc.GetElementsByTagName("temp_cil4");
            XmlNodeList tempcil5 = doc.GetElementsByTagName("temp_cil5");
            XmlNodeList tempcil6 = doc.GetElementsByTagName("temp_cil6");
            for (int i = 0; i != tempcil1.Count; i++)
            {
                dataOpen[i].TempCil1 = Convert.ToDouble(tempcil1[i].InnerText.Replace('.', ','));
                dataOpen[i].TempCil2 = Convert.ToDouble(tempcil2[i].InnerText.Replace('.', ','));
                dataOpen[i].TempCil3 = Convert.ToDouble(tempcil3[i].InnerText.Replace('.', ','));
                dataOpen[i].TempCil4 = Convert.ToDouble(tempcil4[i].InnerText.Replace('.', ','));
                dataOpen[i].TempCil5 = Convert.ToDouble(tempcil5[i].InnerText.Replace('.', ','));
                dataOpen[i].TempCil6 = Convert.ToDouble(tempcil6[i].InnerText.Replace('.', ','));
                
            }
            XmlNodeList voltagebort = doc.GetElementsByTagName("voltage_bort");
            for (int i = 0; i != voltagebort.Count; i++)
            {
                dataOpen[i].VoltageBort = Convert.ToInt32(voltagebort[i].InnerText);
            }

            XmlNodeList iext = doc.GetElementsByTagName("i_ext");
            XmlNodeList uext = doc.GetElementsByTagName("u_ext");
            for (int i = 0; i != iext.Count; i++)
            {
                dataOpen[10].ExtDataPoint.ExtCurrent[i] = Convert.ToInt32(iext[i].InnerText);
                dataOpen[10].ExtDataPoint.ExtVoltage[i] = Convert.ToInt32(uext[i].InnerText);
            }

            XmlNodeList ion1 = doc.GetElementsByTagName("i_on1");
            XmlNodeList ioff1 = doc.GetElementsByTagName("i_off1");
            XmlNodeList uon1 = doc.GetElementsByTagName("u_on1");
            XmlNodeList uoff1 = doc.GetElementsByTagName("u_off1");
            XmlNodeList ion2 = doc.GetElementsByTagName("i_on2");
            XmlNodeList ioff2 = doc.GetElementsByTagName("i_off2");
            XmlNodeList uon2 = doc.GetElementsByTagName("u_on2");
            XmlNodeList uoff2 = doc.GetElementsByTagName("u_off2");
           
                dataOpen[10].SwitchRelePoint.RP1_OFF_current = Convert.ToInt32(ioff1[0].InnerText);
                dataOpen[10].SwitchRelePoint.RP2_OFF_current = Convert.ToInt32(ioff2[0].InnerText);
                dataOpen[10].SwitchRelePoint.RP1_ON_current = Convert.ToInt32(ion1[0].InnerText);
                dataOpen[10].SwitchRelePoint.RP2_ON_current = Convert.ToInt32(ion2[0].InnerText);
                dataOpen[10].SwitchRelePoint.RP1_OFF_voltage = Convert.ToInt32(uoff1[0].InnerText);
                dataOpen[10].SwitchRelePoint.RP2_OFF_voltage = Convert.ToInt32(uoff2[0].InnerText);
                dataOpen[10].SwitchRelePoint.RP1_ON_voltage = Convert.ToInt32(uon1[0].InnerText);
                dataOpen[10].SwitchRelePoint.RP2_ON_voltage = Convert.ToInt32(uon2[0].InnerText);

            CallBackMy.callbackEventHandlerNew(dataOpen);
        }

        private void saveReport_Click_1(object sender, EventArgs e)
        {
            OkReport okForm = new OkReport();
            this.Hide();
            okForm.Show();
        }


        private void printReport_Click_1(object sender, EventArgs e)
        {
            ReportDocument myReport = new ReportDocument();
            //Задаём форму (которую создавали в пункте 3)
            try
            {
                if (dataOpen[10].TypeLoc.IndexOf('7') > 0)
                    myReport.Load(@".\CrystalReport7.rpt");
                else
                    myReport.Load(@".\CrystalReport1.rpt");
            }
            catch(Exception ez)
            {
                MessageBox.Show("Ошибка генератора отчета! "+ez.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            DataSet myDS = new DataSet();
            try
            {
                myDS.ReadXml(@".\report.xml");
            }
            catch
            {
                MessageBox.Show("Отчет не открыт или не сохранен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            myReport.SetDataSource(myDS);
            ReportForm frm = new ReportForm();
            //Указываем отчёт для CrystalReportViewer
            frm.crystalReportViewer1.ReportSource = myReport;
            //frm.crystalReportViewer1.PrintReport();
            //Открываем форму.
            frm.Show();
        }
    }
}
