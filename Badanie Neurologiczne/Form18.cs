using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Badanie_Neurologiczne
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }
        //bool _bFullScreenMode;
        private void Form18_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(
    this.ClientSize.Width / 2 - panel1.Size.Width / 2,
    this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }

        private void Form18_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
    this.ClientSize.Width / 2 - panel1.Size.Width / 2,
    this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            if (label1.Image != null)
            {
                if (label1.Image.Width > 800 || label1.Image.Height > 561)
                {
                    e.Graphics.DrawImage(label1.Image, 0, 0, label1.Width, label1.Height);



                    SizeF textSize = e.Graphics.MeasureString(label1.Text, label1.Font);



                    e.Graphics.DrawString(label1.Text, label1.Font, Brushes.White,

                        (label1.Width - textSize.Width) / 2,

                        (label1.Height - textSize.Height) / 2);
                }
            }
        }
    }
}
