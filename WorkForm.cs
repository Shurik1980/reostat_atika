using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace reostat
{
    public partial class WorkForm : Form
    {
        private int pozTeplovoz;
        private myclass[] dataOpen;
        System.Windows.Forms.Timer workTimer = new System.Windows.Forms.Timer();

        public WorkForm()
        {
            dataOpen = new myclass[11];
            int i = 0;
            while (i != 11)
            {
                dataOpen[i] = new myclass();
                i++;
            }
           
            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.ReloadWork);
            

            if (!workTimer.Enabled)
            {
                
                workTimer.Tick += new EventHandler(timer_work); //подписываемся на события Tick
                workTimer.Interval = 200;
                workTimer.Start();
            }
            
            InitializeComponent();
            ToolTip help = new ToolTip();
            help.SetToolTip(prevOpenForm, "Переход на начальное окно");
            help.SetToolTip(nextPowerButton, "Переход на построение мощностной характеристики");
            help.SetToolTip(upPozReostatButton, "Понижение ступени реостата");
            help.SetToolTip(downPozReostatButton,"Повышение ступени реостата");
        }

        public Point ShowLocation { get; set; }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            
        }


        void timer_work(object sender, EventArgs e)
        {
            string hour = System.DateTime.Now.Hour.ToString();
            if (hour.Length == 1)
                {
                    hour = "0" + hour;
                }
            string minute = System.DateTime.Now.Minute.ToString();
            if (minute.Length == 1)
            {
                minute = "0" + minute;
            }
            string st = hour + "-" + minute;
            //clockControl.Text = st;

            int min = 0;
            int sec = 0;
            if (dataOpen[dataOpen[10].PozDGU].Time > 59)
            {
                min = dataOpen[dataOpen[10].PozDGU].Time / 60;
                sec = dataOpen[dataOpen[10].PozDGU].Time - (min * 60);
            }
            else
                sec = dataOpen[dataOpen[10].PozDGU].Time;
            
            pozTimeControl.Text = min.ToString()+"-"+sec.ToString();


            typeLocWork.Text = dataOpen[10].TypeLoc;
            numberLocWork.Text = dataOpen[10].NumberLoc;
            rpmControl.Text = dataOpen[10].RpmDGU.ToString();
            //tempAirControl.Text = dataOpen[10].TempBort.ToString().Replace(',','.');
            currentControl.Text = dataOpen[10].Current.ToString();
            voltageControl.Text = dataOpen[10].Voltage.ToString();
            voltageBortControl.Text = dataOpen[10].VoltageBort.ToString();
            pressGasControl.Text = dataOpen[10].PressGas.ToString().Replace(',', '.');
            pressOilControl.Text = dataOpen[10].PressOil.ToString().Replace(',', '.');
            powerMeter.Value = (double)dataOpen[10].Power;
            lxLedControlPower.Text = dataOpen[10].Power.ToString();
            pozReostatControl.Text = dataOpen[10].PozReostat.ToString();
            pozDGUControl.Text = dataOpen[10].PozDGU.ToString();
            oilTempControl.Text = dataOpen[10].TempOil.ToString().Replace(',', '.');
            waterTempControl.Text = dataOpen[10].TempWater.ToString().Replace(',', '.');
            gas1Control.Text = dataOpen[10].TempCil1.ToString().Replace(',', '.');
            gas2Control.Text = dataOpen[10].TempCil2.ToString().Replace(',', '.');
            gas3Control.Text = dataOpen[10].TempCil3.ToString().Replace(',', '.');
            gas4Control.Text = dataOpen[10].TempCil4.ToString().Replace(',', '.');
            gas5Control.Text = dataOpen[10].TempCil5.ToString().Replace(',', '.');
            gas6Control.Text = dataOpen[10].TempCil6.ToString().Replace(',', '.');
            //gas7Control.Text = dataOpen[10].TempCil7.ToString().Replace(',', '.');
            //gas8Control.Text = dataOpen[10].TempCil8.ToString().Replace(',', '.');
            //gas9Control.Text = dataOpen[10].TempCil9.ToString().Replace(',', '.');
            //gas10Control.Text = dataOpen[10].TempCil10.ToString().Replace(',', '.');
            //gas11Control.Text = dataOpen[10].TempCil11.ToString().Replace(',', '.');
            //gas12Control.Text = dataOpen[10].TempCil12.ToString().Replace(',', '.');
            tempBortControl.Text = dataOpen[10].TempBort.ToString();
            if(dataOpen[10].StateVSH1 == true)
                VSH1Led.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
            else
                VSH1Led.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;

            if (dataOpen[10].StateVSH2 == true)
                VSH2Led.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
            else
                VSH2Led.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;

            /*if (dataOpen[10].StateObduv == true)
                obduvLed.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
            else
                obduvLed.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;*/

        }


        void ReloadWork(myclass[] param)
        {
            dataOpen = param;
        }


        private void prevOpenForm_Click(object sender, EventArgs e)
        {
            openForm openF = new openForm();
            this.Hide();
            openF.Show();
        }

        
        private void upPozReostatButton_Click(object sender, EventArgs e)
        {
            int poz = dataOpen[10].PozReostat;
            if (dataOpen[10].Power < 20)
            {
                poz++;
                if (poz > 3)
                    poz = 1;
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


        private void nextPowerButton_Click(object sender, EventArgs e)
        {
            GraphPowerForm powerForm = new GraphPowerForm();
            this.Hide();
            powerForm.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void gas6Control_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox23_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CallBackMy.callbackEventHandlerPozKM(pozTeplovoz, checkBox1.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (pozTeplovoz < 8)
                    pozTeplovoz++;
                CallBackMy.callbackEventHandlerPozKM(pozTeplovoz, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (pozTeplovoz > 0)
                    pozTeplovoz--;
                CallBackMy.callbackEventHandlerPozKM(pozTeplovoz, true);
            }
        }
     
    }
}
