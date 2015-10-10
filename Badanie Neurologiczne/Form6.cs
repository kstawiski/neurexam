using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Badanie_Neurologiczne
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt")) { File.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt"); };
            // create a writer and open the file
            TextWriter tw = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt");
            tw.WriteLine(comboBox1.Text + " " + textBox2.Text + " " + textBox3.Text);
            tw.WriteLine(textBox4.Text);
            tw.WriteLine(textBox5.Text);
            tw.WriteLine(textBox6.Text);
            tw.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
