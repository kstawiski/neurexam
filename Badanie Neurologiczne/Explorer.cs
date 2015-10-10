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
    public partial class Explorer : Form
    {
        public Explorer()
        {
            InitializeComponent();
        }

        public string url;
        private void Explorer_Load(object sender, EventArgs e)
        {
            Uri u = new Uri(url);
            webBrowser1.Url = u;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
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
                Directory.CreateDirectory(path  + projectName + "\\");
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
    }
}
