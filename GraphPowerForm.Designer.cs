namespace reostat
{
    partial class GraphPowerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphPowerForm));
            this.prevWorkButton = new System.Windows.Forms.Button();
            this.zedGraphPower = new ZedGraph.ZedGraphControl();
            this.typeLocText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberLocText = new System.Windows.Forms.Label();
            this.NextGraphButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prevWorkButton
            // 
            this.prevWorkButton.Image = ((System.Drawing.Image)(resources.GetObject("prevWorkButton.Image")));
            this.prevWorkButton.Location = new System.Drawing.Point(31, 414);
            this.prevWorkButton.Name = "prevWorkButton";
            this.prevWorkButton.Size = new System.Drawing.Size(70, 70);
            this.prevWorkButton.TabIndex = 0;
            this.prevWorkButton.UseVisualStyleBackColor = true;
            this.prevWorkButton.Click += new System.EventHandler(this.prevWorkButton_Click);
            // 
            // zedGraphPower
            // 
            this.zedGraphPower.Location = new System.Drawing.Point(118, 117);
            this.zedGraphPower.Name = "zedGraphPower";
            this.zedGraphPower.ScrollGrace = 0;
            this.zedGraphPower.ScrollMaxX = 0;
            this.zedGraphPower.ScrollMaxY = 0;
            this.zedGraphPower.ScrollMaxY2 = 0;
            this.zedGraphPower.ScrollMinX = 0;
            this.zedGraphPower.ScrollMinY = 0;
            this.zedGraphPower.ScrollMinY2 = 0;
            this.zedGraphPower.Size = new System.Drawing.Size(1017, 588);
            this.zedGraphPower.TabIndex = 1;
            // 
            // typeLocText
            // 
            this.typeLocText.AutoSize = true;
            this.typeLocText.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeLocText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.typeLocText.Location = new System.Drawing.Point(42, 30);
            this.typeLocText.Name = "typeLocText";
            this.typeLocText.Size = new System.Drawing.Size(0, 46);
            this.typeLocText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(209, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "-";
            // 
            // numberLocText
            // 
            this.numberLocText.AutoSize = true;
            this.numberLocText.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLocText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.numberLocText.Location = new System.Drawing.Point(249, 30);
            this.numberLocText.Name = "numberLocText";
            this.numberLocText.Size = new System.Drawing.Size(0, 46);
            this.numberLocText.TabIndex = 4;
            // 
            // NextGraphButton
            // 
            this.NextGraphButton.Image = global::reostat.Properties.Resources.right;
            this.NextGraphButton.Location = new System.Drawing.Point(1169, 414);
            this.NextGraphButton.Name = "NextGraphButton";
            this.NextGraphButton.Size = new System.Drawing.Size(70, 70);
            this.NextGraphButton.TabIndex = 5;
            this.NextGraphButton.UseVisualStyleBackColor = true;
            this.NextGraphButton.Click += new System.EventHandler(this.NextGraphButton_Click);
            // 
            // GraphPowerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1292, 768);
            this.Controls.Add(this.NextGraphButton);
            this.Controls.Add(this.numberLocText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeLocText);
            this.Controls.Add(this.zedGraphPower);
            this.Controls.Add(this.prevWorkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GraphPowerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GraphPowerForm";
            this.Load += new System.EventHandler(this.GraphPowerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button prevWorkButton;
        private ZedGraph.ZedGraphControl zedGraphPower;
        private System.Windows.Forms.Label typeLocText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numberLocText;
        private System.Windows.Forms.Button NextGraphButton;
    }
}