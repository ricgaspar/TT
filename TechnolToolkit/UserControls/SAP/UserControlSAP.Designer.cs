﻿namespace TechnolToolkit
{
    partial class UserControlSAP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelVnejsi = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHorniVnitrni = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPCname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxZarizeni = new System.Windows.Forms.CheckBox();
            this.buttonVyhledat = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kopírovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zrušitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanelVnejsi.SuspendLayout();
            this.tableLayoutPanelHorniVnitrni.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelVnejsi
            // 
            this.tableLayoutPanelVnejsi.ColumnCount = 1;
            this.tableLayoutPanelVnejsi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.Controls.Add(this.tableLayoutPanelHorniVnitrni, 0, 1);
            this.tableLayoutPanelVnejsi.Controls.Add(this.listView1, 0, 2);
            this.tableLayoutPanelVnejsi.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanelVnejsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelVnejsi.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelVnejsi.Name = "tableLayoutPanelVnejsi";
            this.tableLayoutPanelVnejsi.RowCount = 3;
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelVnejsi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelVnejsi.Size = new System.Drawing.Size(981, 670);
            this.tableLayoutPanelVnejsi.TabIndex = 0;
            // 
            // tableLayoutPanelHorniVnitrni
            // 
            this.tableLayoutPanelHorniVnitrni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tableLayoutPanelHorniVnitrni.ColumnCount = 4;
            this.tableLayoutPanelHorniVnitrni.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanelHorniVnitrni.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 242F));
            this.tableLayoutPanelHorniVnitrni.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanelHorniVnitrni.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHorniVnitrni.Controls.Add(this.textBoxPCname, 1, 0);
            this.tableLayoutPanelHorniVnitrni.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelHorniVnitrni.Controls.Add(this.checkBoxZarizeni, 3, 0);
            this.tableLayoutPanelHorniVnitrni.Controls.Add(this.buttonVyhledat, 2, 0);
            this.tableLayoutPanelHorniVnitrni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHorniVnitrni.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanelHorniVnitrni.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelHorniVnitrni.Name = "tableLayoutPanelHorniVnitrni";
            this.tableLayoutPanelHorniVnitrni.RowCount = 1;
            this.tableLayoutPanelHorniVnitrni.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHorniVnitrni.Size = new System.Drawing.Size(981, 40);
            this.tableLayoutPanelHorniVnitrni.TabIndex = 0;
            // 
            // textBoxPCname
            // 
            this.textBoxPCname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textBoxPCname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPCname.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPCname.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textBoxPCname.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxPCname.Location = new System.Drawing.Point(95, 7);
            this.textBoxPCname.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.textBoxPCname.Name = "textBoxPCname";
            this.textBoxPCname.Size = new System.Drawing.Size(236, 28);
            this.textBoxPCname.TabIndex = 1;
            this.textBoxPCname.TextChanged += new System.EventHandler(this.textBoxPCname_TextChanged);
            this.textBoxPCname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPCname_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(18, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zařízení";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxZarizeni
            // 
            this.checkBoxZarizeni.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZarizeni.AutoSize = true;
            this.checkBoxZarizeni.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxZarizeni.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxZarizeni.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxZarizeni.Location = new System.Drawing.Point(465, 9);
            this.checkBoxZarizeni.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxZarizeni.Name = "checkBoxZarizeni";
            this.checkBoxZarizeni.Size = new System.Drawing.Size(187, 21);
            this.checkBoxZarizeni.TabIndex = 3;
            this.checkBoxZarizeni.Text = "Kopírovat jméno zařízení";
            this.checkBoxZarizeni.UseVisualStyleBackColor = false;
            // 
            // buttonVyhledat
            // 
            this.buttonVyhledat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonVyhledat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.buttonVyhledat.Enabled = false;
            this.buttonVyhledat.FlatAppearance.BorderSize = 0;
            this.buttonVyhledat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVyhledat.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonVyhledat.ForeColor = System.Drawing.Color.White;
            this.buttonVyhledat.Location = new System.Drawing.Point(337, 6);
            this.buttonVyhledat.Name = "buttonVyhledat";
            this.buttonVyhledat.Size = new System.Drawing.Size(114, 28);
            this.buttonVyhledat.TabIndex = 2;
            this.buttonVyhledat.Text = "Vyhledat";
            this.buttonVyhledat.UseVisualStyleBackColor = false;
            this.buttonVyhledat.Click += new System.EventHandler(this.buttonVyhledat_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.ForeColor = System.Drawing.Color.LightGray;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 70);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(981, 600);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zobrazení evidovaného softwaru";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlSAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanelVnejsi);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlSAP";
            this.Size = new System.Drawing.Size(981, 670);
            this.tableLayoutPanelVnejsi.ResumeLayout(false);
            this.tableLayoutPanelVnejsi.PerformLayout();
            this.tableLayoutPanelHorniVnitrni.ResumeLayout(false);
            this.tableLayoutPanelHorniVnitrni.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVnejsi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHorniVnitrni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPCname;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox checkBoxZarizeni;
        private System.Windows.Forms.Button buttonVyhledat;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kopírovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zrušitToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}
