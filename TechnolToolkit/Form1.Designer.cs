﻿namespace TechnolToolkit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanelVnejsi = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSAP = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonAdminTools = new System.Windows.Forms.Button();
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
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
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelVnejsi.Size = new System.Drawing.Size(1227, 713);
            this.tableLayoutPanelVnejsi.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(253, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(971, 707);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.buttonSAP);
            this.panel1.Controls.Add(this.buttonMenu);
            this.panel1.Controls.Add(this.buttonAdminTools);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 713);
            this.panel1.TabIndex = 8;
            // 
            // buttonSAP
            // 
            this.buttonSAP.FlatAppearance.BorderSize = 0;
            this.buttonSAP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.buttonSAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSAP.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSAP.ForeColor = System.Drawing.Color.Black;
            this.buttonSAP.Location = new System.Drawing.Point(0, 123);
            this.buttonSAP.Name = "buttonSAP";
            this.buttonSAP.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonSAP.Size = new System.Drawing.Size(250, 50);
            this.buttonSAP.TabIndex = 7;
            this.buttonSAP.Text = "Náhled do SAPu";
            this.buttonSAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSAP.UseVisualStyleBackColor = true;
            this.buttonSAP.Click += new System.EventHandler(this.buttonSAP_Click);
            this.buttonSAP.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSAP_Paint);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMenu.Location = new System.Drawing.Point(-3, 12);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Padding = new System.Windows.Forms.Padding(62, 0, 0, 0);
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
            this.buttonAdminTools.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.buttonAdminTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdminTools.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdminTools.ForeColor = System.Drawing.Color.Black;
            this.buttonAdminTools.Location = new System.Drawing.Point(0, 68);
            this.buttonAdminTools.Name = "buttonAdminTools";
            this.buttonAdminTools.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.buttonAdminTools.Size = new System.Drawing.Size(250, 50);
            this.buttonAdminTools.TabIndex = 1;
            this.buttonAdminTools.Text = "Admin nástroje";
            this.buttonAdminTools.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdminTools.UseVisualStyleBackColor = true;
            this.buttonAdminTools.Click += new System.EventHandler(this.buttonAdminTools_Click);
            this.buttonAdminTools.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonAdminTools_Paint);
            // 
            // timerMenu
            // 
            this.timerMenu.Interval = 15;
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1227, 713);
            this.Controls.Add(this.tableLayoutPanelVnejsi);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 500);
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
        private System.Windows.Forms.Timer timerMenu;
        private System.Windows.Forms.Button buttonSAP;
    }
}

