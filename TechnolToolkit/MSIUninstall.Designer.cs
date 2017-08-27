namespace TechnolToolkit
{
    partial class MSIUninstall
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
            this.textBoxComputerName = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxTentoPC = new System.Windows.Forms.CheckBox();
            this.textBoxMSIstring = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxComputerName
            // 
            this.textBoxComputerName.AllowDrop = true;
            this.textBoxComputerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.textBoxComputerName.Enabled = false;
            this.textBoxComputerName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxComputerName.ForeColor = System.Drawing.Color.White;
            this.textBoxComputerName.Location = new System.Drawing.Point(157, 40);
            this.textBoxComputerName.Name = "textBoxComputerName";
            this.textBoxComputerName.Size = new System.Drawing.Size(259, 25);
            this.textBoxComputerName.TabIndex = 4;
            this.textBoxComputerName.TextChanged += new System.EventHandler(this.textBoxComputerName_TextChanged);
            this.textBoxComputerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxComputerName_KeyDown);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOK.Enabled = false;
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOK.Location = new System.Drawing.Point(181, 113);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(179, 26);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vyhledání odinstalačních stringů";
            // 
            // checkBoxTentoPC
            // 
            this.checkBoxTentoPC.AutoSize = true;
            this.checkBoxTentoPC.Checked = true;
            this.checkBoxTentoPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTentoPC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxTentoPC.ForeColor = System.Drawing.Color.White;
            this.checkBoxTentoPC.Location = new System.Drawing.Point(434, 40);
            this.checkBoxTentoPC.Name = "checkBoxTentoPC";
            this.checkBoxTentoPC.Size = new System.Drawing.Size(82, 21);
            this.checkBoxTentoPC.TabIndex = 3;
            this.checkBoxTentoPC.Text = "Tento PC";
            this.checkBoxTentoPC.UseVisualStyleBackColor = true;
            this.checkBoxTentoPC.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBoxMSIstring
            // 
            this.textBoxMSIstring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.textBoxMSIstring.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMSIstring.ForeColor = System.Drawing.Color.White;
            this.textBoxMSIstring.Location = new System.Drawing.Point(157, 76);
            this.textBoxMSIstring.Name = "textBoxMSIstring";
            this.textBoxMSIstring.Size = new System.Drawing.Size(359, 25);
            this.textBoxMSIstring.TabIndex = 5;
            this.textBoxMSIstring.TextChanged += new System.EventHandler(this.textBoxMSIstring_TextChanged);
            this.textBoxMSIstring.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMSIstring_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cílový počítač";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hledaná aplikace";
            // 
            // MSIUninstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(535, 151);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMSIstring);
            this.Controls.Add(this.checkBoxTentoPC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxComputerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MSIUninstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxComputerName;
        private System.Windows.Forms.CheckBox checkBoxTentoPC;
        private System.Windows.Forms.TextBox textBoxMSIstring;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}