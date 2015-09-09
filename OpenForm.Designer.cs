namespace reostat
{
    partial class openForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(openForm));
            this.nextWorkForm = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.selTypeLoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selNumberLoc = new System.Windows.Forms.ComboBox();
            this.listReport = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.newTypeLocText = new System.Windows.Forms.TextBox();
            this.newLocButton = new System.Windows.Forms.Button();
            this.newNumberLoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.typeLocOpenForm = new System.Windows.Forms.Label();
            this.numberLocOpenForm = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveReport = new System.Windows.Forms.Button();
            this.printReport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nextWorkForm
            // 
            this.nextWorkForm.Image = ((System.Drawing.Image)(resources.GetObject("nextWorkForm.Image")));
            this.nextWorkForm.Location = new System.Drawing.Point(1210, 420);
            this.nextWorkForm.Name = "nextWorkForm";
            this.nextWorkForm.Size = new System.Drawing.Size(70, 70);
            this.nextWorkForm.TabIndex = 0;
            this.nextWorkForm.UseVisualStyleBackColor = true;
            this.nextWorkForm.Click += new System.EventHandler(this.nextWorkForm_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(31, 688);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(76, 42);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // selTypeLoc
            // 
            this.selTypeLoc.FormattingEnabled = true;
            this.selTypeLoc.Location = new System.Drawing.Point(24, 56);
            this.selTypeLoc.Name = "selTypeLoc";
            this.selTypeLoc.Size = new System.Drawing.Size(131, 24);
            this.selTypeLoc.TabIndex = 2;
            this.selTypeLoc.SelectedIndexChanged += new System.EventHandler(this.typeLoc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип локомотива";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.selNumberLoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.selTypeLoc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(36, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 123);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор локомотива";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(187, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Номер локомотива";
            // 
            // selNumberLoc
            // 
            this.selNumberLoc.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.selNumberLoc.FormattingEnabled = true;
            this.selNumberLoc.Location = new System.Drawing.Point(190, 56);
            this.selNumberLoc.Name = "selNumberLoc";
            this.selNumberLoc.Size = new System.Drawing.Size(146, 24);
            this.selNumberLoc.TabIndex = 4;
            this.selNumberLoc.SelectedIndexChanged += new System.EventHandler(this.selNumberLoc_SelectedIndexChanged);
            // 
            // listReport
            // 
            this.listReport.FormattingEnabled = true;
            this.listReport.Location = new System.Drawing.Point(36, 245);
            this.listReport.Name = "listReport";
            this.listReport.Size = new System.Drawing.Size(397, 394);
            this.listReport.TabIndex = 5;
            this.listReport.SelectedIndexChanged += new System.EventHandler(this.listReport_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(188, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отчеты";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.newTypeLocText);
            this.groupBox2.Controls.Add(this.newLocButton);
            this.groupBox2.Controls.Add(this.newNumberLoc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(475, 577);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 153);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Создание локомотива";
            // 
            // newTypeLocText
            // 
            this.newTypeLocText.Location = new System.Drawing.Point(24, 56);
            this.newTypeLocText.Name = "newTypeLocText";
            this.newTypeLocText.Size = new System.Drawing.Size(109, 23);
            this.newTypeLocText.TabIndex = 21;
            // 
            // newLocButton
            // 
            this.newLocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newLocButton.ForeColor = System.Drawing.Color.Black;
            this.newLocButton.Location = new System.Drawing.Point(112, 104);
            this.newLocButton.Name = "newLocButton";
            this.newLocButton.Size = new System.Drawing.Size(113, 30);
            this.newLocButton.TabIndex = 7;
            this.newLocButton.Text = "Сохранить запись";
            this.newLocButton.UseVisualStyleBackColor = true;
            this.newLocButton.Click += new System.EventHandler(this.newLocButton_Click);
            // 
            // newNumberLoc
            // 
            this.newNumberLoc.Location = new System.Drawing.Point(190, 56);
            this.newNumberLoc.Name = "newNumberLoc";
            this.newNumberLoc.Size = new System.Drawing.Size(130, 23);
            this.newNumberLoc.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(187, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Номер локомотива";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(21, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Тип локомотива";
            // 
            // typeLocOpenForm
            // 
            this.typeLocOpenForm.AutoSize = true;
            this.typeLocOpenForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeLocOpenForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.typeLocOpenForm.Location = new System.Drawing.Point(46, 22);
            this.typeLocOpenForm.Name = "typeLocOpenForm";
            this.typeLocOpenForm.Size = new System.Drawing.Size(0, 46);
            this.typeLocOpenForm.TabIndex = 10;
            // 
            // numberLocOpenForm
            // 
            this.numberLocOpenForm.AutoSize = true;
            this.numberLocOpenForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLocOpenForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.numberLocOpenForm.Location = new System.Drawing.Point(258, 22);
            this.numberLocOpenForm.Name = "numberLocOpenForm";
            this.numberLocOpenForm.Size = new System.Drawing.Size(0, 46);
            this.numberLocOpenForm.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(218, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 46);
            this.label6.TabIndex = 12;
            this.label6.Text = "-";
            // 
            // saveReport
            // 
            this.saveReport.Location = new System.Drawing.Point(140, 688);
            this.saveReport.Name = "saveReport";
            this.saveReport.Size = new System.Drawing.Size(117, 42);
            this.saveReport.TabIndex = 17;
            this.saveReport.Text = "Сохранить отчет";
            this.saveReport.UseVisualStyleBackColor = true;
            this.saveReport.Click += new System.EventHandler(this.saveReport_Click_1);
            // 
            // printReport
            // 
            this.printReport.Location = new System.Drawing.Point(285, 688);
            this.printReport.Name = "printReport";
            this.printReport.Size = new System.Drawing.Size(128, 42);
            this.printReport.TabIndex = 18;
            this.printReport.Text = "Печать отчета";
            this.printReport.UseVisualStyleBackColor = true;
            this.printReport.Click += new System.EventHandler(this.printReport_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::reostat.Properties.Resources.TEM2;
            this.pictureBox1.Location = new System.Drawing.Point(665, 190);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 300);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(774, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(489, 62);
            this.label7.TabIndex = 20;
            this.label7.Text = "Программа автоматизированного \r\nпроведения реостатных испытаний";
            // 
            // openForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1292, 768);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.printReport);
            this.Controls.Add(this.saveReport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numberLocOpenForm);
            this.Controls.Add(this.typeLocOpenForm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.nextWorkForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "openForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "OpenForm";
            this.Load += new System.EventHandler(this.openForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextWorkForm;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ComboBox selTypeLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selNumberLoc;
        private System.Windows.Forms.ListBox listReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox newNumberLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label typeLocOpenForm;
        private System.Windows.Forms.Label numberLocOpenForm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button newLocButton;
        private System.Windows.Forms.Button saveReport;
        private System.Windows.Forms.Button printReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox newTypeLocText;
    }
}

