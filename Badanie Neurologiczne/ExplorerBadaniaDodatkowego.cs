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
    public partial class ExplorerBadaniaDodatkowego : Form
    {
        public ExplorerBadaniaDodatkowego()
        {
            InitializeComponent();
        }
        public string url;
        private string path = "";
        private void getpath()
        {
            string past_url = webBrowser1.Url.ToString();
            string absolute_url = past_url.Remove(0, 8);
            string ostatni = absolute_url.Substring(absolute_url.Length - 1);
            absolute_url = absolute_url.Replace("/", "\\");
            if (ostatni != "\\")
            {
                absolute_url = absolute_url + "\\";
            }
            path = absolute_url;
            //MessageBox.Show(path);
        }
        public string katalogpacjenta = "";
        public string id = "";
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "parametry (wyniki)") { listView2.Visible = true; listView2.Enabled = true; textBox3.Visible = false; } else { textBox3.Visible = true; listView2.Visible = false; listView2.Enabled = false; }
        }

        private void ExplorerBadaniaDodatkowego_Load(object sender, EventArgs e)
        {
            Uri u = new Uri(url);
            webBrowser1.Url = u;

            if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id))
            {
                using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "nazwa"))
                {
                    textBox4.Text = writer.ReadToEnd();
                }
                using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "wynik"))
                {
                    textBox3.Text = writer.ReadToEnd();
                }
                using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "data"))
                {
                    Convert.ToDateTime(writer.ReadToEnd());
                }
                if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "parametry"))
                {
                    comboBox2.Text = "parametry (wyniki)";
                    using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "parametry"))
                    {
                        string pre = writer.ReadToEnd();
                        string[] param = pre.Split('|');
                        int ile = Convert.ToInt32(param.Count().ToString());
                        int i = 0;
                        while (i < (ile - 1))
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = param[i]; i++;
                            item.SubItems.Add(param[i]); i++;
                            item.SubItems.Add(param[i]); i++;
                            item.SubItems.Add(param[i]); i++;

                            listView2.Items.Add(item);


                        }
                    }


                }
                else { comboBox2.Text = "opis"; }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Uri u = new Uri(url);
            webBrowser1.Url = u;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getpath();
            // Create an instance of the open file dialog box.
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

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
                    File.Copy(file, path + System.IO.Path.GetFileName(file));



                }
                MessageBox.Show("OK!");
                webBrowser1.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getpath();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string SourcePath = folderBrowserDialog1.SelectedPath;

                string fullPath = Path.GetFullPath(SourcePath).TrimEnd(Path.DirectorySeparatorChar);
                string projectName = Path.GetFileName(fullPath);
                Directory.CreateDirectory(path + projectName + "\\");
                string DestinationPath = path + projectName + "\\";
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

                //Copy all the files
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
                //pliki = "tak"; 
                MessageBox.Show("OK!"); webBrowser1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
