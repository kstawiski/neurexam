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
    public partial class Form25 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public Form25()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            comboBox1.Text = "parametry (wyniki)";
            foreach (Control c in this.Controls)
            {

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
        public string katalogpacjenta; public string id;
        private void button1_Click(object sender, EventArgs e)
        {
            Form19 f = new Form19();
             f.comboBox1.Text = "Procedury (ICD-9)"; if (f.ShowDialog() == DialogResult.OK) { textBox1.Text = f.wynik; } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p\\"))
            { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p\\"); }
            // Set filter options and filter index.
            openFileDialog1.Title = "Powiąż pliki z pacjentem! (przekopuj je do folderu pacjenta, możesz zaznaczyć wiele plików!)";
            openFileDialog1.Filter = "Wszystkie pliki, możesz zanaznaczyć kilka! (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    //if (!Directory.Exists(Application.StartupPath + katalogpacjenta + "\\pliki")) { Directory.CreateDirectory(Application.StartupPath + katalogpacjenta + "\\pliki") }
                    File.Copy(file, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p\\" + System.IO.Path.GetFileName(file));



                }
                MessageBox.Show("Pliki zostały skopiowane!"); pliki = "tak";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p\\")) 
            { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p\\");}
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string SourcePath = folderBrowserDialog1.SelectedPath;
                
                string fullPath = Path.GetFullPath(SourcePath).TrimEnd(Path.DirectorySeparatorChar);
                string projectName = Path.GetFileName(fullPath);
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p\\" + projectName + "\\");
                string DestinationPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p\\" + projectName + "\\";
                //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            //Copy all the files
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
            pliki = "tak"; MessageBox.Show("Skopiowano!");
            }
            
        }
        public string pliki = "nie";
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "parametry (wyniki)")
            {
                textBox2.Text = "";
                foreach (ListViewItem i in listView1.Items)
                {
                    string jednostka = "";
                    if (i.SubItems[3].Text != "") { jednostka = " [" + i.SubItems[3].Text + "]"; }
                    textBox2.Text += i.SubItems[0].Text + " = " + i.SubItems[2].Text + jednostka + " | ";
                }

            }
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
            }

            using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "nazwa"))
            { writer.Write(textBox1.Text); }
            using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "wynik"))
            { writer.Write(textBox2.Text); }
            using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "data"))
            { writer.Write(dateTimePicker1.Value.ToString()); }
            using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "pliki"))
            { writer.Write(pliki); }
            using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "parametry"))
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    writer.WriteLine(i.SubItems[0].Text + "|" + i.SubItems[1].Text + "|" + i.SubItems[2].Text + "|" + i.SubItems[3].Text + "|");
                }
                DialogResult = DialogResult.OK;
            }
        }
        public bool edyt = false;
        private void Form25_Load(object sender, EventArgs e)
        {

            
            
            label4.Text = "Id badania: " + id;

            if (edyt == true)
            {
                if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id))
                {
                    using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "nazwa"))
                    {
                        textBox1.Text = writer.ReadToEnd();
                    }
                    using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "wynik"))
                    {
                        textBox2.Text = writer.ReadToEnd();
                    }
                    using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "data"))
                    {
                        Convert.ToDateTime(writer.ReadToEnd());
                    }
                    if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "parametry"))
                    {
                        comboBox1.Text = "parametry (wyniki)";
                        using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "parametry"))
                        {
                            string pre = writer.ReadToEnd();
                            string[] param = pre.Split('|');
                            int ile = Convert.ToInt32(param.Count().ToString());
                            int i = 0;
                            while (i < (ile - 1)) {
                                ListViewItem item = new ListViewItem();
                                item.Text = param[i]; i++;
                                item.SubItems.Add(param[i]); i++;
                                item.SubItems.Add(param[i]); i++;
                                item.SubItems.Add(param[i]); i++;

                                listView1.Items.Add(item);
                            
                            
                            }
                        }
                    
                    
                    } else { comboBox1.Text = "opis"; }
                }







            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.Text == "parametry (wyniki)") { listView1.Visible = true; listView1.Enabled = true; toolStrip1.Enabled = true; textBox2.Visible = false; } else { textBox2.Visible = true; listView1.Visible = false; listView1.Enabled = false; toolStrip1.Enabled = false; }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ParametrBadaniaDodatkowego f = new ParametrBadaniaDodatkowego();
            if (f.ShowDialog() == DialogResult.OK) 
            {
                ListViewItem i = new ListViewItem();
                i.Text = f.textBox1.Text;
                if (f.radioButton1.Checked) { i.SubItems.Add("wartość"); i.SubItems.Add(f.numericUpDown1.Value.ToString()); i.SubItems.Add(f.textBox3.Text); }
                if (f.radioButton2.Checked) { i.SubItems.Add("+/-"); i.SubItems.Add(f.comboBox1.Text); i.SubItems.Add(""); }
                if (f.radioButton3.Checked) { i.SubItems.Add("inny"); i.SubItems.Add(f.textBox2.Text); i.SubItems.Add(""); }

            listView1.Items.Add(i);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ParametrBadaniaDodatkowego f = new ParametrBadaniaDodatkowego();
                f.textBox1.Text = listView1.SelectedItems[0].Text;
                if (listView1.SelectedItems[0].SubItems[1].Text == "wartość") { f.radioButton1.Checked = true; f.numericUpDown1.Value = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[2].Text); f.textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text; }
                if (listView1.SelectedItems[0].SubItems[1].Text == "+/-") { f.radioButton2.Checked = true; f.comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text; }
                if (listView1.SelectedItems[0].SubItems[1].Text == "inny") { f.radioButton3.Checked = true; f.textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text; }
                if (f.ShowDialog() == DialogResult.OK)
                {
                    listView1.SelectedItems[0].Remove();
                    ListViewItem i = new ListViewItem();
                    i.Text = f.textBox1.Text;
                    if (f.radioButton1.Checked) { i.SubItems.Add("wartość"); i.SubItems.Add(f.numericUpDown1.Value.ToString()); i.SubItems.Add(f.textBox3.Text); }
                    if (f.radioButton2.Checked) { i.SubItems.Add("+/-"); i.SubItems.Add(f.comboBox1.Text); i.SubItems.Add(""); }
                    if (f.radioButton3.Checked) { i.SubItems.Add("inny"); i.SubItems.Add(f.textBox2.Text); i.SubItems.Add(""); }

                    listView1.Items.Add(i);
                }
            }
            else { MessageBox.Show("Niczego nie zaznaczyłeś!"); }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].Remove();
            }
            else { MessageBox.Show("Niczego nie zaznaczyłeś!"); }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
    }
}
