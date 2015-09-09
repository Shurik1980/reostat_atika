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
    public partial class GraphPowerForm : Form
    {
        private myclass[] dataOpen;
        private bool flagReload;

        public GraphPowerForm()
        {
            flagReload=false;
            dataOpen = new myclass[11];
            int i = 0;
            while (i != 11)
            {
                dataOpen[i] = new myclass();
                i++;
            }
            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.ReloadWork);
            InitializeComponent();
        }

        void ReloadWork(myclass[] param)
        {
            flagReload = true;
            dataOpen = param;
        }

        private void prevWorkButton_Click(object sender, EventArgs e)
        {
            WorkForm workForm = new WorkForm();
            this.Hide();
            workForm.Show();
        }

        private void GraphPowerForm_Load(object sender, EventArgs e)
        {
            while(flagReload==false);
            typeLocText.Text = dataOpen[10].TypeLoc;
            numberLocText.Text = dataOpen[10].NumberLoc;

            GraphPane pane = zedGraphPower.GraphPane;
            pane.Title.Text = "Тепловозная характеристика";
            pane.XAxis.Title.Text = "Позиция КМ";
            pane.YAxis.Title.Text = "Мощность, кВт";
            PointPairList listUp = new PointPairList();
            PointPairList listDown = new PointPairList();
            PointPairList listCurrent = new PointPairList();

            //zedGraphPower.
            listCurrent.Clear();
           
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(@".\rangePower.xml");
            }
            catch
            {
                MessageBox.Show("Файл отсутсвует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
            XmlNodeList type = doc.GetElementsByTagName("name_loc");
            XmlNodeList countPoz = doc.GetElementsByTagName("count_poz");
            XmlNodeList powerMin = doc.GetElementsByTagName("power_min");
            XmlNodeList powerMax = doc.GetElementsByTagName("power_max");
            XmlNodeList powerPoz = doc.GetElementsByTagName("poz");
            int offset =0;
            bool flagPresensePoint = false;
            for (int j = 0; j != type.Count; j++)
            {     
                if (type[j].InnerText == dataOpen[10].TypeLoc)
                {
                    flagPresensePoint = true;
                    for (int i = 0; i != Convert.ToInt32(countPoz[j].InnerText)+1; i++)
                    {
                    listUp.Add(Convert.ToInt32(powerPoz[i+offset].InnerText), Convert.ToInt32(powerMax[i+offset].InnerText));
                    listDown.Add(Convert.ToInt32(powerPoz[i+offset].InnerText), Convert.ToInt32(powerMin[i+offset].InnerText));
                    if ((dataOpen[i].PowerDGU > 0) && (dataOpen[i].PozDGU>0))
                            listCurrent.Add(dataOpen[i].PozDGU,dataOpen[i].PowerDGU);
                    }
                }
                offset = offset + Convert.ToInt32(countPoz[j].InnerText)+1;
            }

            if (flagPresensePoint == false)
            {
                for (int j = 0; j != 8; j++)
                {
                    listCurrent.Add(dataOpen[j].PozDGU, dataOpen[j].Power);
                }
                MessageBox.Show("Локомотив отсутсвует в справочнике!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            LineItem myCurve1 = pane.AddCurve("Верхняя норма", listUp, Color.Black, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("Нижняя норма", listDown, Color.Black, SymbolType.None);
            LineItem myCurve3 = pane.AddCurve("Текущее значение", listCurrent, Color.Red, SymbolType.None);
            myCurve3.Line.Width = 4;
            zedGraphPower.AxisChange();

            // Обновляем график
            zedGraphPower.Invalidate();

            Clipboard.Clear();
            zedGraphPower.Copy(false);
            Image pic;
            pic = Clipboard.GetImage();
            pic.Save(@".\powerGraph.jpg");
        }

        private void NextGraphButton_Click(object sender, EventArgs e)
        {
            GraphExternForm externForm = new GraphExternForm();
            this.Hide();
            externForm.Show();
        }
    }
}
