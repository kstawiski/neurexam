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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { checkBox2.Visible = true; } else { checkBox2.Visible = false; checkBox2.Checked = false; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        bool adnotacje = false;
        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (adnotacje == false)
            {
                textBox4.Text = "";
                adnotacje = true;
                textBox4.Focus();




            }
        }
        
        
    }
}
