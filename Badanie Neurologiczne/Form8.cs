using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
//using System.Data.SQLite;



namespace Badanie_Neurologiczne
{
    


    public partial class Form8 : Form
    {
        //EWALUACJA CZASU
    public string d_rozpoczecia = "";
    
    public string d_rglasgow = "";
    public string d_kglasgow = "";

    public string d_rmmse = "";
    public string d_kmmse = "";

    public string d_zaketap1 = "";

    public string d_rwsocj = "";
    public string d_kwsocj = "";

    public string d_rpukl = "";
    public string d_kpukl = "";

    public string d_zaketap2 = "";

    public string d_zaknc = "";
    public string d_zakg = "";
    public string d_zakd = "";
    public string d_roznc = "";
    public string d_rozg = "";
    public string d_rozd = "";
    public string d_zakonczenia = "";




        //parametryzacja
    public void parametrdodajnast(string nazwa, string typ, string wynik, string jednostka, DateTime data)
    {
        if (nazwa.Contains('\n')) { nazwa = nazwa.Replace('\n', '|'); }
        if (nazwa.Contains('\r')) { nazwa = nazwa.Replace('\r', '|'); }
        if (wynik.Contains('\n')) { wynik = wynik.Replace('\n', '|'); }
        if (wynik.Contains('\r')) { wynik = wynik.Replace('\r', '|'); }
        if (jednostka.Contains('\n')) { jednostka = jednostka.Replace('\n', '|'); }
        if (jednostka.Contains('\r')) { jednostka = jednostka.Replace('\r', '|'); }
        bool korekta = false;
        if (katalogpacjenta.Substring(katalogpacjenta.Length - 1, 1) != "\\") { korekta = true; katalogpacjenta = katalogpacjenta + "\\"; }
        List<string> parametry = new List<string>();
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry")
    )
        {
            foreach (string line in File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry"))
            { parametry.Add(line); }

            
        }
        parametry.Add(nazwa + "\t" + typ + "\t" + wynik + "\t" + jednostka + "\t" + data);
        File.WriteAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry", parametry);
        if (korekta == true) { katalogpacjenta = katalogpacjenta.Substring(1, katalogpacjenta.Length - 1); }
    }
        
        
        public void parametrdodaj(string nazwa, string typ, string wynik, string jednostka, DateTime data) 
    {
        if (nazwa.Contains('\n')) { nazwa = nazwa.Replace('\n', '|'); }
        if (nazwa.Contains('\r')) { nazwa = nazwa.Replace('\r', '|'); }
        if (wynik.Contains('\n')) { wynik = wynik.Replace('\n', '|'); }
        if (wynik.Contains('\r')) { wynik = wynik.Replace('\r', '|'); }
        if (jednostka.Contains('\n')) { jednostka = jednostka.Replace('\n', '|'); }
        if (jednostka.Contains('\r')) { jednostka = jednostka.Replace('\r', '|'); }
        bool korekta = false;
        if (katalogpacjenta.Substring(katalogpacjenta.Length - 1, 1) != "\\") { korekta = true;  katalogpacjenta = katalogpacjenta + "\\"; }
        List <string> parametry = new List<string>();
    if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry")
) {
    foreach (string line in File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry"))
    { parametry.Add(line); }
    
        //Jeśli już istnieje taki to go wywal
        if (parametry.Count > 0)
    {
        for (int i = 0; i < parametry.Count; i++)
        {
            string[] czesc = parametry[i].Split('\t');
            if (czesc[0] == nazwa)
            {
                if (czesc[4] == data.ToString())
                {
                    parametry.Remove(parametry[i]);
                }
            }
        }
    }
    }
    parametry.Add(nazwa + "\t" + typ + "\t" + wynik + "\t" + jednostka + "\t" + data);
    File.WriteAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry", parametry);
    if (korekta == true) { katalogpacjenta = katalogpacjenta.Substring(1, katalogpacjenta.Length - 1); }
    }

    public void parametrusuńjeden(string nazwa, DateTime data)
    {
        bool korekta = false;
        if (katalogpacjenta.Substring(katalogpacjenta.Length - 1, 1) != "\\") { korekta = true; katalogpacjenta = katalogpacjenta + "\\"; }
        List<string> parametry = new List<string>();
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry")
    )
        {
            foreach (string line in File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry"))
            { parametry.Add(line); }

        }
        if (parametry.Count > 0)
        {
            for (int i = 0; i < parametry.Count; i++)
            {
                string[] czesc = parametry[i].Split('\t');
                if (czesc[0] == nazwa)
                {
                    if (czesc[4] == data.ToString()) { parametry.Remove(parametry[i]); }
                }
            }

                File.WriteAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry", parametry);
            
        }
        if (korekta == true) { katalogpacjenta = katalogpacjenta.Substring(1, katalogpacjenta.Length - 1); }
    }

    public void parametrusuńwszystko(string nazwa)
    {
        bool korekta = false;
        if (katalogpacjenta.Substring(katalogpacjenta.Length - 1, 1) != "\\") { korekta = true;  katalogpacjenta = katalogpacjenta + "\\"; }
        List<string> parametry = new List<string>();
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry")
    )
        {
            foreach (string line in File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry"))
            { parametry.Add(line); }

        }
        if (parametry.Count > 0)
        {
            for (int i = 0; i < parametry.Count; i++)
            {
                string[] czesc = parametry[i].Split('\t');
                if (czesc[0] == nazwa)
                {
                    parametry.Remove(parametry[i]);
                }
            }

            File.WriteAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry", parametry);

        }
        if (korekta == true) { katalogpacjenta = katalogpacjenta.Substring(1, katalogpacjenta.Length - 1); }
    }

    public void parametraktualizuj(string nazwa, DateTime data, int co, string naco)
    {
        if (naco.Contains('\n')) { naco = naco.Replace('\n', '|'); }
        if (naco.Contains('\r')) { naco = naco.Replace('\r', '|'); }
        
        
        bool korekta = false;
        if (katalogpacjenta.Substring(katalogpacjenta.Length - 1, 1) != "\\") { katalogpacjenta = katalogpacjenta + "\\"; korekta = true; }
        List<string> parametry = new List<string>();
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry")
    )
        {
            foreach (string line in File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry"))
            { parametry.Add(line); }

        }
        if (parametry.Count > 0)
        {
            for (int i=0; i<parametry.Count; i++){
                string[] czesc = parametry[i].Split('\t');
                if (czesc[0] == nazwa)
                {
                    if (czesc[4] == data.ToString()) {
                        if (co == 0) { parametry[i] = naco + "\t" + czesc[1] + "\t" + czesc[2] + "\t" + czesc[3] + "\t" + czesc[4]; }
                        if (co == 1) { parametry[i] = czesc[0] + "\t" + naco + "\t" + czesc[2] + "\t" + czesc[3] + "\t" + czesc[4]; }
                        if (co == 2) { parametry[i] = czesc[0] + "\t" + czesc[1] + "\t" + naco + "\t" + czesc[3] + "\t" + czesc[4]; }
                        if (co == 3) { parametry[i] = czesc[0] + "\t" + czesc[1] + "\t" + czesc[2] + "\t" + naco + "\t" + czesc[4]; }
                        if (co == 4) { parametry[i] = czesc[0] + "\t" + czesc[1] + "\t" + czesc[2] + "\t" + czesc[3] + "\t" + naco; }
                    
                    }
                }
            }

            File.WriteAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry", parametry);
            if (korekta == true) { katalogpacjenta = katalogpacjenta.Substring(1, katalogpacjenta.Length - 1); } 
        }
    }
    public string parametrodczytaj(string nazwa, DateTime data, int co)
    {
        string odczyt = "";
        bool korekta = false;
        if (katalogpacjenta.Substring(katalogpacjenta.Length - 1, 1) != "\\") { katalogpacjenta = katalogpacjenta + "\\"; korekta = true; }
        List<string> parametry = new List<string>();
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry")
    )
        {
            foreach (string line in File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry"))
            { parametry.Add(line); }

        }
        if (parametry.Count > 0)
        {
            for (int i = 0; i < parametry.Count; i++)
            {
                string[] czesc = parametry[i].Split('\t');
                if (czesc[0] == nazwa)
                {
                    if (czesc[4] == data.ToString())
                    {
                        if (co == 0) { odczyt = czesc[0]; }
                        if (co == 1) { odczyt = czesc[1]; }
                        if (co == 2) { odczyt = czesc[2]; }
                        if (co == 3) { odczyt = czesc[3]; }
                        if (co == 4) { odczyt = czesc[4]; }

                    }
                }
            }

            //File.WriteAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry", parametry);
           





            
        } 
        if (korekta == true) { katalogpacjenta = katalogpacjenta.Substring(1, katalogpacjenta.Length - 1); }
        return odczyt;
    }
    public string parametrodczytajostatni(string nazwa, int co)
    {
        string odczyt = "";
        bool korekta = false;
        if (katalogpacjenta.Substring(katalogpacjenta.Length - 1, 1) != "\\") { katalogpacjenta = katalogpacjenta + "\\"; korekta = true; }
        List<string> parametry = new List<string>();
        if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry")
    )
        {
            foreach (string line in File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry"))
            { parametry.Add(line); }

        }
        if (parametry.Count > 0)
        {
            for (int i = 0; i < parametry.Count; i++)
            {
                string[] czesc = parametry[i].Split('\t');
                if (czesc[0] == nazwa)
                {
                    
                        if (co == 0) { odczyt = czesc[0]; }
                        if (co == 1) { odczyt = czesc[1]; }
                        if (co == 2) { odczyt = czesc[2]; }
                        if (co == 3) { odczyt = czesc[3]; }
                        if (co == 4) { odczyt = czesc[4]; }

                    
                }
            }

            //File.WriteAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry", parametry);







        }
        if (korekta == true) { katalogpacjenta = katalogpacjenta.Substring(1, katalogpacjenta.Length - 1); }
        return odczyt;
    }


















        const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;

const int SET_FEATURE_ON_PROCESS = 0x00000002;

[DllImport("urlmon.dll")]
[PreserveSig]
[return: MarshalAs(UnmanagedType.Error)]
static extern int CoInternetSetFeatureEnabled(
    int FeatureEntry,
    [MarshalAs(UnmanagedType.U4)] int dwFlags,
    bool fEnable);

static void DisableClickSounds()
{
    CoInternetSetFeatureEnabled(
        FEATURE_DISABLE_NAVIGATION_SOUNDS,
        SET_FEATURE_ON_PROCESS,
        true);
}

        
        
        public void parametr(string jaki, string wartosc)
        {
            string strFilename = katalogpacjenta + "parametry.xml";
            //MessageBox.Show("strFilename= " + strFilename );
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilename);

            XmlNodeList imie = xmlDoc.GetElementsByTagName(jaki);
            imie[0].InnerText = wartosc;
            xmlDoc.Save(strFilename);

        }
        bool wywiadrodzinny = false;
        public string katalogpacjenta; bool etap1 = false;
        bool etap2 = false;
        bool etap3 = false; bool etap4 = false; bool etap5 = false; bool etap6 = false;
        public Form8()
        {
            InitializeComponent(); //timer1.Enabled = true; 
            timer2.Enabled = true;
            //odsiezbadaniadodatkowe();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }
        public string podstawaurl;
        private void Form8_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            doc = (mshtml.IHTMLDocument2)this.htmlRenderer.Document.DomDocument;
            doc.designMode = "On";
            DisableClickSounds();
            odsiezbadaniadodatkowe();
            d_rozpoczecia = DateTime.Now.ToString();
            Uri u = new Uri("http://www.comfortzg.com/badanieneurologiczne/s.php");
            webBrowser4.Url = u;


            //PRZYPOMNIJ
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
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            //timer1.Interval = 1000;
            //label3.Text = Convert.ToString(DateTime.Now);

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
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anulujesz badanie. Skasować dane pacjenta? Jeśli wybierzesz 'nie' będziesz mógł ponownie wczytać obecny stan formularza.", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearFolder(katalogpacjenta);
                Directory.Delete(katalogpacjenta);
                Form1 f = new Form1();
                f.Show();
                f.Refresh();
                f.odswiezpacjentow();
                this.Close();
            }
            else { ZAPISZ(); this.Close(); }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            etap1 = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 2000;
            int etap = 0;
            if (b_czaszkowe  == true) { etap++; }
            if (etap1 == true) { etap++; }
            if (etap2 == true) { etap++; }
            if (etap3 == true) { etap++; }
            if (etap4 == true) { etap++; }
            if (etap5 == true) { etap++; }
            if (etap6 == true) { etap++; }
            progressBar1.Value = etap;
            

        }
        public static int CalculateAge(DateTime birthDate)
        {
            // cache the current time
            DateTime now = DateTime.Today; // today is fine, don't need the timestamp from now
            // get the difference in years
            int years = now.Year - birthDate.Year;
            // subtract another year if we're before the
            // birth day in the current year
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                --years;

            return years;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value > DateTime.Now) { dateTimePicker2.Value = DateTime.Now; }
            label9.Text = "wiek " + CalculateAge(dateTimePicker2.Value) + " lat/a";
        }
        string płeć;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { radioButton2.Checked = false; płeć = "mężczyzna"; } else { radioButton2.Checked = true; płeć = "kobieta"; }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { radioButton1.Checked = false; płeć = "kobieta"; } else { radioButton1.Checked = true; płeć = "mężczyzna"; }
        }
        public void wyliczbmi()
        {
            double bmi = Convert.ToDouble(numericUpDown2.Value) / (Convert.ToDouble(numericUpDown1.Value) * Convert.ToDouble(numericUpDown1.Value));
            string opis = "norma";
            if (bmi < 16) { opis = "wygłodzenie"; }
            if (bmi < 18.5) { if (bmi >= 16) { opis = "wychudzenie"; } }
            if (bmi < 25) { if (bmi >= 18.5) { opis = "wartość prawidłowa"; } }
            if (bmi < 30) { if (bmi >= 25) { opis = "nadwaga"; } }
            if (bmi < 35) { if (bmi >= 30) { opis = "I stopień otyłości"; } }
            if (bmi < 40) { if (bmi >= 35) { opis = "II stopień otyłości"; } }
            if (bmi > 40) { opis = "III stopień otyłości"; }
            label13.Text = "BMI = " + Math.Round(bmi, 2) + " - " + opis;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            wyliczbmi();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            wyliczbmi();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            wyliczbmi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            d_rglasgow = DateTime.Now.ToString();
            Form10 f = new Form10();
            if (f.ShowDialog() == DialogResult.OK)
            {
                numericUpDown3.Value = f.wynik;
                label15.Text = "(" + f.szczegwynik + ")";
                //raport1
                d_kglasgow = DateTime.Now.ToString();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11(); f.objaw = 2; //MessageBox.Show(Convert.ToString(f.objaw));
            f.textBox3.Text = "bóle głowy";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                parametrdodaj("powodywizyty|bole_glowy", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|bole_glowy|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 3; f.textBox3.Text = "utraty świadomości";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                parametrdodaj("powodywizyty|utraty_swiadomosci", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|utraty_swiadomosci|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 4; f.textBox3.Text = "zaburzenia widzenia";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                parametrdodaj("powodywizyty|zaburzenia_widzenia", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|zaburzenia_widzenia|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 5; f.textBox3.Text = "zaburzenia mowy";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|zaburzenia_mowy", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|zaburzenia_mowy|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 6; f.textBox3.Text = "zaburzenia ruchu";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|zaburzenia_ruchu", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|zaburzenia_ruchu|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 7; f.textBox3.Text = "zaburzenia czucia";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|zaburzenia_czucia", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|zaburzenia_czucia|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 8; f.textBox3.Text = "osłabienie";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|utraty_swiadomosci", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|utraty_swiadomosci|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 9; f.textBox3.Text = "zaburzenia psychiczne";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|zaburzenia_psychiczne", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|zaburzenia_psychiczne|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 10; f.textBox3.Text = "zaburzenia zwieraczy";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|zaburzenia_zwieraczy", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|zaburzenia_zwieraczy|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 11; f.textBox3.Text = "zaburzenia zdolności poznawczych";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|zaburzenia_zwieraczy", "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|zaburzenia_zwieraczy|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 12; f.textBox3.Text = "napad padaczkowy";
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";

                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 13; f.textBox3.Text = "udar mózgu";
            if (f.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {

            Form11 f = new Form11(); f.objaw = 1; f.butinny.Visible = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = richTextBox1.Text + "- " + f.control.Text + "\n";
                dodajproblemhistoriichoroby(2, f.textBox3.Text, 1, f.control.Text);
                parametrdodaj("powodywizyty|"+ f.textBox3.Text, "bool", "true", "", dateTimePicker1.Value);
                parametrdodaj("powodywizyty|"+ f.textBox3.Text + "|opis", "txt", f.control.Text, "", dateTimePicker1.Value);
            }
        }


        private void podsumujetap1(string text)
        {
            control.Text = control.Text + text;
        }
        private void podsumujetap2(string text) { richTextBox2.Text = richTextBox2.Text + text; }
        private void button6_Click(object sender, EventArgs e)
        {
            //bool jużrazzakończono = false;
            if (etap1 == false)
            {
                d_zaketap1 = DateTime.Now.ToString();
                panel1.Enabled = false; etap1 = true; control.Visible = true;
                button5.Enabled = true; button7.Enabled = true;
                podsumujetap1("Nr ewidencyjny " + textBox2.Text + ", "); podsumujetap1("data badania " + Convert.ToString(dateTimePicker1.Value) + ", dane kontaktowe: " + textBox4.Text + ".\n");
                parametrdodaj("nr_ewidencyjny", "txt", textBox2.Text, "", dateTimePicker1.Value);
                parametrdodaj("inicjaly", "txt", textBox3.Text.Substring(1, 1) + textBox1.Text.Substring(1, 1), "", dateTimePicker1.Value);
                parametrdodaj("data_pierwszego_badania", "txt", dateTimePicker1.Value.ToString(), "", dateTimePicker1.Value);
                parametrdodaj("data_urodzenia", "txt", dateTimePicker2.Value.ToString(), "", dateTimePicker1.Value);
                parametrdodaj("waga", "war", numericUpDown2.Value.ToString(), "kg", dateTimePicker1.Value);
                parametrdodaj("wzrost", "war", numericUpDown1.Value.ToString(), "m", dateTimePicker1.Value);
                parametrdodaj("bmi", "txt", label13.Text.ToString(), "", dateTimePicker1.Value);
                parametrdodaj("plec", "txt", płeć, "", dateTimePicker1.Value);
                parametrdodaj("gcs", "war", numericUpDown3.Value.ToString(), "pkt", dateTimePicker1.Value);
                parametrdodaj("brak_zaburzen_mowy", "bool", checkBox1.Checked.ToString(), "", dateTimePicker1.Value);
                podsumujetap1("Pacjent: " + textBox3.Text + " " + textBox1.Text + " (" + płeć + ", lat " + CalculateAge(dateTimePicker2.Value) + ", ur. " + Convert.ToString(dateTimePicker2.Value.Day + "." + dateTimePicker2.Value.Month + "." + dateTimePicker2.Value.Year) + ", waga " + Convert.ToString(numericUpDown2.Value) + " kg, wzrost " + Convert.ToString(numericUpDown1.Value) + " m, " + label13.Text + ") \n");
                podsumujetap1("Poziom świadomości GCS " + Convert.ToString(numericUpDown3.Value) + "pkt. " + label15.Text + ". ");
                if (checkBox1.Checked == true) { podsumujetap1("Brak zaburzeń mowy. "); } if (checkBox2.Checked == true) { parametrdodaj("mmse", "txt", numericUpDown4.Value.ToString(), "pkt", dateTimePicker1.Value); if (numericUpDown4.Value < 25) { podsumujetap1("MMSE: " + numericUpDown4.Value + " pkt. (sugeruje otępienie)"); } else { podsumujetap1("MMSE: " + numericUpDown4.Value + " pkt."); } }
                podsumujetap1("\nGłówne powody wizyty:\n");
                podsumujetap1(richTextBox1.Text);
                

                   

                



                //jużrazzakończono = true;
            }
            else
            {
                if (MessageBox.Show("Cofnąć zakończenie etapu? To może spowodować utratę zmian w podsumowaniu!", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    panel1.Enabled = true; etap1 = false; control.Visible = false; control.Text = "";
                    button5.Enabled = false; button7.Enabled = false;
                }
            }

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        public void dodajproblemhistoriichoroby(int kategoria, string problem, int aktywny, string opis)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = problem;
            lvi.Group = listView1.Groups[kategoria];
            //aktywność
            string aktywny_txt = "Nie";
            if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
            lvi.SubItems.Add(aktywny_txt);
            //opis
            lvi.SubItems.Add(opis);
            lvi.ToolTipText = opis;
            listView1.Items.Add(lvi);
        }
        private void button24_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "Nazwa Problemu";
            lvi.Group = listView1.Groups[0];
            //aktywność
            lvi.SubItems.Add("Tak");
            //opis
            lvi.SubItems.Add("Jakiś opis");
            listView1.Items.Add(lvi);
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            if (f.ShowDialog() == DialogResult.OK)
            {

                int kategoria = 4;
                if (f.radioButton1.Checked == true) { kategoria = 0; }
                if (f.radioButton2.Checked == true) { kategoria = 1; }
                if (f.radioButton3.Checked == true) { kategoria = 2; }
                int aktywny = 1;
                if (f.comboBox1.Text == "tak") { aktywny = 1; } else { aktywny = 0; }
                dodajproblemhistoriichoroby(kategoria, f.textBox1.Text, aktywny, f.textBox2.Text);



            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (listView1.SelectedItems[0].ToolTipText != "")
                {
                    MessageBox.Show(listView1.SelectedItems[0].ToolTipText);
                }
                else { MessageBox.Show("Nie sprecyzowano szczegółów!"); }
            }
            else { MessageBox.Show("Niczego nie zaznaczyłeś!"); }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Na pewno chcesz usunąć ten problem?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { listView1.SelectedItems[0].Remove(); }
            }
            else { MessageBox.Show("Niczego nie zaznaczyłeś!"); }

        }
        bool pierwszylek = true;
        private void button27_Click(object sender, EventArgs e)
        {

            Form13 f = new Form13();
            if (f.ShowDialog() == DialogResult.OK)
            {

                if (pierwszylek == true) { textBox5.Text = f.textBox1.Text + " (" + f.textBox2.Text + ")"; pierwszylek = false; } else { textBox5.Text = textBox5.Text + ", " + f.textBox1.Text + " (" + f.textBox2.Text + ")"; }
                parametrdodaj("lekiprzed|" + f.textBox1.Text, "txt", f.textBox2.Text, "", dateTimePicker1.Value);





            }
        }
        bool wywiadsocjalny = false;
        private void button29_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = "";
                if (f.textBox1.Text != "") { textBox7.Text += "Zawód: " + f.textBox1.Text; parametrdodaj("wywiad_socjalny|zawod", "txt", f.textBox1.Text, "", dateTimePicker1.Value); }
                if (f.comboBox1.Text != "") { textBox7.Text += " (" + f.comboBox1.Text + ")."; parametrdodaj("wywiad_socjalny|typpracy", "txt", f.comboBox1.Text, "", dateTimePicker1.Value); }
                if (f.textBox3.Text != "") { textBox7.Text += " Warunki mieszkaniowe: " + f.textBox3.Text + "."; parametrdodaj("wywiad_socjalny|warunki_mieszkaniowe", "txt", f.textBox3.Text, "", dateTimePicker1.Value); }
                if (checkBox1.Checked == false)
                {
                    textBox7.Text += " Pacjent nie jest w stanie wykonywać sam czynności dnia codzinnego.";
                    parametrdodaj("wywiad_socjalny|samodzielne_wykonywanie_czynnosci_dnia_codziennego", "bool", "true", "", dateTimePicker1.Value);

                    if (f.textBox2.Text != "brak informacji") { textBox7.Text += " Potencjalni opiekunowie i dotychczasowa sposoby radzenia  sobie z tymi czynnościami: " + f.textBox2.Text + "."; parametrdodaj("wywiad_socjalny|potencjalni_opiekunowie", "txt", f.textBox2.Text, "", dateTimePicker1.Value); }
                }
                if (f.textBox4.Text == "brak" || f.textBox4.Text == "") { parametrdodaj("wywiad_socjalny|istotne_hobby", "bool", "false", "", dateTimePicker1.Value); } else { textBox7.Text += " Istotnym diagnostycznie hobby pacjenta może być " + f.textBox4.Text + "."; parametrdodaj("wywiad_socjalny|istotne_hobby", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|istotne_hobby|opis", "txt", f.textBox4.Text, "", dateTimePicker1.Value); }
                if (f.textBox5.Text != "nie są istotne" || f.textBox5.Text != "") { textBox7.Text += " Niedawne podróże: " + f.textBox5.Text + "."; parametrdodaj("wywiad_socjalny|niedawne_podroze", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|niedawne_podroze|opis", "txt", f.textBox5.Text, "", dateTimePicker1.Value); } else { parametrdodaj("wywiad_socjalny|niedawne_podroze", "bool", "false", "", dateTimePicker1.Value); }
                if (f.checkBox2.Checked == true || f.checkBox3.Checked == true || f.checkBox3.Checked == true || f.textBox6.Text != "inne")
                {
                    parametrdodaj("wywiad_socjalny|stresory", "bool", "true", "", dateTimePicker1.Value);
                    bool pierwszywpis = true;
                    textBox7.Text += " Obecne są następujące stresory:";
                    if (f.checkBox2.Checked == true)
                    {
                        if (pierwszywpis == true) { textBox7.Text += " " + f.checkBox2.Text; pierwszywpis = false; } else { textBox7.Text += ", " + f.checkBox2.Text; }
                    }
                    if (f.checkBox3.Checked == true) { if (pierwszywpis == true) { textBox7.Text += " " + f.checkBox3.Text; pierwszywpis = false; } else { textBox7.Text += ", " + f.checkBox3.Text; } }
                    if (f.checkBox4.Checked == true) { if (pierwszywpis == true) { textBox7.Text += " " + f.checkBox4.Text; pierwszywpis = false; } else { textBox7.Text += ", " + f.checkBox4.Text; } }
                    if (f.textBox7.Text == "opis" || f.textBox7.Text == "") { textBox7.Text += "."; } else { textBox7.Text += ". " + f.textBox7.Text + "."; }

                    parametrdodaj("wywiad_socjalny|stresory|opis", "txt", f.textBox7.Text, "", dateTimePicker1.Value);

                }
                else { parametrdodaj("wywiad_socjalny|stresory", "bool", "false", "", dateTimePicker1.Value); }
                if (f.checkBox5.Checked == true || f.checkBox6.Checked == true || f.checkBox7.Checked == true)
                {
                    if (f.checkBox5.Checked == true)
                    { textBox7.Text += " Pacjent zażywa narkotyki (" + f.textBox8.Text + ")."; parametrdodaj("wywiad_socjalny|narkotyki", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|narkotyki|opis", "txt", f.textBox8.Text, "", dateTimePicker1.Value); }
                    else { parametrdodaj("wywiad_socjalny|narkotyki", "bool", "false", "", dateTimePicker1.Value); }
                    
                    if (f.checkBox6.Checked == true)
                    { textBox7.Text += " Pacjent pali papierosy (" + Decimal.Round(f.paczkolata, 2) + " paczkolata).";
                    parametrdodaj("wywiad_socjalny|papierosy", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|papierosy|paczkolata", "war", Decimal.Round(f.paczkolata, 2).ToString(), "paczkolata", dateTimePicker1.Value);
                    }
                    else { parametrdodaj("wywiad_socjalny|papierosy", "bool", "false", "", dateTimePicker1.Value); }
                    if (f.checkBox7.Checked == true)
                    {
                        parametrdodaj("wywiad_socjalny|ocena_spozycia_alkoholu", "bool", "true", "", dateTimePicker1.Value);
                        textBox7.Text += " Pacjent w ostatnim tygodniu spożył alkohol w ilości " + f.numericUpDown3.Value + " jednostek (" + f.ocenaalkoholizmu + ")."; }
                    parametrdodaj("wywiad_socjalny|ocena_spozycia_alkoholu|ile", "war", f.numericUpDown3.Value.ToString(), "jednostki", dateTimePicker1.Value);
                    parametrdodaj("wywiad_socjalny|ocena_spozycia_alkoholu|ocena", "txt", f.ocenaalkoholizmu, "jednostki", dateTimePicker1.Value);
                }
                else { textBox7.Text += " Brak używek i uzależnień."; }
                if (f.checkBox8.Checked == true) { parametrdodaj("wywiad_socjalny|nieprawidlowe_odzywianie", "bool", "false", "", dateTimePicker1.Value); textBox7.Text += " Pacjent odżywia się prawidłowo."; } else { textBox7.Text += " Pacjent odżywia się nieprawidłowo (" + f.textBox9.Text + ")."; parametrdodaj("wywiad_socjalny|nieprawidlowe_odzywianie", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|nieprawidlowe_odzywianie|opis", "txt", f.textBox9.Text, "", dateTimePicker1.Value); }
                if (f.textBox10.Text == "dodatkowe adnotacje" || f.textBox10.Text == "") { } else { parametrdodaj("wywiad_socjalny|dodatkowe_adnotacje", "txt", f.textBox10.Text, "", dateTimePicker1.Value); textBox7.Text += " " + f.textBox10.Text + "."; }; textBox7.Enabled = true; textBox7.ReadOnly = false;
            }
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            if (wywiadrodzinny == false)
            {
                textBox8.Text = "";
                wywiadrodzinny = true;
                textBox8.Focus();
            }
        }
        bool alergie = false;
        private void textBox6_Click(object sender, EventArgs e)
        {
            if (alergie == false)
            {
                textBox6.Text = "";
                alergie = true;
                textBox6.Focus();
            }
        }
        bool bylpierwszywpis = false;
        private void wylicztext(string text, TextBox textbox) { if (bylpierwszywpis == true) { if (text != "") { textbox.Text += ", " + text; } } else { if (text != "") { textbox.Text += text; bylpierwszywpis = true; } } }
        private void button31_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16(); textBox9.Enabled = true; textBox9.ReadOnly = false;
            if (płeć == "mężczyzna") { f.checkBox22.Visible = false; } else { f.checkBox22.Visible = true; }
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = "";
                bylpierwszywpis = false;
                if (f.checkBox27.Checked == true) { wylicztext(f.checkBox27.Text, textBox9); }
                if (f.checkBox28.Checked == true) { wylicztext(f.checkBox28.Text, textBox9); } else { wylicztext("zaburzenia apetytu", textBox9); }
                if (f.checkBox29.Checked == true) { wylicztext(f.checkBox29.Text, textBox9); }
                textBox9.Text += "\r\n";
                //oddechowy
                if (f.checkBox1.Checked == true || f.checkBox2.Checked == true || f.checkBox4.Checked == true || f.checkBox6.Checked == true)
                {
                    textBox9.Text += "układ oddechowy: "; bylpierwszywpis = false;
                    if (f.checkBox1.Checked == true) { wylicztext(f.checkBox1.Text, textBox9); }
                    if (f.checkBox2.Checked == true) { textBox9.Text += " z wydzieliną"; }
                    if (f.checkBox4.Checked == true) { wylicztext(f.checkBox4.Text, textBox9); }
                    if (f.textBox3.Text != "") { textBox9.Text += " - " + f.textBox3.Text; }
                }
                else { textBox9.Text += "układ oddechowy: brak objawów"; }
                //krążenia
                if (f.checkBox8.Checked == true || f.checkBox3.Checked == true || f.checkBox7.Checked == true || f.checkBox9.Checked == true || f.checkBox10.Checked == true || f.checkBox5.Checked == true)
                {
                    textBox9.Text += "\r\nukład krążenia: "; bylpierwszywpis = false;
                    if (f.checkBox8.Checked == true) { wylicztext(f.checkBox8.Text, textBox9); }
                    if (f.checkBox3.Checked == true) { wylicztext(f.checkBox3.Text, textBox9); }
                    if (f.checkBox7.Checked == true) { wylicztext(f.checkBox7.Text, textBox9); }
                    if (f.checkBox9.Checked == true) { wylicztext(f.checkBox9.Text, textBox9); }
                    if (f.checkBox10.Checked == true) { wylicztext(f.checkBox10.Text, textBox9); }
                    if (f.textBox5.Text != "") { textBox9.Text += " - " + f.textBox5.Text; }
                }
                else { textBox9.Text += "\r\nnukład krążenia: brak objawów"; }
                //pokarmowy
                if (f.checkBox16.Checked == true || f.checkBox13.Checked == true || f.checkBox15.Checked == true || f.checkBox17.Checked == true || f.checkBox12.Checked == true || f.checkBox11.Checked == true || f.checkBox18.Checked == true || f.checkBox14.Checked == true)
                {
                    textBox9.Text += "\r\nukład pokarmowy: "; bylpierwszywpis = false;
                    if (f.checkBox16.Checked == true) { wylicztext(f.checkBox16.Text, textBox9); }
                    if (f.checkBox13.Checked == true) { wylicztext(f.checkBox13.Text, textBox9); }
                    if (f.checkBox15.Checked == true) { wylicztext(f.checkBox15.Text, textBox9); }
                    if (f.checkBox17.Checked == true) { wylicztext(f.checkBox17.Text, textBox9); }
                    if (f.checkBox12.Checked == true) { wylicztext(f.checkBox12.Text, textBox9); }
                    if (f.checkBox11.Checked == true) { wylicztext(f.checkBox11.Text, textBox9); }
                    if (f.checkBox18.Checked == true) { wylicztext(f.checkBox18.Text, textBox9); }
                    //if (f.checkBox12.Checked == true) { wylicztext(f.checkBox10.Text, textBox9); }
                    if (f.textBox1.Text != "") { textBox9.Text += " - " + f.textBox1.Text; }
                }
                else { textBox9.Text += "\r\nukład pokarmowy: brak objawów"; }
                //moczowo-płciowy
                if (f.checkBox26.Checked == true || f.checkBox23.Checked == true || f.checkBox20.Checked == true || f.checkBox19.Checked == true || f.checkBox21.Checked == true || f.checkBox22.Checked == true || f.checkBox25.Checked == true || f.checkBox24.Checked == true)
                {
                    textBox9.Text += "\r\nukład moczowo-płciowy: "; bylpierwszywpis = false;
                    if (f.checkBox26.Checked == true) { wylicztext(f.checkBox26.Text, textBox9); }
                    if (f.checkBox23.Checked == true) { wylicztext(f.checkBox23.Text, textBox9); }
                    if (f.checkBox25.Checked == true) { wylicztext(f.checkBox25.Text, textBox9); }
                    if (f.checkBox20.Checked == true) { wylicztext(f.checkBox20.Text, textBox9); }
                    if (f.checkBox19.Checked == true) { wylicztext(f.checkBox19.Text, textBox9); }
                    if (f.checkBox21.Checked == true) { wylicztext(f.checkBox21.Text, textBox9); }
                    if (f.checkBox22.Checked == true) { wylicztext(f.checkBox22.Text, textBox9); }
                    //if (f.checkBox12.Checked == true) { wylicztext(f.checkBox10.Text, textBox9); }
                    if (f.textBox2.Text != "") { textBox9.Text += " - " + f.textBox2.Text; }
                }
                else { textBox9.Text += "\r\nukład moczowo-płciowy: brak objawów"; }
                //inne
                if (f.textBox4.Text == "" || f.textBox4.Text == "dodatkowe adnotacje") { } else { textBox9.Text += "\r\n" + f.textBox4.Text; }



            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            int selstart = richTextBox2.SelectionStart;
            int sellength = richTextBox2.SelectionLength;
            // ... previous code
            richTextBox2.SelectionFont = new Font(control.Font, FontStyle.Bold);
            richTextBox2.SelectionStart = control.SelectionStart + control.SelectionLength;
            richTextBox2.SelectionLength = 0;
            richTextBox2.SelectionFont = control.Font;

            richTextBox2.Select(selstart, sellength);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            richTextBox2.Undo();

            richTextBox2.ClearUndo();
        }
        string cowpisalem;
        private void button22_Click(object sender, EventArgs e)
        {
            if (etap2 == false)
            {
                d_zaketap2 = DateTime.Now.ToString();
                panel2.Enabled = false; etap2 = true; richTextBox2.Visible = true;
                button23.Enabled = true; button21.Enabled = true;
                bool jestgrupa;
                //podsumujetap2(" ");
                //wypisujemy problemy
                //grupa0 - hospitalizacje i zabiegi operacyjne


                if (listView1.Items.Count > 0)
                {
                    int problemów = 1;

                    //richTextBox2.Rtf = @"{\rtf1\ansi \b Historia choroby w układzie problemowym \b0 :}";


                    //richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Bold);
                    //richTextBox2.SelectionStart = richTextBox2.TextLength;
                    podsumujetap2("\nHISTORIA CHOROBY (w układzie problemowym)");
                    //cowpisalem = ":";
                    //richTextBox2.SelectionLength = cowpisalem.Length;
                    //richTextBox2.SelectionFont = new Font(richTextBox2.Font, FontStyle.Bold);
                    //richTextBox2.SelectionLength = 0;
                    //richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Regular);
                    jestgrupa = false;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (jestgrupa == false) { if (item.Group == listView1.Groups[0]) { podsumujetap2("\nHospitalizacje i zabiegi operacyjne:"); jestgrupa = true; } }
                        if (item.Group == listView1.Groups[0]) { podsumujetap2("\n  [P" + problemów + ", aktywny: " + item.SubItems[1].Text + "] " + item.SubItems[0].Text + " (" + item.SubItems[2].Text + ")"); problemów++; 
                            parametrdodaj("historiachoroby|hospitalizacje|" + item.SubItems[0].Text, "txt", item.SubItems[2].Text, "", dateTimePicker1.Value);
                            bool aktywny; if (item.SubItems[1].Text == "tak") { aktywny = true; } else { aktywny = false; }
                            parametrdodaj("historiachoroby|hospitalizacje|" + item.SubItems[0].Text + "|aktywny", "bool", aktywny.ToString(), "", dateTimePicker1.Value); 
                        }

                    }
                    //grupa1 - 
                    jestgrupa = false;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (jestgrupa == false) { if (item.Group.Header == listView1.Groups[1].Header) { podsumujetap2("\nChoroby przebyte i przewlekłe:"); jestgrupa = true; } }
                        if (item.Group.Header == listView1.Groups[1].Header) { podsumujetap2("\n  [P" + problemów + ", aktywny: " + item.SubItems[1].Text + "] " + item.SubItems[0].Text + " (" + item.SubItems[2].Text + ")"); problemów++;
                        parametrdodaj("historiachoroby|choroby_przewlekle|" + item.SubItems[0].Text, "txt", item.SubItems[2].Text, "", dateTimePicker1.Value);
                        bool aktywny; if (item.SubItems[1].Text == "tak") { aktywny = true; } else { aktywny = false; }
                        parametrdodaj("historiachoroby|choroby_przewlekle|" + item.SubItems[0].Text + "|aktywny", "bool", aktywny.ToString(), "", dateTimePicker1.Value); 
                        
                        }

                    }
                    jestgrupa = false;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (jestgrupa == false) { if (item.Group.Header == listView1.Groups[2].Header) { podsumujetap2("\nProblemy związane z obecną chorobą:"); jestgrupa = true; } }
                        if (item.Group.Header == listView1.Groups[2].Header) { podsumujetap2("\n  [P" + problemów + ", aktywny: " + item.SubItems[1].Text + "] " + item.SubItems[0].Text + " (" + item.SubItems[2].Text + ")"); problemów++;
                        parametrdodaj("historiachoroby|obecnachoroba|" + item.SubItems[0].Text, "txt", item.SubItems[2].Text, "", dateTimePicker1.Value);
                        bool aktywny; if (item.SubItems[1].Text == "tak") { aktywny = true; } else { aktywny = false; }
                        parametrdodaj("historiachoroby|obecnachoroba|" + item.SubItems[0].Text + "|aktywny", "bool", aktywny.ToString(), "", dateTimePicker1.Value); 
                        
                        
                        
                        }

                    }
                    podsumujetap2("\n");
                }

                if (textBox5.Text == "" || textBox5.Text == "brak") { podsumujetap2("\nPacjent aktualnie nie przyjmuje żadnych leków."); parametrdodaj("lekiprzed", "bool", "false", "", dateTimePicker1.Value); }
                else
                {
                    parametrdodaj("lekiprzed", "bool", "true", "", dateTimePicker1.Value);
                    richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Bold);
                    podsumujetap2("\nPacjent aktualnie przyjmuje " + textBox5.Text + ".");
                    parametrdodaj("lekiprzed|jakie", "txt", textBox5.Text, "", dateTimePicker1.Value);
                    
                    richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Regular);
                }
                if (textBox6.Text == "" || textBox6.Text == "brak") { podsumujetap2("\nPacjent nie ma żadnych alergii."); parametrdodaj("alergie", "bool", "false", "", dateTimePicker1.Value); }
                else
                {
                    parametrdodaj("alergie", "bool", "true", "", dateTimePicker1.Value);
                    parametrdodaj("alergie|jakie", "txt", textBox6.Text, "", dateTimePicker1.Value);
                    richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Bold);
                    podsumujetap2("\n!!! PACJENT MA ALERGIE: " + textBox6.Text + "."); richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Regular);
                }
                if (textBox8.Text != "") { podsumujetap2("\n\nWYWIAD RODZINNY: " + textBox8.Text); parametrdodaj("wywiad_rodzinny", "txt", textBox8.Text, "", dateTimePicker1.Value); }
                if (textBox7.Text != "jeszcze nie przeprowadzono") { podsumujetap2("\n\nWYWIAD SOCJALNY: " + textBox7.Text); parametrdodaj("wywiad_socjalny", "txt", textBox7.Text, "", dateTimePicker1.Value); }
                if (textBox9.Text != "jeszcze nie przeprowadzono") { podsumujetap2("\n\nPRZEGLĄD UKŁADÓW: " + textBox9.Text); parametrdodaj("przeglad_ukladow", "txt", textBox7.Text, "", dateTimePicker1.Value); }





            }
            else
            {
                if (MessageBox.Show("Cofnąć zakończenie etapu? To może spowodować utratę zmian w podsumowaniu!", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    panel2.Enabled = true; etap2 = false; richTextBox2.Visible = false; richTextBox2.Text = "";
                    button23.Enabled = false; button21.Enabled = false;
                }
            }
        }

        private void button24_Click_2(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            if (f.ShowDialog() == DialogResult.OK)
            {

                int kategoria = 4;
                if (f.radioButton1.Checked == true) { kategoria = 0; }
                if (f.radioButton2.Checked == true) { kategoria = 1; }
                if (f.radioButton3.Checked == true) { kategoria = 2; }
                int aktywny = 1;
                if (f.comboBox1.Text == "tak") { aktywny = 1; } else { aktywny = 0; }
                dodajproblemhistoriichoroby(kategoria, f.textBox1.Text, aktywny, f.textBox1.Text + ": " + f.textBox2.Text);



            }
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            d_rwsocj = DateTime.Now.ToString();
            Form14 f = new Form14();
            if (f.ShowDialog() == DialogResult.OK)
            {
                d_kwsocj = DateTime.Now.ToString();
                textBox7.Text = "";
                if (f.textBox1.Text != "") { textBox7.Text += "Zawód: " + f.textBox1.Text; parametrdodaj("wywiad_socjalny|zawod", "txt", f.textBox1.Text, "", dateTimePicker1.Value); }
                if (f.comboBox1.Text != "") { textBox7.Text += " (" + f.comboBox1.Text + ")."; parametrdodaj("wywiad_socjalny|typpracy", "txt", f.comboBox1.Text, "", dateTimePicker1.Value); }
                if (f.textBox3.Text != "") { textBox7.Text += " Warunki mieszkaniowe: " + f.textBox3.Text + "."; parametrdodaj("wywiad_socjalny|warunki_mieszkaniowe", "txt", f.textBox3.Text, "", dateTimePicker1.Value); }
                if (checkBox1.Checked == false)
                {
                    textBox7.Text += " Pacjent nie jest w stanie wykonywać sam czynności dnia codzinnego.";
                    parametrdodaj("wywiad_socjalny|samodzielne_wykonywanie_czynnosci_dnia_codziennego", "bool", "true", "", dateTimePicker1.Value);

                    if (f.textBox2.Text != "brak informacji") { textBox7.Text += " Potencjalni opiekunowie i dotychczasowa sposoby radzenia  sobie z tymi czynnościami: " + f.textBox2.Text + "."; parametrdodaj("wywiad_socjalny|potencjalni_opiekunowie", "txt", f.textBox2.Text, "", dateTimePicker1.Value); }
                }
                if (f.textBox4.Text == "brak" || f.textBox4.Text == "") { parametrdodaj("wywiad_socjalny|istotne_hobby", "bool", "false", "", dateTimePicker1.Value); } else { textBox7.Text += " Istotnym diagnostycznie hobby pacjenta może być " + f.textBox4.Text + "."; parametrdodaj("wywiad_socjalny|istotne_hobby", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|istotne_hobby|opis", "txt", f.textBox4.Text, "", dateTimePicker1.Value); }
                if (f.textBox5.Text != "nie są istotne" || f.textBox5.Text != "") { textBox7.Text += " Niedawne podróże: " + f.textBox5.Text + "."; parametrdodaj("wywiad_socjalny|niedawne_podroze", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|niedawne_podroze|opis", "txt", f.textBox5.Text, "", dateTimePicker1.Value); } else { parametrdodaj("wywiad_socjalny|niedawne_podroze", "bool", "false", "", dateTimePicker1.Value); }
                if (f.checkBox2.Checked == true || f.checkBox3.Checked == true || f.checkBox3.Checked == true || f.textBox6.Text != "inne")
                {
                    parametrdodaj("wywiad_socjalny|stresory", "bool", "true", "", dateTimePicker1.Value);
                    bool pierwszywpis = true;
                    textBox7.Text += " Obecne są następujące stresory:";
                    if (f.checkBox2.Checked == true)
                    {
                        if (pierwszywpis == true) { textBox7.Text += " " + f.checkBox2.Text; pierwszywpis = false; } else { textBox7.Text += ", " + f.checkBox2.Text; }
                    }
                    if (f.checkBox3.Checked == true) { if (pierwszywpis == true) { textBox7.Text += " " + f.checkBox3.Text; pierwszywpis = false; } else { textBox7.Text += ", " + f.checkBox3.Text; } }
                    if (f.checkBox4.Checked == true) { if (pierwszywpis == true) { textBox7.Text += " " + f.checkBox4.Text; pierwszywpis = false; } else { textBox7.Text += ", " + f.checkBox4.Text; } }
                    if (f.textBox7.Text == "opis" || f.textBox7.Text == "") { textBox7.Text += "."; } else { textBox7.Text += ". " + f.textBox7.Text + "."; }

                    parametrdodaj("wywiad_socjalny|stresory|opis", "txt", f.textBox7.Text, "", dateTimePicker1.Value);

                }
                else { parametrdodaj("wywiad_socjalny|stresory", "bool", "false", "", dateTimePicker1.Value); }
                if (f.checkBox5.Checked == true || f.checkBox6.Checked == true || f.checkBox7.Checked == true)
                {
                    if (f.checkBox5.Checked == true)
                    { textBox7.Text += " Pacjent zażywa narkotyki (" + f.textBox8.Text + ")."; parametrdodaj("wywiad_socjalny|narkotyki", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|narkotyki|opis", "txt", f.textBox8.Text, "", dateTimePicker1.Value); }
                    else { parametrdodaj("wywiad_socjalny|narkotyki", "bool", "false", "", dateTimePicker1.Value); }
                    
                    if (f.checkBox6.Checked == true)
                    { textBox7.Text += " Pacjent pali papierosy (" + Decimal.Round(f.paczkolata, 2) + " paczkolata).";
                    parametrdodaj("wywiad_socjalny|papierosy", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|papierosy|paczkolata", "war", Decimal.Round(f.paczkolata, 2).ToString(), "paczkolata", dateTimePicker1.Value);
                    }
                    else { parametrdodaj("wywiad_socjalny|papierosy", "bool", "false", "", dateTimePicker1.Value); }
                    if (f.checkBox7.Checked == true)
                    {
                        parametrdodaj("wywiad_socjalny|ocena_spozycia_alkoholu", "bool", "true", "", dateTimePicker1.Value);
                        textBox7.Text += " Pacjent w ostatnim tygodniu spożył alkohol w ilości " + f.numericUpDown3.Value + " jednostek (" + f.ocenaalkoholizmu + ")."; }
                    parametrdodaj("wywiad_socjalny|ocena_spozycia_alkoholu|ile", "war", f.numericUpDown3.Value.ToString(), "jednostki", dateTimePicker1.Value);
                    parametrdodaj("wywiad_socjalny|ocena_spozycia_alkoholu|ocena", "txt", f.ocenaalkoholizmu, "jednostki", dateTimePicker1.Value);
                }
                else { textBox7.Text += " Brak używek i uzależnień."; }
                if (f.checkBox8.Checked == true) { parametrdodaj("wywiad_socjalny|nieprawidlowe_odzywianie", "bool", "false", "", dateTimePicker1.Value); textBox7.Text += " Pacjent odżywia się prawidłowo."; } else { textBox7.Text += " Pacjent odżywia się nieprawidłowo (" + f.textBox9.Text + ")."; parametrdodaj("wywiad_socjalny|nieprawidlowe_odzywianie", "bool", "true", "", dateTimePicker1.Value); parametrdodaj("wywiad_socjalny|nieprawidlowe_odzywianie|opis", "txt", f.textBox9.Text, "", dateTimePicker1.Value); }
                if (f.textBox10.Text == "dodatkowe adnotacje" || f.textBox10.Text == "") { } else { parametrdodaj("wywiad_socjalny|dodatkowe_adnotacje", "txt", f.textBox10.Text, "", dateTimePicker1.Value); textBox7.Text += " " + f.textBox10.Text + "."; }; textBox7.Enabled = true; textBox7.ReadOnly = false;
            

                }
                
            
        }

        private void button31_Click_1(object sender, EventArgs e)
        {
            d_rpukl = DateTime.Now.ToString();
            Form16 f = new Form16(); textBox9.Enabled = true; textBox9.ReadOnly = false;
            if (płeć == "mężczyzna") { f.checkBox22.Visible = false; } else { f.checkBox22.Visible = true; }
            if (f.ShowDialog() == DialogResult.OK)
            {
                d_kpukl = DateTime.Now.ToString();
                textBox9.Text = "";
                bylpierwszywpis = false;
                if (f.checkBox27.Checked == true) { wylicztext(f.checkBox27.Text, textBox9); parametrdodaj("przeglad_ukladow|" + f.checkBox27.Text, "bool", "true", "", dateTimePicker1.Value); } else { parametrdodaj("przeglad_ukladow|" + f.checkBox27.Text, "bool", "false", "", dateTimePicker1.Value); }
                if (f.checkBox28.Checked == true) { wylicztext(f.checkBox28.Text, textBox9); } else { wylicztext("zaburzenia apetytu", textBox9); } parametrdodaj("przeglad_ukladow|" + f.checkBox28.Text, "bool", f.checkBox28.Checked.ToString(), "", dateTimePicker1.Value);
                if (f.checkBox29.Checked == true) { wylicztext(f.checkBox29.Text, textBox9); } parametrdodaj("przeglad_ukladow|" + f.checkBox29.Text, "bool", f.checkBox29.Checked.ToString(), "", dateTimePicker1.Value);
                textBox9.Text += "\r\n";
                //oddechowy
                if (f.checkBox1.Checked == true || f.checkBox2.Checked == true || f.checkBox4.Checked == true || f.checkBox6.Checked == true)
                {
                    textBox9.Text += "układ oddechowy: "; bylpierwszywpis = false; parametrdodaj("przeglad_ukladow|oddechowy", "bool", "true", "", dateTimePicker1.Value);
                    if (f.checkBox1.Checked == true) { wylicztext(f.checkBox1.Text, textBox9); } parametrdodaj("przeglad_ukladow|oddechowy|" + f.checkBox1.Text, "bool", f.checkBox1.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox2.Checked == true) { textBox9.Text += " z wydzieliną"; } parametrdodaj("przeglad_ukladow|oddechowy|kaszel|" + f.checkBox2.Text, "bool", f.checkBox2.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox4.Checked == true) { wylicztext(f.checkBox4.Text, textBox9); } parametrdodaj("przeglad_ukladow|oddechowy|" + f.checkBox4.Text, "bool", f.checkBox4.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.textBox3.Text != "") { textBox9.Text += " - " + f.textBox3.Text; } parametrdodaj("przeglad_ukladow|oddechowy|opis", "txt", f.textBox3.Text.ToString(), "", dateTimePicker1.Value);
                }
                else { textBox9.Text += "układ oddechowy: brak objawów"; parametrdodaj("przeglad_ukladow|oddechowy", "bool", "false", "", dateTimePicker1.Value); }
                //krążenia
                if (f.checkBox8.Checked == true || f.checkBox3.Checked == true || f.checkBox7.Checked == true || f.checkBox9.Checked == true || f.checkBox10.Checked == true || f.checkBox5.Checked == true)
                {
                    textBox9.Text += "\r\nukład krążenia: "; bylpierwszywpis = false; parametrdodaj("przeglad_ukladow|krazenia", "bool", "true", "", dateTimePicker1.Value);
                    if (f.checkBox8.Checked == true) { wylicztext(f.checkBox8.Text, textBox9); } parametrdodaj("przeglad_ukladow|krazenia|" + f.checkBox8.Text, "bool", f.checkBox8.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox3.Checked == true) { wylicztext(f.checkBox3.Text, textBox9); } parametrdodaj("przeglad_ukladow|krazenia|" + f.checkBox3.Text, "bool", f.checkBox3.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox7.Checked == true) { wylicztext(f.checkBox7.Text, textBox9); } parametrdodaj("przeglad_ukladow|krazenia|" + f.checkBox7.Text, "bool", f.checkBox7.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox9.Checked == true) { wylicztext(f.checkBox9.Text, textBox9); } parametrdodaj("przeglad_ukladow|krazenia|" + f.checkBox9.Text, "bool", f.checkBox9.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox10.Checked == true) { wylicztext(f.checkBox10.Text, textBox9); } parametrdodaj("przeglad_ukladow|krazenia|" + f.checkBox10.Text, "bool", f.checkBox10.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.textBox5.Text != "") { textBox9.Text += " - " + f.textBox5.Text; } parametrdodaj("przeglad_ukladow|krazenia|opis", "txt", f.textBox5.Text.ToString(), "", dateTimePicker1.Value);
                }
                else { textBox9.Text += "\r\nnukład krążenia: brak objawów"; parametrdodaj("przeglad_ukladow|krazenia", "bool", "false", "", dateTimePicker1.Value); }
                //pokarmowy
                if (f.checkBox16.Checked == true || f.checkBox13.Checked == true || f.checkBox15.Checked == true || f.checkBox17.Checked == true || f.checkBox12.Checked == true || f.checkBox11.Checked == true || f.checkBox18.Checked == true || f.checkBox14.Checked == true)
                {
                    textBox9.Text += "\r\nukład pokarmowy: "; bylpierwszywpis = false; parametrdodaj("przeglad_ukladow|pokarmowy", "bool", "true", "", dateTimePicker1.Value);
                    if (f.checkBox16.Checked == true) { wylicztext(f.checkBox16.Text, textBox9); } parametrdodaj("przeglad_ukladow|pokarmowy|" + f.checkBox16.Text, "bool", f.checkBox16.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox13.Checked == true) { wylicztext(f.checkBox13.Text, textBox9); } parametrdodaj("przeglad_ukladow|pokarmowy|" + f.checkBox13.Text, "bool", f.checkBox13.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox15.Checked == true) { wylicztext(f.checkBox15.Text, textBox9); } parametrdodaj("przeglad_ukladow|pokarmowy|" + f.checkBox15.Text, "bool", f.checkBox15.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox17.Checked == true) { wylicztext(f.checkBox17.Text, textBox9); } parametrdodaj("przeglad_ukladow|pokarmowy|" + f.checkBox17.Text, "bool", f.checkBox17.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox12.Checked == true) { wylicztext(f.checkBox12.Text, textBox9); } parametrdodaj("przeglad_ukladow|pokarmowy|" + f.checkBox12.Text, "bool", f.checkBox12.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox11.Checked == true) { wylicztext(f.checkBox11.Text, textBox9); } parametrdodaj("przeglad_ukladow|pokarmowy|" + f.checkBox11.Text, "bool", f.checkBox11.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox18.Checked == true) { wylicztext(f.checkBox18.Text, textBox9); } parametrdodaj("przeglad_ukladow|pokarmowy|" + f.checkBox18.Text, "bool", f.checkBox18.Checked.ToString(), "", dateTimePicker1.Value);
                    //if (f.checkBox12.Checked == true) { wylicztext(f.checkBox10.Text, textBox9); }
                    if (f.textBox1.Text != "") { textBox9.Text += " - " + f.textBox1.Text; } parametrdodaj("przeglad_ukladow|pokarmowy|opis", "txt", f.textBox1.Text.ToString(), "", dateTimePicker1.Value);
                }
                else { textBox9.Text += "\r\nukład pokarmowy: brak objawów"; parametrdodaj("przeglad_ukladow|pokarmowy", "bool", "false", "", dateTimePicker1.Value); }
                //moczowo-płciowy
                if (f.checkBox26.Checked == true || f.checkBox23.Checked == true || f.checkBox20.Checked == true || f.checkBox19.Checked == true || f.checkBox21.Checked == true || f.checkBox22.Checked == true || f.checkBox25.Checked == true || f.checkBox24.Checked == true)
                {
                    textBox9.Text += "\r\nukład moczowo-płciowy: "; bylpierwszywpis = false; parametrdodaj("przeglad_ukladow|moczpl", "bool", "true", "", dateTimePicker1.Value);
                    if (f.checkBox26.Checked == true) { wylicztext(f.checkBox26.Text, textBox9); } parametrdodaj("przeglad_ukladow|moczpl|" + f.checkBox26.Text, "bool", f.checkBox26.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox23.Checked == true) { wylicztext(f.checkBox23.Text, textBox9); } parametrdodaj("przeglad_ukladow|moczpl|" + f.checkBox23.Text, "bool", f.checkBox23.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox25.Checked == true) { wylicztext(f.checkBox25.Text, textBox9); } parametrdodaj("przeglad_ukladow|moczpl|" + f.checkBox25.Text, "bool", f.checkBox25.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox20.Checked == true) { wylicztext(f.checkBox20.Text, textBox9); } parametrdodaj("przeglad_ukladow|moczpl|" + f.checkBox20.Text, "bool", f.checkBox20.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox19.Checked == true) { wylicztext(f.checkBox19.Text, textBox9); } parametrdodaj("przeglad_ukladow|moczpl|" + f.checkBox19.Text, "bool", f.checkBox19.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox21.Checked == true) { wylicztext(f.checkBox21.Text, textBox9); } parametrdodaj("przeglad_ukladow|moczpl|" + f.checkBox21.Text, "bool", f.checkBox21.Checked.ToString(), "", dateTimePicker1.Value);
                    if (f.checkBox22.Checked == true) { wylicztext(f.checkBox22.Text, textBox9); } parametrdodaj("przeglad_ukladow|moczpl|" + f.checkBox22.Text, "bool", f.checkBox22.Checked.ToString(), "", dateTimePicker1.Value);
                    //if (f.checkBox12.Checked == true) { wylicztext(f.checkBox10.Text, textBox9); }
                    if (f.textBox2.Text != "") { textBox9.Text += " - " + f.textBox2.Text; } parametrdodaj("przeglad_ukladow|moczpl|opis", "txt", f.textBox2.Text.ToString(), "", dateTimePicker1.Value);
                }
                else { textBox9.Text += "\r\nukład moczowo-płciowy: brak objawów"; parametrdodaj("przeglad_ukladow|moczpl", "bool", "false", "", dateTimePicker1.Value); }
                //inne
                if (f.textBox4.Text == "" || f.textBox4.Text == "dodatkowe adnotacje") { } else { textBox9.Text += "\r\n" + f.textBox4.Text; parametrdodaj("przeglad_ukladow|dodatkowy_opis", "txt", f.textBox4.Text.ToString(), "", dateTimePicker1.Value); }



            }
        }
        string dupa;
        private void button25_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (listView1.SelectedItems[0].ToolTipText != "")
                {
                    MessageBox.Show(listView1.SelectedItems[0].ToolTipText);
                }
                else { MessageBox.Show("Nie sprecyzowano szczegółów!"); }
            }
            else { MessageBox.Show("Niczego nie zaznaczyłeś!"); }
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("Na pewno chcesz usunąć ten problem?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { listView1.SelectedItems[0].Remove(); }
            }
            else { MessageBox.Show("Niczego nie zaznaczyłeś!"); }
        }

        private void textBox8_Click_1(object sender, EventArgs e)
        {
            if (wywiadrodzinny == false)
            {
                textBox8.Text = "";
                wywiadrodzinny = true;
                textBox8.Focus();
            }
        }



        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (alergie == false)
            {
                textBox6.Text = "";
                alergie = true;
                textBox6.Focus();
            }
        }

        private void textBox6_Click_1(object sender, EventArgs e)
        {

            if (alergie == false)
            {
                textBox6.Text = "";
                alergie = true;
                textBox6.Focus();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            d_rmmse  = DateTime.Now.ToString();
            Form17 f = new Form17();
            if (f.ShowDialog() == DialogResult.OK)
            {
                numericUpDown4.Value = f.wynik;
                d_kmmse  = DateTime.Now.ToString();
            }
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Ta czynność spowoduje utratę wszelkich danych wprowadzonych do formularza! Jesteś tego pewien?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    if (MessageBox.Show("Czy chcesz zapisać obecne badanie tak, żeby można je było potem wczytać? Tak = zapisz. Nie = skasuj badanie.", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { ZAPISZ(); e.Cancel = false; }
            //    else
            //    {
            //        e.Cancel = false;
            //        ClearFolder(katalogpacjenta);
            //        Directory.Delete(katalogpacjenta);
            //        Form1 f = new Form1();
            //        f.Show();
            //        f.Refresh();
            //        f.odswiezpacjentow();
            //    }
            //}
            //else
            //{
            //    e.Cancel = true; 
            //}

            //UCZ
           
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { numericUpDown4.Visible = true; button28.Visible = true; numericUpDown4.SendToBack(); } else { numericUpDown4.Visible = false; button28.Visible = false; }
        }

        private void pokażFolderPacjentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Explorer ee = new Explorer();
            ee.url = podstawaurl;
            ee.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            string dupa = podstawaurl + "b_czaszkowe.html";
            Uri url = new Uri(podstawaurl + "b_czaszkowe.html");
            webBrowser1.Url = url;
            Uri url2 = new Uri(podstawaurl + "b_kgorne.html");
            webBrowser2.Url = url2;
            //MessageBox.Show("dupa =" +  dupa);
            //string curDir = Directory.GetCurrentDirectory();
            //this.webBrowser1.Url = new Uri(String.Format("file:///{0}/HTMLPage1.htm", curDir));
        }

        private void button44_Click(object sender, EventArgs e)
        {

        }
        public bool b_czaszkowe = false;
        private void button30_Click(object sender, EventArgs e)
        {
            d_roznc = DateTime.Now.ToString();
            b_czaszkowe = true;
            Form20 f = new Form20();
            f.katalogpacjenta = katalogpacjenta;
            f.podstawaurl = podstawaurl;
            if (f.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Refresh();
                d_zaknc = DateTime.Now.ToString();
            }
        }

        private void button44_Click_1(object sender, EventArgs e)
        {

            string html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html");
            Form21 f = new Form21();
            //f.htmlwysiwyg1.allowEdit(true);

            //f.htmlwysiwyg1.setHTML(html);
            //f.htmlwysiwyg1.addFont("Segoe UI");
            f.html = html;
            f.textBox1.Text = "Badanie nerwów czaszkowych";
            if (f.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html");
                file.WriteLine(f.htmlwysiwyg1.getHTML());
                file.Close();

            }
        }

        private void dodajPlikplikiToolStripMenuItem_Click(object sender, EventArgs e)
        {// Create an instance of the open file dialog box.
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
                    File.Copy(file, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "pliki\\" + System.IO.Path.GetFileName(file));



                }
                MessageBox.Show("Pliki zostały skopiowane!");

            }

        }

        private void pokażDotychczasowePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Explorer ee = new Explorer();
            ee.url = podstawaurl + "pliki";
            ee.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox10.Text = "";
                textBox10.Text += f.numericUpDown1.Value + " bpm (" + f.textBox1.Text + ")";
                if (f.comboBox1.Text != "") { textBox10.Text += ", " + f.comboBox1.Text; }
                if (f.comboBox2.Text != "") { textBox10.Text += ", " + f.comboBox2.Text; }
                if (f.comboBox3.Text != "") { textBox10.Text += ", " + f.comboBox3.Text; }
                if (f.comboBox4.Text != "") { textBox10.Text += ", " + f.comboBox4.Text; }
                if (f.comboBox5.Text != "") { textBox10.Text += ", " + f.comboBox5.Text; }
            }
        }

        private void ocenaBP() {
            if (numericUpDown5.Value < 120 && numericUpDown6.Value < 80) { textBox11.Text = "ciśnienie optymalne (wg ESH/ESC)"; }
            if (numericUpDown5.Value <= 129 && numericUpDown5.Value >= 120 && numericUpDown6.Value <= 84 && numericUpDown6.Value >= 80) { textBox11.Text = "ciśnienie prawidłowe (wg ESH/ESC)"; }
            if (numericUpDown5.Value <= 139 && numericUpDown5.Value >= 130 && numericUpDown6.Value <= 89 && numericUpDown6.Value >= 85) { textBox11.Text = "ciśnienie wysokie prawidłowe (wg ESH/ESC)"; }
            if (numericUpDown5.Value <= 159 && numericUpDown5.Value >= 140 && numericUpDown6.Value <= 99 && numericUpDown6.Value >= 90) { textBox11.Text = "nadciśnienie stopień 1 (łagodne) (wg ESH/ESC)"; }
            if (numericUpDown5.Value <= 179 && numericUpDown5.Value >= 160 && numericUpDown6.Value <= 109 && numericUpDown6.Value >= 100) { textBox11.Text = "nadciśnienie stopień 2 (umiarkowane) (wg ESH/ESC)"; }
            if (numericUpDown5.Value >= 180 && numericUpDown6.Value >= 110) { textBox11.Text = "naciśnienie stopień 3 (cięzkie) (wg ESH/ESC)"; }
            if (numericUpDown5.Value >= 140 && numericUpDown6.Value < 90) { textBox11.Text = "naciśnienie izolowane skurczowe (wg ESH/ESC)"; }
            if (numericUpDown5.Value < 100 && numericUpDown6.Value < 60) { textBox11.Text = "hipotensja"; }
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            ocenaBP();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            ocenaBP();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { textBox10.Enabled = true; button32.Enabled = true; } else { textBox10.Enabled = false; button32.Enabled = false; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { textBox11.Enabled = true; numericUpDown5.Enabled = true; numericUpDown6.Enabled = true; }
            else { textBox11.Enabled = false; numericUpDown5.Enabled = false; numericUpDown6.Enabled = false; }
        
        }

        private void nagrajAdnotacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form24 f = new Form24();
            //f.katalogpacjenta = katalogpacjenta;
            //f.ShowDialog();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            d_rozg = DateTime.Now.ToString();
            etap3 = true;
            Form23 f = new Form23();
            f.katalogpacjenta = katalogpacjenta;
            f.podstawaurl = podstawaurl;
            f.kreator = "kgorna";
            if (f.ShowDialog() == DialogResult.OK)
            {
                d_zakg = DateTime.Now.ToString();
                webBrowser2.Refresh();
            }
            //foreach (Control c in this.Controls)
            //{
             //   if (c.GetType().ToString() == "System.Windows.Form.Textbox")
             //   {
             //       //your code goes here
             //   }
            //}
        }

        private void button36_Click(object sender, EventArgs e)
        {
            d_rozd = DateTime.Now.ToString();
            etap4 = true;
            Form23 f = new Form23();
            f.katalogpacjenta = katalogpacjenta;
            f.podstawaurl = podstawaurl;
            f.kreator = "kdolna";
            if (f.ShowDialog() == DialogResult.OK)
            {
                d_zakd = DateTime.Now.ToString();
                webBrowser3.Refresh();
            }
        }

        private void tabPage9_Paint(object sender, PaintEventArgs e)
        {
            Uri url = new Uri(podstawaurl + "b_kdolne.html");
            webBrowser3.Url = url;
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {

            string html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html");
            Form21 f = new Form21();
            //f.htmlwysiwyg1.allowEdit(true);

            //f.htmlwysiwyg1.setHTML(html);
            //f.htmlwysiwyg1.addFont("Segoe UI");
            f.html = html;
            f.textBox1.Text = "Badanie kończyn górnych";
            if (f.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html");
                file.WriteLine(f.htmlwysiwyg1.getHTML());
                file.Close();

            }
        }

        private void button35_Click(object sender, EventArgs e)
        {

            string html = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html");
            Form21 f = new Form21();
            //f.htmlwysiwyg1.allowEdit(true);

            //f.htmlwysiwyg1.setHTML(html);
            //f.htmlwysiwyg1.addFont("Segoe UI");
            f.html = html;
            f.textBox1.Text = "Badanie kończyn dolnych i tułowia";
            if (f.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html");
                file.WriteLine(f.htmlwysiwyg1.getHTML());
                file.Close();

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { panel4.Enabled = true; } else { panel4.Enabled = false; }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true) { panel5.Enabled = true; } else { panel5.Enabled = false; }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true) { panel7.Enabled = true; } else { panel7.Enabled = false; }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true) { panel6.Enabled = true; } else { panel6.Enabled = false; }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Text = "";
            if (comboBox6.Text != "prawidłowy")
            {
                if (comboBox6.Text == "nieprawidłowy asymetryczny")
                {
                    comboBox7.Enabled = true;
                    comboBox7.Items.Clear();
                    comboBox7.Items.Add("połowiczoniedowładny (koszący)");
                    comboBox7.Items.Add("w rwie kulszowej");
                    comboBox7.Items.Add("brodzący");
                }

                if (comboBox6.Text == "nieprawidłowy symetryczny o szerokiej podstawie")
                {
                    comboBox7.Enabled = true;
                    comboBox7.Items.Clear();
                    comboBox7.Items.Add("tylnosznurowy");
                    comboBox7.Items.Add("móżdżkowy");
                    
                }
                if (comboBox6.Text == "nieprawidłowy symetryczny")
                {
                    comboBox7.Enabled = true;
                    comboBox7.Items.Clear();
                    comboBox7.Items.Add("paraparetyczno-spastyczny (kurczowy)");
                    comboBox7.Items.Add("kurczowo-bezładny (kurczowo-ataktyczny)");
                    comboBox7.Items.Add("parkinsonowski");
                    comboBox7.Items.Add("kaczkowaty");
                }





            }
            else {
                comboBox7.Text = ""; comboBox7.Enabled = false;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Form25 f = new Form25();
            f.katalogpacjenta = katalogpacjenta;
            bool mamid = false;
            int id = 0;
            while (mamid == false) {
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
        }

        private void tabPage10_Paint(object sender, PaintEventArgs e)
        {
            etap5 = true;
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            etap6 = true;
            //odsiezbadaniadodatkowe();
        }
        public void WCZYTAJ()
        {
            if (zapisano == false) { MessageBox.Show("Najpierw zapisz chociaż raz :)","Wiadomość",MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                string podstawa = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "_zapis\\";
                foreach (TabPage t in tabControl1.Controls.OfType<TabPage>())
                {
                    foreach (RadioButton x in t.Controls.OfType<RadioButton>())
                    {
                        //MessageBox.Show(podstawa+x.Name);  
                        if (File.Exists(podstawa+x.Name)) {
                        using (StreamReader writer = new StreamReader(podstawa + x.Name))
                        {
                            x.Checked = Convert.ToBoolean(writer.ReadToEnd());
                        }}
                    }
                    foreach (DateTimePicker x in t.Controls.OfType<DateTimePicker>())
                    {
                        //MessageBox.Show(podstawa+x.Name);  
                        if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                        {
                            x.Value = Convert.ToDateTime(writer.ReadToEnd());
                        }}
                    }
                    foreach (TextBox x in t.Controls.OfType<TextBox>())
                    {
                        //MessageBox.Show(podstawa+x.Name);  
                        if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                        {
                            x.Text = writer.ReadToEnd();
                        }}
                    }
                    foreach (RichTextBox x in t.Controls.OfType<RichTextBox>())
                    {
                        if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                        {
                            x.Text = writer.ReadToEnd();
                        }}
                    }
                    foreach (ComboBox x in t.Controls.OfType<ComboBox>())
                    {
                        if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                        {
                            x.Text = writer.ReadToEnd();
                        }}
                    }
                    foreach (NumericUpDown x in t.Controls.OfType<NumericUpDown>())
                    {
                        if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                        {
                            x.Value = Convert.ToDecimal(writer.ReadToEnd());
                        }}
                    }
                    foreach (CheckBox x in t.Controls.OfType<CheckBox>())
                    {
                        if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                        {
                            x.Checked = Convert.ToBoolean(writer.ReadToEnd());
                        }}
                    }
                    foreach (Panel p in t.Controls.OfType<Panel>())
                    {
                        foreach (RadioButton x in p.Controls.OfType<RadioButton>())
                        {
                            //MessageBox.Show(podstawa+x.Name);  
                            if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                            {
                                x.Checked = Convert.ToBoolean(writer.ReadToEnd()); ;
                            }}
                        }
                        foreach (DateTimePicker x in p.Controls.OfType<DateTimePicker>())
                        {
                            //MessageBox.Show(podstawa+x.Name);  
                            if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                            {
                                x.Value = Convert.ToDateTime(writer.ReadToEnd());
                            }}
                        }
                        foreach (TextBox x in p.Controls.OfType<TextBox>())
                        {
                            //MessageBox.Show(podstawa+x.Name);  
                            if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                            {
                                x.Text = writer.ReadToEnd();
                            }}
                        }
                        foreach (RichTextBox x in p.Controls.OfType<RichTextBox>())
                        {
                            if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                            {
                                x.Text = writer.ReadToEnd();
                            }}
                        }
                        foreach (ComboBox x in p.Controls.OfType<ComboBox>())
                        {
                            if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                            {
                                x.Text = writer.ReadToEnd();
                            }}
                        }
                        foreach (NumericUpDown x in p.Controls.OfType<NumericUpDown>())
                        {
                            if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                            {
                                x.Value = Convert.ToDecimal(writer.ReadToEnd());
                            }}
                        }
                        foreach (CheckBox x in p.Controls.OfType<CheckBox>())
                        {
                            if (File.Exists(podstawa+x.Name)) {using (StreamReader writer = new StreamReader(podstawa + x.Name))
                            {
                                x.Checked = Convert.ToBoolean(writer.ReadToEnd()); ;
                            }}
                        }
                    }
                }
                if (File.Exists(podstawa + "listView1"))
                {
                    listView1.Items.Clear();
                    using (StreamReader writer = new StreamReader(podstawa + "listView1"))
                    {

                        while (!writer.EndOfStream)
                        {
                            string lin = writer.ReadLine();
                            ListViewItem lvi = new ListViewItem();
                            string[] l;
                            l = lin.Split(new Char[] { '\\' });
                            
                            lvi.Text = l[1];
                            //lvi.Group = listView1.Groups[kategoria];
                            //aktywność
                            //string aktywny_txt = "Nie";
                            //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
                            //lvi.SubItems.Add(aktywny_txt);
                            //opis
                            
                            lvi.SubItems.Add(l[2]);
                            lvi.SubItems.Add(l[3]); lvi.Group = listView1.Groups[Convert.ToInt32(l[0])];
                            //lvi.ToolTipText = problem;
                            listView1.Items.Add(lvi);
                        }
                        
                    }
                }
                if (File.Exists(podstawa + "listView2"))
                {
                    listView2.Items.Clear();
                    using (StreamReader writer = new StreamReader(podstawa + "listView2"))
                    {

                        while (!writer.EndOfStream)
                        {
                            string lin = writer.ReadLine();
                            ListViewItem lvi = new ListViewItem();
                            string[] l;
                            l = lin.Split(new Char[] { '\\' });
                            lvi.Text = l[0];
                            //lvi.Group = listView1.Groups[kategoria];
                            //aktywność
                            //string aktywny_txt = "Nie";
                            //if (aktywny == 1) { aktywny_txt = "Tak"; } else { aktywny_txt = "Nie"; }
                            //lvi.SubItems.Add(aktywny_txt);
                            //opis
                            lvi.SubItems.Add(l[1]);
                            lvi.SubItems.Add(l[2]);
                            lvi.SubItems.Add(l[3]);
                            //lvi.ToolTipText = problem;
                            listView2.Items.Add(lvi);
                        }
                    }
                }
                MessageBox.Show("Wczytano!","Wiadomość",MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public bool zapisano = false;
        public void ZAPISZ() {
            //MessageBox.Show("wywoluje");
            string podstawa = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "_zapis\\";
            foreach (Control c in this.Controls) {
                
                if (c is TextBox) { MessageBox.Show(podstawa + c.Name);
                    using (StreamWriter writer = new StreamWriter(podstawa + c.Name))
                    {
                        writer.Write(c.Text);
                    }
                
                }
            
            }
            foreach (TabPage t in tabControl1.Controls.OfType<TabPage>())
            {
                foreach (RadioButton x in t.Controls.OfType<RadioButton>())
                {
                    //MessageBox.Show(podstawa+x.Name);  
                    using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                    {
                        writer.Write(x.Checked);
                    }
                }
                foreach (DateTimePicker x in t.Controls.OfType<DateTimePicker>())
                {
                    //MessageBox.Show(podstawa+x.Name);  
                    using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                    {
                        writer.Write(x.Value.ToString());
                    }
                }
                foreach (TextBox x in t.Controls.OfType<TextBox>())
                {
                    //MessageBox.Show(podstawa+x.Name);  
                    using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                    {
                        writer.Write(x.Text);
                    }
                }
                foreach (RichTextBox x in t.Controls.OfType<RichTextBox>())
                {
                    using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                    {
                        writer.Write(x.Text);
                    }
                }
                foreach (ComboBox x in t.Controls.OfType<ComboBox>())
                {
                    using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                    {
                        writer.Write(x.Text);
                    }
                }
                foreach (NumericUpDown x in t.Controls.OfType<NumericUpDown>())
                {
                    using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                    {
                        writer.Write(x.Value);
                    }
                }
                foreach (CheckBox x in t.Controls.OfType<CheckBox>())
                {
                    using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                    {
                        writer.Write(x.Checked.ToString());
                    }
                }
                foreach (Panel p in t.Controls.OfType<Panel>())
                {
                    foreach (RadioButton x in p.Controls.OfType<RadioButton>())
                    {
                        //MessageBox.Show(podstawa+x.Name);  
                        using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                        {
                            writer.Write(x.Checked);
                        }
                    }
                    foreach (DateTimePicker x in p.Controls.OfType<DateTimePicker>())
                    {
                        //MessageBox.Show(podstawa+x.Name);  
                        using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                        {
                            writer.Write(x.Value.ToString());
                        }
                    }
                    foreach (TextBox x in p.Controls.OfType<TextBox>())
                    {
                        //MessageBox.Show(podstawa+x.Name);  
                        using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                        {
                            writer.Write(x.Text);
                        }
                    }
                    foreach (RichTextBox x in p.Controls.OfType<RichTextBox>())
                    {
                        using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                        {
                            writer.Write(x.Text);
                        }
                    }
                    foreach (ComboBox x in p.Controls.OfType<ComboBox>())
                    {
                        using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                        {
                            writer.Write(x.Text);
                        }
                    }
                    foreach (NumericUpDown x in p.Controls.OfType<NumericUpDown>())
                    {
                        using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                        {
                            writer.Write(x.Value);
                        }
                    }
                    foreach (CheckBox x in p.Controls.OfType<CheckBox>())
                    {
                        using (StreamWriter writer = new StreamWriter(podstawa + x.Name))
                        {
                            writer.Write(x.Checked.ToString());
                        }
                    }
                }
            }
            if (listView1.Items.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter(podstawa + "listView1"))
                    {foreach (ListViewItem i in listView1.Items)
                {
                    
                        int grupa = 0;
                        if (i.Group.ToString() == "hospitalizacje i zabiegi operacyjne") { grupa = 0; }
                        if (i.Group.ToString() == "choroby przebyte i przewlekłe") { grupa = 1; }
                        if (i.Group.ToString() == "problemy związane z obecną chorobą") { grupa = 2; }
                        writer.Write(grupa.ToString() + "\\" + i.SubItems[0].Text + "\\" + i.SubItems[1].Text + "\\" + i.SubItems[2].Text + "\n");
                    }
                }
            }
            if (listView2.Items.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter(podstawa + "listView2"))
                    {foreach (ListViewItem i in listView2.Items)
                {
                    
                        writer.Write(i.SubItems[0].Text + "\\" + i.SubItems[1].Text + "\\" + i.SubItems[2].Text + "\\" + i.SubItems[3].Text + "\n");
                    }
                }
            }
            zapisano = true;
            MessageBox.Show("Zapisano!","Wiadomość",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zapiszObecneUzupełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZAPISZ();
        }

        private void wczytajUzupełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WCZYTAJ(); odsiezbadaniadodatkowe();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            //odsiezbadaniadodatkowe();
            if (listView2.SelectedItems.Count == 1)
            {
                string id = listView2.SelectedItems[0].SubItems[4].Text;
                //MessageBox.Show(" id = " + listView2.SelectedItems[0].SubItems[4].Text);
                using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "pliki"))
                {
                    if (writer.ReadToEnd() == "nie") { MessageBox.Show("Nie ma plików dla tego zaznaczenia"); }
                    else
                    {
                        Explorer ee = new Explorer();
                        
                        ee.url = podstawaurl + "badania_dodatkowe\\" + id + "\\p\\";
                        //MessageBox.Show(ee.url);
                        ee.Show();
                        //System.Diagnostics.Process.Start(Application.StartupPath + "\\");



                    }
                }





            }
            else { MessageBox.Show("Najpierw coś zaznacz."); }
        }

        public void odsiezbadaniadodatkowe() {
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
                    using (StreamReader writer = new StreamReader(directory +  "\\" + "nazwa"))
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
                else {
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

        private void button15_Click_1(object sender, EventArgs e)
        {
            odsiezbadaniadodatkowe();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
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
                    odsiezbadaniadodatkowe();
                }
            }
        }
        private mshtml.IHTMLDocument2 doc;
        const int HowDeepToScan=4; 
        List<string> linkdopliku;
public void ProcessDir(string sourceDir, int recursionLvl) 
{
  linkdopliku.Clear();
    if (recursionLvl<=HowDeepToScan)
  {
    // Process the list of files found in the directory. 
    string [] fileEntries = Directory.GetFiles(sourceDir);
    foreach(string fileName in fileEntries)
    {
       // do something with fileName
       linkdopliku.Add(Uri.EscapeUriString("file://" + sourceDir + "/" + fileName));
    }


    // Recurse into subdirectories of this directory.
    string [] subdirEntries = Directory.GetDirectories(sourceDir);
    foreach(string subdir in subdirEntries)
       // Do not iterate through reparse points
       if ((File.GetAttributes(subdir) &
            FileAttributes.ReparsePoint) !=
                FileAttributes.ReparsePoint)

            ProcessDir(subdir,recursionLvl+1);
  }
}

        private void button1_Click(object sender, EventArgs e)
        {
            odsiezbadaniadodatkowe();
            if (MessageBox.Show("Jesteś pewny, że chcesz zakończyć badanie i wygenerować raport? Przed wygenerowaniem raportu dane formularza zostaną zapisane i będzie je można ponownie wczytac korzystając z menu głównego.", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ZAPISZ();
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
                 }


                d_zakonczenia = DateTime.Now.ToString();
                if (MessageBox.Show("Jeśli to badanie zostało przeprowadzone w rzeczywistości, to czy chciałbyś wysłać anonimowe dane ewaluacyjne informujące o chronometrażu wypełnia elementów formularza?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    string d = d_rozpoczecia + "," + d_zakonczenia + "," + d_rglasgow + "," + d_kglasgow + "," + d_rmmse + "," + d_kmmse + "," + d_rwsocj + "," + d_kwsocj + "," + d_rpukl + "," + d_kpukl + "," + d_zaketap1 + "," + d_zaketap2 + "," + d_roznc + "," + d_zaknc + "," + d_rozg + "," + d_zakd + "," + d_rozd + "," + d_zakd;
                    wyslane = false;
                    Uri d_export = new Uri("http://www.comfortzg.com/badanieneurologiczne/czas.php?d=" + d);
                    Form28 send = new Form28();
                    send.Show();
                    send.webBrowser1.Url = d_export;
                    
                    
                    //webBrowser4.Url = d_export;
                    //while (wyslane == false)
                    //{
                    //    ; ; ; ;
                    //}
                    //Cursor.Current = Cursors.Arrow;
                }

                doc.body.innerText = "";

                // ETAP 1 i 2
                //Backup
                
                Clipboard.Clear();
                control.SelectAll();
                control.Copy();
                doc.execCommand("Paste", false, null);
                richTextBox2.SelectAll();
                richTextBox2.Copy();
                doc.execCommand("Paste", false, null);
                //htmlwysiwyg1.allowEdit(true);
                //htmlwysiwyg1.wklej();
                System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap1i2.html");
                file.WriteLine("<title>Badanie Neurologiczne v1.0 by Konrad Stawiski</title><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\">" + doc.body.innerHTML);
                file.Close();
                Clipboard.Clear();

               
                // TWORZYMY DLA RESZTY
                
                using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "t+rr.html"))
                    {
                        if(checkBox3.Checked) { 
                            string i ="";
                            if (textBox10.Text != "") { i = textBox10.Text; }
                            writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>TĘTNO: </strong></u>" + i +"<br>");
                        }
                    if(checkBox4.Checked) { 
                            string i ="";
                            if (textBox11.Text != "") { i = numericUpDown5.Value + " mmHg / " + numericUpDown6.Value+ " mmHg - " +textBox11.Text; }
                            writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>CIŚNIENIE TĘTNICZE: </strong></u>" + i +"<br>");
                        }


            }
                using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "etap4i5i6.html"))
                {
                    if (checkBox5.Checked)
                    {
                        string i = "";bool objawoponowy = false;
                        if (checkBox6.Checked == true) { i += checkBox6.Text + ", "; objawoponowy = true; }
                        if (checkBox7.Checked == true) { i += checkBox7.Text + ", "; objawoponowy = true; }
                        if (checkBox8.Checked == true) { i += checkBox8.Text + ", "; objawoponowy = true; }
                        if (checkBox13.Checked == true) { i += checkBox13.Text + ", "; objawoponowy = true; }
                        if (checkBox9.Checked == true) { i += checkBox9.Text + ", "; objawoponowy = true; }
                        if (checkBox11.Checked == true) { i += checkBox11.Text + ", "; objawoponowy = true; }
                        if (checkBox10.Checked == true) { i += checkBox10.Text + ", "; objawoponowy = true; }
                        if (checkBox12.Checked == true) { i += checkBox12.Text + ", "; objawoponowy = true; }
                        if (objawoponowy == false) { i = "brak, "; }
                        if (textBox12.Text == "" || textBox12.Text == "uwagi") { } else { i += textBox12.Text; }
                        writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>OBJAWY OPONOWE: </strong></u>" + i + "<br>");
                    }
                    
                    if (checkBox22.Checked)
                    {
                        string i = "";
                        i += "<table border=\"1\"><thead><th>Objaw</th><th>Prawa Strona</th><th>Lewa Strona</th></thead><tbody><tr><td>objaw Lasegue'a</td>";
                        if (checkBox21.Checked == true) { i += "<td><b>obecny</b></td>"; } else { i += "<td>nieobecny</td>"; }
                        if (checkBox18.Checked == true) { i += "<td><b>obecny</b></td>"; } else { i += "<td>nieobecny</td>"; }
                        i += "</tr><tr><td>objaw Fajersztajna-Krzemickiego</td>";
                        if (checkBox14.Checked == true) { i += "<td><b>obecny</b></td>"; } else { i += "<td>nieobecny</td>"; }
                        if (checkBox17.Checked == true) { i += "<td><b>obecny</b></td>"; } else { i += "<td>nieobecny</td>"; }
                        i += "</tr><tr><td>objaw Mackiewicza</td>";
                        if (checkBox15.Checked == true) { i += "<td><b>obecny</b></td>"; } else { i += "<td>nieobecny</td>"; }
                        if (checkBox16.Checked == true) { i += "<td><b>obecny</b></td>"; } else { i += "<td>nieobecny</td>"; }
                        i += "</tr></tbody></table>";
                        if (textBox13.Text == "" || textBox13.Text == "uwagi") { } else { i += textBox13.Text; }
                        writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>OBJAWY KORZENIOWE: </strong></u>" + i + "<br>");
                    }

                    if (checkBox19.Checked)
                    {
                        string i = "";
                        if (comboBox1.Text != "") { i += "lordoza szyjna - " + comboBox1.Text + ", "; }
                        if (comboBox2.Text != "") { i += "kifoza piersiowa - " + comboBox2.Text + ", "; }
                        if (comboBox3.Text != "") { i += "lordoza lędźwiowa - " + comboBox3.Text + ", "; }
                        if (comboBox4.Text != "") { i += "kifoza krzyżowa - " + comboBox4.Text + ", "; }
                        if (checkBox25.Checked == true) { i += checkBox25.Text + ", "; }
                        if (checkBox23.Checked == true) { i += checkBox23.Text + ", "; }
                        if (checkBox24.Checked == true) { i += checkBox24.Text + ", "; }
                        if (checkBox20.Checked == true) { i += checkBox20.Text + ", "; }
                        if (checkBox26.Checked == true) { i += checkBox26.Text + ", "; }
                        if (textBox14.Text == "" || textBox14.Text == "uwagi") { } else { i += textBox14.Text; }
                        writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>OCENA KRĘGOSŁUPA: </strong></u>" + i + "<br>");
                    }


                    if (checkBox27.Checked)
                    {
                        string i = "";
                        if (checkBox28.Checked == true && comboBox5.Text != "") { i += "padanie w kierunku " + comboBox5.Text + ", "; }
                        if (checkBox29.Checked == true) { i += checkBox29.Text + ", "; }
                        if (checkBox28.Checked == false && checkBox29.Checked == false) { i += "negatywna (brak padania) " + comboBox5.Text + ", "; }
                        
                        if (textBox15.Text == "" || textBox15.Text == "uwagi") { } else { i += textBox15.Text; }
                        writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>PRÓBA ROMBERGA: </strong></u>" + i + "<br>");
                    }
                    if (checkBox32.Checked)
                    {
                        string i = "";
                        if (comboBox6.Text != "") { i += comboBox6.Text + ", "; }
                        if (comboBox7.Text != "") { i += comboBox7.Text + ", "; }

                        if (textBox16.Text == "" || textBox16.Text == "uwagi") { } else { i += textBox16.Text; }
                        writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>CHÓD: </strong></u>" + i + "<br>");
                    }

                    writer.Write("<meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><br><u>BADANIA DODATKOWE: </strong></u><br />");
                    writer.Write("<table border=\"1\"><thead><tr><td>Nazwa</td><td>Wynik i opis</td><td>Data</td><td>Pliki</td></thead><tbody>");
                    foreach (ListViewItem i in listView2.Items)
                    {
                        string pliki = "nie wiem";






                        string id = i.SubItems[4].Text;

                        using (StreamReader w = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "pliki"))
                {
                    if (w.ReadToEnd() == "nie") { pliki = "nie"; }
                    else
                    {
                        //ProcessDir(Application.StartupPath + "\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + "pliki",
                        pliki = "";
                        //foreach (string sss in linkdopliku ) { 
                        //pliki += sss + " , ";
                        string uuu = Uri.EscapeUriString("file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\p");
                        pliki += "<a href=\""+uuu+"\">tak</a> ";
                        
                        
                        }



                    }











                        writer.Write("<tr><td>" + i.SubItems[0].Text + "</td><td>" + i.SubItems[1].Text + "</td><td>" + i.SubItems[2].Text + "</td><td>" + pliki + "</td></tr>");
                    }
                    writer.Write("</tbody></table><br><br><br>");

                   
                    

                }


                //TWORZYMY CAŁOŚCIOWY RAPORT:::::::
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
                    using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html"))
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

                    //META
                    if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "end.html"))
                    {
                        using (StreamReader czytnik = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "end.html"))
                        {
                            koniec.Write(czytnik.ReadToEnd());
                        }
                    }
                    else
                    {
                        koniec.Write("<br><table width=\"100%\"><thead><tr><td><b>EWALUACJA: OCENA KOŃCOWA</b></td></tr></thead><tbody><tr><td>[ ] Podsumowanie przekroczyło moje oczekiwania.</td></tr><tr><td>[ ] Podsumowanie spełnia moje oczekiwania.</td></tr><tr><td>[ ] Podsumowanie nie spelnia moich oczekiwań.</td></tr></tbody></table>");
                        string d = d_rozpoczecia + "," + d_zakonczenia + "," + d_rglasgow + "," + d_kglasgow + "," + d_rmmse + "," + d_kmmse + "," + d_rwsocj + "," + d_kwsocj + "," + d_rpukl + "," + d_kpukl + "," + d_zaketap1 + "," + d_zaketap2 + "," + d_roznc + "," + d_zaknc + "," + d_rozg + "," + d_zakd + "," + d_rozd + "," + d_zakd;
                        koniec.Write("<br><font size=\"2\">Chronometraż (kodowany): " + d);
                        TimeSpan t = Convert.ToDateTime(d_zakonczenia) - Convert.ToDateTime(d_rozpoczecia);
                        koniec.Write("<br>Czas całego badania [min]: " + t.TotalMinutes);
                        if (d_rmmse != "" && d_kmmse != "")
                        {
                            t = Convert.ToDateTime(d_kmmse) - Convert.ToDateTime(d_rmmse);
                            koniec.Write("| Czas MMSE [min]: " + t.TotalMinutes);
                        }
                        if (d_kpukl != "" && d_rpukl != "")
                        {
                            t = Convert.ToDateTime(d_kpukl) - Convert.ToDateTime(d_rpukl);
                            koniec.Write("| Czas Przeglądu układów [min]: " + t.TotalMinutes);
                        }
                        if (d_kwsocj != "" && d_rwsocj != "")
                        {
                            t = Convert.ToDateTime(d_kwsocj) - Convert.ToDateTime(d_rwsocj);
                            koniec.Write("| Czas Wywiadu socjalnego [min]: " + t.TotalMinutes);
                        }
                        if (d_zaketap1 != "" && d_rozpoczecia != "")
                        {
                            t = Convert.ToDateTime(d_zaketap1) - Convert.ToDateTime(d_rozpoczecia);
                            koniec.Write("| Czas Etapu 1 [min]: " + t.TotalMinutes);
                        }
                        if (d_zaketap2 != "" && d_zaketap1 != "")
                        {
                            t = Convert.ToDateTime(d_zaketap2) - Convert.ToDateTime(d_zaketap1);
                            koniec.Write("| Czas Etapu 2 [min]: " + t.TotalMinutes);
                        }
                        if (d_zaknc != "" && d_roznc != "")
                        {
                            t = Convert.ToDateTime(d_zaknc) - Convert.ToDateTime(d_roznc);
                            koniec.Write("| Czas Bad. NC [min]: " + t.TotalMinutes);
                        }
                        if (d_zakg != "" && d_rozg != "")
                        {
                            t = Convert.ToDateTime(d_zakg) - Convert.ToDateTime(d_rozg);
                            koniec.Write("| Czas Bad. K. Górnych [min]: " + t.TotalMinutes);
                        }
                        if (d_zakd != "" && d_rozd != "")
                        {
                            t = Convert.ToDateTime(d_zakd) - Convert.ToDateTime(d_rozd);
                            koniec.Write("| Czas Bad. K. Dolnych [min]: " + t.TotalMinutes);
                        }
                        koniec.Write("</font><br>");
                    }
                    koniec.Write("<font size=\"1\"><a href=\"http://www.comfortzg.com/badanieneurologiczne\">Wygenerowany przez Badanie Neurologiczne by Konrad Stawiski v1.0 SUPREME</a></font></html>");


                    using (StreamWriter kkk = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\_zapis\\data_pierwszego_badania"))
                    { kkk.Write(dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day); }

                }

                //ARCHIWIZACJA CHRONOMETRAZU
                if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "end.html"))
                {
                    using (StreamWriter koniec = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "end.html"))
                    {
                        koniec.Write("<br><table width=\"100%\"><thead><tr><td><b>EWALUACJA: OCENA KOŃCOWA</b></td></tr></thead><tbody><tr><td>[ ] Podsumowanie przekroczyło moje oczekiwania.</td></tr><tr><td>[ ] Podsumowanie spełnia moje oczekiwania.</td></tr><tr><td>[ ] Podsumowanie nie spelnia moich oczekiwań.</td></tr></tbody></table>");
                        string d = d_rozpoczecia + "," + d_zakonczenia + "," + d_rglasgow + "," + d_kglasgow + "," + d_rmmse + "," + d_kmmse + "," + d_rwsocj + "," + d_kwsocj + "," + d_rpukl + "," + d_kpukl + "," + d_zaketap1 + "," + d_zaketap2 + "," + d_roznc + "," + d_zaknc + "," + d_rozg + "," + d_zakd + "," + d_rozd + "," + d_zakd;
                        koniec.Write("<br><font size=\"2\">Chronometraż (kodowany): " + d);
                        TimeSpan t = Convert.ToDateTime(d_zakonczenia) - Convert.ToDateTime(d_rozpoczecia);
                        koniec.Write("<br>Czas całego badania [min]: " + t.TotalMinutes);
                        //t = Convert.ToDateTime(d_kmmse) - Convert.ToDateTime(d_rmmse);
                        if (d_rmmse != "" && d_kmmse != "")
                        {
                            t = Convert.ToDateTime(d_kmmse) - Convert.ToDateTime(d_rmmse);
                            koniec.Write("| Czas MMSE [min]: " + t.TotalMinutes);
                        }
                        if (d_kpukl != "" && d_rpukl != "")
                        {
                            t = Convert.ToDateTime(d_kpukl) - Convert.ToDateTime(d_rpukl);
                            koniec.Write("| Czas Przeglądu układów [min]: " + t.TotalMinutes);
                        }
                        if (d_kwsocj != "" && d_rwsocj != "")
                        {
                            t = Convert.ToDateTime(d_kwsocj) - Convert.ToDateTime(d_rwsocj);
                            koniec.Write("| Czas Wywiadu socjalnego [min]: " + t.TotalMinutes);
                        }
                        if (d_zaketap1 != "" && d_rozpoczecia != "")
                        {
                            t = Convert.ToDateTime(d_zaketap1) - Convert.ToDateTime(d_rozpoczecia);
                            koniec.Write("| Czas Etapu 1 [min]: " + t.TotalMinutes);
                        }
                        if (d_zaketap2 != "" && d_zaketap1 != "")
                        {
                            t = Convert.ToDateTime(d_zaketap2) - Convert.ToDateTime(d_zaketap1);
                            koniec.Write("| Czas Etapu 2 [min]: " + t.TotalMinutes);
                        }
                        if (d_zaknc != "" && d_roznc != "")
                        {
                            t = Convert.ToDateTime(d_zaknc) - Convert.ToDateTime(d_roznc);
                            koniec.Write("| Czas Bad. NC [min]: " + t.TotalMinutes);
                        }
                        if (d_zakg != "" && d_rozg != "")
                        {
                            t = Convert.ToDateTime(d_zakg) - Convert.ToDateTime(d_rozg);
                            koniec.Write("| Czas Bad. K. Górnych [min]: " + t.TotalMinutes);
                        }
                        if (d_zakd != "" && d_rozd != "")
                        {
                            t = Convert.ToDateTime(d_zakd) - Convert.ToDateTime(d_rozd);
                            koniec.Write("| Czas Bad. K. Dolnych [min]: " + t.TotalMinutes);
                        }
                        koniec.Write("</font><br>");
                    }
                }
                
                //BADANIE: CZAS
    //                public string d_rozpoczecia = "";
    
    //public string d_rglasgow = "";
    //public string d_kglasgow = "";

    //public string d_rmmse = "";
    //public string d_kmmse = "";

    //public string d_zaketap1 = "";

    //public string d_rwsocj = "";
    //public string d_kwsocj = "";

    //public string d_rpukl = "";
    //public string d_kpukl = "";

    //public string d_zaketap2 = "";

    //public string d_zaknc = "";
    //public string d_zakg = "";
    //public string d_zakd = "";
    //public string d_roznc = "";
    //public string d_rozg = "";
    //public string d_rozd = "";
    //public string d_zakonczenia = "";
               
                //Pokazujemy dzieło
                Form26 f = new Form26();
                Uri url = new Uri(podstawaurl + "index.html");
                f.webBrowser1.Url = url;
                f.Show();
                f.katalogpacjenta = katalogpacjenta; f.podstawaurl = podstawaurl;
                this.Close();
            }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 5)
            { MessageBox.Show("Najprawdopodobniej zakończyłeś badanie. Przejdź do rozpoznania i podsumowania (czerwony przycisk na dole). "); }
            else
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            { MessageBox.Show("Nie mogę się jeszcze bardziej cofnąć :("); }
            else
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value >= DateTime.Now) { dateTimePicker1.Value = DateTime.Now; }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox32.Checked) { panel8.Enabled = true; } else { panel8.Enabled = false; }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.comfortzg.com/badanieneurologiczne");
        }

        private void adnotacjeGłosoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotatkiGlosowe n = new NotatkiGlosowe();
            n.katalogpacjenta = katalogpacjenta;
            n.Show();
            n.toolStripLabel1.Text = katalogpacjenta;

        }
        bool wyslane = false;
        private void webBrowser4_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //wyslane = false;
        }

        private void webBrowser4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wyslane = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void platformaEleariningowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elearning el = new elearning();
            el.Show();
        }
        
        
        
        
        
        }

    }

