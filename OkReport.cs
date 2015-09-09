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

namespace reostat
{
    public partial class OkReport : Form
    {
        private myclass[] dataOpen;
        private bool flagReloadreport = false;

        public OkReport()
        {
            dataOpen = new myclass[11];
            int i = 0;
            while (i != 11)
            {
                dataOpen[i] = new myclass();
                i++;
            }
            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.Reload);
            InitializeComponent();
        }


        void Reload(myclass[] param)
        {
            flagReloadreport = true;
            dataOpen = param;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            while (flagReloadreport == false) ;
            flagReloadreport = false;
            while (flagReloadreport == false) ;


            string path = @".\Baza\" + dataOpen[10].TypeLoc;
            path = path + "\\" + dataOpen[10].NumberLoc + "\\";
            string time = System.DateTime.Now.Day.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Year.ToString();
            time = time + " " + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString();
            path = path + time + ".xml";

            DataSet myDs = new DataSet();

            DataTable tableId = new DataTable("identification");
            DataColumn columnDate = new DataColumn("date", typeof(string));
            DataColumn columnNumber = new DataColumn("number_loc", typeof(string));
            DataColumn columnType = new DataColumn("type_loc", typeof(string));
            tableId.Columns.Add(columnDate);
            tableId.Columns.Add(columnNumber);
            tableId.Columns.Add(columnType);
            tableId.Rows.Add(time, dataOpen[10].NumberLoc, dataOpen[10].TypeLoc);
            myDs.Tables.Add(tableId);

            DataTable table = new DataTable("poz");
            DataColumn columnPower = new DataColumn("power", typeof(int));
            DataColumn columnVoltage = new DataColumn("voltage", typeof(int));
            DataColumn columnCurrent = new DataColumn("current", typeof(int));
            DataColumn columnPoz = new DataColumn("id_poz", typeof(int));
            DataColumn columnRpm = new DataColumn("rpm", typeof(int));
            DataColumn columnPressOil = new DataColumn("press_oil", typeof(double));
            DataColumn columnPressGas = new DataColumn("press_gas", typeof(double));
            DataColumn columnTempWater = new DataColumn("temp_water", typeof(double));
            DataColumn columnTempOil = new DataColumn("temp_oil", typeof(double));
            DataColumn columnTempBort = new DataColumn("temp_bort", typeof(double));
            DataColumn columnTempCil1 = new DataColumn("temp_cil1", typeof(double));
            DataColumn columnTempCil2 = new DataColumn("temp_cil2", typeof(double));
            DataColumn columnTempCil3 = new DataColumn("temp_cil3", typeof(double));
            DataColumn columnTempCil4 = new DataColumn("temp_cil4", typeof(double));
            DataColumn columnTempCil5 = new DataColumn("temp_cil5", typeof(double));
            DataColumn columnTempCil6 = new DataColumn("temp_cil6", typeof(double));
            DataColumn columnTempCil7 = new DataColumn("temp_cil7", typeof(double));
            DataColumn columnTempCil8 = new DataColumn("temp_cil8", typeof(double));
            DataColumn columnTempCil9 = new DataColumn("temp_cil9", typeof(double));
            DataColumn columnTempCil10 = new DataColumn("temp_cil10", typeof(double));
            DataColumn columnTempCil11 = new DataColumn("temp_cil11", typeof(double));
            DataColumn columnTempCil12 = new DataColumn("temp_cil12", typeof(double));
            DataColumn columnVoltageBort = new DataColumn("voltage_bort", typeof(int));
            DataColumn columnTime = new DataColumn("time", typeof(int));
            table.Columns.Add(columnPoz);
            table.Columns.Add(columnPower);
            table.Columns.Add(columnVoltage);
            table.Columns.Add(columnCurrent);
            table.Columns.Add(columnRpm);
            table.Columns.Add(columnPressOil);
            table.Columns.Add(columnPressGas);
            table.Columns.Add(columnTempWater);
            table.Columns.Add(columnTempOil);
            table.Columns.Add(columnTempBort);
            table.Columns.Add(columnTempCil1);
            table.Columns.Add(columnTempCil2);
            table.Columns.Add(columnTempCil3);
            table.Columns.Add(columnTempCil4);
            table.Columns.Add(columnTempCil5);
            table.Columns.Add(columnTempCil6);
            table.Columns.Add(columnTempCil7);
            table.Columns.Add(columnTempCil8);
            table.Columns.Add(columnTempCil9);
            table.Columns.Add(columnTempCil10);
            table.Columns.Add(columnTempCil11);
            table.Columns.Add(columnTempCil12);
            table.Columns.Add(columnVoltageBort);
            table.Columns.Add(columnTime);
            for (int i = 0; i != 9; i++)
            {
                table.Rows.Add(dataOpen[i].PozDGU, dataOpen[i].Power, dataOpen[i].Voltage, dataOpen[i].Current, dataOpen[i].RpmDGU, dataOpen[i].PressOil, dataOpen[i].PressGas, dataOpen[i].TempWater, dataOpen[i].TempOil, dataOpen[10].TempBort, dataOpen[i].TempCil1, dataOpen[i].TempCil2, dataOpen[i].TempCil3, dataOpen[i].TempCil4, dataOpen[i].TempCil5, dataOpen[i].TempCil6, dataOpen[i].TempCil7, dataOpen[i].TempCil8, dataOpen[i].TempCil9, dataOpen[i].TempCil10, dataOpen[i].TempCil11, dataOpen[i].TempCil12, dataOpen[i].VoltageBort, dataOpen[i].Time / 60);
            }
            myDs.Tables.Add(table);
            

            DataTable tableExt = new DataTable("ext_graph");
            DataColumn columnI = new DataColumn("i_ext", typeof(int));
            DataColumn columnU = new DataColumn("u_ext", typeof(int));
            tableExt.Columns.Add(columnI);
            tableExt.Columns.Add(columnU);
            tableExt.Rows.Add(dataOpen[10].ExtDataPoint.ExtCurrent[0], dataOpen[10].ExtDataPoint.ExtVoltage[0]);
            tableExt.Rows.Add(dataOpen[10].ExtDataPoint.ExtCurrent[1], dataOpen[10].ExtDataPoint.ExtVoltage[1]);
            tableExt.Rows.Add(dataOpen[10].ExtDataPoint.ExtCurrent[2], dataOpen[10].ExtDataPoint.ExtVoltage[2]);
            myDs.Tables.Add(tableExt);

            DataTable tableComment = new DataTable("comment");
            DataColumn columnfio = new DataColumn("fio", typeof(string));
            DataColumn columntext = new DataColumn("text", typeof(string));
            tableComment.Columns.Add(columnfio);
            tableComment.Columns.Add(columntext);
            string txt = commentTextBox.Text;
            txt = txt.Replace('\r', ' ');
            txt = txt.Replace('\n', ' ');
            tableComment.Rows.Add(fioTextBox.Text, txt);
            myDs.Tables.Add(tableComment);

            DataTable tableRp = new DataTable("rele_per");
            DataColumn columnIon1 = new DataColumn("i_on1", typeof(int));
            DataColumn columnUon1 = new DataColumn("u_on1", typeof(int));
            DataColumn columnIoff1 = new DataColumn("i_off1", typeof(int));
            DataColumn columnUoff1 = new DataColumn("u_off1", typeof(int));
            DataColumn columnIon2 = new DataColumn("i_on2", typeof(int));
            DataColumn columnUon2 = new DataColumn("u_on2", typeof(int));
            DataColumn columnIoff2 = new DataColumn("i_off2", typeof(int));
            DataColumn columnUoff2 = new DataColumn("u_off2", typeof(int));
            tableRp.Columns.Add(columnIon1);
            tableRp.Columns.Add(columnUon1);
            tableRp.Columns.Add(columnIoff1);
            tableRp.Columns.Add(columnUoff1);
            tableRp.Columns.Add(columnIon2);
            tableRp.Columns.Add(columnUon2);
            tableRp.Columns.Add(columnIoff2);
            tableRp.Columns.Add(columnUoff2);
            tableRp.Rows.Add(dataOpen[10].SwitchRelePoint.RP1_ON_current, dataOpen[10].SwitchRelePoint.RP1_ON_voltage, dataOpen[10].SwitchRelePoint.RP1_OFF_current, dataOpen[10].SwitchRelePoint.RP1_OFF_voltage, dataOpen[10].SwitchRelePoint.RP2_ON_current, dataOpen[10].SwitchRelePoint.RP2_ON_voltage, dataOpen[10].SwitchRelePoint.RP2_OFF_current, dataOpen[10].SwitchRelePoint.RP2_OFF_voltage);

            myDs.Tables.Add(tableRp);

            //Создаём новую таблицу
            DataTable tableI = new DataTable("ImageTable");
            //Создаём столбец
            DataColumn column = new DataColumn("MyImage");
            //Задаём тим данных массив byte для ячеек столбца
            column.DataType = System.Type.GetType("System.Byte[]");
            column.AllowDBNull = true;
            column.Caption = "My Image";
            //Добавляем созданный столбец в таблицу
            tableI.Columns.Add(column);
            //Создаём запись к таблице (строку)
            DataRow row = tableI.NewRow();
            //Получаем из файла изображение и преобразуем его в массив байт
            byte[] m_Bitmap = null;
            try
            {
                FileStream fs = new FileStream(@".\powerGraph.jpg", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                int length = (int)br.BaseStream.Length;
                m_Bitmap = new byte[length];
                m_Bitmap = br.ReadBytes(length);
                br.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("График мощностной характеристики не построен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
           
           
            //добавляем в ячейку полученный m_Bitmap;
            row["MyImage"] = m_Bitmap;
            //Добавляем запись в таблицу.
            tableI.Rows.Add(row);
            myDs.Tables.Add(tableI);

            //Создаём новую таблицу
            DataTable tableIext = new DataTable("ImageTableExt");
            //Создаём столбец
            DataColumn columnExt = new DataColumn("MyImageExt");
            //Задаём тим данных массив byte для ячеек столбца
            columnExt.DataType = System.Type.GetType("System.Byte[]");
            columnExt.AllowDBNull = true;
            columnExt.Caption = "My Image Ext";
            //Добавляем созданный столбец в таблицу
            tableIext.Columns.Add(columnExt);
            //Создаём запись к таблице (строку)
            DataRow rowext = tableIext.NewRow();
            //Получаем из файла изображение и преобразуем его в массив байт
            byte[] m_Bitmapext = null;
            try
            {
                FileStream fsext = new FileStream(@".\extGraph.jpg", FileMode.Open);
                BinaryReader brext = new BinaryReader(fsext);
                int lengthext = (int)brext.BaseStream.Length;
                m_Bitmapext = new byte[lengthext];
                m_Bitmapext = brext.ReadBytes(lengthext);
                brext.Close();
                fsext.Close();
            }
            catch
            {
                MessageBox.Show("График внешней характеристики не построен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //добавляем в ячейку полученный m_Bitmap;
            rowext["MyImageExt"] = m_Bitmapext;
            //Добавляем запись в таблицу.
            tableIext.Rows.Add(rowext);
            myDs.Tables.Add(tableIext);

            myDs.WriteXml(@".\report.xml", XmlWriteMode.WriteSchema);
            myDs.WriteXml(path, XmlWriteMode.WriteSchema);

            openForm open = new openForm();
            this.Hide();
            open.Show();
        }
    }
}
