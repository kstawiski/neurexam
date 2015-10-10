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
    public partial class WybierzEdycje : Form
    {
        public WybierzEdycje()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "") { DialogResult = DialogResult.OK; } else { MessageBox.Show("Nic nie zostało wybrane!"); }
        }
    }
}
