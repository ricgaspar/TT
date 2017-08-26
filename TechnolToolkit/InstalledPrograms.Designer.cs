﻿namespace TechnolToolkit
{
    partial class InstalledPrograms
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.tableLayoutPanelHorni = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelHorniVnoreny = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxLocalPC = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonVyhledat = new System.Windows.Forms.Button();
            this.tableLayoutPanelVnejsi = new System.Windows.Forms.TableLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.otevrenoToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.checkBoxKopirujVerze = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelHorni.SuspendLayout();
            this.tableLayoutPanelHorniVnoreny.SuspendLayout();
            this.tableLayoutPanelVnejsi.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.Location = new System.Drawing.Point(3, 81);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(924, 488);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // tableLayoutPanelHorni
            // 
            this.tableLayoutPanelHorni.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelHorni.ColumnCount = 1;
            this.tableLayoutPanelHorni.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHorni.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelHorni.Controls.Add(this.tableLayoutPanelHorniVnoreny, 0, 1);
            this.tableLayoutPanelHorni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHorni.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHorni.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelHorni.Name = "tableLayoutPanelHorni";
            this.tableLayoutPanelHorni.RowCount = 2;
            this.tableLayoutPanelHorni.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHorni.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanelHorni.Size = new System.Drawing.Size(930, 78);
            this.tableLayoutPanelHorni.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(359, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vyhledání nainstalovaných programů";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelHorniVnoreny
            // 
            this.tableLayoutPanelHorniVnoreny.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelHorniVnoreny.ColumnCount = 4;
            this.tableLayoutPanelHorniVnoreny.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanelHorniVnoreny.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanelHorniVnoreny.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanelHorniVnoreny.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHorniVnoreny.Controls.Add(this.checkBoxLocalPC, 0, 1);
            this.tableLayoutPanelHorniVnoreny.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanelHorniVnoreny.Controls.Add(this.buttonVyhledat, 2, 1);
            this.tableLayoutPanelHorniVnoreny.Controls.Add(this.checkBoxKopirujVerze, 3, 1);
            this.tableLayoutPanelHorniVnoreny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHorniVnoreny.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanelHorniVnoreny.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelHorniVnoreny.Name = "tableLayoutPanelHorniVnoreny";
            this.tableLayoutPanelHorniVnoreny.RowCount = 2;
            this.tableLayoutPanelHorniVnoreny.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHorniVnoreny.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelHorniVnoreny.Size = new System.Drawing.Size(930, 43);
            this.tableLayoutPanelHorniVnoreny.TabIndex = 0;
            // 
            // checkBoxLocalPC
            // 
            this.checkBoxLocalPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLocalPC.AutoSize = true;
            this.checkBoxLocalPC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxLocalPC.Checked = true;
            this.checkBoxLocalPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLocalPC.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxLocalPC.ForeColor = System.Drawing.Color.Black;
            this.checkBoxLocalPC.Location = new System.Drawing.Point(57, 16);
            this.checkBoxLocalPC.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.checkBoxLocalPC.Name = "checkBoxLocalPC";
            this.checkBoxLocalPC.Size = new System.Drawing.Size(75, 17);
            this.checkBoxLocalPC.TabIndex = 4;
            this.checkBoxLocalPC.Text = "Localhost";
            this.checkBoxLocalPC.UseVisualStyleBackColor = true;
            this.checkBoxLocalPC.CheckedChanged += new System.EventHandler(this.checkBoxLocalPC_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(138, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Lokální pc";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonVyhledat
            // 
            this.buttonVyhledat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonVyhledat.Location = new System.Drawing.Point(337, 13);
            this.buttonVyhledat.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.buttonVyhledat.Name = "buttonVyhledat";
            this.buttonVyhledat.Size = new System.Drawing.Size(80, 21);
            this.buttonVyhledat.TabIndex = 3;
            this.buttonVyhledat.Text = "Vyhledat";
            this.buttonVyhledat.UseVisualStyleBackColor = true;
            this.buttonVyhledat.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tableLayoutPanelVnejsi
            // 
            this.tableLayoutPanelVnejsi.ColumnCount = 1;
            this.tableLayoutPanelVnejsi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.Controls.Add(this.tableLayoutPanelHorni, 0, 0);
            this.tableLayoutPanelVnejsi.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanelVnejsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVnejsi.Location = new System.Drawing.Point(10, 0);
            this.tableLayoutPanelVnejsi.Name = "tableLayoutPanelVnejsi";
            this.tableLayoutPanelVnejsi.RowCount = 2;
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.Size = new System.Drawing.Size(930, 572);
            this.tableLayoutPanelVnejsi.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\ProgramData\\TechnolToolkit\\InstalledPrograms";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otevrenoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(10, 572);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // otevrenoToolStripMenuItem
            // 
            this.otevrenoToolStripMenuItem.AutoSize = false;
            this.otevrenoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.otevrenoToolStripMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.otevrenoToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.otevrenoToolStripMenuItem.Name = "otevrenoToolStripMenuItem";
            this.otevrenoToolStripMenuItem.ReadOnly = true;
            this.otevrenoToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.otevrenoToolStripMenuItem.Size = new System.Drawing.Size(300, 19);
            this.otevrenoToolStripMenuItem.Text = "Otevřeno: NULL";
            // 
            // checkBoxKopirujVerze
            // 
            this.checkBoxKopirujVerze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxKopirujVerze.AutoSize = true;
            this.checkBoxKopirujVerze.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxKopirujVerze.Location = new System.Drawing.Point(423, 10);
            this.checkBoxKopirujVerze.Name = "checkBoxKopirujVerze";
            this.checkBoxKopirujVerze.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.checkBoxKopirujVerze.Size = new System.Drawing.Size(114, 23);
            this.checkBoxKopirujVerze.TabIndex = 5;
            this.checkBoxKopirujVerze.Text = "Kopírovat verze";
            this.checkBoxKopirujVerze.UseVisualStyleBackColor = true;
            // 
            // InstalledPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(950, 596);
            this.Controls.Add(this.tableLayoutPanelVnejsi);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(672, 530);
            this.Name = "InstalledPrograms";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vyhledání nainstalovaných programů";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstalledPrograms_FormClosing);
            this.tableLayoutPanelHorni.ResumeLayout(false);
            this.tableLayoutPanelHorni.PerformLayout();
            this.tableLayoutPanelHorniVnoreny.ResumeLayout(false);
            this.tableLayoutPanelHorniVnoreny.PerformLayout();
            this.tableLayoutPanelVnejsi.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHorni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHorniVnoreny;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVnejsi;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.CheckBox checkBoxLocalPC;
        private System.Windows.Forms.Button buttonVyhledat;
        private System.Windows.Forms.ToolStripTextBox otevrenoToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxKopirujVerze;
    }
}