﻿namespace TechnolToolkit
{
    partial class statusBox
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.processingControl1 = new AltoControls.ProcessingControl();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.labelRunningForAmmountOfTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.processingControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRestart, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelRunningForAmmountOfTime, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(230, 235);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(3, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "V případě příliš dlouhého načítání můžete restartovat celou aplikaci";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Probíhá načítání";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // processingControl1
            // 
            this.processingControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.processingControl1.BackColor = System.Drawing.Color.Transparent;
            this.processingControl1.IndexColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.processingControl1.Interval = 100;
            this.processingControl1.Location = new System.Drawing.Point(72, 46);
            this.processingControl1.Name = "processingControl1";
            this.processingControl1.NCircle = 9;
            this.processingControl1.Others = System.Drawing.Color.DimGray;
            this.processingControl1.Radius = 10;
            this.processingControl1.Size = new System.Drawing.Size(85, 85);
            this.processingControl1.Spin = true;
            this.processingControl1.TabIndex = 3;
            this.processingControl1.Text = "processingControl1";
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.buttonRestart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRestart.FlatAppearance.BorderSize = 0;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRestart.ForeColor = System.Drawing.Color.White;
            this.buttonRestart.Location = new System.Drawing.Point(0, 205);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(230, 30);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Restartovat";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // labelRunningForAmmountOfTime
            // 
            this.labelRunningForAmmountOfTime.AutoSize = true;
            this.labelRunningForAmmountOfTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRunningForAmmountOfTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRunningForAmmountOfTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.labelRunningForAmmountOfTime.Location = new System.Drawing.Point(3, 138);
            this.labelRunningForAmmountOfTime.Name = "labelRunningForAmmountOfTime";
            this.labelRunningForAmmountOfTime.Size = new System.Drawing.Size(224, 29);
            this.labelRunningForAmmountOfTime.TabIndex = 4;
            this.labelRunningForAmmountOfTime.Text = "Běží již 0 sekund";
            this.labelRunningForAmmountOfTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(232, 237);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "statusBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "statusBox";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.statusBox_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private AltoControls.ProcessingControl processingControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label labelRunningForAmmountOfTime;
    }
}