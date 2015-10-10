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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            foreach (TabPage tp in tabControl1.Controls.OfType<TabPage>())
            {
                foreach (TextBox t in tp.Controls.OfType<TextBox>())
                {
                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + t.Name;

                    if (File.Exists(identyfikacja))
                    {
                        string pre = "";
                        t.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                        t.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                        StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                        string[] preuz = pre.Split('|');
                        t.AutoCompleteCustomSource.AddRange(preuz);
                    }
                }
            }
            foreach (Panel tp in tabControl1.Controls.OfType<Panel>())
            {
                foreach (TextBox t in tp.Controls.OfType<TextBox>())
                {
                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + t.Name;

                    if (File.Exists(identyfikacja))
                    {
                        
                        string pre = "";
                        t.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                        t.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                        StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                        string[] preuz = pre.Split('|');
                        t.AutoCompleteCustomSource.AddRange(preuz);
                    }
                }
            }
        }
        public void HideTabPage(TabPage tp)
        {
            if (tabControl1.TabPages.Contains(tp))
                tabControl1.TabPages.Remove(tp);
        }


        public void ShowTabPage(TabPage tp)
        {
            ShowTabPage(tp, tabControl1.TabPages.Count);
        }


        private void ShowTabPage(TabPage tp, int index)
        {
            if (tabControl1.TabPages.Contains(tp)) return;
            InsertTabPage(tp, index);
        }

        private void Pokaz(TabPage tabpage) { tabControl1.SelectedTab = tabpage; }
        private void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > tabControl1.TabCount)
                throw new ArgumentException("Index out of Range.");
            tabControl1.TabPages.Add(tabpage);
            if (index < tabControl1.TabCount - 1)
                do
                {
                    SwapTabPages(tabpage, (tabControl1.TabPages[tabControl1.TabPages.IndexOf(tabpage) - 1]));
                }
                while (tabControl1.TabPages.IndexOf(tabpage) != index);
            //tabControl1.SelectedTab = tabpage;
        }

        private void raportuj(string info)
        {
            control.Text = control.Text + info;


        }
        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            if (tabControl1.TabPages.Contains(tp1) == false || tabControl1.TabPages.Contains(tp2) == false)
                throw new ArgumentException("TabPages must be in the TabControls TabPageCollection.");

            int Index1 = tabControl1.TabPages.IndexOf(tp1);
            int Index2 = tabControl1.TabPages.IndexOf(tp2);
            tabControl1.TabPages[Index1] = tp2;
            tabControl1.TabPages[Index2] = tp1;

            //Uncomment the following section to overcome bugs in the Compact Framework
            //tabControl1.SelectedIndex = tabControl1.SelectedIndex; 
            //string tp1Text, tp2Text;
            //tp1Text = tp1.Text;
            //tp2Text = tp2.Text;
            //tp1.Text=tp2Text;
            //tp2.Text=tp1Text;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Wszystkie pliki|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Form8 f = new Form8();
                string katalogpacjenta = f.katalogpacjenta;
                File.Copy(openFileDialog1.FileName, katalogpacjenta, true);
                MessageBox.Show("Plik został przypisany!");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int selstart = control.SelectionStart;
            int sellength = control.SelectionLength;
            // ... previous code
            control.SelectionFont = new Font(control.Font, FontStyle.Bold);
            control.SelectionStart = control.SelectionStart + control.SelectionLength;
            control.SelectionLength = 0;
            control.SelectionFont = control.Font;

            control.Select(selstart, sellength);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            control.Undo();

            control.ClearUndo();
        }
        public int objaw;
        private void Form11_Load(object sender, EventArgs e)
        {
            HideTabPage(tabPage2);
            HideTabPage(tabPage3);
            HideTabPage(tabPage4);
            HideTabPage(tabPage5);
            HideTabPage(tabPage6);
            HideTabPage(tabPage7);
            HideTabPage(tabPage8);
            HideTabPage(tabPage9);
            HideTabPage(tabPage10);
            HideTabPage(tabPage11);
            HideTabPage(tabPage12);
            HideTabPage(tabPage13);
            Form8 f = new Form8();
            //MessageBox.Show(Convert.ToString(objaw));
            if (objaw == 2) { ShowTabPage(tabPage2); }
            if (objaw == 3) { ShowTabPage(tabPage3); }
            if (objaw == 4) { ShowTabPage(tabPage4); }
            if (objaw == 5) { ShowTabPage(tabPage5); }
            if (objaw == 6) { ShowTabPage(tabPage6); }
            if (objaw == 7) { ShowTabPage(tabPage7); }
            if (objaw == 8) { ShowTabPage(tabPage8); }
            if (objaw == 9) { ShowTabPage(tabPage9); }
            if (objaw == 10) { ShowTabPage(tabPage10); }
            if (objaw == 11) { ShowTabPage(tabPage11); }
            if (objaw == 12) { ShowTabPage(tabPage12); }
            if (objaw == 13) { ShowTabPage(tabPage13); }
            if (objaw > 1) { button9.Visible = true; } else { button9.Visible = false; }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            foreach (TabPage tp in tabControl1.Controls.OfType<TabPage>())
            {
                foreach (TextBox t in tp.Controls.OfType<TextBox>())
                {
                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + t.Name;
                    string pre = "";
                    if (File.Exists(identyfikacja))
                    {
                        StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                        string[] preuz = pre.Split('|');
                        bool juzjest = false;
                        foreach (string uz in preuz)
                        {
                            if (t.Text == uz) { juzjest = true; }
                        }
                        if (juzjest == false)
                        {
                            StreamWriter w = new StreamWriter(identyfikacja);
                            w.Write(pre + "|" + t.Text); w.Close();
                        }
                    }
                    else
                    {
                        StreamWriter w = new StreamWriter(identyfikacja);
                        w.Write(t.Text); w.Close();
                    }

                }
                foreach (Panel p in tp.Controls.OfType<Panel>())
                {
                    foreach (TextBox t in p.Controls.OfType<TextBox>())
                    {
                        string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + t.Name;
                        string pre = "";
                        if (File.Exists(identyfikacja))
                        {
                            StreamReader r = new StreamReader(identyfikacja); pre = r.ReadToEnd(); r.Close();
                            string[] preuz = pre.Split('|');
                            bool juzjest = false;
                            foreach (string uz in preuz)
                            {
                                if (t.Text == uz) { juzjest = true; }
                            }
                            if (juzjest == false)
                            {
                                StreamWriter w = new StreamWriter(identyfikacja);
                                w.Write(pre + "|" + t.Text); w.Close();
                            }
                        }
                        else
                        {
                            StreamWriter w = new StreamWriter(identyfikacja);
                            w.Write(t.Text); w.Close();
                        }

                    }

                }
            }
            
            
            
            DialogResult = DialogResult.OK;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "nie stwierdzono";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "sporadycznie (brak regularnej powtarzalności)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "nie stwierdzono";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "niepewny";
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            control.Undo();

            control.ClearUndo();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int selstart = control.SelectionStart;
            int sellength = control.SelectionLength;
            // ... previous code
            control.SelectionFont = new Font(control.Font, FontStyle.Bold);
            control.SelectionStart = control.SelectionStart + control.SelectionLength;
            control.SelectionLength = 0;
            control.SelectionFont = control.Font;

            control.Select(selstart, sellength);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        bool zakończonopodstawy = false;
        private void button9_Click(object sender, EventArgs e)
        {
            if (objaw > 1)
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;
                if (objaw == 2) { Pokaz(tabPage2); }
                if (objaw == 3) { Pokaz(tabPage3); }
                if (objaw == 4) { Pokaz(tabPage4); }
                if (objaw == 5) { Pokaz(tabPage5); }
                if (objaw == 6) { Pokaz(tabPage6); }
                if (objaw == 7) { Pokaz(tabPage7); }
                if (objaw == 8) { Pokaz(tabPage8); }
                if (objaw == 9) { Pokaz(tabPage9); }
                if (objaw == 10) { Pokaz(tabPage10); }
                if (objaw == 11) { Pokaz(tabPage11); }
                if (objaw == 12) { Pokaz(tabPage12); }
                if (objaw == 13) { Pokaz(tabPage13); }
                //przedtem Główne powody wizyty:
                raportuj("objaw " + textBox3.Text + " (");
                bool realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox2.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", czas trwania: " + textBox2.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox2.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");
                button9.Enabled = false;
            }
            else
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;

                //przedtem Główne powody wizyty:
                raportuj("objaw " + textBox3.Text + " (");
                bool realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox2.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", czas trwania: " + textBox2.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox2.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");
                button9.Enabled = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "") { listBox1.Items.Add(textBox9.Text); textBox9.Text = ""; } else { MessageBox.Show("Uzupełnij!"); }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox9.Text = "wymioty: ";
            textBox9.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox9.Text = "zaburzenia widzenia: ";
            textBox9.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox9.Text = "upośledzenie świadomości: ";
            textBox9.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox9.Text = "zaburzenia emocjonalne: ";
            textBox9.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox9.Text = "sztywność karku (obajwy oponowe?): ";
            textBox9.Focus();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "") { listBox2.Items.Add("czynnik łagodzący: " + textBox11.Text); textBox11.Text = ""; } else { MessageBox.Show("Uzupełnij!"); }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "") { listBox2.Items.Add("czynnik zaostrzający: " + textBox11.Text); textBox11.Text = ""; } else { MessageBox.Show("Uzupełnij!"); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (zakończonopodstawy == false)
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;

                //przedtem Główne powody wizyty:
                raportuj("objaw " + textBox3.Text + " (");
                bool realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox4.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox4.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox5.Text != "") { raportuj(", czas trwania: " + textBox5.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox5.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");
            }
            if (textBox7.Text != "") { raportuj("Ból głowy nasilony " + textBox7.Text + ". "); }
            if (textBox8.Text != "") { raportuj("Charakter opisywany jako " + textBox8.Text + ". "); }
            if (listBox1.Items.Count == 0) { raportuj("Nie towarzyszą mu żadne objawy towarzyszące. "); }
            else
            {
                raportuj("Towarzyszą mu następujące objawy towarzyszące: ");
                int pobieranzlistboxa = 0;
                foreach (string s in listBox1.Items)
                {
                    int numer = pobieranzlistboxa + 1;
                    if (pobieranzlistboxa == 0) { raportuj("(1) " + s); } else { raportuj(", (" + Convert.ToString(numer) + ") " + s); }
                    pobieranzlistboxa++;

                }
                raportuj(". ");
            }
            if (listBox2.Items.Count == 0) { raportuj("Pacjent nie zauważył żadnych czynników zaostrzających lub łagodzących ból. "); }
            else
            {
                raportuj("Pacjent twierdzi, że na ból wpływa ");
                int pobieranzlistboxa = 0;
                foreach (string s in listBox2.Items)
                {
                    int numer = pobieranzlistboxa + 1;
                    if (pobieranzlistboxa == 0) { raportuj("(1) " + s); } else { raportuj(", (" + Convert.ToString(numer) + ") " + s); }
                    pobieranzlistboxa++;

                }
                raportuj(". ");
            }
            HideTabPage(tabPage2); Pokaz(tabPage1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "") { listBox3.Items.Add(textBox12.Text); textBox12.Text = ""; } else { MessageBox.Show("Uzupełnij!"); }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (zakończonopodstawy == false)
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;

                //przedtem Główne powody wizyty:
                raportuj("objaw " + textBox3.Text + " (");
                bool realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox4.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox4.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", czas trwania: " + textBox5.Text); } } else { if (textBox5.Text != "") { raportuj("czas trwania: " + textBox5.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");

            }
            if (listBox3.Items.Count == 0) { raportuj("Pacjent twierdzi, że utracie przytomności nie towarzyszyły żadne objawy zwiastunowe. "); }
            else
            {
                raportuj("Pacjent twierdzi, że utracie przytomności towarzyszyły objawy zwiastunowe: ");
                int pobieranzlistboxa = 0;
                foreach (string s in listBox3.Items)
                {
                    int numer = pobieranzlistboxa + 1;
                    if (pobieranzlistboxa == 0) { raportuj("(1) " + s); } else { raportuj(", (" + Convert.ToString(numer) + ") " + s); }
                    pobieranzlistboxa++;

                }
                raportuj(". ");
            }
            if (textBox13.Text != "") { raportuj("Samopoczucie pacjenta przed utratą świadomości można opisać jako " + textBox13.Text + ". "); }
            if (textBox14.Text != "") { raportuj("Samopoczucie pacjenta po utracie i odzyskaniu świadomości można opisać jako " + textBox14.Text + ". "); }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true) { raportuj("Objawom utraty przytomności towarzyszyły: "); } else { if (textBox15.Text == "") { raportuj("Utracie przytomności nie towarzyszyły żadne dodatkowe objawy. "); } else { raportuj(textBox15.Text); } }
            bool pierwszy = false;
            if (checkBox1.Checked == true) { raportuj("przygryzanie języka "); pierwszy = true; }
            if (checkBox2.Checked == true) { if (pierwszy == true) { raportuj(", nietrzymanie kału/moczu"); } else { raportuj("nietrzymanie kału/moczu"); pierwszy = true; } }
            if (checkBox3.Checked == true) { if (pierwszy == true) { raportuj(", drgawki"); } else { raportuj("drgawki "); pierwszy = true; } }
            if (checkBox4.Checked == true) { if (pierwszy == true) { raportuj(", nadużywanie alkoholu/narkotyków"); } else { raportuj("nadużywanie alkoholu/narkotyków"); pierwszy = true; } }
            if (checkBox5.Checked == true) { if (pierwszy == true) { raportuj(", uraz głowy"); } else { raportuj("uraz głowy"); pierwszy = true; } }
            if (checkBox6.Checked == true) { if (pierwszy == true) { raportuj(", objawy ze strony układu krążenia"); } else { raportuj("objawy ze strony układu krążenia"); pierwszy = true; } }
            if (checkBox7.Checked == true) { if (pierwszy == true) { raportuj(", objawy ze strony układu oddechowego"); } else { raportuj("objawy ze strony układu oddechowego"); pierwszy = true; } }
            raportuj(". ");
            if (textBox15.Text != "") { raportuj(textBox15.Text + " "); }
            if (checkBox8.Checked == true)
            {
                raportuj("Utratę świadomości zaobserwowali świadkowie/świadek. ");

                if (checkBox9.Checked == true)
                {
                    raportuj("Zbadał/li tętno podczas tego zdarzenia stwierdzając, że " + textBox16.Text + " ");
                }
                if (checkBox10.Checked == true)
                {
                    raportuj("Świadek/świadkowie potwierdzili długość trawnia utraty przytomności. ");
                }
                if (checkBox11.Checked == true)
                {
                    raportuj("Świadków był/było " + numericUpDown1.Value + ". " + textBox17.Text + " ");
                }




            }
            if (textBox18.Text != "") { raportuj(textBox18.Text); }

            HideTabPage(tabPage3); Pokaz(tabPage1);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true) { panel3.Visible = true; } else { panel3.Visible = false; }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true) { label20.Visible = true; textBox19.Visible = true; } else { label20.Visible = false; textBox19.Visible = false; }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            if (zakończonopodstawy == false)
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;

                //przedtem Główne powody wizyty:
                
                bool realizowanopierwszywpis;
                raportuj("objaw " + textBox3.Text + " (");
                realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox4.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox4.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox5.Text != "") { raportuj(", czas trwania: " + textBox5.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox5.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");

            }

            if (comboBox2.Text == "" || comboBox2.Text == "nie dotyczy") { }
            else
            {
                raportuj("Pacjent twierdzi, że uszkodzenie jest " + comboBox2.Text + ". ");
            }
            if (checkBox12.Checked == true)
            {
                raportuj("Podwójne widzenie");
                if (textBox19.Text != "") { raportuj(" (zależność od kierunku spojrzenia: " + textBox19.Text + "). "); } else { raportuj(". "); }
            }
            if (checkBox14.Checked == true) { raportuj("Pacjent ma złudzenia. "); }
            if (textBox20.Text != "") { raportuj(textBox20.Text + " "); }




            HideTabPage(tabPage4); Pokaz(tabPage1);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true) { checkBox19.Visible = true; textBox21.Visible = true; } else { checkBox19.Visible = false; textBox21.Visible = false; }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true) { comboBox4.Visible = true; } else { comboBox4.Visible = false; }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked == true) { comboBox5.Visible = true; } else { comboBox5.Visible = false; }
        }
        bool realizowanopierwszywpis = false;
        private void wylicztext(string info, string text)
        {

            if (realizowanopierwszywpis == true) { if (text != "") { raportuj(", " + info + ": " + text + " "); } } else { if (text != "") { raportuj(info + ": " + text); realizowanopierwszywpis = true; } }



        }
        private void wylicztext(string text) { if (realizowanopierwszywpis == true) { if (text != "") { raportuj(", " + text); } } else { if (text != "") { raportuj(text); realizowanopierwszywpis = true; } } }
        private void button7_Click_2(object sender, EventArgs e)
        {
            if (zakończonopodstawy == false)
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;

                //przedtem Główne powody wizyty:
                raportuj("objaw " + textBox3.Text + " (");
                realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox4.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox4.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox5.Text != "") { raportuj(", czas trwania: " + textBox5.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox5.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");
                button7.Enabled = false;
            }



            raportuj(""); realizowanopierwszywpis = false;
            //przed wyliczaniem zawsze realizowanopierwszywpis = false;
            if (checkBox16.Checked == true)
            {
                wylicztext(checkBox16.Text);
            }
            if (checkBox17.Checked == true)
            {
                wylicztext(checkBox17.Text);
            }
            if (checkBox15.Checked == true)
            {
                wylicztext(checkBox15.Text); if (comboBox4.Text != "inna") { raportuj(": " + comboBox4.Text + " "); }
            }
            if (checkBox18.Checked == true)
            {
                wylicztext(checkBox18.Text); if (checkBox19.Checked == true) { raportuj(checkBox19.Text + ": " + textBox21.Text+" "); }
            }
            if (checkBox20.Checked == true)
            {
                wylicztext(checkBox20.Text);
            } if (checkBox21.Checked == true)
            {
                wylicztext(checkBox21.Text);
            } if (checkBox22.Checked == true)
            {
                wylicztext(checkBox22.Text);
            } if (checkBox23.Checked == true)
            {
                wylicztext(checkBox23.Text);
            }
            if (checkBox24.Checked == true)
            {
                wylicztext(checkBox24.Text); if (comboBox5.Text != "inna") { raportuj(": " + comboBox5.Text + " "); }
            }
            if (textBox22.Text != "") { raportuj(";"+textBox22.Text + " "); }
            HideTabPage(tabPage5); Pokaz(tabPage1);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true) { comboBox3.Visible = true; } else { comboBox3.Visible = false; }

        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true)
            {
                comboBox6.Visible = true;
                comboBox7.Visible = true; comboBox8.Visible = true;
            }
            else
            {
                comboBox6.Visible = false;
                comboBox7.Visible = false; comboBox8.Visible = false;
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (zakończonopodstawy == false)
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;

                //przedtem Główne powody wizyty:
                raportuj("objaw " + textBox3.Text + " (");
                realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox4.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox4.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox5.Text != "") { raportuj(", czas trwania: " + textBox5.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox5.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");

            }
            raportuj("Pacjent skarży się na ");
            realizowanopierwszywpis = false;
            if (checkBox26.Checked == true)
            {
                wylicztext(checkBox26.Text);
            }
            if (checkBox25.Checked == true)
            {
                wylicztext(checkBox25.Text); raportuj(": "); raportuj(comboBox6.Text + " "); raportuj(comboBox7.Text + " "); raportuj(comboBox8.Text);
            }
            if (checkBox27.Checked == true)
            {
                wylicztext(checkBox26.Text);
            }
            if (textBox23.Text != "") { raportuj("; " + textBox23.Text + " "); }





            HideTabPage(tabPage6); Pokaz(tabPage1);
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox28.Checked == true) { textBox24.Visible = true; } else { textBox24.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true) { textBox25.Visible = true; } else { textBox25.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true) { textBox26.Visible = true; } else { textBox26.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked == true) { textBox27.Visible = true; } else { textBox27.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox33.Checked == true) { textBox28.Visible = true; } else { textBox28.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox34.Checked == true) { textBox29.Visible = true; } else { textBox29.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox35.Checked == true) { textBox30.Visible = true; } else { textBox30.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox36.Checked == true) { textBox31.Visible = true; } else { textBox31.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox37.Checked == true) { textBox32.Visible = true; } else { textBox32.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox38.Checked == true) { textBox33.Visible = true; } else { textBox33.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox39.Checked == true) { textBox34.Visible = true; } else { textBox34.Visible = false; }if (checkBox29.Checked == true) { checkBox28.Checked = false; checkBox30.Checked = false; checkBox31.Checked = false; checkBox32.Checked = false; checkBox33.Checked = false; checkBox34.Checked = false; checkBox35.Checked = false; checkBox36.Checked = false; checkBox37.Checked = false; }
        }
        private void wyliczcheckboxztextem(CheckBox checkBox, TextBox textBox)
        {
            string opis = "";
            if (checkBox.Checked == true)
            {
                if (textBox.Text != "") { opis = " (" + textBox.Text + ")"; } else { opis = ""; }
                wylicztext(checkBox.Text + opis);
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            if (zakończonopodstawy == false)
            {
                zakończonopodstawy = true;
                panel2.Enabled = false;
                panel1.Enabled = true;

                //przedtem Główne powody wizyty:
                raportuj("objaw " + textBox3.Text + " (");
                realizowanopierwszywpis = false;
                if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox4.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox4.Text); realizowanopierwszywpis = true; } }
                if (realizowanopierwszywpis == true) { if (textBox5.Text != "") { raportuj(", czas trwania: " + textBox5.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox5.Text); realizowanopierwszywpis = true; } }
                raportuj("). ");

            }
           
            realizowanopierwszywpis = false;
            if (checkBox29.Checked == true) { }
            else
            {
                string opis; raportuj("Objaw ten może być powiązany z: ");
                if (checkBox28.Checked == true)
                {
                    if (textBox24.Text != "") { opis = " (" + textBox24.Text + ")"; } else { opis = ""; }
                    wylicztext(checkBox28.Text+opis);
                } if (checkBox30.Checked == true)
                {
                    if (textBox25.Text != "") { opis = " (" + textBox25.Text + ")"; } else { opis = ""; }
                    wylicztext(checkBox38.Text + opis);
                }
                wyliczcheckboxztextem(checkBox31, textBox26);
                wyliczcheckboxztextem(checkBox32, textBox27);
                wyliczcheckboxztextem(checkBox33, textBox28);
                wyliczcheckboxztextem(checkBox34, textBox29);
                wyliczcheckboxztextem(checkBox35, textBox30);
                wyliczcheckboxztextem(checkBox36, textBox31);
                wyliczcheckboxztextem(checkBox37, textBox32); raportuj(". ");

                if (checkBox38.Checked == true || checkBox39.Checked == true)
                {
                    raportuj("Stwierdza się "); realizowanopierwszywpis = false;
                    wyliczcheckboxztextem(checkBox38, textBox33);
                    wyliczcheckboxztextem(checkBox39, textBox34); raportuj("objawu. ");
                    
                } HideTabPage(tabPage8); Pokaz(tabPage1);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            raportuj("objaw " + textBox3.Text + " (");
            realizowanopierwszywpis = false;
            if (textBox1.Text != "") { raportuj("czynniki wyzalające: " + textBox1.Text); realizowanopierwszywpis = true; }
            if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj(", początek " + comboBox1.Text + ": " + textBox1.Text); } } else { if (textBox6.Text != "" && comboBox1.Text != "") { raportuj("początek " + comboBox1.Text + ": " + textBox1.Text); realizowanopierwszywpis = true; } }
            if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "nie dotyczy") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
            if (realizowanopierwszywpis == true) { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj(", początek: " + textBox6.Text); } } else { if (textBox6.Text != "" && comboBox1.Text == "") { raportuj("początek: " + textBox6.Text); realizowanopierwszywpis = true; } }
            if (realizowanopierwszywpis == true) { if (textBox2.Text != "") { raportuj(", częstość: " + textBox2.Text); } } else { if (textBox2.Text != "") { raportuj("częstość: " + textBox2.Text); realizowanopierwszywpis = true; } }
            if (realizowanopierwszywpis == true) { if (textBox4.Text != "") { raportuj(", zależność od pory dnia i roku: " + textBox4.Text); } } else { if (textBox4.Text != "") { raportuj("zależność od pory dnia i roku: " + textBox4.Text); realizowanopierwszywpis = true; } }
            if (realizowanopierwszywpis == true) { if (textBox5.Text != "") { raportuj(", czas trwania: " + textBox5.Text); } } else { if (textBox4.Text != "") { raportuj("czas trwania: " + textBox5.Text); realizowanopierwszywpis = true; } }
            raportuj("). ");
            panel2.Enabled = false;
            panel1.Enabled = true;
            butinny.Enabled = false;
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
