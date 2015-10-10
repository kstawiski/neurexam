using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Badanie_Neurologiczne
{
    public partial class Form23 : Form
    {
        public string kreator;
        public Form23()
        {
            InitializeComponent();
            var tabc = tabControl1.TabPages;
            foreach (TabPage t in tabc)
            {
                //HideTabPage(t);
            }
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            ColumnHeader columnheader;		// Used for creating column headers.
            ListViewItem listviewitem;		// Used for creating listview items.

            // Ensure that the view is set to show details.
            listView1.View = View.Details;
            if (kreator == "kgorna") { listView2.Size = new Size(listView2.Size.Width, 163); groupBox1.Visible = true; groupBox2.Visible = false; ruchykgornej(); odruchykgornej(); HideTabPage(tabPage5); }
            if (kreator == "kdolna") { listView2.Size = new Size(listView2.Size.Width, 264); groupBox1.Visible = false; groupBox2.Visible = true; ruchykdolnej(); odruchykdolnej(); HideTabPage(tabPage4); }


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
        private void Form23_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            { checkedListBox1.SetItemChecked(i, true); }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            { checkedListBox2.SetItemChecked(i, true); }
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            { checkedListBox3.SetItemChecked(i, true); }
            for (int i = 0; i < checkedListBox4.Items.Count; i++)
            { checkedListBox4.SetItemChecked(i, true); }

            if (kreator == "kgorna") { listView2.Size = new Size(listView2.Size.Width, 163); groupBox1.Visible = true; groupBox2.Visible = false; ruchykgornej(); odruchykgornej(); HideTabPage(tabPage5); }
            if (kreator == "kdolna") { listView2.Size = new Size(listView2.Size.Width, 264); groupBox1.Visible = false; groupBox2.Visible = true; ruchykdolnej(); odruchykdolnej(); HideTabPage(tabPage4); }







            //testowo:::::::::::::::::::::::::::::::::::
            var tabc = tabControl1.TabPages;
            //foreach (TabPage t in tabc)
            //{
            //    ShowTabPage(t);
            //}
            //ruchykgornej();


            foreach (TabPage tp in tabControl1.Controls.OfType<TabPage>())
            {
                foreach (TextBox t in tp.Controls.OfType<TextBox>())
                {
                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + kreator + t.Name;

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

        private void button2_Click(object sender, EventArgs e)
        {
            ///textBox10.Text += button2.Text + " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //textBox10.Text += button4.Text + " ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // textBox10.Text += button5.Text + " ";
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            // if (checkBox10.Checked) { button2.Enabled = true; button4.Enabled = true; button5.Enabled = true; textBox10.Enabled = true; }
            //if (!checkBox10.Checked) { button2.Enabled = !true; button4.Enabled = !true; button5.Enabled = !true; textBox10.Enabled = !true; }
        }
        public void dodajodruch(string problem, string opis)
        {
            //                                  LEWA
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "LEWA: " + problem;
            //lvi.Group = listView1.Groups[kategoria];
            //aktywność
            //string aktywny_txt = "Nie";
            //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
            //lvi.SubItems.Add(aktywny_txt);
            //opis
            lvi.SubItems.Add(opis);
            lvi.SubItems.Add("prawidłowe");
            lvi.ToolTipText = problem;
            listView2.Items.Add(lvi);
            //                                  PRAWA
            ListViewItem lvi2 = new ListViewItem();
            lvi2.Text = "PRAWA: " + problem;
            //lvi.Group = listView1.Groups[kategoria];
            //aktywność
            //string aktywny_txt = "Nie";
            //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
            //lvi.SubItems.Add(aktywny_txt);
            //opis
            lvi2.SubItems.Add(opis);
            lvi2.SubItems.Add("prawidłowe");
            lvi2.ToolTipText = problem;
            listView2.Items.Add(lvi2);
        }
        public void dodajruch(string problem, string opis)
        {
            //                                  LEWA
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "LEWA: " + problem;
            //lvi.Group = listView1.Groups[kategoria];
            //aktywność
            //string aktywny_txt = "Nie";
            //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
            //lvi.SubItems.Add(aktywny_txt);
            //opis
            lvi.SubItems.Add(opis);
            lvi.SubItems.Add("prawidłowe");
            lvi.ToolTipText = problem;
            listView1.Items.Add(lvi);
            //                                  PRAWA
            ListViewItem lvi2 = new ListViewItem();
            lvi2.Text = "PRAWA: " + problem;
            //lvi.Group = listView1.Groups[kategoria];
            //aktywność
            //string aktywny_txt = "Nie";
            //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
            //lvi.SubItems.Add(aktywny_txt);
            //opis
            lvi2.SubItems.Add(opis);
            lvi2.SubItems.Add("prawidłowe");
            lvi2.ToolTipText = problem;
            listView1.Items.Add(lvi2);
        }
        public void odruchykgornej()
        {
            listView2.Items.Clear();
            
            dodajodruch("odruch z m. ramienno-promieniowego (C5/6)", "++ (odruch prawidłowy)");
            dodajodruch("odruch z m. dwugłowego ramienia (C5/6)", "++ (odruch prawidłowy)");
            dodajodruch("odruch z m. trójgłowego ramienia (C6/7)", "++ (odruch prawidłowy)");
            dodajodruch("odruch z m. piersiowego większego (C7/8)", "nie sprawdzony");
            dodajodruch("odruch zgięcia palców Trommera-Hoffmanna", "odruch patologiczny nieobecny");
        }
        public void odruchykdolnej()
        {
            listView2.Items.Clear();
            dodajodruch("odruch z mm. przywodzicieli (L2/3)", "++ (odruch prawidłowy)");
            dodajodruch("odruch kolanowy (L2/3/4)", "++ (odruch prawidłowy)");
            dodajodruch("odruch skokowy (S1)", "++ (odruch prawidłowy)");
            dodajodruch("odruch brzuszny z dolnego łuku ostatnich żeber (T8/9)", "++ (odruch prawidłowy)");
            dodajodruch("odruch brzuszny z na wysokości pępka (T10)", "++ (odruch prawidłowy)");
            dodajodruch("odruch brzuszny z na wysokości więzadła pachwinowego (T11/12)", "++ (odruch prawidłowy)");
            dodajodruch("objaw Babińskiego", "odruch patologiczny nieobecny");
            dodajodruch("objaw Chaddocka", "odruch patologiczny nieobecny");
            dodajodruch("objaw Oppenheima", "odruch patologiczny nieobecny");
            dodajodruch("objaw Rossolimo", "odruch patologiczny nieobecny");
        }
        public void ruchykgornej()
        {
            listView1.Items.Clear();
            dodajruch("odwodzenie ramienia (drugie 45 stopni, C5, n. pachowy, m. naramienny)", "MRC 5");
            dodajruch("odwodzenie ramienia (pierwsze 45 stopni, C5, n. nadłopatkowy, m. nadgrzebieniowy)", "MRC 5");
            dodajruch("rotacja zewnętrzna ramienia (C5, n. nadłopatkowy/pachowy, m. nadgrzebieniowy/podgrzebieniowy/obły mniejszy)", "MRC 5");
            dodajruch("rotacja wewnętrzna ramienia (C5, n. podłopatkowy, m. podłopatkowy/obły mniejszy)", "MRC 5");
            dodajruch("przywodzenie ramienia (C7, n. piersiowo-grzbietowy/piersiowe, m. najszerszy grzebietu/piersiowy większy)", "MRC 5");

            dodajruch("zginanie łokcia w supinacji (C5/6, n. mieśniowo-skórny, m. dwugłowy ramienia)", "MRC 5");
            dodajruch("zginanie łokcia w pronacji (C6, n. promieniowy, m. ramienno-promieniowy)", "MRC 5");
            dodajruch("supinacja przedramienia (C6, n. promieniowy, m. odwracacz)", "MRC 5");
            dodajruch("pronacja przedramienia (C6, n. pośrodkowy, m. nawrotny obły/nawrotny czworoboczny)", "MRC 5");
            dodajruch("prostowanie łokcia (C6/7, n. promieniowy, m. trójgłowy ramienia)", "MRC 5");

            dodajruch("prostowanie nadgarstka (C6/7, n. promieniowy, m. prostowniki przedramienia)", "MRC 5");
            dodajruch("zginanie nadgarstka (C7/8, n. pośrodkowy/łokciowy, m. zginacze przedramienia)", "MRC 5");
            dodajruch("zginanie palców (paliczki dalsze) (C8, palec II i III - n. pośrodkowy, palec IV i V - n. łokciowy, m. zginacz głęboki palców)", "MRC 5");
            dodajruch("prostowanie palców (C8, n. promieniowy)", "MRC 5");
            dodajruch("zwarcie kciuka i wskaziciela (paliczki dalsze) (C8, n. pośrodkowy, m. zginacz długi kciuka i wskaziciela)", "MRC 5");
            dodajruch("odwodzenie kciuka (Th1, n. pośrodkowy, m. odwodziciel krótki kciuka)", "MRC 5");
            dodajruch("odwodzenie i przywodzenie palców (Th1, n. łokciowy, m. międzykostne i odwodziciel palca V)", "MRC 5");


        }
        public void ruchykdolnej()
        {
            listView1.Items.Clear();
            dodajruch("zginanie uda (L2/3, bezpośrednio i n. udowy, m. biodrowo-lędźwiowy", "MRC 5");
            dodajruch("prostowanie kolana (L2/3, n. udowy, m. czworogłowy", "MRC 5");
            dodajruch("przywodzenie uda (L2/3, n. zasłonowy, mm. przywodziciele uda", "MRC 5");
            dodajruch("odwodzenie uda (L4/5, nn. pośladkowe, mm. pośladkowe i napinacz powięzi szerokiej", "MRC 5");
            dodajruch("prostowanie uda (L4/5, nn. pośladkowe, mm. pośladkowe", "MRC 5");
            dodajruch("zginanie kolana (L5/S1, n. kulszowy, m. półbłoniasty/półścięgnisty/głowa krótka dwugłowego uda", "MRC 5");

            dodajruch("supinacja stopy (L4, n. piszczelony/strzałkowy, m. piszczelowy przedni i tylny", "MRC 5");
            dodajruch("zginanie grzbietowe stopy (L4/5, n. strzałkowy, m. piszczelowy przedni/długie prostowniki palców/prostownik krótki palców", "MRC 5");
            dodajruch("zginanie grzbietowe palucha (L5, n. strzałkowy, m. prostownik krótki i długi palucha", "MRC 5");
            dodajruch("pronacja stopy (S1, n. strzałkowy, mm. strzałkowe", "MRC 5");
            dodajruch("zginanie podeszwowe stopy (S1/2, n. piszczelowy, m. trójgłowy łydki", "MRC 5");


        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
        bool uwagi = false;
        public string katalogpacjenta; public string podstawaurl;
        private void textBox11_Click(object sender, EventArgs e)
        {
            if (uwagi == false) { textBox11.Text = ""; textBox11.Focus(); uwagi = true; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.Checked == true) { i.SubItems[1].Text = comboBox3.Text; }


                }
            }
            else { MessageBox.Show("Na jakie MRC mam zmienić???"); }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Selected == true) { i.Selected = false; if (i.Checked == false) { i.Checked = true; } else { i.Checked = false; } }


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { textBox1.Enabled = true; } else { textBox1.Enabled = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { textBox2.Enabled = true; } else { textBox2.Enabled = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) { textBox3.Enabled = true; } else { textBox3.Enabled = false; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) { textBox4.Enabled = true; } else { textBox4.Enabled = false; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { textBox5.Enabled = true; comboBox1.Enabled = true; comboBox2.Enabled = true; } else { textBox5.Enabled = false; comboBox1.Enabled = false; comboBox2.Enabled = false; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true) { textBox6.Enabled = true; } else { textBox6.Enabled = false; }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true) { textBox7.Enabled = true; } else { textBox7.Enabled = false; }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true) { textBox8.Enabled = true; } else { textBox8.Enabled = false; }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true) { textBox9.Enabled = true; } else { textBox9.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Na pewno zakończyć badanie?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (kreator == "kgorna")
                {
                    using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html"))
                    {
                        writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><br><strong><u>BADANIE KOŃCZYN GÓRNYCH:</strong></u><br>");

                        if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false)
                        {
                            writer.Write("<b>1. Oglądanie i palpacja</b> - bez odchyleń od normy<br>");
                        }
                        else
                        {
                            writer.Write("<b>1. Oglądanie i palpacja</b> - ");
                            if (checkBox1.Checked == true) { string t; if (textBox1.Text != "") { t = " (" + textBox1.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox1.Text + "</u>" + t + ", "); }
                            if (checkBox2.Checked == true) { string t; if (textBox2.Text != "") { t = " (" + textBox2.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox2.Text + "</u>" + t + ", "); }
                            if (checkBox3.Checked == true) { string t; if (textBox3.Text != "") { t = " (" + textBox3.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox3.Text + "</u>" + t + ", "); }
                            if (checkBox4.Checked == true) { string t; if (textBox4.Text != "") { t = " (" + textBox4.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox4.Text + "</u>" + t + ", "); }
                            if (checkBox5.Checked == true)
                            {

                                string t = "";
                                if (comboBox1.Text != "" || comboBox2.Text != "" || textBox5.Text != "")
                                {
                                    t = " (";
                                    if (comboBox1.Text != "") { t += comboBox1.Text; }
                                    if (comboBox2.Text != "") { t += ", " + comboBox2.Text; }
                                    if (textBox5.Text != "") { t += ", " + textBox5.Text; }
                                    t += "),";

                                }
                                writer.Write("<u>" + checkBox5.Text + "</u>" + t + ", ");

                            }
                            if (checkBox6.Checked == true) { string t; if (textBox6.Text != "") { t = " (" + textBox6.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox6.Text + "</u>" + t + ", "); }
                            if (checkBox7.Checked == true) { string t; if (textBox7.Text != "") { t = " (" + textBox7.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox7.Text + "</u>" + t + ", "); }
                            if (checkBox8.Checked == true) { string t; if (textBox8.Text != "") { t = " (" + textBox8.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox8.Text + "</u>" + t + ", "); }
                            if (checkBox9.Checked == true) { if (textBox9.Text != "") { writer.Write("<u>" + checkBox9.Text + "</u>"); } }
                        }
                        string uwagi;
                        if (textBox11.Text == "" || textBox11.Text == "uwagi") { uwagi = "brak uwag"; } else { uwagi = textBox11.Text; }
                        writer.Write("<br><b>2. Ruchy bierne i czynne</b><br /><table border=\"1\"><thead><tr><th>Rodzaj ruchu</th><th>Ocena MRC</th><th>Ocena ruchu biernego</th></tr></thead><tfoot><tr><td>" + uwagi + "</td></tr></tfoot><tbody>");
                        foreach (ListViewItem i in listView1.Items)
                        {
                            writer.Write("<tr><td>" + i.SubItems[0].Text + "</td><td>" + i.SubItems[1].Text + "</td><td>" + i.SubItems[2].Text + "</td></tr>");
                        }
                        writer.Write("</tbody></table><br>");
                        writer.Write("<br><b>3. Odruchy i zborność ruchów</b><br /><table border=\"1\"><thead><tr><th>Odruch</th><th>Ocena</th></tr></thead><tbody>");
                        foreach (ListViewItem i in listView2.Items)
                        {
                            writer.Write("<tr><td>" + i.SubItems[0].Text + "</td><td>" + i.SubItems[1].Text + "</td></tr>");
                        }
                        writer.Write("</tbody></table><br>");
                        //dot. tylko k.gornej
                        if (checkBox14.Checked == true) { string t; if (textBox12.Text != "") { t = " - " + textBox12.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox14.Text + "</u>" + t + ", "); }
                        if (checkBox15.Checked == true) { string t; if (textBox13.Text != "") { t = " - " + textBox13.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox15.Text + "</u>" + t + ", "); }
                        if (checkBox16.Checked == true) { string t; if (textBox14.Text != "") { t = " - " + textBox14.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox16.Text + "</u>" + t + ", "); }
                        if (checkBox17.Checked == true) { string t; if (textBox15.Text != "") { t = " - " + textBox15.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox17.Text + "</u>" + t + ", "); }
                        if (textBox16.Text == "" || textBox16.Text == "uwagi") { } else { writer.Write("<br />" + textBox16.Text); }
                        writer.Write("<br><b>4. Czucie</b><br /><table border=\"1\"><tbody><tr><td><img width= \"100%\" src=\"" + podstawaurl + "obrazki/czucie_gora.jpg\"></td><td>");
                        if (checkBox10.Checked == true) { writer.Write(checkBox10.Text + ", "); } else { writer.Write("<u>czucie ułożenia nieprawidłowe po stronie prawej</u>, "); }
                        if (checkBox11.Checked == true) { writer.Write(checkBox11.Text + ", "); } else { writer.Write("<u>czucie ułożenia nieprawidłowe po stronie lewej</u>, "); }
                        if (checkBox12.Checked == true) { writer.Write(checkBox12.Text + ", "); } else { writer.Write("<u>czucie wibracji nieprawidłowe po stronie prawej</u>, "); }
                        if (checkBox13.Checked == true) { writer.Write(checkBox13.Text + ""); } else { writer.Write("<u>czucie wibracji nieprawidłowe po stronie lewej</u>"); }
                        if (textBox10.Text == "" || textBox10.Text == "uwagi") { writer.Write("</td></tr></table>"); } else { writer.Write("<br />" + textBox10.Text + "</td></tr></table>"); }

                    }
                }

                if (kreator == "kdolna")
                {
                    using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html"))
                    {
                        writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>BADANIE KOŃCZYN DOLNYCH I TUŁOWIA:</strong></u><br>");

                        if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false)
                        {
                            writer.Write("<b>1. Oglądanie i palpacja</b> - bez odchyleń od normy<br>");
                        }
                        else
                        {
                            writer.Write("<b>1. Oglądanie i palpacja</b> - ");
                            if (checkBox1.Checked == true) { string t; if (textBox1.Text != "") { t = " (" + textBox1.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox1.Text + "</u>" + t + ", "); }
                            if (checkBox2.Checked == true) { string t; if (textBox2.Text != "") { t = " (" + textBox2.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox2.Text + "</u>" + t + ", "); }
                            if (checkBox3.Checked == true) { string t; if (textBox3.Text != "") { t = " (" + textBox3.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox3.Text + "</u>" + t + ", "); }
                            if (checkBox4.Checked == true) { string t; if (textBox4.Text != "") { t = " (" + textBox4.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox4.Text + "</u>" + t + ", "); }
                            if (checkBox5.Checked == true)
                            {

                                string t = "";
                                if (comboBox1.Text != "" || comboBox2.Text != "" || textBox5.Text != "")
                                {
                                    t = " (";
                                    if (comboBox1.Text != "") { t += comboBox1.Text; }
                                    if (comboBox2.Text != "") { t += ", " + comboBox2.Text; }
                                    if (textBox5.Text != "") { t += ", " + textBox5.Text; }
                                    t += "),";

                                }
                                writer.Write("<u>" + checkBox5.Text + "</u>" + t + ", ");

                            }
                            if (checkBox6.Checked == true) { string t; if (textBox6.Text != "") { t = " (" + textBox6.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox6.Text + "</u>" + t + ", "); }
                            if (checkBox7.Checked == true) { string t; if (textBox7.Text != "") { t = " (" + textBox7.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox7.Text + "</u>" + t + ", "); }
                            if (checkBox8.Checked == true) { string t; if (textBox8.Text != "") { t = " (" + textBox8.Text + ")"; } else { t = ""; }; writer.Write("<u>" + checkBox8.Text + "</u>" + t + ", "); }
                            if (checkBox9.Checked == true) { if (textBox9.Text != "") { writer.Write("<u>" + checkBox9.Text + "</u>"); } }
                        }
                        string uwagi;
                        if (textBox11.Text == "" || textBox11.Text == "uwagi") { uwagi = "brak uwag"; } else { uwagi = textBox11.Text; }
                        writer.Write("<br><b>2. Ruchy bierne i czynne</b><br /><table border=\"1\"><thead><tr><th>Rodzaj ruchu</th><th>Ocena MRC</th><th>Ocena ruchu biernego</th></tr></thead><tfoot><tr><td>" + uwagi + "</td></tr></tfoot><tbody>");
                        foreach (ListViewItem i in listView1.Items)
                        {
                            writer.Write("<tr><td>" + i.SubItems[0].Text + "</td><td>" + i.SubItems[1].Text + "</td><td>" + i.SubItems[2].Text + "</td></tr>");
                        }
                        writer.Write("</tbody></table><br>");
                        writer.Write("<br><b>3. Odruchy i zborność ruchów</b><br /><table border=\"1\"><thead><tr><th>Odruch</th><th>Ocena</th></tr></thead><tbody>");
                        foreach (ListViewItem i in listView2.Items)
                        {
                            writer.Write("<tr><td>" + i.SubItems[0].Text + "</td><td>" + i.SubItems[1].Text + "</td></tr>");
                        }
                        writer.Write("</tbody></table><br>");
                        //dot. tylko k.dol
                        if (checkBox25.Checked == true) { string t; if (textBox22.Text != "") { t = " - " + textBox22.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox25.Text + "</u>" + t + ", "); }
                        //if (checkBox15.Checked == true) { string t; if (textBox13.Text != "") { t = " - " + textBox13.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox15.Text + "</u>" + t + ", "); }
                        //if (checkBox16.Checked == true) { string t; if (textBox14.Text != "") { t = " - " + textBox14.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox16.Text + "</u>" + t + ", "); }
                        //if (checkBox17.Checked == true) { string t; if (textBox15.Text != "") { t = " - " + textBox15.Text; } else { t = ""; }; writer.Write("<br /><u>" + checkBox17.Text + "</u>" + t + ", "); }
                        if (textBox18.Text == "" || textBox18.Text == "uwagi") { } else { writer.Write("<br />" + textBox18.Text); }
                        writer.Write("<br><b>4. Czucie</b><br /><table border=\"1\"><tbody><tr><td><img width= \"100%\" src=\"" + podstawaurl + "obrazki/czucie_dol.jpg\"></td><td>");
                        if (checkBox21.Checked == true) { writer.Write(checkBox10.Text + ", "); } else { writer.Write("<u>czucie ułożenia nieprawidłowe po stronie prawej</u>, "); }
                        if (checkBox20.Checked == true) { writer.Write(checkBox11.Text + ", "); } else { writer.Write("<u>czucie ułożenia nieprawidłowe po stronie lewej</u>, "); }
                        if (checkBox19.Checked == true) { writer.Write(checkBox12.Text + ", "); } else { writer.Write("<u>czucie wibracji nieprawidłowe po stronie prawej</u>, "); }
                        if (checkBox18.Checked == true) { writer.Write(checkBox13.Text + ""); } else { writer.Write("<u>czucie wibracji nieprawidłowe po stronie lewej</u>"); }
                        if (textBox17.Text == "" || textBox17.Text == "uwagi") { writer.Write("</td></tr></tbody></table>"); } else { writer.Write("<br />" + textBox17.Text + "</td></tr></tbody></table>"); }
                        //writer.Write("</tbody></table><br>");



                    }
                }
























                DialogResult = DialogResult.OK;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Na pewno anulować badanie? Dane zostaną utracone.", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        private ListViewColumnSorter lvwColumnSorter;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.Checked == true) { i.SubItems[2].Text = comboBox4.Text; }


                }
            }
            else { MessageBox.Show("Jaki jest ten ruch bierny???"); }
        }

        private void checkedListBox2_MouseLeave(object sender, EventArgs e)
        {
            checkedListBox2.SelectedIndex = -1; checkedListBox1.SelectedIndex = -1;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_MouseLeave(object sender, EventArgs e)
        {
            checkedListBox1.SelectedIndex = -1; checkedListBox2.SelectedIndex = -1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                foreach (ListViewItem i in listView2.Items)
                {
                    if (i.Checked == true) { i.SubItems[1].Text = comboBox5.Text; }


                }
            }
            else { MessageBox.Show("pusto???"); }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true) { textBox12.Enabled = true; } else { textBox12.Enabled = false; }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true) { textBox13.Enabled = true; } else { textBox13.Enabled = false; }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked == true) { textBox14.Enabled = true; } else { textBox14.Enabled = false; }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true) { textBox15.Enabled = true; } else { textBox15.Enabled = false; }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == true) { textBox22.Enabled = true; } else { textBox22.Enabled = false; }
        }
        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }
        private void tabPage4_MouseLeave(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            bounds.Location = pictureBox1.Location;
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Size s = new Size();
                    //s.Width = pictureBox2.Width; s.Height = pictureBox2.Height;
                    //g.CopyFromScreen(pictureBox2.Location.X, pictureBox2.Location.Y, 100, 100, s);
                    g.CopyFromScreen(new Point(this.Left, this.Top), Point.Empty, this.Size);
                }
                //Rectangle rect = new Rectangle(p.Location.X, p.Location.Y, p.Width, p.Height );
                //Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
                //Bitmap n = CropBitmap(bitmap,p.Location.X, p.Location.Y, p.Width, p.Height);
                int x = tabControl1.Location.X + pictureBox1.Location.X + 2;
                int y = tabControl1.Location.Y + 55 + pictureBox1.Location.Y;
                int w = pictureBox1.Size.Width;
                int h = pictureBox1.Size.Height;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);

                //MessageBox.Show(Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //string adres = Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg";
                //adres = adres.Replace("\\", "/");
                //adres = adres.Insert(3, "\\");

                //string adres = Path.Combine(Application.StartupPath, katalogpacjenta, "obrazy\\uszkodzenie_NCII.jpg"); //MessageBox.Show(adres);

                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                //bitmap.Dispose();
                //string adres=Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg";
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\czucie_gora.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");
                //label6.Visible = true;
            }
        }

        private void tabPage5_MouseLeave(object sender, EventArgs e)
        {
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Size s = new Size();
                    //s.Width = pictureBox2.Width; s.Height = pictureBox2.Height;
                    //g.CopyFromScreen(pictureBox2.Location.X, pictureBox2.Location.Y, 100, 100, s);
                    g.CopyFromScreen(new Point(this.Left, this.Top), Point.Empty, this.Size);
                }
                //Rectangle rect = new Rectangle(p.Location.X, p.Location.Y, p.Width, p.Height );
                //Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
                //Bitmap n = CropBitmap(bitmap,p.Location.X, p.Location.Y, p.Width, p.Height);
                int x = tabControl1.Location.X + label10.Location.X + 2;
                int y = tabControl1.Location.Y + 55 + pictureBox2.Location.Y;
                int w = pictureBox2.Size.Width + 140;
                int h = pictureBox2.Size.Height - 3;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);

                //MessageBox.Show(Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //string adres = Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg";
                //adres = adres.Replace("\\", "/");
                //adres = adres.Insert(3, "\\");

                //string adres = Path.Combine(Application.StartupPath, katalogpacjenta, "obrazy\\uszkodzenie_NCII.jpg"); //MessageBox.Show(adres);

                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                //bitmap.Dispose();
                //string adres=Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg";
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\czucie_dol.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");
                //label6.Visible = true;
            }
        }

        private void tabPage5_DragLeave(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_MouseLeave(object sender, EventArgs e)
        {
            checkedListBox3.SelectedIndex = -1; checkedListBox4.SelectedIndex = -1;
        }

        private void checkedListBox3_MouseLeave(object sender, EventArgs e)
        {
            checkedListBox3.SelectedIndex = -1; checkedListBox4.SelectedIndex = -1;
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
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
            this.listView2.Sort();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView2.Items)
            {
                if (i.Selected == true) { i.Selected = false; if (i.Checked == false) { i.Checked = true; } else { i.Checked = false; } }


            }
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                foreach (ListViewItem i in listView2.Items)
                {
                    if (i.Checked == true) { i.SubItems[1].Text = comboBox5.Text; }


                }
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView2.Items)
            {
                if (i.Checked == true) { i.Checked = false; }


            }
            comboBox5.Text = "";
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.Checked == true) { i.SubItems[2].Text = comboBox4.Text; }


                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Checked == true) { i.Checked = false; }


            }
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.Checked == true) { i.SubItems[1].Text = comboBox3.Text; }


                }
            }
        }

        private void Form23_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tp in tabControl1.Controls.OfType<TabPage>())
            {
                foreach (TextBox t in tp.Controls.OfType<TextBox>())
                {
                    string identyfikacja = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto\\" + this.Name + kreator + t.Name;
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


    }
}
