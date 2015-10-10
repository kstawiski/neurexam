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
    public partial class ParametrBadaniaDodatkowego : Form
    {
        public ParametrBadaniaDodatkowego()
        {
            InitializeComponent();
            //PRZYPOMNIJ
            foreach (Control c in this.Controls)
            {
                if (c is ComboBox )
                {
                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + c.Name;

                if (File.Exists(identyfikacja))
                {
                    string pre; StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                    string[] preuz = pre.Split('|');
                    ComboBox combo = c as ComboBox;
                    combo.Items.AddRange(preuz);
                }
                }

                if (c is TextBox)
                {

                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + c.Name;

                    if (File.Exists(identyfikacja))
                    {
                        string pre = ""; TextBox t = c as TextBox;
                        t.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                        t.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                        StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                        string[] preuz = pre.Split('|');
                        t.AutoCompleteCustomSource.AddRange(preuz);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {

                if (c is TextBox)
                {
                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + c.Name;
                    string pre = "";
                    if (File.Exists(identyfikacja))
                    {
                        StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                        string[] preuz = pre.Split('|');
                        bool juzjest = false;
                        foreach (string uz in preuz)
                        {
                            if (c.Text == uz) { juzjest = true; }
                        }
                        if (juzjest == false)
                        {
                            StreamWriter w = new StreamWriter(identyfikacja);
                            w.Write(pre + "|" + c.Text); w.Close();
                        }
                    }
                    else
                    {
                        StreamWriter w = new StreamWriter(identyfikacja);
                        w.Write(c.Text); w.Close();
                    }
                }
                if (c is ComboBox)
                {
                    if (c.Text != "pozytywny (+)" && c.Text != "negatywny (-)")
                    {
                        string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + c.Name;
                        string pre = "";
                        if (File.Exists(identyfikacja))
                        {
                            StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                            string[] preuz = pre.Split('|');
                            bool juzjest = false;
                            foreach (string uz in preuz)
                            {
                                if (c.Text == uz) { juzjest = true; }
                            }
                            if (juzjest == false)
                            {
                                StreamWriter w = new StreamWriter(identyfikacja);
                                w.Write(pre + "|" + c.Text); w.Close();
                            }
                        }
                        else
                        {
                            StreamWriter w = new StreamWriter(identyfikacja);
                            w.Write(c.Text); w.Close();
                        }
                    }
                }
            }
            DialogResult = DialogResult.OK;
        }
        private void sprawdztyp() {
            if (radioButton3.Checked) { textBox2.Visible = true; } else { textBox2.Visible = false; }
            if (radioButton2.Checked) { comboBox1.Visible = true; } else { comboBox1.Visible = false; }
            if (radioButton1.Checked) { numericUpDown1.Visible = true; label3.Visible = true; textBox3.Visible = true; } else { numericUpDown1.Visible = false ; label3.Visible = false ; textBox3.Visible = false ; }
            label4.Visible = true; button5.Enabled = true;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) { radioButton1.Checked = false; radioButton2.Checked = false; } sprawdztyp();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { radioButton1.Checked = false; radioButton3.Checked = false; } sprawdztyp();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { radioButton2.Checked = false; radioButton3.Checked = false; } sprawdztyp();
        }
    }
}
