namespace TechnolToolkit
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUSER = new System.Windows.Forms.TextBox();
            this.textBoxMD5 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBoxRememberUser = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape3,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(417, 344);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.White;
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.BorderColor = System.Drawing.Color.White;
            this.rectangleShape2.CornerRadius = 3;
            this.rectangleShape2.Location = new System.Drawing.Point(70, 145);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(270, 60);
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.rectangleShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape3.BorderColor = System.Drawing.Color.White;
            this.rectangleShape3.CornerRadius = 5;
            this.rectangleShape3.Location = new System.Drawing.Point(70, 220);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(270, 60);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.White;
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.White;
            this.rectangleShape1.CornerRadius = 3;
            this.rectangleShape1.Location = new System.Drawing.Point(70, 75);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(270, 60);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Přihlášení";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxUSER
            // 
            this.textBoxUSER.BackColor = System.Drawing.Color.White;
            this.textBoxUSER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUSER.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUSER.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxUSER.Location = new System.Drawing.Point(135, 91);
            this.textBoxUSER.Name = "textBoxUSER";
            this.textBoxUSER.Size = new System.Drawing.Size(193, 32);
            this.textBoxUSER.TabIndex = 2;
            this.textBoxUSER.Text = "Uživatel";
            this.textBoxUSER.Click += new System.EventHandler(this.textBoxUSER_Click);
            // 
            // textBoxMD5
            // 
            this.textBoxMD5.BackColor = System.Drawing.Color.White;
            this.textBoxMD5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMD5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMD5.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxMD5.Location = new System.Drawing.Point(135, 160);
            this.textBoxMD5.Name = "textBoxMD5";
            this.textBoxMD5.Size = new System.Drawing.Size(193, 32);
            this.textBoxMD5.TabIndex = 3;
            this.textBoxMD5.Text = "MD5 Hash";
            this.textBoxMD5.Click += new System.EventHandler(this.textBoxMD5_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Location = new System.Drawing.Point(129, 319);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(141, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Nemám přístupové údaje";
            // 
            // checkBoxRememberUser
            // 
            this.checkBoxRememberUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxRememberUser.ForeColor = System.Drawing.Color.Black;
            this.checkBoxRememberUser.Location = new System.Drawing.Point(104, 288);
            this.checkBoxRememberUser.Name = "checkBoxRememberUser";
            this.checkBoxRememberUser.Size = new System.Drawing.Size(199, 26);
            this.checkBoxRememberUser.TabIndex = 8;
            this.checkBoxRememberUser.Text = "Zapamatovat si přihlášení";
            this.checkBoxRememberUser.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(77, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(77, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(73, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "Přihlásit";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(417, 344);
            this.Controls.Add(this.checkBoxRememberUser);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxMD5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUSER);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUSER;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.TextBox textBoxMD5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBoxRememberUser;
        private System.Windows.Forms.Button button1;
    }
}