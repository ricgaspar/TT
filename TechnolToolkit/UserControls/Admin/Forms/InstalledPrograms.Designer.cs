namespace TechnolToolkit
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tableLayoutPanelHorni = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelHorniVnoreny = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxLocalPC = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonVyhledat = new System.Windows.Forms.Button();
            this.checkBoxKopirujVerze = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelVnejsi = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.otevrenoToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kopírovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zrušitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelHorni.SuspendLayout();
            this.tableLayoutPanelHorniVnoreny.SuspendLayout();
            this.tableLayoutPanelVnejsi.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.Location = new System.Drawing.Point(3, 81);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(944, 488);
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
            this.tableLayoutPanelHorni.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanelHorni.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHorni.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelHorni.Name = "tableLayoutPanelHorni";
            this.tableLayoutPanelHorni.RowCount = 2;
            this.tableLayoutPanelHorni.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHorni.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanelHorni.Size = new System.Drawing.Size(950, 78);
            this.tableLayoutPanelHorni.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(371, 30);
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
            this.tableLayoutPanelHorniVnoreny.Size = new System.Drawing.Size(950, 43);
            this.tableLayoutPanelHorniVnoreny.TabIndex = 0;
            // 
            // checkBoxLocalPC
            // 
            this.checkBoxLocalPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLocalPC.AutoSize = true;
            this.checkBoxLocalPC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxLocalPC.Checked = true;
            this.checkBoxLocalPC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLocalPC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxLocalPC.ForeColor = System.Drawing.Color.Black;
            this.checkBoxLocalPC.Location = new System.Drawing.Point(37, 13);
            this.checkBoxLocalPC.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.checkBoxLocalPC.Name = "checkBoxLocalPC";
            this.checkBoxLocalPC.Size = new System.Drawing.Size(95, 25);
            this.checkBoxLocalPC.TabIndex = 1;
            this.checkBoxLocalPC.Text = "Localhost";
            this.checkBoxLocalPC.UseVisualStyleBackColor = true;
            this.checkBoxLocalPC.CheckedChanged += new System.EventHandler(this.checkBoxLocalPC_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(138, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 25);
            this.textBox1.TabIndex = 2;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonVyhledat
            // 
            this.buttonVyhledat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonVyhledat.ForeColor = System.Drawing.Color.Black;
            this.buttonVyhledat.Location = new System.Drawing.Point(337, 13);
            this.buttonVyhledat.Margin = new System.Windows.Forms.Padding(3, 13, 0, 3);
            this.buttonVyhledat.Name = "buttonVyhledat";
            this.buttonVyhledat.Size = new System.Drawing.Size(80, 25);
            this.buttonVyhledat.TabIndex = 3;
            this.buttonVyhledat.Text = "Vyhledat";
            this.buttonVyhledat.UseVisualStyleBackColor = false;
            this.buttonVyhledat.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // checkBoxKopirujVerze
            // 
            this.checkBoxKopirujVerze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxKopirujVerze.AutoSize = true;
            this.checkBoxKopirujVerze.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxKopirujVerze.ForeColor = System.Drawing.Color.Black;
            this.checkBoxKopirujVerze.Location = new System.Drawing.Point(423, 7);
            this.checkBoxKopirujVerze.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkBoxKopirujVerze.Name = "checkBoxKopirujVerze";
            this.checkBoxKopirujVerze.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.checkBoxKopirujVerze.Size = new System.Drawing.Size(147, 31);
            this.checkBoxKopirujVerze.TabIndex = 4;
            this.checkBoxKopirujVerze.Text = "Kopírovat verze";
            this.checkBoxKopirujVerze.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelVnejsi
            // 
            this.tableLayoutPanelVnejsi.ColumnCount = 1;
            this.tableLayoutPanelVnejsi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.Controls.Add(this.tableLayoutPanelHorni, 0, 0);
            this.tableLayoutPanelVnejsi.Controls.Add(this.listView1, 0, 1);
            this.tableLayoutPanelVnejsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVnejsi.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelVnejsi.Name = "tableLayoutPanelVnejsi";
            this.tableLayoutPanelVnejsi.RowCount = 2;
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.Size = new System.Drawing.Size(950, 572);
            this.tableLayoutPanelVnejsi.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otevrenoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 572);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(950, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // otevrenoToolStripMenuItem
            // 
            this.otevrenoToolStripMenuItem.AutoSize = false;
            this.otevrenoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.otevrenoToolStripMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.otevrenoToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.otevrenoToolStripMenuItem.Name = "otevrenoToolStripMenuItem";
            this.otevrenoToolStripMenuItem.ReadOnly = true;
            this.otevrenoToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.otevrenoToolStripMenuItem.Size = new System.Drawing.Size(300, 19);
            this.otevrenoToolStripMenuItem.Text = "Otevřeno: NULL";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopírovatToolStripMenuItem,
            this.zrušitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 48);
            // 
            // kopírovatToolStripMenuItem
            // 
            this.kopírovatToolStripMenuItem.Image = global::TechnolToolkit.Properties.Resources.icons8_Copy_to_Clipboard_96_color;
            this.kopírovatToolStripMenuItem.Name = "kopírovatToolStripMenuItem";
            this.kopírovatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.kopírovatToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.kopírovatToolStripMenuItem.Text = "Kopírovat";
            this.kopírovatToolStripMenuItem.Click += new System.EventHandler(this.kopírovatToolStripMenuItem_Click);
            // 
            // zrušitToolStripMenuItem
            // 
            this.zrušitToolStripMenuItem.Image = global::TechnolToolkit.Properties.Resources.icons8_Close_Window_96;
            this.zrušitToolStripMenuItem.Name = "zrušitToolStripMenuItem";
            this.zrušitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.zrušitToolStripMenuItem.Text = "Zrušit";
            // 
            // InstalledPrograms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(950, 596);
            this.Controls.Add(this.tableLayoutPanelVnejsi);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(672, 530);
            this.Name = "InstalledPrograms";
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
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.CheckBox checkBoxLocalPC;
        private System.Windows.Forms.Button buttonVyhledat;
        private System.Windows.Forms.ToolStripTextBox otevrenoToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxKopirujVerze;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kopírovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zrušitToolStripMenuItem;
    }
}