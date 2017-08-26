namespace TechnolToolkit
{
    partial class UserControlSCCM
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonKolekce = new System.Windows.Forms.Button();
            this.buttonZasadyPC = new System.Windows.Forms.Button();
            this.buttonAkceVsechny = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonKolekce);
            this.flowLayoutPanel1.Controls.Add(this.buttonZasadyPC);
            this.flowLayoutPanel1.Controls.Add(this.buttonAkceVsechny);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(951, 541);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonKolekce
            // 
            this.buttonKolekce.BackColor = System.Drawing.Color.Silver;
            this.buttonKolekce.FlatAppearance.BorderSize = 0;
            this.buttonKolekce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKolekce.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonKolekce.ForeColor = System.Drawing.Color.Black;
            this.buttonKolekce.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKolekce.Location = new System.Drawing.Point(6, 6);
            this.buttonKolekce.Margin = new System.Windows.Forms.Padding(6);
            this.buttonKolekce.Name = "buttonKolekce";
            this.buttonKolekce.Size = new System.Drawing.Size(305, 121);
            this.buttonKolekce.TabIndex = 1;
            this.buttonKolekce.Text = "Přidání/Odebrání zařízení do kolekce";
            this.buttonKolekce.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonKolekce.UseVisualStyleBackColor = false;
            this.buttonKolekce.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonKolekce_Paint);
            // 
            // buttonZasadyPC
            // 
            this.buttonZasadyPC.BackColor = System.Drawing.Color.Silver;
            this.buttonZasadyPC.FlatAppearance.BorderSize = 0;
            this.buttonZasadyPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZasadyPC.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZasadyPC.ForeColor = System.Drawing.Color.Black;
            this.buttonZasadyPC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonZasadyPC.Location = new System.Drawing.Point(323, 6);
            this.buttonZasadyPC.Margin = new System.Windows.Forms.Padding(6);
            this.buttonZasadyPC.Name = "buttonZasadyPC";
            this.buttonZasadyPC.Size = new System.Drawing.Size(305, 121);
            this.buttonZasadyPC.TabIndex = 2;
            this.buttonZasadyPC.Text = "Aktualizace zásad počítače";
            this.buttonZasadyPC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonZasadyPC.UseVisualStyleBackColor = false;
            this.buttonZasadyPC.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonZasadyPC_Paint);
            // 
            // buttonAkceVsechny
            // 
            this.buttonAkceVsechny.BackColor = System.Drawing.Color.Silver;
            this.buttonAkceVsechny.FlatAppearance.BorderSize = 0;
            this.buttonAkceVsechny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAkceVsechny.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAkceVsechny.ForeColor = System.Drawing.Color.Black;
            this.buttonAkceVsechny.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAkceVsechny.Location = new System.Drawing.Point(640, 6);
            this.buttonAkceVsechny.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAkceVsechny.Name = "buttonAkceVsechny";
            this.buttonAkceVsechny.Size = new System.Drawing.Size(305, 121);
            this.buttonAkceVsechny.TabIndex = 3;
            this.buttonAkceVsechny.Text = "Aktualizace všech akcí počítače";
            this.buttonAkceVsechny.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAkceVsechny.UseVisualStyleBackColor = false;
            this.buttonAkceVsechny.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonAkceVsechny_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 571);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(951, 30);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(859, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nástroje pro usnadnění práce s SCCM a jeho administrace";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlSCCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlSCCM";
            this.Size = new System.Drawing.Size(951, 571);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonKolekce;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonZasadyPC;
        private System.Windows.Forms.Button buttonAkceVsechny;
    }
}
