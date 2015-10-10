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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_MouseClick(object sender, MouseEventArgs e)
        {

        }
        bool pierwszyklik = true;
        DateTime start;
        DateTime koniec;
        int kliknieć = 0;
        private void label1_Click(object sender, EventArgs e)
        {
            if (pierwszyklik == true)
            {
                start = DateTime.Now;
                pierwszyklik = false;
                kliknieć++;
            }
            else {
                koniec = DateTime.Now; kliknieć++;
                TimeSpan czas = koniec - start;
                //MessageBox.Show(Convert.ToString(czas.Milliseconds));
                decimal tetno = Math.Round(Convert.ToDecimal(60000*kliknieć)/((czas.Minutes*60*1000)+(czas.Seconds*1000)+czas.Milliseconds),0);
                numericUpDown1.Value = tetno;
                pierwszyklik = false;
            }
        }

        private void wynik(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.BackColor = System.Drawing.Color.RoyalBlue ;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Crimson ;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {
            pierwszyklik = true;
            kliknieć = 0;
            numericUpDown1.Value = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bool patologia = false;
            if (numericUpDown1.Value < 50) { textBox1.Text = "bradykardia"; patologia = true; }
            if (numericUpDown1.Value > 100) { textBox1.Text = "tachykardia"; patologia = true; }
            if (patologia == false) { textBox1.Text = "normokardia"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
