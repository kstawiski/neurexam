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
    public partial class Form27 : Form
    {
        public Form27()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form19 f = new Form19();
            f.comboBox1.Text = "Procedury (ICD-9)"; if (f.ShowDialog() == DialogResult.OK) { textBox2.Text += " \n" + f.wynik; } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
                Form19 f = new Form19();
            f.comboBox1.Text = "Rozpoznania (ICD-10)"; if (f.ShowDialog() == DialogResult.OK) { textBox1.Text += " \n" + f.wynik; } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
