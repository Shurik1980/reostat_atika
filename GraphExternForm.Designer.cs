namespace reostat
{
    partial class GraphExternForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphExternForm));
            this.prevTask = new System.Windows.Forms.Button();
            this.AnalogVoltage = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.AnalogCur = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.label7 = new System.Windows.Forms.Label();
            this.pozReostatControl = new LxControl.LxLedControl();
            this.downPozReostatButton = new System.Windows.Forms.Button();
            this.upPozReostatButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pozDGUControl = new LxControl.LxLedControl();
            this.numberLocWork = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeLocWork = new System.Windows.Forms.Label();
            this.zedGraphExtern = new ZedGraph.ZedGraphControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExtValid = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label4 = new System.Windows.Forms.Label();
            this.lxLedControl1 = new LxControl.LxLedControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lxLedControl2 = new LxControl.LxLedControl();
            this.label9 = new System.Windows.Forms.Label();
            this.lxLedControl3 = new LxControl.LxLedControl();
            ((System.ComponentModel.ISupportInitialize)(this.pozReostatControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozDGUControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // prevTask
            // 
            this.prevTask.Image = global::reostat.Properties.Resources.left;
            this.prevTask.Location = new System.Drawing.Point(30, 414);
            this.prevTask.Name = "prevTask";
            this.prevTask.Size = new System.Drawing.Size(70, 70);
            this.prevTask.TabIndex = 0;
            this.prevTask.UseVisualStyleBackColor = true;
            this.prevTask.Click += new System.EventHandler(this.prevTask_Click);
            // 
            // AnalogVoltage
            // 
            this.AnalogVoltage.BackColor = System.Drawing.Color.Transparent;
            this.AnalogVoltage.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AnalogVoltage.Location = new System.Drawing.Point(535, 526);
            this.AnalogVoltage.MaxValue = 1000;
            this.AnalogVoltage.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.AnalogVoltage.MinValue = 0;
            this.AnalogVoltage.Name = "AnalogVoltage";
            this.AnalogVoltage.NeedleColor = System.Drawing.Color.Red;
            this.AnalogVoltage.Renderer = null;
            this.AnalogVoltage.ScaleColor = System.Drawing.Color.White;
            this.AnalogVoltage.ScaleDivisions = 11;
            this.AnalogVoltage.ScaleSubDivisions = 10;
            this.AnalogVoltage.Size = new System.Drawing.Size(209, 212);
            this.AnalogVoltage.TabIndex = 2;
            this.AnalogVoltage.Value = 0;
            this.AnalogVoltage.ViewGlass = false;
            // 
            // AnalogCur
            // 
            this.AnalogCur.BackColor = System.Drawing.Color.Transparent;
            this.AnalogCur.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AnalogCur.Location = new System.Drawing.Point(750, 526);
            this.AnalogCur.MaxValue = 3000;
            this.AnalogCur.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.AnalogCur.MinValue = 0;
            this.AnalogCur.Name = "AnalogCur";
            this.AnalogCur.NeedleColor = System.Drawing.Color.Red;
            this.AnalogCur.Renderer = null;
            this.AnalogCur.ScaleColor = System.Drawing.Color.White;
            this.AnalogCur.ScaleDivisions = 9;
            this.AnalogCur.ScaleSubDivisions = 10;
            this.AnalogCur.Size = new System.Drawing.Size(213, 212);
            this.AnalogCur.TabIndex = 3;
            this.AnalogCur.Value = 0;
            this.AnalogCur.ViewGlass = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(52, 571);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ступени реостата";
            // 
            // pozReostatControl
            // 
            this.pozReostatControl.BackColor = System.Drawing.Color.Transparent;
            this.pozReostatControl.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozReostatControl.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozReostatControl.BevelRate = 0.5F;
            this.pozReostatControl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozReostatControl.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozReostatControl.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozReostatControl.ForeColor = System.Drawing.Color.Red;
            this.pozReostatControl.HighlightOpaque = ((byte)(50));
            this.pozReostatControl.Location = new System.Drawing.Point(99, 646);
            this.pozReostatControl.Name = "pozReostatControl";
            this.pozReostatControl.Size = new System.Drawing.Size(52, 58);
            this.pozReostatControl.TabIndex = 20;
            this.pozReostatControl.Text = "0";
            // 
            // downPozReostatButton
            // 
            this.downPozReostatButton.Image = ((System.Drawing.Image)(resources.GetObject("downPozReostatButton.Image")));
            this.downPozReostatButton.Location = new System.Drawing.Point(22, 679);
            this.downPozReostatButton.Name = "downPozReostatButton";
            this.downPozReostatButton.Size = new System.Drawing.Size(54, 53);
            this.downPozReostatButton.TabIndex = 19;
            this.downPozReostatButton.UseVisualStyleBackColor = true;
            this.downPozReostatButton.Click += new System.EventHandler(this.downPozReostatButton_Click);
            // 
            // upPozReostatButton
            // 
            this.upPozReostatButton.Image = ((System.Drawing.Image)(resources.GetObject("upPozReostatButton.Image")));
            this.upPozReostatButton.Location = new System.Drawing.Point(22, 609);
            this.upPozReostatButton.Name = "upPozReostatButton";
            this.upPozReostatButton.Size = new System.Drawing.Size(54, 48);
            this.upPozReostatButton.TabIndex = 18;
            this.upPozReostatButton.UseVisualStyleBackColor = true;
            this.upPozReostatButton.Click += new System.EventHandler(this.upPozReostatButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(355, 583);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 34);
            this.label6.TabIndex = 23;
            this.label6.Text = "Позиция контроллера \r\n       машиниста";
            // 
            // pozDGUControl
            // 
            this.pozDGUControl.BackColor = System.Drawing.Color.Transparent;
            this.pozDGUControl.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozDGUControl.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozDGUControl.BevelRate = 0.5F;
            this.pozDGUControl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozDGUControl.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozDGUControl.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pozDGUControl.ForeColor = System.Drawing.Color.Red;
            this.pozDGUControl.HighlightOpaque = ((byte)(50));
            this.pozDGUControl.Location = new System.Drawing.Point(414, 631);
            this.pozDGUControl.Name = "pozDGUControl";
            this.pozDGUControl.Size = new System.Drawing.Size(92, 58);
            this.pozDGUControl.TabIndex = 22;
            this.pozDGUControl.Text = "0";
            // 
            // numberLocWork
            // 
            this.numberLocWork.AutoSize = true;
            this.numberLocWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLocWork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.numberLocWork.Location = new System.Drawing.Point(307, 22);
            this.numberLocWork.Name = "numberLocWork";
            this.numberLocWork.Size = new System.Drawing.Size(0, 46);
            this.numberLocWork.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(267, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 46);
            this.label1.TabIndex = 25;
            this.label1.Text = "-";
            // 
            // typeLocWork
            // 
            this.typeLocWork.AutoSize = true;
            this.typeLocWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeLocWork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.typeLocWork.Location = new System.Drawing.Point(57, 22);
            this.typeLocWork.Name = "typeLocWork";
            this.typeLocWork.Size = new System.Drawing.Size(0, 46);
            this.typeLocWork.TabIndex = 24;
            // 
            // zedGraphExtern
            // 
            this.zedGraphExtern.Location = new System.Drawing.Point(109, 107);
            this.zedGraphExtern.Name = "zedGraphExtern";
            this.zedGraphExtern.ScrollGrace = 0;
            this.zedGraphExtern.ScrollMaxX = 0;
            this.zedGraphExtern.ScrollMaxY = 0;
            this.zedGraphExtern.ScrollMaxY2 = 0;
            this.zedGraphExtern.ScrollMinX = 0;
            this.zedGraphExtern.ScrollMinY = 0;
            this.zedGraphExtern.ScrollMinY2 = 0;
            this.zedGraphExtern.Size = new System.Drawing.Size(1060, 377);
            this.zedGraphExtern.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(552, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Напряжение генератора";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(797, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Ток генератора";
            // 
            // ExtValid
            // 
            this.ExtValid.BackColor = System.Drawing.Color.Transparent;
            this.ExtValid.BlinkInterval = 500;
            this.ExtValid.ForeColor = System.Drawing.Color.Black;
            this.ExtValid.Label = "";
            this.ExtValid.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.ExtValid.LedColor = System.Drawing.Color.Lime;
            this.ExtValid.LedSize = new System.Drawing.SizeF(50F, 50F);
            this.ExtValid.Location = new System.Drawing.Point(228, 637);
            this.ExtValid.Name = "ExtValid";
            this.ExtValid.Renderer = null;
            this.ExtValid.Size = new System.Drawing.Size(63, 52);
            this.ExtValid.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.ExtValid.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.ExtValid.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(200, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 34);
            this.label4.TabIndex = 41;
            this.label4.Text = "    Значение \r\nзафиксировано";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lxLedControl1
            // 
            this.lxLedControl1.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl1.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl1.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl1.BevelRate = 0.5F;
            this.lxLedControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl1.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl1.ForeColor = System.Drawing.Color.Red;
            this.lxLedControl1.HighlightOpaque = ((byte)(50));
            this.lxLedControl1.Location = new System.Drawing.Point(978, 542);
            this.lxLedControl1.Name = "lxLedControl1";
            this.lxLedControl1.Size = new System.Drawing.Size(167, 52);
            this.lxLedControl1.TabIndex = 42;
            this.lxLedControl1.Text = "0";
            this.lxLedControl1.TotalCharCount = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(962, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Температура воды";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(1123, 506);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "Температура масла";
            // 
            // lxLedControl2
            // 
            this.lxLedControl2.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl2.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl2.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl2.BevelRate = 0.5F;
            this.lxLedControl2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl2.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl2.ForeColor = System.Drawing.Color.Red;
            this.lxLedControl2.HighlightOpaque = ((byte)(50));
            this.lxLedControl2.Location = new System.Drawing.Point(1126, 542);
            this.lxLedControl2.Name = "lxLedControl2";
            this.lxLedControl2.Size = new System.Drawing.Size(141, 52);
            this.lxLedControl2.TabIndex = 44;
            this.lxLedControl2.Text = "0";
            this.lxLedControl2.TotalCharCount = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(1123, 625);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Давление масла";
            // 
            // lxLedControl3
            // 
            this.lxLedControl3.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl3.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl3.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl3.BevelRate = 0.5F;
            this.lxLedControl3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl3.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl3.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lxLedControl3.ForeColor = System.Drawing.Color.Red;
            this.lxLedControl3.HighlightOpaque = ((byte)(50));
            this.lxLedControl3.Location = new System.Drawing.Point(1126, 661);
            this.lxLedControl3.Name = "lxLedControl3";
            this.lxLedControl3.Size = new System.Drawing.Size(141, 52);
            this.lxLedControl3.TabIndex = 46;
            this.lxLedControl3.Text = "0";
            this.lxLedControl3.TotalCharCount = 4;
            // 
            // GraphExternForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1292, 768);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lxLedControl3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lxLedControl2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lxLedControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExtValid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zedGraphExtern);
            this.Controls.Add(this.numberLocWork);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeLocWork);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pozDGUControl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pozReostatControl);
            this.Controls.Add(this.downPozReostatButton);
            this.Controls.Add(this.upPozReostatButton);
            this.Controls.Add(this.AnalogCur);
            this.Controls.Add(this.AnalogVoltage);
            this.Controls.Add(this.prevTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GraphExternForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GraphExternForm";
            this.Load += new System.EventHandler(this.GraphExternForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pozReostatControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pozDGUControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button prevTask;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter AnalogVoltage;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter AnalogCur;
        private System.Windows.Forms.Label label7;
        private LxControl.LxLedControl pozReostatControl;
        private System.Windows.Forms.Button downPozReostatButton;
        private System.Windows.Forms.Button upPozReostatButton;
        private System.Windows.Forms.Label label6;
        private LxControl.LxLedControl pozDGUControl;
        private System.Windows.Forms.Label numberLocWork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label typeLocWork;
        private ZedGraph.ZedGraphControl zedGraphExtern;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private LBSoft.IndustrialCtrls.Leds.LBLed ExtValid;
        private System.Windows.Forms.Label label4;
        private LxControl.LxLedControl lxLedControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private LxControl.LxLedControl lxLedControl2;
        private System.Windows.Forms.Label label9;
        private LxControl.LxLedControl lxLedControl3;
    }
}