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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        //bool _bFullScreenMode;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Źródło: Folstein et al. J. Psych Res 12: 196-198; 1975 oraz Wills A. How to perform a neurological examination. Symptoms and Signs, Medicine 40:8; 2012");
        }
        //public int wynik = 30;
        public int wynik = 30;
        public void jakiwynik() {
            wynik = 0;
            if (checkBox1.Checked == true) { wynik++; }
            if (checkBox2.Checked == true) { wynik++; }
            if (checkBox3.Checked == true) { wynik++; }
            if (checkBox4.Checked == true) { wynik++; }
            if (checkBox5.Checked == true) { wynik++; }
            if (checkBox6.Checked == true) { wynik++; }
            if (checkBox7.Checked == true) { wynik++; }
            if (checkBox8.Checked == true) { wynik++; }
            if (checkBox9.Checked == true) { wynik++; }
            if (checkBox10.Checked == true) { wynik++; }
            if (checkBox11.Checked == true) { wynik++; }
            if (checkBox12.Checked == true) { wynik++; }
            if (checkBox13.Checked == true) { wynik++; }
            if (checkBox14.Checked == true) { wynik++; }
            if (checkBox15.Checked == true) { wynik++; }
            if (checkBox16.Checked == true) { wynik++; }
            if (checkBox17.Checked == true) { wynik++; }
            if (checkBox18.Checked == true) { wynik++; }
            if (checkBox19.Checked == true) { wynik++; }
            if (checkBox20.Checked == true) { wynik++; }
            if (checkBox21.Checked == true) { wynik++; }
            if (checkBox22.Checked == true) { wynik++; }
            if (checkBox23.Checked == true) { wynik++; }
            if (checkBox24.Checked == true) { wynik++; }
            if (checkBox25.Checked == true) { wynik++; }
            if (checkBox26.Checked == true) { wynik++; }
            if (checkBox27.Checked == true) { wynik++; }
            if (checkBox28.Checked == true) { wynik++; }
            if (checkBox29.Checked == true) { wynik++; }
            if (checkBox30.Checked == true) { wynik++; }
            label8.Text = "Wynik: " + wynik + " pkt.";
            if (wynik < 25) { label9.Visible = true; pictureBox1.Visible = true; } else { label9.Visible = false ; pictureBox1.Visible = false ; }
        
        
        
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Weź do ręki tę kartkę papieru, złóż ją na pół i połóż na stole.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form18 f = new Form18();
            Image image1 = Image.FromFile("white-star-md.png");
            f.label1.Image = image1;
            f.label1.Text = "";






            f.Show();
            //_bFullScreenMode = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form18 f = new Form18();
            f.label1.Text = textBox1.Text;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Obrazki|*.jpg;*.gif;*.bmp;*.png;*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form18 f = new Form18();
                Image image1 = Image.FromFile(openFileDialog1.FileName );
                f.label1.Image = image1;
                f.label1.Text = "";






                f.Show();




            }
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            jakiwynik();
        }
    }
}
