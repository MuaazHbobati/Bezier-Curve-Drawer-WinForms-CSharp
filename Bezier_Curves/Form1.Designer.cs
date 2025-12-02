namespace Bezier_Curves
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_De_Casteljau = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Drw = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_De_Casteljau);
            this.panel1.Controls.Add(this.btn_Clear);
            this.panel1.Controls.Add(this.btn_Drw);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 727);
            this.panel1.TabIndex = 0;
            // 
            // btn_De_Casteljau
            // 
            this.btn_De_Casteljau.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_De_Casteljau.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_De_Casteljau.Location = new System.Drawing.Point(22, 119);
            this.btn_De_Casteljau.Name = "btn_De_Casteljau";
            this.btn_De_Casteljau.Size = new System.Drawing.Size(128, 49);
            this.btn_De_Casteljau.TabIndex = 2;
            this.btn_De_Casteljau.Text = "De Casteljau";
            this.btn_De_Casteljau.UseVisualStyleBackColor = false;
            this.btn_De_Casteljau.Click += new System.EventHandler(this.btn_De_Casteljau_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Clear.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Clear.Location = new System.Drawing.Point(22, 66);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(128, 47);
            this.btn_Clear.TabIndex = 1;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Drw
            // 
            this.btn_Drw.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Drw.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_Drw.Location = new System.Drawing.Point(22, 13);
            this.btn_Drw.Name = "btn_Drw";
            this.btn_Drw.Size = new System.Drawing.Size(128, 47);
            this.btn_Drw.TabIndex = 0;
            this.btn_Drw.Text = "Draw Points";
            this.btn_Drw.UseVisualStyleBackColor = false;
            this.btn_Drw.Click += new System.EventHandler(this.btn_Drw_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(170, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 761);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 484);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bezier Curves";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_De_Casteljau;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Drw;
        private System.Windows.Forms.Panel panel2;
    }
}

