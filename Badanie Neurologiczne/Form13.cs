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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent(); 
        }
        bool kliknieto = false;
        private void Form13_Load(object sender, EventArgs e)
        {
            kliknieto = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (kliknieto == false) { kliknieto = true; textBox2.Text = ""; textBox2.Focus(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
