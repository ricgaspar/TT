namespace TechnolToolkit
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
            this.tableLayoutPanelVnejsi = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEasterEgg = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonAddToGroup = new System.Windows.Forms.Button();
            this.buttonDZC = new System.Windows.Forms.Button();
            this.buttonSAP = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonAdminTools = new System.Windows.Forms.Button();
            this.tableLayoutPanelVnejsi.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelVnejsi
            // 
            this.tableLayoutPanelVnejsi.AutoScroll = true;
            this.tableLayoutPanelVnejsi.ColumnCount = 2;
            this.tableLayoutPanelVnejsi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanelVnejsi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanelVnejsi.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelVnejsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVnejsi.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelVnejsi.Name = "tableLayoutPanelVnejsi";
            this.tableLayoutPanelVnejsi.RowCount = 1;
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 711F));
            this.tableLayoutPanelVnejsi.Size = new System.Drawing.Size(1234, 711);
            this.tableLayoutPanelVnejsi.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(250, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(984, 711);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.buttonEasterEgg);
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Controls.Add(this.buttonAddToGroup);
            this.panel1.Controls.Add(this.buttonDZC);
            this.panel1.Controls.Add(this.buttonSAP);
            this.panel1.Controls.Add(this.buttonMenu);
            this.panel1.Controls.Add(this.buttonAdminTools);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 711);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonEasterEgg
            // 
            this.buttonEasterEgg.BackColor = System.Drawing.Color.Transparent;
            this.buttonEasterEgg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEasterEgg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(241)))));
            this.buttonEasterEgg.Location = new System.Drawing.Point(3, 687);
            this.buttonEasterEgg.Name = "buttonEasterEgg";
            this.buttonEasterEgg.Size = new System.Drawing.Size(75, 23);
            this.buttonEasterEgg.TabIndex = 10;
            this.buttonEasterEgg.UseVisualStyleBackColor = false;
            this.buttonEasterEgg.Click += new System.EventHandler(this.buttonEasterEgg_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSettings.Location = new System.Drawing.Point(0, 294);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonSettings.Size = new System.Drawing.Size(249, 50);
            this.buttonSettings.TabIndex = 9;
            this.buttonSettings.Text = "Nastavení";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSettings_Paint);
            // 
            // buttonAddToGroup
            // 
            this.buttonAddToGroup.FlatAppearance.BorderSize = 0;
            this.buttonAddToGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonAddToGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddToGroup.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddToGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonAddToGroup.Location = new System.Drawing.Point(0, 240);
            this.buttonAddToGroup.Name = "buttonAddToGroup";
            this.buttonAddToGroup.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonAddToGroup.Size = new System.Drawing.Size(249, 50);
            this.buttonAddToGroup.TabIndex = 9;
            this.buttonAddToGroup.Text = "Správa skupin";
            this.buttonAddToGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddToGroup.UseVisualStyleBackColor = true;
            this.buttonAddToGroup.Click += new System.EventHandler(this.buttonAddToGroup_Click);
            this.buttonAddToGroup.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonAddToGroup_Paint);
            // 
            // buttonDZC
            // 
            this.buttonDZC.FlatAppearance.BorderSize = 0;
            this.buttonDZC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonDZC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.buttonDZC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDZC.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDZC.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonDZC.Location = new System.Drawing.Point(0, 185);
            this.buttonDZC.Name = "buttonDZC";
            this.buttonDZC.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonDZC.Size = new System.Drawing.Size(249, 50);
            this.buttonDZC.TabIndex = 8;
            this.buttonDZC.Text = "Hledání DZC";
            this.buttonDZC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDZC.UseVisualStyleBackColor = true;
            this.buttonDZC.Click += new System.EventHandler(this.buttonDZC_Click);
            this.buttonDZC.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonDZC_Paint);
            // 
            // buttonSAP
            // 
            this.buttonSAP.FlatAppearance.BorderSize = 0;
            this.buttonSAP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonSAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSAP.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSAP.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSAP.Location = new System.Drawing.Point(0, 130);
            this.buttonSAP.Name = "buttonSAP";
            this.buttonSAP.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonSAP.Size = new System.Drawing.Size(249, 50);
            this.buttonSAP.TabIndex = 7;
            this.buttonSAP.Text = "SAP";
            this.buttonSAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSAP.UseVisualStyleBackColor = true;
            this.buttonSAP.Click += new System.EventHandler(this.ButtonSAP_Click);
            this.buttonSAP.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSAP_Paint);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonMenu.Location = new System.Drawing.Point(-3, 13);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonMenu.Size = new System.Drawing.Size(253, 50);
            this.buttonMenu.TabIndex = 0;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            this.buttonMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonMenu_Paint);
            // 
            // buttonAdminTools
            // 
            this.buttonAdminTools.FlatAppearance.BorderSize = 0;
            this.buttonAdminTools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonAdminTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdminTools.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdminTools.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonAdminTools.Location = new System.Drawing.Point(0, 75);
            this.buttonAdminTools.Name = "buttonAdminTools";
            this.buttonAdminTools.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonAdminTools.Size = new System.Drawing.Size(249, 50);
            this.buttonAdminTools.TabIndex = 1;
            this.buttonAdminTools.Text = "Nástroje";
            this.buttonAdminTools.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdminTools.UseVisualStyleBackColor = true;
            this.buttonAdminTools.Click += new System.EventHandler(this.buttonAdminTools_Click);
            this.buttonAdminTools.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonAdminTools_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1234, 711);
            this.Controls.Add(this.tableLayoutPanelVnejsi);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1250, 730);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Technology Toolkit";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanelVnejsi.ResumeLayout(false);
            this.tableLayoutPanelVnejsi.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVnejsi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAdminTools;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonSAP;
        private System.Windows.Forms.Button buttonDZC;
        private System.Windows.Forms.Button buttonAddToGroup;
        private System.Windows.Forms.Button buttonEasterEgg;
        private System.Windows.Forms.Button buttonSettings;
    }
}

