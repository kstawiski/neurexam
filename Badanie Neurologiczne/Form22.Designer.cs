﻿namespace Badanie_Neurologiczne
{
    partial class Form22
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button32 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 143);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klikaj to pole paralelnie z tętnem.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "tętno (bpm)";
            this.label2.Click += new System.EventHandler(this.wynik);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.numericUpDown1.Location = new System.Drawing.Point(149, 146);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 36);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.RoyalBlue;
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button32.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button32.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button32.Location = new System.Drawing.Point(417, 146);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(60, 27);
            this.button32.TabIndex = 61;
            this.button32.Text = "resetuj";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 62;
            this.label3.Text = "ocena";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(405, 29);
            this.textBox1.TabIndex = 63;
            this.textBox1.Text = "normokardia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 64;
            this.label4.Text = "cechy:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "twarde",
            "miękkie"});
            this.comboBox1.Location = new System.Drawing.Point(74, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 29);
            this.comboBox1.TabIndex = 65;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "miarowe",
            "niemiarowe"});
            this.comboBox2.Location = new System.Drawing.Point(287, 226);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(190, 29);
            this.comboBox2.TabIndex = 66;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "wysokie",
            "niskie"});
            this.comboBox3.Location = new System.Drawing.Point(328, 261);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(149, 29);
            this.comboBox3.TabIndex = 67;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "chybkie",
            "leniwe"});
            this.comboBox4.Location = new System.Drawing.Point(179, 261);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(143, 29);
            this.comboBox4.TabIndex = 68;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "symetryczne",
            "niesymetryczne"});
            this.comboBox5.Location = new System.Drawing.Point(16, 261);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(157, 29);
            this.comboBox5.TabIndex = 69;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(2, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(475, 31);
            this.button3.TabIndex = 70;
            this.button3.Text = "zakończ ocenę tętna";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(479, 329);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form22";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tętno";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form22_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.ComboBox comboBox4;
        public System.Windows.Forms.ComboBox comboBox5;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.TextBox textBox1;
    }
}