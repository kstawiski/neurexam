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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

      

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { radioButton2.Checked = false; radioButton3.Checked = false; }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { radioButton1.Checked = false; radioButton3.Checked = false; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) { radioButton2.Checked = false; radioButton1.Checked = false; }
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text!="")
            {
                DialogResult = DialogResult.OK;
            }
            else { MessageBox.Show("Uzupełnij!"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form19 f = new Form19();
            if (radioButton1.Checked == true || radioButton2.Checked == true)
            {
                if (radioButton2.Checked == true) { f.comboBox1.Text = "Rozpoznania (ICD-10)"; if (f.ShowDialog() == DialogResult.OK) { textBox1.Text = f.wynik; } }
                if (radioButton1.Checked == true) { f.comboBox1.Text = "Procedury (ICD-9)"; if (f.ShowDialog() == DialogResult.OK) { textBox1.Text = f.wynik; } }
            }
            else { f.comboBox1.Text = "Wszystko"; if (f.ShowDialog() == DialogResult.OK) { textBox1.Text = f.wynik; } }
        }
    }
}
