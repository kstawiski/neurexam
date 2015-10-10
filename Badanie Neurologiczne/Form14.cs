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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent(); timer1.Enabled = true;
        }
        bool podrozeniedotyczy = true;
        bool adnotacjedodatkowe = false;
        bool istotnehobby = false;
        bool stresinne = false;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedText == "nie dotyczy") { textBox1.Text = "-"; textBox1.ReadOnly = true; } else { textBox1.ReadOnly = false; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false) { textBox2.Text = ""; textBox2.ReadOnly = false; textBox2.Focus(); } else { textBox2.Text = "brak informacji"; textBox2.ReadOnly = true; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (podrozeniedotyczy == true) { textBox5.Text = ""; podrozeniedotyczy = false; textBox5.Focus(); }
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            if (adnotacjedodatkowe == false) { textBox10.Text = ""; adnotacjedodatkowe = true; textBox10.Focus(); }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (istotnehobby == false) { textBox4.Text = ""; istotnehobby = true; textBox4.Focus(); }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (stresinne == false) { textBox6.Text = ""; stresinne = true; textBox6.Focus(); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            if (checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || textBox6.Text != "inne") { textBox7.ReadOnly = false; } else { textBox7.ReadOnly = true; textBox7.Text = "opis"; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { textBox8.Visible = true; } else { textBox8.Visible = false; textBox8.Text = ""; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true) { numericUpDown1.Visible = true; numericUpDown2.Visible = true; label8.Visible = true; label9.Visible = true; } else { numericUpDown1.Visible = false; numericUpDown2.Visible = false; label8.Visible = false; label9.Visible = false; }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true) { numericUpDown3.Visible = true; numericUpDown4.Visible = true; label10.Visible = true; label11.Visible = true; button23.Visible = true; } else { numericUpDown3.Visible = false; numericUpDown4.Visible = false; label10.Visible = false; label11.Visible = false; button23.Visible = false; }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == false) { textBox9.Visible = true; } else { textBox9.Visible = false; textBox9.Text = ""; }
        }
        public string ocenaalkoholizmu; public bool oceninoalk = false;
        private void button23_Click(object sender, EventArgs e)
        {
            Form15 f = new Form15();
            if (f.ShowDialog() == DialogResult.OK) {
                numericUpDown3.Value = f.jednostek;
                numericUpDown4.Value = f.jednostekdziennie;
                ocenaalkoholizmu = f.label7.Text; oceninoalk = true;
            
            
            
            
            
            
            }
        }
        
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            //if (zmienionoalkohol == false) { numericUpDown4.Value = numericUpDown3.Value / 7; zmienionoalkohol = true; }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            //if (zmienionoalkohol == false) { numericUpDown3.Value = numericUpDown4.Value * 7; }
        }

        private void numericUpDown3_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown4.Value = numericUpDown3.Value / 7;  
        }

        private void numericUpDown4_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown3.Value = numericUpDown4.Value * 7;
        }
        public decimal paczkolata;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            paczkolata = numericUpDown1.Value * numericUpDown2.Value;
            Decimal.Round(paczkolata,2);
            label9.Text = "lat (" + Decimal.Round(paczkolata, 2) + " paczkolat)";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            paczkolata = numericUpDown1.Value * numericUpDown2.Value;
            Decimal.Round(paczkolata, 2);
            label9.Text = "lat (" + Decimal.Round(paczkolata,2) + " paczkolat)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
