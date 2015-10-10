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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent(); 
        }
        
        private void Form19_Load(object sender, EventArgs e)
        {
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Wszystko")
            {
                if (textBox1.Text.Count() > 1)
                {
                    listBox1.Items.Clear();
                    string[] lines = File.ReadLines("ICD10.txt").ToArray();
                    foreach (string s in lines)
                    {
                        if (s.IndexOf(textBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) != -1) { listBox1.Items.Add(s); }
                    }
                    string[] lines2 = File.ReadLines("ICD9.txt").ToArray();
                    foreach (string s in lines2)
                    {
                        if (s.IndexOf(textBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) != -1) { listBox1.Items.Add(s); }
                    }



                }
                else
                {
                    if (wyszukiwanie == true)
                    {
                        if (textBox1.Text.Count() == 0)
                        {
                            listBox1.Items.Clear();
                            string[] lines = File.ReadLines("ICD10.txt").ToArray();
                            foreach (string s in lines)
                            {
                                listBox1.Items.Add(s);
                            }
                            string[] lines2 = File.ReadLines("ICD9.txt").ToArray();
                            foreach (string s in lines2)
                            {
                                if (s.IndexOf(textBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) != -1) { listBox1.Items.Add(s); }
                            }
                        }
                    }
                }

            }
            if (comboBox1.Text == "Procedury (ICD-9)")
            {
                if (textBox1.Text.Count() > 1)
                {
                    listBox1.Items.Clear();
                    
                    string[] lines2 = File.ReadLines("ICD9.txt").ToArray();
                    foreach (string s in lines2)
                    {
                        if (s.IndexOf(textBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) != -1) { listBox1.Items.Add(s); }
                    }



                }
                else
                {
                    if (wyszukiwanie == true)
                    {
                        if (textBox1.Text.Count() == 0)
                        {
                            listBox1.Items.Clear();
                            
                            string[] lines2 = File.ReadLines("ICD9.txt").ToArray();
                            foreach (string s in lines2)
                            {
                                if (s.IndexOf(textBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) != -1) { listBox1.Items.Add(s); }
                            }
                        }
                    }
                }}
                if (comboBox1.Text == "Rozpoznania (ICD-10)")
                {
                    if (textBox1.Text.Count() > 1)
                    {
                        listBox1.Items.Clear();
                        string[] lines = File.ReadLines("ICD10.txt").ToArray();
                        foreach (string s in lines)
                        {
                            if (s.IndexOf(textBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) != -1) { listBox1.Items.Add(s); }
                        }
                        



                    }
                    else
                    {
                        if (wyszukiwanie == true)
                        {
                            if (textBox1.Text.Count() == 0)
                            {
                                listBox1.Items.Clear();
                                string[] lines = File.ReadLines("ICD10.txt").ToArray();
                                foreach (string s in lines)
                                {
                                    listBox1.Items.Add(s);
                                }
                                
                            }
                        }
                    

                }

            }
        }
        bool wyszukiwanie = false;
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (wyszukiwanie == false) { textBox1.Text = ""; wyszukiwanie = true; textBox1.Focus(); }
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        public string wynik;
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                wynik = listBox1.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
            else { MessageBox.Show("Nic nie znaznaczyłeś!", "Błąd",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.Text == "Wszystko") {
                string[] lines = File.ReadLines("ICD10.txt").ToArray();
                foreach (string s in lines)
                {

                    listBox1.Items.Add(s);
                }
                string[] lines2 = File.ReadLines("ICD9.txt").ToArray();
                foreach (string s in lines2)
                {

                    listBox1.Items.Add(s);
                }
            
            
            }
            if (comboBox1.Text == "Procedury (ICD-9)")
            {
               
                string[] lines2 = File.ReadLines("ICD9.txt").ToArray();
                foreach (string s in lines2)
                {

                    listBox1.Items.Add(s);
                }


            }
            if (comboBox1.Text == "Rozpoznania (ICD-10)")
            {
                string[] lines = File.ReadLines("ICD10.txt").ToArray();
                foreach (string s in lines)
                {

                    listBox1.Items.Add(s);
                }
                


            }
            if (textBox1.Text != "dynamiczne wyszukiwanie")
            {




            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strTip = "";

            //Get the item
            int nIdx = listBox1.SelectedIndex;
            if ((nIdx >= 0) && (nIdx < listBox1.Items.Count))
                strTip = listBox1.Items[nIdx].ToString();

            toolTip1.SetToolTip(listBox1, strTip);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (listBox1.SelectedItems.Count > 0)
                {
                    wynik = listBox1.SelectedItem.ToString();
                    DialogResult = DialogResult.OK;
                }
                else { MessageBox.Show("Nic nie znaznaczyłeś!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
    
}
