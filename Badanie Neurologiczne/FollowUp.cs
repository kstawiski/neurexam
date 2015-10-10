using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Badanie_Neurologiczne
{
    public partial class FollowUp : Form
    {
        public FollowUp()
        {
            InitializeComponent();
        }

        private void FollowUp_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\";
            DirectoryInfo MyRoot = new DirectoryInfo(path);

            DirectoryInfo[] MySub = MyRoot.GetDirectories();
            foreach (DirectoryInfo D in MySub)
            {
                if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + D.Name + "\\_zapis\\data_pierwszego_badania")) { listBox1.Items.Add(D.Name); }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.LongCount() > 1)
            {
                listBox1.Items.Clear();
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\";
                DirectoryInfo MyRoot = new DirectoryInfo(path);

                DirectoryInfo[] MySub = MyRoot.GetDirectories();
                foreach (DirectoryInfo D in MySub)
                {
                    if (textBox1.Text != "")
                    {
                        if (D.Name.Contains(textBox1.Text))
                        {
                            if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + D.Name + "\\index.html")) { listBox1.Items.Add(D.Name); }
                        }
                    }
                    else { if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + D.Name + "\\index.html")) { listBox1.Items.Add(D.Name); } }
                }

            }
            else
            {
                listBox1.Items.Clear();
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\";
                DirectoryInfo MyRoot = new DirectoryInfo(path);

                DirectoryInfo[] MySub = MyRoot.GetDirectories();
                foreach (DirectoryInfo D in MySub)
                { listBox1.Items.Add(D.Name); }
            }
        }
        //bool pierwszyklik = true;
        private void textBox1_Click(object sender, EventArgs e)
        {
           textBox1.Text = "";
        }
        public void odsiezbadaniadodatkowe()
        {
            listView2.Items.Clear();
            bool mamkońcoweid = false;
            int id = 0;
            //MessageBox.Show(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\");
            string[] directories = Directory.GetDirectories(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\");
            foreach (string directory in directories)
            {
                if (File.Exists(directory + "\\" + "nazwa"))
                {
                    ListViewItem lvi = new ListViewItem();
                    using (StreamReader writer = new StreamReader(directory + "\\" + "nazwa"))
                    {
                        lvi.Text = writer.ReadToEnd();
                    }
                    using (StreamReader writer = new StreamReader(directory + "\\" + "wynik"))
                    {
                        lvi.SubItems.Add(writer.ReadToEnd());
                    }
                    using (StreamReader writer = new StreamReader(directory + "\\" + "data"))
                    {
                        lvi.SubItems.Add(writer.ReadToEnd());
                    }
                    //lvi.Group = listView1.Groups[kategoria];
                    //aktywność
                    //string aktywny_txt = "Nie";
                    //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
                    //lvi.SubItems.Add(aktywny_txt);
                    //opis
                    using (StreamReader writer = new StreamReader(directory + "\\" + "pliki"))
                    {
                        lvi.SubItems.Add(writer.ReadToEnd());
                    }
                    //directory.Last("/");
                    string id_dowpis = Convert.ToString(directory.Substring(directory.LastIndexOf('\\') + 1));
                    //MessageBox.Show(id_dowpis);
                    lvi.SubItems.Add(id_dowpis);
                    listView2.Items.Add(lvi);


                }
                else
                {
                    //kasujemy błędne rekorny
                    Directory.Delete(directory, true);






                }
            }


            while (mamkońcoweid == false)
            {

                if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id))
                {

                    id++;
                }
                else { mamkońcoweid = true; }

            }





        }

        string katalogpacjenta = "";
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                katalogpacjenta = "Pacjenci\\" + listBox1.SelectedItems[0].ToString();
                //MessageBox.Show("katalogpacjenta =" + katalogpacjenta);

                groupBox2.Enabled = true;
                groupBox4.Enabled = true;
                //GETbadania
                listBox2.Items.Clear();
                using (StreamReader r = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\_zapis\\data_pierwszego_badania"))
                {
                    string data_pierwszego_badania = r.ReadToEnd();
                    listBox2.Items.Add("pierwsze badanie (" + data_pierwszego_badania + ")");
                }
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup";
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                DirectoryInfo MyRoot = new DirectoryInfo(path);
                
                FileInfo[] MySub = MyRoot.GetFiles();
                if (MySub.Count() > 0)
                {
                    foreach (FileInfo f in MySub)
                    {
                        string[] czesc = f.Name.ToString().Split('_');
                        string[] czesc2 = czesc[1].Split('.');
                        listBox2.Items.Add("nr " + czesc[0] + " (" + czesc2[0] +")");



                    }


                }


                //ośwież badania dodatkowe
                listView2.Items.Clear();
                bool mamkońcoweid = false;
                int id = 0;
                //MessageBox.Show(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\");
                string[] directories = Directory.GetDirectories(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\badania_dodatkowe\\");
                foreach (string directory in directories)
                {
                    if (File.Exists(directory + "\\" + "nazwa"))
                    {
                        ListViewItem lvi = new ListViewItem();
                        using (StreamReader writer = new StreamReader(directory + "\\" + "nazwa"))
                        {
                            lvi.Text = writer.ReadToEnd();
                        }
                        using (StreamReader writer = new StreamReader(directory + "\\" + "wynik"))
                        {
                            lvi.SubItems.Add(writer.ReadToEnd());
                        }
                        using (StreamReader writer = new StreamReader(directory + "\\" + "data"))
                        {
                            lvi.SubItems.Add(writer.ReadToEnd());
                        }
                        //lvi.Group = listView1.Groups[kategoria];
                        //aktywność
                        //string aktywny_txt = "Nie";
                        //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
                        //lvi.SubItems.Add(aktywny_txt);
                        //opis
                        using (StreamReader writer = new StreamReader(directory + "\\" + "pliki"))
                        {
                            lvi.SubItems.Add(writer.ReadToEnd());
                        }
                        //directory.Last("/");
                        string id_dowpis = Convert.ToString(directory.Substring(directory.LastIndexOf('\\') + 1));
                        //MessageBox.Show(id_dowpis);
                        lvi.SubItems.Add(id_dowpis);
                        listView2.Items.Add(lvi);


                    }
                    else
                    {
                        //kasujemy błędne rekorny
                        Directory.Delete(directory, true);






                    }
                }


                while (mamkońcoweid == false)
                {

                    if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id))
                    {

                        id++;
                    }
                    else { mamkońcoweid = true; }

                }


            }
            else { groupBox4.Enabled = false; groupBox2.Enabled = false; }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) { toolStripButton1.Enabled = false; toolStripButton3.Enabled = false; toolStripButton4.Enabled = false; } else { toolStripButton1.Enabled = true; toolStripButton3.Enabled = true; toolStripButton4.Enabled = true; }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count == 0) { groupBox3.Enabled = false; }
            else
            {
                groupBox3.Enabled = true;
                if (listBox2.SelectedItem.ToString().Contains("pierwsze")) { webBrowser1.Navigate("file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\index.html"); }
                else {
                    string[] czesc = listBox2.SelectedItem.ToString().Split(' ');
                    webBrowser1.Navigate("file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup\\" + czesc[1] + "_" + czesc[2].Substring(1, czesc[2].Length - 2) + ".html");

                
                
                }
            
            
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            katalogpacjenta = katalogpacjenta + "\\";
            Form25 f = new Form25();
            f.katalogpacjenta = katalogpacjenta;
            //bool mamid = false;
            //int id = 0;
            if (listView2.SelectedItems.Count == 1)
            {
                string id = listView2.SelectedItems[0].SubItems[4].Text;
                f.id = id; f.edyt = true;
                if (f.ShowDialog() == DialogResult.OK)
                {

                    //odświeżyć listview
                    
                    //katalogpacjenta = katalogpacjenta + "\\";
                    odsiezbadaniadodatkowe();
                    //katalogpacjenta = katalogpacjenta.Remove(katalogpacjenta.Length - 1);
                }
            }
            katalogpacjenta = katalogpacjenta.Remove(katalogpacjenta.Length - 1);
        }
        private void ClearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.IsReadOnly = false;
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            katalogpacjenta = katalogpacjenta + "\\";
            if (listView2.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Czy jesteś pewny, że chcesz skasować to badanie?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    string id = listView2.SelectedItems[0].SubItems[4].Text;
                    ClearFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id);
                    Directory.Delete(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id);
                    odsiezbadaniadodatkowe();
                }
            }
            katalogpacjenta = katalogpacjenta.Remove(katalogpacjenta.Length - 1);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            katalogpacjenta = katalogpacjenta + "\\";
            if (listView2.SelectedItems.Count == 1)
            {
                ExplorerBadaniaDodatkowego eee = new ExplorerBadaniaDodatkowego();
                eee.katalogpacjenta = katalogpacjenta;
                eee.id = listView2.SelectedItems[0].SubItems[4].Text;
                //MessageBox.Show(" id = " + listView2.SelectedItems[0].SubItems[4].Text);
                using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + eee.id + "\\" + "pliki"))
                {
                    if (writer.ReadToEnd() == "nie") { MessageBox.Show("Nie ma plików dla tego zaznaczenia"); }
                    else
                    {
                        string uu = "file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/Badanie Neurologiczne by Konrad Stawiski/" + katalogpacjenta;
                        string podstawaurl = uu.Replace("\\", "/");

                        eee.url = podstawaurl + "badania_dodatkowe\\" + eee.id + "\\p\\";
                        //MessageBox.Show(ee.url);
                        eee.Show();
                        //System.Diagnostics.Process.Start(Application.StartupPath + "\\");



                    }
                }





            }
            katalogpacjenta = katalogpacjenta.Remove(katalogpacjenta.Length - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            katalogpacjenta = katalogpacjenta + "\\";
           
            NotatkiGlosowe n = new NotatkiGlosowe();
            n.katalogpacjenta = katalogpacjenta;
            n.Show();
            n.toolStripLabel1.Text = katalogpacjenta; katalogpacjenta = katalogpacjenta.Remove(katalogpacjenta.Length - 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            katalogpacjenta = katalogpacjenta + "\\";
            string uu = "file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta;
            string podstawaurl = uu.Replace("\\", "/");
            Explorer ee = new Explorer();
            ee.url = podstawaurl + "/pliki";
            ee.Show(); katalogpacjenta = katalogpacjenta.Remove(katalogpacjenta.Length - 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                string co = webBrowser1.Url.ToString().Substring(8);
                co = co.Replace('/', '\\');
                //string plik = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\index.html";
                //if (!listBox2.SelectedItems[0].ToString().Contains("ierwsze")) {
                    //string[] czesc = listBox2.SelectedItem.ToString().Split(' ');
                    //webBrowser1.Navigate("file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup\\" + czesc[1] + "_" + czesc[2].Substring(1, czesc[2].Length - 2) + ".html");


                   // plik = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup\\" + czesc[1] + "_" + czesc[2].Substring(1, czesc[2].Length - 2) + ".html";
                //}
                string html = File.ReadAllText(co);
                Form21 f = new Form21();
                //f.htmlwysiwyg1.allowEdit(true);

                //f.htmlwysiwyg1.setHTML(html);
                //f.htmlwysiwyg1.addFont("Segoe UI");
                f.html = html;
                f.textBox1.Text = listBox2.SelectedItems[0].ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(co);
                    file.WriteLine(f.htmlwysiwyg1.getHTML());
                    file.Close();

                }

                webBrowser1.Refresh();
            }
            else { MessageBox.Show("Żadne badanie nie zostało jeszcze wybrane! Należy edytować samodzielne badania."); }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text == "") { textBox2.Text = "Szukaj"; }
            List<string> wszystko = new List<string>();
            using (StreamReader r = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\_zapis\\data_pierwszego_badania"))
            {
                string data_pierwszego_badania = r.ReadToEnd();
                wszystko.Add("pierwsze badanie (" + data_pierwszego_badania + ")");
            }
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup";
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
            DirectoryInfo MyRoot = new DirectoryInfo(path);

            FileInfo[] MySub = MyRoot.GetFiles();
            if (MySub.Count() > 0)
            {
                foreach (FileInfo f in MySub)
                {
                    string[] czesc = f.Name.ToString().Split('_');
                    string[] czesc2 = czesc[1].Split('.');
                    wszystko.Add("nr " + czesc[0] + " (" + czesc2[0] + ")");



                }


            }


            if (textBox2.Text == "" || textBox2.Text == "Szukaj")
            {
                listBox2.Items.Clear();
                foreach (string w in wszystko)
                {
                    listBox2.Items.Add(w);
                }
            }
            else
            {
                listBox2.Items.Clear(); foreach (string w in wszystko) { if (w.Contains(textBox2.Text)) { listBox2.Items.Add(w); } }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int id;
            if (Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup\\", "*.html").Count().ToString() != "0")
            {
                string[] dodatkowewpisy = Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup\\", "*.html")
                                         .Select(path => Path.GetFileName(path))
                                         .ToArray();

                List<int> ileid = new List<int>();
                foreach (string plik in dodatkowewpisy)
                {
                    string[] czesc = plik.Split('_');
                    ileid.Add(Convert.ToInt32(czesc[0]));

                }
                id = Convert.ToInt32(ileid.Max());
                id++;



            }
            else { id = 2; }
            
            string html = "<font face=\"Segoe UI\"><b><u>Wizyta nr" + id.ToString() + " dnia " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "</b></u><br>";
            Form21 f = new Form21();
            //f.htmlwysiwyg1.allowEdit(true);

            //f.htmlwysiwyg1.setHTML(html);
            //f.htmlwysiwyg1.addFont("Segoe UI");
            f.html = html;
            f.textBox1.Text = "Wizyta nr " + id.ToString() + " dnia " + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            if (f.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup\\" + id.ToString() + "_"  + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".html");
                file.WriteLine(f.htmlwysiwyg1.getHTML());
                file.Close();
                listBox2.Items.Clear();
                using (StreamReader r = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\_zapis\\data_pierwszego_badania"))
                {
                    string data_pierwszego_badania = r.ReadToEnd();
                    listBox2.Items.Add("pierwsze badanie (" + data_pierwszego_badania + ")");
                }
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup";
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                DirectoryInfo MyRoot = new DirectoryInfo(path);

                FileInfo[] MySub = MyRoot.GetFiles();
                if (MySub.Count() > 0)
                {
                    foreach (FileInfo fff in MySub)
                    {
                        string[] czesc = fff.Name.ToString().Split('_');
                        listBox2.Items.Add("nr " + czesc[0] + " (" + czesc[1] + ")");



                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF|*.pdf";
            saveFileDialog1.Title = "Eksport PDF";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                //File.Copy(Application.StartupPath + "\\" + katalogpacjenta + "index.html",Application.StartupPath + "\\pdf\\index.html");
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Application.StartupPath + "\\pdf\\wkhtmltopdf.exe";

                string co = webBrowser1.Url.ToString().Substring(8);
                co = co.Replace('/', '\\');


                startInfo.Arguments = "\"" + co + "\" \"" + saveFileDialog1.FileName + "\"";
                
                Process p = Process.Start(startInfo);
                // System.Diagnostics.Process.Start(Application.StartupPath + "\\pdf\\wkhtmltopdf.exe index.html index.pdf");
                ////Wait for the window to finish loading.
                //p.WaitForInputIdle();
                ////Wait for the process to end.

                p.WaitForExit();
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                //File.Copy(Application.StartupPath + "\\pdf\\index.pdf", saveFileDialog1.FileName);
                //File.Delete(Application.StartupPath + "\\pdf\\index.html");
                //File.Delete(Application.StartupPath + "\\pdf\\index.pdf");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pathh = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\podsum.html";
            using (System.IO.StreamWriter w = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\podsum.html"))
            {
                w.Write(File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\index.html"));
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup";
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                DirectoryInfo MyRoot = new DirectoryInfo(path);

                FileInfo[] MySub = MyRoot.GetFiles();
                if (MySub.Count() > 0)
                {
                    foreach (FileInfo fff in MySub)
                    {
                        w.Write("<hr>");
                        w.Write(File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\followup\\" + fff.Name));



                    }
                }
            
            }
            string url = pathh.Replace('\\', '/');
            url = "file://" + url;
            webBrowser1.Navigate(url);

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            katalogpacjenta = katalogpacjenta + "\\";
            Form25 f = new Form25();
            f.katalogpacjenta = katalogpacjenta;
            bool mamid = false;
            int id = 0;
            while (mamid == false)
            {
                if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id))
                {
                    id++;
                    mamid = false;
                }
                else { mamid = true; Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id); }

            }
            f.id = Convert.ToString(id);
            if (f.ShowDialog() == DialogResult.OK)
            {

                //odświeżyć listview
                odsiezbadaniadodatkowe();
            }
            katalogpacjenta = katalogpacjenta.Remove(katalogpacjenta.Length - 1);
        }
    }
}
