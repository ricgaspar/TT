namespace TechnolToolkit
{
    partial class InfoPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoPC));
            this.tableLayoutPanelVnejsi = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHorni = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelHorniVnoreny = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxLocalPC = new System.Windows.Forms.CheckBox();
            this.textBoxPCName = new System.Windows.Forms.TextBox();
            this.buttonVyhledat = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelVnejsi.SuspendLayout();
            this.tableLayoutPanelHorni.SuspendLayout();
            this.tableLayoutPanelHorniVnoreny.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanelVnejsi.Size = new System.Drawing.Size(950, 581);
            this.tableLayoutPanelVnejsi.TabIndex = 4;
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
            this.label1.Size = new System.Drawing.Size(456, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informace o PC  [zatim vypisovani do konzole]";
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
            this.tableLayoutPanelHorniVnoreny.Controls.Add(this.textBoxPCName, 1, 1);
            this.tableLayoutPanelHorniVnoreny.Controls.Add(this.buttonVyhledat, 2, 1);
            this.tableLayoutPanelHorniVnoreny.Controls.Add(this.comboBox1, 3, 1);
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
            this.checkBoxLocalPC.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxLocalPC.ForeColor = System.Drawing.Color.Black;
            this.checkBoxLocalPC.Location = new System.Drawing.Point(57, 18);
            this.checkBoxLocalPC.Margin = new System.Windows.Forms.Padding(3, 18, 3, 3);
            this.checkBoxLocalPC.Name = "checkBoxLocalPC";
            this.checkBoxLocalPC.Size = new System.Drawing.Size(75, 17);
            this.checkBoxLocalPC.TabIndex = 1;
            this.checkBoxLocalPC.Text = "Localhost";
            this.checkBoxLocalPC.UseVisualStyleBackColor = true;
            this.checkBoxLocalPC.CheckedChanged += new System.EventHandler(this.checkBoxLocalPC_CheckedChanged);
            // 
            // textBoxPCName
            // 
            this.textBoxPCName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxPCName.Enabled = false;
            this.textBoxPCName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPCName.ForeColor = System.Drawing.Color.Black;
            this.textBoxPCName.Location = new System.Drawing.Point(138, 13);
            this.textBoxPCName.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.textBoxPCName.Name = "textBoxPCName";
            this.textBoxPCName.Size = new System.Drawing.Size(193, 25);
            this.textBoxPCName.TabIndex = 2;
            this.textBoxPCName.TextChanged += new System.EventHandler(this.textBoxPCName_TextChanged);
            // 
            // buttonVyhledat
            // 
            this.buttonVyhledat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonVyhledat.ForeColor = System.Drawing.Color.Black;
            this.buttonVyhledat.Location = new System.Drawing.Point(337, 13);
            this.buttonVyhledat.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.buttonVyhledat.Name = "buttonVyhledat";
            this.buttonVyhledat.Size = new System.Drawing.Size(80, 25);
            this.buttonVyhledat.TabIndex = 3;
            this.buttonVyhledat.Text = "Vyhledat";
            this.buttonVyhledat.UseVisualStyleBackColor = false;
            this.buttonVyhledat.Click += new System.EventHandler(this.buttonVyhledat_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.Location = new System.Drawing.Point(3, 81);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(944, 497);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "logo.png");
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Details",
            "LargeIcon",
            "SmallIcon",
            "List",
            "Title"});
            this.comboBox1.Location = new System.Drawing.Point(423, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // InfoPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(950, 581);
            this.Controls.Add(this.tableLayoutPanelVnejsi);
            this.Name = "InfoPC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InfoPC";
            this.Load += new System.EventHandler(this.InfoPC_Load);
            this.tableLayoutPanelVnejsi.ResumeLayout(false);
            this.tableLayoutPanelHorni.ResumeLayout(false);
            this.tableLayoutPanelHorni.PerformLayout();
            this.tableLayoutPanelHorniVnoreny.ResumeLayout(false);
            this.tableLayoutPanelHorniVnoreny.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelVnejsi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHorni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHorniVnoreny;
        private System.Windows.Forms.CheckBox checkBoxLocalPC;
        private System.Windows.Forms.TextBox textBoxPCName;
        private System.Windows.Forms.Button buttonVyhledat;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}