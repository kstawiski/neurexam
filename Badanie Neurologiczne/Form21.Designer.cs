namespace Badanie_Neurologiczne
{
    partial class Form21
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wstawZdjeciegrafikęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ączemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wstawLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wstawTabelęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakoInnyPlikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlwysiwyg1 = new HTMLWYSIWYG.htmlwysiwyg();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.button1.Location = new System.Drawing.Point(560, 528);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Zapisz";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.LavenderBlush;
            this.button2.Location = new System.Drawing.Point(476, 528);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(1, 1);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(658, 22);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wstawZdjeciegrafikęToolStripMenuItem,
            this.ączemToolStripMenuItem,
            this.wstawLinkToolStripMenuItem,
            this.wstawTabelęToolStripMenuItem,
            this.zapiszJakoInnyPlikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1, 496);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(657, 27);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wstawZdjeciegrafikęToolStripMenuItem
            // 
            this.wstawZdjeciegrafikęToolStripMenuItem.Name = "wstawZdjeciegrafikęToolStripMenuItem";
            this.wstawZdjeciegrafikęToolStripMenuItem.Size = new System.Drawing.Size(147, 23);
            this.wstawZdjeciegrafikęToolStripMenuItem.Text = "Wstaw zdjecie/grafikę";
            // 
            // ączemToolStripMenuItem
            // 
            this.ączemToolStripMenuItem.Name = "ączemToolStripMenuItem";
            this.ączemToolStripMenuItem.Size = new System.Drawing.Size(166, 23);
            this.ączemToolStripMenuItem.Text = "Wstaw plik z hiperłączem";
            // 
            // wstawLinkToolStripMenuItem
            // 
            this.wstawLinkToolStripMenuItem.Name = "wstawLinkToolStripMenuItem";
            this.wstawLinkToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.wstawLinkToolStripMenuItem.Text = "Wstaw link";
            // 
            // wstawTabelęToolStripMenuItem
            // 
            this.wstawTabelęToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripTextBox2,
            this.dodajToolStripMenuItem});
            this.wstawTabelęToolStripMenuItem.Name = "wstawTabelęToolStripMenuItem";
            this.wstawTabelęToolStripMenuItem.Size = new System.Drawing.Size(98, 23);
            this.wstawTabelęToolStripMenuItem.Text = "Wstaw tabelę";
            this.wstawTabelęToolStripMenuItem.Click += new System.EventHandler(this.wstawTabelęToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.dodajToolStripMenuItem.Text = "Dodaj";
            this.dodajToolStripMenuItem.Click += new System.EventHandler(this.dodajToolStripMenuItem_Click);
            // 
            // zapiszJakoInnyPlikToolStripMenuItem
            // 
            this.zapiszJakoInnyPlikToolStripMenuItem.Name = "zapiszJakoInnyPlikToolStripMenuItem";
            this.zapiszJakoInnyPlikToolStripMenuItem.Size = new System.Drawing.Size(136, 23);
            this.zapiszJakoInnyPlikToolStripMenuItem.Text = "Zapisz jako inny plik";
            this.zapiszJakoInnyPlikToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakoInnyPlikToolStripMenuItem_Click);
            // 
            // htmlwysiwyg1
            // 
            this.htmlwysiwyg1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.htmlwysiwyg1.Location = new System.Drawing.Point(1, 23);
            this.htmlwysiwyg1.Margin = new System.Windows.Forms.Padding(0);
            this.htmlwysiwyg1.Name = "htmlwysiwyg1";
            this.htmlwysiwyg1.ShowAlignCenterButton = true;
            this.htmlwysiwyg1.ShowAlignLeftButton = true;
            this.htmlwysiwyg1.ShowAlignRightButton = true;
            this.htmlwysiwyg1.ShowBackColorButton = true;
            this.htmlwysiwyg1.ShowBolButton = true;
            this.htmlwysiwyg1.ShowBulletButton = true;
            this.htmlwysiwyg1.ShowCopyButton = true;
            this.htmlwysiwyg1.ShowCutButton = true;
            this.htmlwysiwyg1.ShowFontFamilyButton = true;
            this.htmlwysiwyg1.ShowFontSizeButton = true;
            this.htmlwysiwyg1.ShowIndentButton = true;
            this.htmlwysiwyg1.ShowItalicButton = true;
            this.htmlwysiwyg1.ShowJustifyButton = true;
            this.htmlwysiwyg1.ShowLinkButton = true;
            this.htmlwysiwyg1.ShowNewButton = false;
            this.htmlwysiwyg1.ShowOrderedListButton = true;
            this.htmlwysiwyg1.ShowOutdentButton = true;
            this.htmlwysiwyg1.ShowPasteButton = true;
            this.htmlwysiwyg1.ShowPrintButton = true;
            this.htmlwysiwyg1.ShowTxtBGButton = true;
            this.htmlwysiwyg1.ShowTxtColorButton = true;
            this.htmlwysiwyg1.ShowUnderlineButton = true;
            this.htmlwysiwyg1.ShowUnlinkButton = true;
            this.htmlwysiwyg1.Size = new System.Drawing.Size(658, 500);
            this.htmlwysiwyg1.TabIndex = 0;
            // 
            // Form21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(660, 563);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.htmlwysiwyg1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form21";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edytor";
            this.Load += new System.EventHandler(this.Form21_Load);
            this.Shown += new System.EventHandler(this.Form21_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public HTMLWYSIWYG.htmlwysiwyg htmlwysiwyg1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wstawZdjeciegrafikęToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ączemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wstawLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wstawTabelęToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakoInnyPlikToolStripMenuItem;

    }
}