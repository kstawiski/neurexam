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
//using Istrib.Sound.Example.WinForms;

namespace Badanie_Neurologiczne
{
    
    
    
    
    public partial class Form1 : Form
    {
        private FormWindowState mLastState;
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                         string lpFileName);
        public Form1()
        {
            //SPRAWDZANIE ROZDZIELCZOSCI
            if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski")) { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski"); }
            
            bool spelniaw = false;
                bool spelniah = false;
                int spelnia = 0;
                if (Screen.AllScreens.Count() > 1)
                {
                    bool wybralemekran = false;
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (wybralemekran==false) {
                        spelniah = false; spelniaw = false;
                        if (s.Bounds.Height < 735) {  } else { spelniah = true; }
                        if (s.Bounds.Width < 955) { } else { spelniaw = true; }
                        if (spelniah == true && spelniaw == true) {
                            spelnia++;
                            if (MessageBox.Show("Posiadasz podłączony więcej niż jeden ekran. Ekran " + s.DeviceName + "  spełnia wymagania aplikacji. Czy chcesz go używać? Jesli klikniejsz nie zostanie Ci zaproponowany kolejny ekran, który spełnia wymagania.", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            wybralemekran=true;
                            this.Location = new Point(s.Bounds.X, s.Bounds.Y);
                            
                            
                            }
                        
                        }
                        }

                    }
                    if (wybralemekran == false) {
                        if (spelnia > 1) {
                            MessageBox.Show("Nie wybrałeś żadnego z proponowanych ekranów. Będzie użyty pierwszy ekran spełniający wymagania. Jeśli chcesz to zmienić zrestartuj aplikacje.");
                            foreach (Screen s in Screen.AllScreens)
                            {
                                if (wybralemekran == false)
                                {
                                    spelniah = false; spelniaw = false;
                                    if (s.Bounds.Height < 735) { } else { spelniah = true; }
                                    if (s.Bounds.Width < 955) { } else { spelniaw = true; }
                                    if (spelniah == true && spelniaw == true)
                                    {

                                        wybralemekran = true;
                                        this.Location = new Point(s.Bounds.X, s.Bounds.Y);




                                    }
                                }
                            }
                        }
                        if (spelnia == 1) {
                    MessageBox.Show("Niestety żaden inny ekran nie pełnia kryteriów.");
                        foreach (Screen s in Screen.AllScreens)
                    {
                        if (wybralemekran == false)
                        {
                            spelniah = false; spelniaw = false;
                            if (s.Bounds.Height < 735) { } else { spelniah = true; }
                            if (s.Bounds.Width < 955) { } else { spelniaw = true; }
                            if (spelniah == true && spelniaw == true)
                            {
                                
                                    wybralemekran = true;
                                    this.Location = new Point(s.Bounds.X, s.Bounds.Y);


                                

                            }
                        }
                    }
                    
                    }

                    if (spelnia == 0)
                    {
                        if (MessageBox.Show("Wymagane jest 735 pikseli wysokości oraz 955 pikseli szerokości. Żaden z twoich podłączonych ekranów nie spełnia tych wymagań. Mogą pojawić się błędy obsługi grafiki. Czy chcesz kontynuuować uruchamianie?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.No) { Application.Exit(); }
                    
                    }

                    
                    
                    }
                }
                else
                {
                    if (Screen.PrimaryScreen.Bounds.Height < 735) { spelniah = false; } else { spelniah = true; }; if (Screen.PrimaryScreen.Bounds.Width < 955) { spelniaw = false; } else { spelniaw = true; };
                    if (spelniah == false || spelniaw == false) { 
                        if (MessageBox.Show("Wymagane jest 735 pikseli wysokości oraz 955 pikseli szerokości. Twoja rozdzielczość ekranu wydaje się być za mała aby program mógł być w pełni funkcjonalny. Mogą pojawić się błędy obsługi grafiki. Czy chcesz kontynuuować uruchamianie?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.No) { Application.Exit(); }
                        
                    
                    }
                }
            // INSTALACJA CZCIONEK
            int result = -1;
            int error = 0;
            result = AddFontResource(Application.StartupPath + "\\seguisb.ttf");
            error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
                //MessageBox.Show("Błąd instalacji czcionek!");
            }
            else
            {
                // wszystko ok
            }
            result = AddFontResource(Application.StartupPath + "\\segoeui.ttf");
            error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
                //MessageBox.Show("Błąd instalacji czcionek!");
            }
            else
            {
                // wszystko ok
            }
            result = AddFontResource(Application.StartupPath + "\\segoeuib.ttf");
            error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
                //MessageBox.Show("Błąd instalacji czcionek!");
            }
            else
            {
                // wszystko ok
            }
            result = AddFontResource(Application.StartupPath + "\\segoeuii.ttf");
            error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
                //MessageBox.Show("Błąd instalacji czcionek!");
            }
            else
            {
                // wszystko ok
            }
            result = AddFontResource(Application.StartupPath + "\\segoeuiz.ttf");
            error = Marshal.GetLastWin32Error();
            if (error != 0)
            {
               // MessageBox.Show("Błąd instalacji czcionek!");
            }
            else
            {
                // wszystko ok
            }
            
            
            
            
            
            
            
            string fontName = "Segoe UI";
            float fontSize = 12;

            //if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeui.ttf")) { MessageBox.Show(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeuisb.ttf"); }
                
                Font fontTester = new Font(
                fontName,
                fontSize,
                FontStyle.Regular,
                GraphicsUnit.Pixel);

            if (fontTester.Name == fontName)
            {
                // Font exists
                
            }
            else
            {
                // Font doesn't exist
                if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeui.ttf")) { File.Copy("segoeui.ttf", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeui.ttf"); }
                if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeuib.ttf")) { File.Copy("segoeuib.ttf", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeuib.ttf"); }
                if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeuii.ttf")) { File.Copy("segoeuii.ttf", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeuii.ttf"); }
                if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeuiz.ttf")) { File.Copy("segoeuiz.ttf", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\segoeuiz.ttf"); }
            }
            if (!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\seguisb.ttf")) { File.Copy(Application.StartupPath + "\\seguisb.ttf", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts) + "\\seguisb.ttf"); }
            InitializeComponent(); mLastState = this.WindowState;
            panel1.Location = new Point(
    this.ClientSize.Width / 2 - panel1.Size.Width / 2,
    this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            label5.Location = new Point(0, 0);
            label1.Size = new Size(this.ClientSize.Width - 2, this.ClientSize.Height - 2);
            label1.Location = new Point(0, 0);
            //linkLabel1.Location = new Point(this.ClientSize.Width - 144, 0);
            button1.Location = new Point(this.ClientSize.Width - button1.Size.Width - 2, 2);
            button2.Location = new Point(this.ClientSize.Width - button1.Size.Width - 2 - 2 - button2.Size.Width, 2);

            if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p"))
            {
                DirectoryInfo di = Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p");
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\auto");
            }
            if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt"))
            {
                using (StreamReader writer = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt"))
                { textBox1.Text = writer.ReadToEnd(); }
            }
            
            timer1.Enabled = true;
            if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci") == true) { } else { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci"); };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            label1.Text = Convert.ToString(DateTime.Now);
            if (Application.OpenForms.Count == 1) { panel1.Visible = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            elearning elearning = new elearning();
            elearning.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 dodatki = new Form3();
            dodatki.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\";
            MessageBox.Show(path);
            System.Diagnostics.Process.Start(@path);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 bazaprzypadków = new Form4();
            bazaprzypadków.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            if (f.ShowDialog() == DialogResult.OK) {

textBox1.Text =
      File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\p\\lekarz.txt");
}
        }

        private void button6_Click(object sender, EventArgs e)
        {
        
        }
        public void odswiezpacjentow()
        {
            listBox1.Items.Clear();
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\";
            DirectoryInfo MyRoot = new DirectoryInfo(path);

            DirectoryInfo[] MySub = MyRoot.GetDirectories();
            foreach (DirectoryInfo D in MySub)
            {
                listBox1.Items.Add(D.Name);

            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(
    this.ClientSize.Width / 2 - panel1.Size.Width / 2,
    this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            label5.Location = new Point(0, 0);
            label1.Size = new Size(this.ClientSize.Width - 2, this.ClientSize.Height - 2);
            label1.Location = new Point(0, 0);
            //linkLabel1.Location = new Point(this.ClientSize.Width - 144, 0);
            button1.Location = new Point(this.ClientSize.Width - button1.Size.Width - 2, 2);
            button2.Location = new Point(this.ClientSize.Width - button1.Size.Width - 2 - 2 - button2.Size.Width, 2);







            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\";
            DirectoryInfo MyRoot = new DirectoryInfo(path);

            DirectoryInfo[] MySub = MyRoot.GetDirectories();
            foreach (DirectoryInfo D in MySub)
            {
                listBox1.Items.Add(D.Name);

            }
        }
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Form9 f9 = new Form9();
            if (f9.ShowDialog() == DialogResult.OK)
            {




                Form8 f = new Form8();
                
                f.label2.Text = "pacjent: " + f9.textBox2.Text + " " + f9.textBox3.Text;
                f.katalogpacjenta = "Pacjenci\\" + f9.textBox3.Text + " " + f9.textBox2.Text + "\\";
                string strFilename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + f.katalogpacjenta + "parametry.xml";
                //MessageBox.Show("strFilename= " + strFilename );
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFilename);

                XmlNodeList imie = xmlDoc.GetElementsByTagName("imie");
                f.textBox3.Text = imie[0].InnerText;
                XmlNodeList nazwisko = xmlDoc.GetElementsByTagName("nazwisko");
                f.textBox1.Text = nazwisko[0].InnerText;
                
                //generowanie podstawy odczytu HTMLi
                string uu = "file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/Badanie Neurologiczne by Konrad Stawiski/" + f.katalogpacjenta;
                f.podstawaurl = uu.Replace("\\","/");
                //MessageBox.Show(f.podstawaurl);
              
                
                
                
                
                
                f.wyliczbmi(); f.Show();
                if (f9.radioButton2.Checked == true) { f.zapisano = true;  f.WCZYTAJ(); }
                //tutaj jeszcze przerzucenie do pola imienia i nazwiska (może) 
                //this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Czy jesteś pewnien, że chcesz zakończyć działanie programu?", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
    this.ClientSize.Width / 2 - panel1.Size.Width / 2,
    this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            label5.Location = new Point(0, 0);
            label1.Size = new Size(this.ClientSize.Width - 2, this.ClientSize.Height - 2);
            label1.Location = new Point(0, 0);
            //linkLabel1.Location = new Point(this.ClientSize.Width - 144, 0);
            button1.Location = new Point(this.ClientSize.Width - button1.Size.Width - 2, 2);
            button2.Location = new Point(this.ClientSize.Width - button1.Size.Width - 2 -2 - button2.Size.Width, 2);


            //foreach (Form f in Application.OpenForms) { if (f != this) { this.Focus(); f.Activate(); f.Focus(); } }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Czy jesteś pewnien, że chcesz zakończyć działanie programu?", "Potwierdzenie", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            if (Application.OpenForms.Count > 1)
            {
                if (MessageBox.Show("Widzę, że są jeszcze otwarte okna! Czy na pewno chcesz zamknąć program???", "Potwierdzenie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { Application.Exit(); }
            }
            else
            {


                Application.Exit();
            }
//}
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            panel1.Visible = true; panel1.Enabled = true; 
            //foreach (Form f in Application.OpenForms) { if (f != this) { this.Focus(); f.Activate(); f.Focus(); } }
            
        }
        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (this.WindowState != mLastState)
            {
                mLastState = this.WindowState;
                OnWindowStateChanged(e);
            }
            base.OnClientSizeChanged(e);
        }
        protected void OnWindowStateChanged(EventArgs e)
        {
            // Do your stuff
            
            //foreach (Form f in Application.OpenForms) { if (f != this) { this.Focus(); f.Activate(); f.Focus(); } }
        }

        private bool CheckForm(Form form)
        {
            foreach (Form f in Application.OpenForms)
                if (form == f)
                    return true;

            return false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //foreach (Form f in Application.OpenForms) { if (f != this) { this.Focus(); f.Activate(); f.Focus(); } }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           // foreach (Form f in Application.OpenForms) { if (f != this) { this.Focus(); f.Activate(); f.Focus(); f.Show();  } }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("działam"); foreach (Form f in Application.OpenForms) { if (f != this) { MessageBox.Show("przeszedłem if"); this.Focus(); f.Activate(); f.Focus(); } }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                foreach (Form f in Application.OpenForms) { if (f != this) { f.Activate(); } }
            }
            
        }
        private bool pierwszklikform1 = true;
        private void label1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                foreach (Form f in Application.OpenForms) { if (f != this) { f.Activate(); } }
            }
            else { panel1.Visible = true; }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Istrib.Sound.Example.WinForms.MainForm());
            //Istrib.Sound.Example.WinForms.MainForm f = new Istrib.Sound.Example.WinForms.MainForm();
            //Application.Run(new Istrib.Sound.Example.WinForms.MainForm());
            Form20 f = new Form20();
            f.Show();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
           string html=File.ReadAllText(openFileDialog1.FileName);
                Form21 f = new Form21();
            //f.htmlwysiwyg1.allowEdit(true);
            
            //f.htmlwysiwyg1.setHTML(html);
            //f.htmlwysiwyg1.addFont("Segoe UI");
            f.html = html;
            f.textBox1.Text = openFileDialog1.FileName;
            if (f.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(openFileDialog1.FileName);
file.WriteLine(f.htmlwysiwyg1.getHTML());
file.Close();






            }



            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.comfortzg.com/badanieneurologiczne");
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                string katalogpacjenta = "Pacjenci\\" + listBox1.SelectedItem + "\\";
                string uu = "file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/Badanie Neurologiczne by Konrad Stawiski/" + katalogpacjenta;
                string podstawaurl = uu.Replace("\\","/");
                
                //string podstawaurl = Uri.EscapeUriString("file://" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta);
                Form26 f = new Form26();
                Uri url = new Uri(podstawaurl + "index.html");
                f.webBrowser1.Url = url; 
                f.Show();
                f.katalogpacjenta = katalogpacjenta; f.podstawaurl = podstawaurl;
                if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "_zapis\\_rozpoznanie.html")) { f.rozp = true; } else { f.rozp = false; }
                //this.Close();

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //backup pacjentów
            //string backuppath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "Badanie Neurologiczne (backup)";
            //string SourcePath = Application.StartupPath + "Pacjenci\\";
            //if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "Badanie Neurologiczne (backup)")) { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "Badanie Neurologiczne (backup)"); }
            //string fullPath = Path.GetFullPath(SourcePath).TrimEnd(Path.DirectorySeparatorChar);
            //string projectName = Path.GetFileName(fullPath);
            //if Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "Badanie Neurologiczne (backup)\\Pacjenci"));
            //string DestinationPath = Application.StartupPath + "\\" + katalogpacjenta + "badania_dodatkowe\\" + id + "\\" + projectName + "\\";
            ////Now Create all of the directories
            //foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
            //    SearchOption.AllDirectories))
            //    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            ////Copy all the files
            //foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
            //    SearchOption.AllDirectories))
            //    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath));
            //pliki = "tak"; MessageBox.Show("Skopiowano!");
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NotatkiGlosowe n = new NotatkiGlosowe();
            n.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.comfortzg.com/badanieneurologiczne/?page_id=36");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.comfortzg.com/badanieneurologiczne/?page_id=40");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.comfortzg.com/badanieneurologiczne/?page_id=44");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            elearning el = new elearning();
            el.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            FollowUp  f = new FollowUp();
            f.Show();
        }
    }

 

}
