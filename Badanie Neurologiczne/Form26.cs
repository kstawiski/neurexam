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
    public partial class Form26 : Form
    {
        public Form26()
        {
            InitializeComponent(); timer1.Enabled = true;
        }
        public string katalogpacjenta;
        private void Form26_Load(object sender, EventArgs e)
        {
           //htmlwysiwyg1.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W następnej wersji programu!!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (rozp == false) { MessageBox.Show("Edycja przy braku ustalonego rozpoznania i zaleceń może spowodować, że jeśli po edycji ustalisz rozpoznanie utracisz zmiany dokonane podaczas edycji!!!!"); }
             Form21 f = new Form21();string html= File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "index.html");
            WybierzEdycje we = new WybierzEdycje();
            we.comboBox1.Items.Clear();
            we.comboBox1.Items.Add("Etap 1 i 2");
            we.comboBox1.Items.Add("Etap 4, 5 i 6");
            we.comboBox1.Items.Add("Pomiar tętna i BP");
            we.comboBox1.Items.Add("Badanie k. dolnych");
            we.comboBox1.Items.Add("Badanie k. górnych");
            we.comboBox1.Items.Add("Badanie n. czaszkowych");
            we.comboBox1.Items.Add("Rozpoznanie i zalecenia");
            if (we.ShowDialog() == DialogResult.OK) {
                f.textBox1.Text = we.comboBox1.Text;
                if (we.comboBox1.Text == "Etap 1 i 2") { html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap1i2.html");}
                if (we.comboBox1.Text == "Etap 4, 5 i 6") { html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap4i5i6.html"); }
                if (we.comboBox1.Text == "Pomiar tętna i BP") { html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "t+rr.html"); }
                if (we.comboBox1.Text == "Badanie k. dolnych") { html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html"); }
                if (we.comboBox1.Text == "Badanie n. czaszkowych") { html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html"); }
                if (we.comboBox1.Text == "Badanie k. górnych") { html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html"); }
                if (we.comboBox1.Text == "Rozpoznanie i zalecenia") { html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "_zapis\\_rozpoznanie.html"); }
                f.html = html;
            if (f.ShowDialog() == DialogResult.OK)
            {
                string co = "";
                if (we.comboBox1.Text == "Etap 1 i 2") { co = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap1i2.html"; }
                if (we.comboBox1.Text == "Etap 4, 5 i 6") { co = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap4i5i6.html"; }
                if (we.comboBox1.Text == "Pomiar tętna i BP") { co = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "t+rr.html"; }
                if (we.comboBox1.Text == "Badanie k. dolnych") { co = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html"; }
                if (we.comboBox1.Text == "Badanie n. czaszkowych") { co = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html"; }
                if (we.comboBox1.Text == "Badanie k. górnych") { co = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html"; }
                if (we.comboBox1.Text == "Rozpoznanie i zalecenia") { co = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "_zapis\\_rozpoznanie.html"; }
                
                
                System.IO.StreamWriter file = new System.IO.StreamWriter(co);
                file.WriteLine(f.htmlwysiwyg1.getHTML());
                file.Close();

                html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap1i2.html"); 
                 html += File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap4i5i6.html"); 
                html += File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "t+rr.html"); 
                html += File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html");html += File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html");html += File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html"); 
                 
                 
                html += File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "_zapis\\_rozpoznanie.html");

                System.IO.StreamWriter file2 = new System.IO.StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "index.html");
                file2.WriteLine(f.htmlwysiwyg1.getHTML());
                file2.Close();
            
            }
            
            
            
            
            }
                
                
           
            //f.htmlwysiwyg1.allowEdit(true);

            //f.htmlwysiwyg1.setHTML(html);
            //f.htmlwysiwyg1.addFont("Segoe UI");
            f.html = html;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
webBrowser1.ShowPrintDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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
startInfo.Arguments = "\"" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "index.html\" \"" + saveFileDialog1.FileName + "\"";
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
        public string podstawaurl;
        private void button6_Click(object sender, EventArgs e)
        {
            //Form26 f = new Form26();
            Uri url = new Uri(podstawaurl + "index.html");
            webBrowser1.Url = url;
            button6.Enabled = false;
            //f.Show();
            //f.katalogpacjenta = katalogpacjenta;
            //this.Close();
        }
        public bool rozp = false;
        private void button7_Click(object sender, EventArgs e)
        {

            Form27 f = new Form27();
            if (f.ShowDialog() == DialogResult.OK) {
                string rozpoznanie = f.textBox1.Text;
                string zalecenia = f.textBox2.Text;
                rozp = true;
                using (StreamWriter koniec = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "_zapis\\_rozpoznanie.html"))
                {
                    koniec.Write("<u><b>ROZPOZNANIE:</u> " + rozpoznanie + "<br></b>");
                    koniec.Write("<u><b>ZALECENIA:</u> " + zalecenia + "<br></b><br>");

                }
                using (StreamWriter koniec = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "index.html"))
                {
                    using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap1i2.html"))
                    {
                        koniec.Write(czytnik.ReadToEnd());
                    }
                    koniec.Write("<br><table width=\"100%\"><thead><tr><td><b>EWALUACJA #1: ETAP 1 i 2</b></td></tr></thead><tbody><tr><td>[ ] 5 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone i dokładnie opisane)</td></tr><tr><td>[ ] 4 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone, jednak brakuje istotnych szczegółów)</td></tr><tr><td>[ ] 3 pkt. (jedna istotna klinicznie informacja została pominięta, ale reszta została opisana dokładnie)</td></tr><tr><td>[ ] 2 pkt. (jedna istotna klinicznie informacja została pomięta, a reszta nie została dokładnie opisana)</td></tr><tr><td>[ ] 1 pkt. (więcej niż jedna istotna klinicznie informacja została pominięta)</td></tr></tbody></table>");

                    koniec.Write("<hr>");
                    using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html"))
                    {
                        koniec.Write(czytnik.ReadToEnd());
                    }
                    koniec.Write("<br><table width=\"100%\"><thead><tr><td><b>EWALUACJA #2: BADANIE NERWÓW CZASZKOWYCH</b></td></tr></thead><tbody><tr><td>[ ] 5 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone i dokładnie opisane)</td></tr><tr><td>[ ] 4 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone, jednak brakuje istotnych szczegółów)</td></tr><tr><td>[ ] 3 pkt. (jedna istotna klinicznie informacja została pominięta, ale reszta została opisana dokładnie)</td></tr><tr><td>[ ] 2 pkt. (jedna istotna klinicznie informacja została pomięta, a reszta nie została dokładnie opisana)</td></tr><tr><td>[ ] 1 pkt. (więcej niż jedna istotna klinicznie informacja została pominięta)</td></tr></tbody></table>");
                    koniec.Write("<hr>");
                    using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\"+ katalogpacjenta + "b_kgorne.html"))
                    {
                        koniec.Write(czytnik.ReadToEnd());
                    }
                    koniec.Write("<br><table width=\"100%\"><thead><tr><td><b>EWALUACJA #3: BADANIE KOŃCZYN GÓRNYCH</b></td></tr></thead><tbody><tr><td>[ ] 5 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone i dokładnie opisane)</td></tr><tr><td>[ ] 4 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone, jednak brakuje istotnych szczegółów)</td></tr><tr><td>[ ] 3 pkt. (jedna istotna klinicznie informacja została pominięta, ale reszta została opisana dokładnie)</td></tr><tr><td>[ ] 2 pkt. (jedna istotna klinicznie informacja została pomięta, a reszta nie została dokładnie opisana)</td></tr><tr><td>[ ] 1 pkt. (więcej niż jedna istotna klinicznie informacja została pominięta)</td></tr></tbody></table>");
                    koniec.Write("<hr>");
                    using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html"))
                    {
                        koniec.Write(czytnik.ReadToEnd());
                    }
                    koniec.Write("<br><table width=\"100%\"><thead><tr><td><b>EWALUACJA #4: BADANIE KOŃCZYN DOLNYCH I TUŁOWIA</b></td></tr></thead><tbody><tr><td>[ ] 5 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone i dokładnie opisane)</td></tr><tr><td>[ ] 4 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone, jednak brakuje istotnych szczegółów)</td></tr><tr><td>[ ] 3 pkt. (jedna istotna klinicznie informacja została pominięta, ale reszta została opisana dokładnie)</td></tr><tr><td>[ ] 2 pkt. (jedna istotna klinicznie informacja została pomięta, a reszta nie została dokładnie opisana)</td></tr><tr><td>[ ] 1 pkt. (więcej niż jedna istotna klinicznie informacja została pominięta)</td></tr></tbody></table>");
                   
                    using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap4i5i6.html"))
                    {
                        koniec.Write(czytnik.ReadToEnd());
                    }
                    koniec.Write("<br><table width=\"100%\"><thead><tr><td><b>EWALUACJA #5: ETAP 4, 5 i 6</b></td></tr></thead><tbody><tr><td>[ ] 5 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone i dokładnie opisane)</td></tr><tr><td>[ ] 4 pkt. (wszystkie istotne klinicznie informacje zostały wychwycone, jednak brakuje istotnych szczegółów)</td></tr><tr><td>[ ] 3 pkt. (jedna istotna klinicznie informacja została pominięta, ale reszta została opisana dokładnie)</td></tr><tr><td>[ ] 2 pkt. (jedna istotna klinicznie informacja została pomięta, a reszta nie została dokładnie opisana)</td></tr><tr><td>[ ] 1 pkt. (więcej niż jedna istotna klinicznie informacja została pominięta)</td></tr></tbody></table>");
                   
                    koniec.Write("<hr><br>");

                    koniec.Write("<u><b>ROZPOZNANIE:</u> " + rozpoznanie.Replace("\n","<br />") + "<br></b>");
                    koniec.Write("<u><b>ZALECENIA:</u> " + zalecenia.Replace("\n", "<br />") + "<br></b><br>");
                    if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt"))
                    {
                        using (StreamReader w = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt"))
                        {
                            koniec.Write("<table border=\"0\"><tr><td></td><td>");

                            string lekarz = w.ReadToEnd();
                            lekarz = lekarz.Replace("\n", "<br>");
                            koniec.Write(lekarz + "</td></tr></table><br><br>");
                        }
                    }
                    using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "end.html"))
                    {
                        koniec.Write(czytnik.ReadToEnd());
                    }
                    koniec.Write("<font size=\"1\"><a href=\"http://www.comfortzg.com/badanieneurologiczne\">Wygenerowany przez Badanie Neurologiczne by Konrad Stawiski v1.0 SUPREME</a></font></html>");
                }
                webBrowser1.Refresh(); button1.Enabled = true; button3.Text = "Powrót do menu (następne badanie)"; button7.Enabled = false; button7.Text = "Rozpoznanie i zalecenia zostały już ustalone";


            
            
            
            
            }






          










        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 2500;Uri url = new Uri(podstawaurl + "index.html");
            if (webBrowser1.Url == url) { button6.Enabled = false; } else { button6.Enabled = true; }
            if (rozp == true) { button1.Enabled = true; button3.Text = "Powrót do menu (następne badanie)"; button7.Enabled = false; button7.Text = "Rozpoznanie i zalecenia zostały już ustalone";}
            if (rozp == false) { button1.Enabled = false; button3.Text = "Ustal rozpoznanie później (menu)"; button7.Text = "Ustal rozpoznanie i zalecenia"; ; button7.Enabled = true; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(katalogpacjenta);
            NotatkiGlosowe n = new NotatkiGlosowe();
            n.katalogpacjenta = katalogpacjenta;
            n.Show();
            n.toolStripLabel1.Text = katalogpacjenta;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Explorer ee = new Explorer();
            ee.url = podstawaurl+  "pliki";
            ee.Show();
        }
        }
    }

