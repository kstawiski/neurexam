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


namespace Badanie_Neurologiczne
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
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
        }
        public void dodajparametr(string nazwa, string wart)
        {
            string katalogpacjenta = "Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\";
            string strFilename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry.xml";
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(strFilename) == false)
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                  "<Pacjent>"+ "<imie></imie>" + "<nazwisko></nazwisko>"+
                                  "</Pacjent>");
                xml.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry.xml");
            }
            xmlDoc.Load(strFilename);

            XmlElement elmXML = xmlDoc.CreateElement(nazwa);
            XmlNodeList wynik = xmlDoc.GetElementsByTagName(nazwa);
            wynik[0].InnerText = wart;
            elmXML.InnerText = wart;
            xmlDoc.Save(strFilename);
        }
        public void odczytajparametr(string nazwa)
        {

            //MessageBox.Show("nazwa = " + nazwa);
            string katalogpacjenta = "Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\";
            string strFilename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry.xml";
            //MessageBox.Show("strFilename= " + strFilename );
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilename);

            XmlNodeList wynik = xmlDoc.GetElementsByTagName(nazwa);
            MessageBox.Show(wynik[0].InnerText);



        }
        private void button5_Click(object sender, EventArgs e)
        {
            bool uzup = true;
            if (textBox2.Text == "") { MessageBox.Show("Uzupełnij!"); uzup = false; }
            if (textBox3.Text == "") { MessageBox.Show("Uzupełnij!"); uzup = false; }
            if (uzup == true)
            {
                if (radioButton1.Checked == true)
                {
                    if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text) == true) { MessageBox.Show("Taki pacjent już istnieje!"); } else { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text); };
                    if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\obrazki") == true) { MessageBox.Show("Taki pacjent już istnieje!"); } else { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\obrazki"); };
                    if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\pliki") == true) { MessageBox.Show("Taki pacjent już istnieje!"); } else { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\pliki"); };
                    if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\badania_dodatkowe") == true) { MessageBox.Show("Taki pacjent już istnieje!"); } else { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\badania_dodatkowe"); };
                    if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\notatki i nagrania") == true) { MessageBox.Show("Taki pacjent już istnieje!"); } else { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\notatki i nagrania"); };
                    if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\_zapis") == true) { MessageBox.Show("Taki pacjent już istnieje!"); } else { Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\_zapis"); };
                    dodajparametr("imie", textBox2.Text);
                    dodajparametr("nazwisko", textBox3.Text);





                    //tworzenie HTMLi JEŚLI NOWY!
                    string katalogpacjenta = "Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\";
                    using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html"))
                    {
                        writer.Write("<HTML><font face=\"Segoe UI\"><strong>Jeszcze nie przeprowadzono</strong></HTML>");

                    }

                    using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kgorne.html"))
                    {
                        writer.Write("<HTML><font face=\"Segoe UI\"><strong>Jeszcze nie przeprowadzono</strong></HTML>");

                    }
                    using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_kdolne.html"))
                    {
                        writer.Write("<HTML><font face=\"Segoe UI\"><strong>Jeszcze nie przeprowadzono</strong></HTML>");

                    }


                }
                if (radioButton2.Checked == true)
                {
                    string katalogpacjenta = "Pacjenci\\" + comboBox1.Text + "\\"; string strFilename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry.xml";
                    //MessageBox.Show("strFilename= " + strFilename );
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(strFilename);

                    XmlNodeList imie = xmlDoc.GetElementsByTagName("imie");
                    textBox2.Text = imie[0].InnerText;
                    XmlNodeList nazwisko = xmlDoc.GetElementsByTagName("nazwisko");
                    textBox3.Text = nazwisko[0].InnerText;

                }
                //odczytajparametr("imie");
                //odczytajparametr("nazwisko");

                //string katalogpacjenta = "Pacjenci\\" + textBox3.Text + " " + textBox2.Text + "\\";
                //string strFilename = katalogpacjenta + "parametry.xml";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(strFilename);

                //XmlElement elmXML = xmlDoc.CreateElement("imie");
                //elmXML.InnerText = textBox2.Text;
                //XmlElement elmXML2 = xmlDoc.CreateElement("nazwisko");
                //elmXML2.InnerText = textBox2.Text;

                //TextWriter tw = new StreamWriter(katalogpacjenta + "_parametry");
                //tw.WriteLine("imie = " + textBox2.Text);
                //tw.WriteLine("nazwisko = " + textBox3.Text);
                //tw.Close();
                DialogResult = DialogResult.OK;

                


                //UCZ
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
                            w.Write(c.Text);w.Close();
                        }
                    }
                }
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\Pacjenci\\";
            DirectoryInfo MyRoot = new DirectoryInfo(path);

            DirectoryInfo[] MySub = MyRoot.GetDirectories();
            foreach (DirectoryInfo D in MySub)
            {
                comboBox1.Items.Add(D.Name);

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) { radioButton2.Checked = false; } else { radioButton2.Checked = true; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { radioButton1.Checked = false; comboBox1.Enabled = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; button5.Text = "wczytaj badanie pacjenta"; } else { radioButton1.Checked = true; comboBox1.Enabled = false; textBox2.ReadOnly = false; textBox3.ReadOnly = false; button5.Text = "dodaj pacjenta"; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string katalogpacjenta = "Pacjenci\\" + comboBox1.Text + "\\"; string strFilename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "parametry.xml";
            //MessageBox.Show("strFilename= " + strFilename );
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFilename);

            XmlNodeList imie = xmlDoc.GetElementsByTagName("imie");
            textBox2.Text = imie[0].InnerText;
            XmlNodeList nazwisko = xmlDoc.GetElementsByTagName("nazwisko");
            textBox3.Text = nazwisko[0].InnerText;
        }
    }
}
