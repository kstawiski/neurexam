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
    public partial class elearning : Form
    {
        public elearning()
        {
            InitializeComponent();
        }

        private void elearning_Load(object sender, EventArgs e)
        {
            //Uri u = new Uri("file://" + Application.StartupPath + "\\e-learn\\index.html");
            //webBrowser1.Url = u;
        }

        private void elearning_Shown(object sender, EventArgs e)
        {
            Uri u = new Uri(Uri.EscapeUriString("file://" + Application.StartupPath + "\\e-learn\\bad_neuro.swf"));
            webBrowser1.Url = u;
        }
    }
}
