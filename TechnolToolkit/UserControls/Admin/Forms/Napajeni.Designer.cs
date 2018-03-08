namespace TechnolToolkit
{
    partial class Napajeni
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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonActionTimeNow = new System.Windows.Forms.RadioButton();
            this.radioButtonActionTimeLater = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelUpozorneni = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonNoAction = new System.Windows.Forms.RadioButton();
            this.radioButtonStopAction = new System.Windows.Forms.RadioButton();
            this.radioButtonRestartAction = new System.Windows.Forms.RadioButton();
            this.radioButtonPowerOffAction = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAction = new System.Windows.Forms.Button();
            this.textBoxComputername = new System.Windows.Forms.TextBox();
            this.buttonMultiplePCs = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(213, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Napájení počítače";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxComment, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonMultiplePCs, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 295);
            this.tableLayoutPanel1.TabIndex = 5;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // textBoxComment
            // 
            this.textBoxComment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxComment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxComment.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxComment.Location = new System.Drawing.Point(6, 185);
            this.textBoxComment.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(398, 20);
            this.textBoxComment.TabIndex = 5;
            this.textBoxComment.Text = "Komentář k prováděné akci (nepovinné)";
            this.textBoxComment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxComment_MouseClick);
            this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
            this.textBoxComment.Enter += new System.EventHandler(this.textBoxComment_Enter);
            this.textBoxComment.Leave += new System.EventHandler(this.textBoxComment_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(404, 135);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(166, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 132);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kdy se akce provede";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.labelUpozorneni, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.42857F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.57143F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(229, 110);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.radioButtonActionTimeNow, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.radioButtonActionTimeLater, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(229, 31);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // radioButtonActionTimeNow
            // 
            this.radioButtonActionTimeNow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonActionTimeNow.AutoSize = true;
            this.radioButtonActionTimeNow.Checked = true;
            this.radioButtonActionTimeNow.ForeColor = System.Drawing.Color.White;
            this.radioButtonActionTimeNow.Location = new System.Drawing.Point(10, 5);
            this.radioButtonActionTimeNow.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.radioButtonActionTimeNow.Name = "radioButtonActionTimeNow";
            this.radioButtonActionTimeNow.Size = new System.Drawing.Size(62, 21);
            this.radioButtonActionTimeNow.TabIndex = 0;
            this.radioButtonActionTimeNow.TabStop = true;
            this.radioButtonActionTimeNow.Text = "Ihned";
            this.radioButtonActionTimeNow.UseVisualStyleBackColor = true;
            // 
            // radioButtonActionTimeLater
            // 
            this.radioButtonActionTimeLater.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonActionTimeLater.AutoSize = true;
            this.radioButtonActionTimeLater.ForeColor = System.Drawing.Color.White;
            this.radioButtonActionTimeLater.Location = new System.Drawing.Point(117, 5);
            this.radioButtonActionTimeLater.Name = "radioButtonActionTimeLater";
            this.radioButtonActionTimeLater.Size = new System.Drawing.Size(72, 21);
            this.radioButtonActionTimeLater.TabIndex = 0;
            this.radioButtonActionTimeLater.Text = "Později";
            this.radioButtonActionTimeLater.UseVisualStyleBackColor = true;
            this.radioButtonActionTimeLater.CheckedChanged += new System.EventHandler(this.radioButtonActionTimeLater_CheckedChanged);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel9.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.54054F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(229, 32);
            this.tableLayoutPanel9.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Za";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "min";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(40, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(144, 23);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelUpozorneni
            // 
            this.labelUpozorneni.AutoSize = true;
            this.labelUpozorneni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUpozorneni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUpozorneni.ForeColor = System.Drawing.Color.Red;
            this.labelUpozorneni.Location = new System.Drawing.Point(3, 63);
            this.labelUpozorneni.Name = "labelUpozorneni";
            this.labelUpozorneni.Size = new System.Drawing.Size(223, 47);
            this.labelUpozorneni.TabIndex = 9;
            this.labelUpozorneni.Text = "Na vzdáleném počítači bude zobrazeno upozornění o naplánované akci!";
            this.labelUpozorneni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUpozorneni.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(157, 132);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Výběr akce";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.34875F));
            this.tableLayoutPanel3.Controls.Add(this.radioButtonNoAction, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonStopAction, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonRestartAction, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonPowerOffAction, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(151, 113);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // radioButtonNoAction
            // 
            this.radioButtonNoAction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonNoAction.AutoSize = true;
            this.radioButtonNoAction.Checked = true;
            this.radioButtonNoAction.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonNoAction.ForeColor = System.Drawing.Color.White;
            this.radioButtonNoAction.Location = new System.Drawing.Point(3, 3);
            this.radioButtonNoAction.Name = "radioButtonNoAction";
            this.radioButtonNoAction.Size = new System.Drawing.Size(103, 21);
            this.radioButtonNoAction.TabIndex = 0;
            this.radioButtonNoAction.TabStop = true;
            this.radioButtonNoAction.Text = "Žádná akce";
            this.radioButtonNoAction.UseVisualStyleBackColor = true;
            this.radioButtonNoAction.CheckedChanged += new System.EventHandler(this.radioButtonNoAction_CheckedChanged);
            // 
            // radioButtonStopAction
            // 
            this.radioButtonStopAction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonStopAction.AutoSize = true;
            this.radioButtonStopAction.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonStopAction.ForeColor = System.Drawing.Color.White;
            this.radioButtonStopAction.Location = new System.Drawing.Point(3, 88);
            this.radioButtonStopAction.Name = "radioButtonStopAction";
            this.radioButtonStopAction.Size = new System.Drawing.Size(113, 21);
            this.radioButtonStopAction.TabIndex = 0;
            this.radioButtonStopAction.Text = "Přerušení akcí";
            this.radioButtonStopAction.UseVisualStyleBackColor = true;
            this.radioButtonStopAction.CheckedChanged += new System.EventHandler(this.radioButtonSleepAction_CheckedChanged);
            // 
            // radioButtonRestartAction
            // 
            this.radioButtonRestartAction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonRestartAction.AutoSize = true;
            this.radioButtonRestartAction.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonRestartAction.ForeColor = System.Drawing.Color.White;
            this.radioButtonRestartAction.Location = new System.Drawing.Point(3, 31);
            this.radioButtonRestartAction.Name = "radioButtonRestartAction";
            this.radioButtonRestartAction.Size = new System.Drawing.Size(133, 21);
            this.radioButtonRestartAction.TabIndex = 0;
            this.radioButtonRestartAction.Text = "Restart počítače";
            this.radioButtonRestartAction.UseVisualStyleBackColor = true;
            this.radioButtonRestartAction.CheckedChanged += new System.EventHandler(this.radioButtonRestartAction_CheckedChanged);
            // 
            // radioButtonPowerOffAction
            // 
            this.radioButtonPowerOffAction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonPowerOffAction.AutoSize = true;
            this.radioButtonPowerOffAction.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonPowerOffAction.ForeColor = System.Drawing.Color.White;
            this.radioButtonPowerOffAction.Location = new System.Drawing.Point(3, 59);
            this.radioButtonPowerOffAction.Name = "radioButtonPowerOffAction";
            this.radioButtonPowerOffAction.Size = new System.Drawing.Size(137, 21);
            this.radioButtonPowerOffAction.TabIndex = 0;
            this.radioButtonPowerOffAction.Text = "Vypnutí počítače";
            this.radioButtonPowerOffAction.UseVisualStyleBackColor = true;
            this.radioButtonPowerOffAction.CheckedChanged += new System.EventHandler(this.radioButtonPowerOffAction_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel4.Controls.Add(this.buttonAction, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBoxComputername, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 215);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(410, 39);
            this.tableLayoutPanel4.TabIndex = 11;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // buttonAction
            // 
            this.buttonAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.buttonAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAction.Enabled = false;
            this.buttonAction.FlatAppearance.BorderSize = 0;
            this.buttonAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAction.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAction.ForeColor = System.Drawing.Color.White;
            this.buttonAction.Location = new System.Drawing.Point(275, 3);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(132, 33);
            this.buttonAction.TabIndex = 5;
            this.buttonAction.Text = "Spuštění akce";
            this.buttonAction.UseVisualStyleBackColor = false;
            this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
            // 
            // textBoxComputername
            // 
            this.textBoxComputername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxComputername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBoxComputername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxComputername.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxComputername.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxComputername.Location = new System.Drawing.Point(6, 9);
            this.textBoxComputername.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBoxComputername.Name = "textBoxComputername";
            this.textBoxComputername.Size = new System.Drawing.Size(260, 20);
            this.textBoxComputername.TabIndex = 5;
            this.textBoxComputername.Text = "Název počítače";
            this.textBoxComputername.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxComputername_MouseClick);
            this.textBoxComputername.TextChanged += new System.EventHandler(this.textBoxComputername_TextChanged);
            this.textBoxComputername.Enter += new System.EventHandler(this.textBoxComputername_Enter);
            this.textBoxComputername.Leave += new System.EventHandler(this.textBoxComputername_Leave);
            // 
            // buttonMultiplePCs
            // 
            this.buttonMultiplePCs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonMultiplePCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplePCs.FlatAppearance.BorderSize = 0;
            this.buttonMultiplePCs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMultiplePCs.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMultiplePCs.ForeColor = System.Drawing.Color.White;
            this.buttonMultiplePCs.Location = new System.Drawing.Point(100, 261);
            this.buttonMultiplePCs.Margin = new System.Windows.Forms.Padding(100, 7, 100, 7);
            this.buttonMultiplePCs.Name = "buttonMultiplePCs";
            this.buttonMultiplePCs.Size = new System.Drawing.Size(210, 27);
            this.buttonMultiplePCs.TabIndex = 7;
            this.buttonMultiplePCs.Text = "Hromadné spuštění";
            this.buttonMultiplePCs.UseVisualStyleBackColor = false;
            this.buttonMultiplePCs.Click += new System.EventHandler(this.buttonMultiplePCs_Click);
            // 
            // Napajeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(410, 295);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Napajeni";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Napájení počítače";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxComputername;
        private System.Windows.Forms.Button buttonMultiplePCs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.RadioButton radioButtonActionTimeNow;
        private System.Windows.Forms.RadioButton radioButtonActionTimeLater;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonAction;
        private System.Windows.Forms.Label labelUpozorneni;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton radioButtonNoAction;
        private System.Windows.Forms.RadioButton radioButtonStopAction;
        private System.Windows.Forms.RadioButton radioButtonRestartAction;
        private System.Windows.Forms.RadioButton radioButtonPowerOffAction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}