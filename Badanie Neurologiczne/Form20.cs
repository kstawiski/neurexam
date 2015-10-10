using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Badanie_Neurologiczne
{
    public partial class Form20 : Form
    {
        
        public Form20()
        {
            InitializeComponent(); OcenOdruchZreniczny(); OcenRuchOczu(); label15.Text = ""; ocenczucieNCV(); ocenaNCV();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { comboBox2.Enabled = true; } else { comboBox2.Enabled = false; }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "prawidłowe") { panel1.Enabled = true; } else { panel1.Enabled = false; }
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            comboBox2.Text = "prawidłowe"; toolStripTextBox1.Text = "5,00"; toolStripTextBox2.Text = "5,00"; comboBox3.Text = "brak znaczenia plamki żółtej";
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.numericUpDown2, "Klikając bezpośrednio na cyfry otworzysz mini-kalkulator!"); ToolTip1.SetToolTip(this.numericUpDown1, "Klikając bezpośrednio na cyfry otworzysz mini-kalkulator!");

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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        bool ostroscleweoko;
        private void numericUpDown2_MouseClick(object sender, MouseEventArgs e)
        {
            ostroscleweoko = true; contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            toolStripTextBox1.Text = "5,00"; toolStripTextBox2.Text = "5,00";
        }

        private void contextMenuStrip1_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (toolStripTextBox1.Text != "" && toolStripTextBox2.Text != "")
            {
                decimal d = Convert.ToDecimal(toolStripTextBox1.Text);
                decimal D = Convert.ToDecimal(toolStripTextBox2.Text);
                decimal wynik = d / D;
                if (ostroscleweoko == true) { numericUpDown2.Value = wynik; }
                if (ostroscleweoko == false) { numericUpDown1.Value = wynik; }
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                string Str = toolStripTextBox1.Text.Trim();
                double Num;
                bool isNum = double.TryParse(Str, out Num);
                if (isNum == false) { MessageBox.Show("To musi być liczba!"); toolStripTextBox1.Text = "5,00"; }
            }

        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text != "")
            {
                string Str = toolStripTextBox2.Text.Trim();
                double Num;
                bool isNum = double.TryParse(Str, out Num);
                if (isNum == false) { MessageBox.Show("To musi być liczba!"); toolStripTextBox2.Text = "5,00"; }
            }
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            ostroscleweoko = false; contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true) { numericUpDown1.Enabled = true; numericUpDown2.Enabled = true; } else { numericUpDown1.Enabled = false; numericUpDown2.Enabled = false; } 
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) { panel2.Enabled = true; } else { panel2.Enabled = false; }
        }
        private void czegoniewidze() {
            bool mamdiagnoze = false;
            if (checkBox9.Checked == true && checkBox7.Checked == true && checkBox8.Checked == true && checkBox10.Checked == true && checkBox11.Checked == true && checkBox12.Checked == true && checkBox13.Checked == true && checkBox14.Checked == true && checkBox15.Checked == true && checkBox16.Checked == true) { textBox3.Text = "prawidłowe"; mamdiagnoze = true; }
            if (comboBox3.Text == "znaczenie plamki żółtej")
            {
                if (mamdiagnoze == false) { if (checkBox9.Checked == true && checkBox7.Checked == true && checkBox8.Checked == true && checkBox10.Checked == true && checkBox11.Checked == true && checkBox12.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false) { textBox3.Text = "ślepota jednostronna oka prawego (uszkodznie nerwu wzrokowego)"; label5.Visible = true; label5.Location = new Point(519, 49); mamdiagnoze = true; } }
                if (mamdiagnoze == false) { if (checkBox9.Checked == false && checkBox7.Checked == false && checkBox8.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox12.Checked == true && checkBox13.Checked == true && checkBox14.Checked == true && checkBox15.Checked == true && checkBox16.Checked == true) { textBox3.Text = "ślepota jednostronna oka lewego (uszkodznie nerwu wzrokowego)"; label5.Visible = true; label5.Location = new Point(449, 49); mamdiagnoze = true; } }
                if (mamdiagnoze==false) {if(checkBox7.Checked==false && checkBox8.Checked==false && checkBox9.Checked==false && checkBox10.Checked==false && checkBox11.Checked==false && checkBox12.Checked==false && checkBox13.Checked==false && checkBox14.Checked==false && checkBox15.Checked==false && checkBox16.Checked==false) {textBox3.Text = "Całkowita ślepota"; mamdiagnoze=true;  } }
                if (mamdiagnoze==false) { if(checkBox7.Checked==true && checkBox8.Checked==true && checkBox9.Checked==true && checkBox10.Checked==true && checkBox11.Checked==true && checkBox12.Checked==false && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==true && checkBox16.Checked==true)   {textBox3.Text = "ślepota plamkowa oka prawego";label5.Visible = true; label5.Location= new Point (529,20);  mamdiagnoze=true;  } }
                if (mamdiagnoze == false) { if (checkBox7.Checked == false && checkBox8.Checked == true && checkBox9.Checked == true && checkBox10.Checked == true && checkBox11.Checked == true && checkBox12.Checked == true && checkBox13.Checked == true && checkBox14.Checked == true && checkBox15.Checked == true && checkBox16.Checked == true) { textBox3.Text = "ślepota plamkowa oka prawego"; label5.Visible = true; label5.Location = new Point(529, 20); mamdiagnoze = true; } }
                if (mamdiagnoze==false) {if(checkBox7.Checked==true && checkBox8.Checked==true && checkBox9.Checked==true && checkBox10.Checked==false && checkBox11.Checked==false && checkBox12.Checked==true && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==false && checkBox16.Checked==false) {textBox3.Text = "Niedowidzenie połowicze jednoimienne prawostronne z zachowaniem plamki żółtej (niedrożność lewej tętnicy tylnej mózgu"; mamdiagnoze=true;  } }
                if (mamdiagnoze==false) {if(checkBox7.Checked==false && checkBox8.Checked==false && checkBox9.Checked==true && checkBox10.Checked==true && checkBox11.Checked==true && checkBox12.Checked==false && checkBox13.Checked==false && checkBox14.Checked==true && checkBox15.Checked==true && checkBox16.Checked==true) {textBox3.Text = "Niedowidzenie połowicze jednoimienne lewostronne z zachowaniem plamki żółtej (niedrożność prawej tętnicy tylnej mózgu)"; label5.Visible = true; label5.Location= new Point (); mamdiagnoze=true;  } }
            
            
            
            
            
            
            
            
            
            
            }
            if (comboBox3.Text == "brak znaczenia plamki żółtej")
            {
                if (mamdiagnoze == false) { if (checkBox9.Checked == true && checkBox8.Checked == true && checkBox10.Checked == true && checkBox11.Checked == true && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false) { textBox3.Text = "ślepota jednostronna oka prawego (uszkodznie nerwu wzrokowego)"; label5.Visible = true; label5.Location = new Point(519, 49); mamdiagnoze = true; } }
                if (mamdiagnoze == false) { if (checkBox9.Checked == false && checkBox8.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox13.Checked == true && checkBox14.Checked == true && checkBox15.Checked == true && checkBox16.Checked == true) { textBox3.Text = "ślepota jednostronna oka lewego (uszkodznie nerwu wzrokowego)"; label5.Visible = true; label5.Location = new Point(449, 49); mamdiagnoze = true; } }
                if (mamdiagnoze == false) { if (checkBox8.Checked == false && checkBox9.Checked == false && checkBox10.Checked == false && checkBox11.Checked == false && checkBox13.Checked == false && checkBox14.Checked == false && checkBox15.Checked == false && checkBox16.Checked == false) { textBox3.Text = "Całkowita ślepota"; mamdiagnoze = true; } }
                if (mamdiagnoze==false) {if(checkBox8.Checked==false && checkBox9.Checked==false && checkBox10.Checked==true && checkBox11.Checked==true && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==false && checkBox16.Checked==false) {textBox3.Text = "Niedowidzenie połowicze obustronne dwuskroniowe (uszkodzenie skrzyzowania wzrokowego)";  label5.Visible = true; label5.Location= new Point (480,90); mamdiagnoze=true;  } }
                if (mamdiagnoze==false) {if(checkBox8.Checked==true && checkBox9.Checked==true && checkBox10.Checked==false && checkBox11.Checked==false && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==false && checkBox16.Checked==false) {textBox3.Text = "Niedowidzenie połowicze jednoimienne prawostronne (uszkodzenie lewego pasma wzrokowego)"; label5.Visible = true; label5.Location= new Point (448,118); mamdiagnoze=true;  } }
                if (mamdiagnoze == false) { if (checkBox8.Checked == false  && checkBox9.Checked == false  && checkBox10.Checked == true  && checkBox11.Checked == true  && checkBox13.Checked == false  && checkBox14.Checked == false  && checkBox15.Checked == true  && checkBox16.Checked == true ) { textBox3.Text = "Niedowidzenie połowicze jednoimienne lewostronne (uszkodzenie prawego pasma wzrokowego)"; label5.Visible = true; label5.Location = new Point(508, 118); mamdiagnoze = true; } }
                if (mamdiagnoze==false) {if(checkBox8.Checked==true && checkBox9.Checked==true && checkBox10.Checked==true && checkBox11.Checked==false && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==false && checkBox16.Checked==true) {textBox3.Text = "Niedowidzenie połowicze obuoczne prawego dolnego kwadrantu (częściowe uszkodzenie promienistosci wzrokowej lewej przez zmianę znajdującą się w lewym płacie ciemieniowym)"; label5.Visible = true; label5.Location= new Point(446,184 ); mamdiagnoze=true;  } }
                if (mamdiagnoze == false) { if (checkBox8.Checked == false  && checkBox9.Checked == true && checkBox10.Checked == true && checkBox11.Checked == true  && checkBox13.Checked == false  && checkBox14.Checked == true && checkBox15.Checked == true  && checkBox16.Checked == true) { textBox3.Text = "Niedowidzenie połowicze obuoczne lewego dolnego kwadrantu (częściowe uszkodzenie promienistosci wzrokowej prawej przez zmianę znajdującą się w prawym płacie ciemieniowym)"; label5.Visible = true; label5.Location = new Point(504, 184); mamdiagnoze = true; } }
            if (mamdiagnoze==false) {if(checkBox8.Checked==true && checkBox9.Checked==true && checkBox10.Checked==true && checkBox11.Checked==true && checkBox13.Checked==false && checkBox14.Checked==false && checkBox15.Checked==true && checkBox16.Checked==true) {textBox3.Text = "Niedowidzenie połowicze nosowe oka prawego (uszkodzenie nieskrzyżowanych włókien nerwu wzrokowego prawego)";  label5.Visible = true; label5.Location= new Point (539,43); mamdiagnoze=true;  } }
                if (mamdiagnoze==false) {if(checkBox8.Checked==true && checkBox9.Checked==true && checkBox10.Checked==false && checkBox11.Checked==true && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==true && checkBox16.Checked==false) {textBox3.Text = "Niedowidzenie połowicze obuoczne prawego gównego kwadrantu (uszkodzenie promienistości wzrokowej lewej w obrębie płata skroniowego)";  label5.Visible = true; label5.Location= new Point (392,201); mamdiagnoze=true;  } }
            if (mamdiagnoze==false) {if( checkBox8.Checked==true && checkBox9.Checked==true && checkBox10.Checked==true && checkBox11.Checked==true && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==false && checkBox16.Checked==false) {textBox3.Text = "Niedowidzenie połowicze skroniowe oka prawego (uszkodzenie skrzyżowanych włókien nerwu wzrokowego prawego)";  label5.Visible = true; label5.Location= new Point (513,27); mamdiagnoze=true;  } }
            if (mamdiagnoze==false) {if(checkBox8.Checked==true && checkBox9.Checked==false && checkBox10.Checked==false && checkBox11.Checked==true && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==true && checkBox16.Checked==true) {textBox3.Text = "Niedowidzenie połowicze nosowe oka lewego (uszkodzenie nieskrzyżowanych włókien nerwu wzrokowego lewego)"; label5.Visible = true; label5.Location= new Point (419,30); mamdiagnoze=true;  } }
            if (mamdiagnoze==false) {if( checkBox8.Checked==false && checkBox9.Checked==true && checkBox10.Checked==true && checkBox11.Checked==true && checkBox13.Checked==true && checkBox14.Checked==true && checkBox15.Checked==true && checkBox16.Checked==true) {textBox3.Text = "Niedowidzenie połowicze skroniowe oka lewego (uszkodzenie skrzyżowanych włókien nerwu wzrokowego lewego)"; label5.Visible = true; label5.Location= new Point (); mamdiagnoze=true;  } }
            if (mamdiagnoze==false) {if(checkBox8.Checked==false && checkBox9.Checked==true && checkBox10.Checked==true && checkBox11.Checked==true && checkBox13.Checked==false && checkBox14.Checked==true && checkBox15.Checked==true && checkBox16.Checked==true) {textBox3.Text = "Niedowidzenie połowicze obuoczne prawego dolnego kwadrantu (częściowe uszkodzenie promienistosci wzrokowej prawej przez zmianę znajdującą się w prawym płacie ciemieniowym)"; label5.Visible = true; label5.Location= new Point(504, 184 ); mamdiagnoze=true;  } }
            if (mamdiagnoze==false) {if(checkBox8.Checked==true && checkBox9.Checked==false && checkBox10.Checked==true && checkBox11.Checked==true && checkBox13.Checked==true && checkBox14.Checked==false && checkBox15.Checked==true && checkBox16.Checked==true) {textBox3.Text = "Niedowidzenie połowicze lewego górnego kwadrantu (częściowe uszkodzenie promienistości wzrokowej prawej przez zmianę znajdującą się w prawym płacie skroniowym)"; label5.Visible = true; label5.Location= new Point(550,198 ); mamdiagnoze=true;  } }
            
            
            }
            if (mamdiagnoze == false) { textBox3.Text = ""; label5.Visible = false; }


            //robimy zdjęcie
           

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

            czegoniewidze();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox3.Text == "znaczenie plamki żółtej") { pictureBox2.Visible = true; pictureBox4.Visible = false; checkBox7.Visible =true; checkBox7.Checked = true; checkBox12.Visible = true; checkBox12.Checked = true; }
            if (comboBox3.Text == "brak znaczenia plamki żółtej") { pictureBox4.Visible = true; pictureBox2.Visible = false; checkBox7.Visible = false; checkBox7.Checked = true; checkBox12.Visible = false; checkBox12.Checked = true; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { panel3.Enabled = true; } else { panel3.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { panel3.Enabled = true; } else { panel3.Enabled = false; } czegoniewidze();
        }

        private void checkBox9_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox7_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox10_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox14_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox13_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox12_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox16_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void checkBox15_CheckedChanged_1(object sender, EventArgs e)
        {
            czegoniewidze();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.Text == "znaczenie plamki żółtej") { pictureBox2.Visible = true; pictureBox4.Visible = false; checkBox7.Visible =true; checkBox7.Checked = true; checkBox12.Visible = true; checkBox12.Checked = true; }
            if (comboBox3.Text == "brak znaczenia plamki żółtej") { pictureBox4.Visible = true; pictureBox2.Visible = false; checkBox7.Visible = false; checkBox7.Checked = true; checkBox12.Visible = false; checkBox12.Checked = true; }
            czegoniewidze();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odznacz nieczynne u pacjenta obszary pola widzenia. Zaznaczenie równoznaczne jest z tym, że pacjent widzi przedmioty zbierane przez przeciwległą (nosową/skroniową) część siatkówki. Możesz uwzględnić plamkę żółtą zmieniając opcje pod obrazkiem. Program potrafi diagnozować najprostsze uszkodzenia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OcenOdruchZreniczny()
        {
            textBox10.Text = "";
            //prawe
            if (checkBox28.Checked == true && checkBox29.Checked == false) { textBox10.Text += "w przypadku prawego oka - odruch prawidłowy, ale nie jest konsensualny"; }
            if (checkBox28.Checked == false && checkBox29.Checked == true) { textBox10.Text += "sugeruje uszkodzenie prawego nerwu okoruchowego"; }
            if (checkBox28.Checked == false && checkBox29.Checked == false) { textBox10.Text += "sugeruje uszkodzenie prawego nerwu wzrokowego"; }
            if (checkBox28.Checked == false && checkBox29.Checked == false) { textBox10.Text += "brak odruchu przy oświetlaniu prawgo oka"; }
            if (checkBox28.Checked == true && checkBox29.Checked == true) { textBox10.Text += "prawidłowy odruch po stronie prawej"; }
            //lewe
            if (checkBox33.Checked == false && checkBox31.Checked == true) { textBox10.Text += ", w przypadku lewego oka - odruch prawidłowy, ale nie jest konsensualny"; }
            if (checkBox33.Checked == true && checkBox31.Checked == false) { textBox10.Text += ", sugeruje uszkodzenie lewego nerwu okoruchowego"; }
            if (checkBox33.Checked == false && checkBox31.Checked == false) { textBox10.Text += ", sugeruje uszkodzenie lewego nerwu wzrokowego"; }
            if (checkBox33.Checked == false && checkBox31.Checked == false) { textBox10.Text += ", brak odruchu przy oświetlaniu lewego oka"; }
            if (checkBox33.Checked == true && checkBox31.Checked == true) { textBox10.Text += ", prawidłowy odruch po stronie lewej"; } 

            //ogólne
            if (checkBox28.Checked == true && checkBox29.Checked == true && checkBox33.Checked == true && checkBox31.Checked == true) { textBox10.Text = "prawidłowy konsensualny odruch"; }
            if (checkBox28.Checked == false && checkBox29.Checked == false && checkBox33.Checked == false && checkBox31.Checked == false) { textBox10.Text = "brak odruchu źrenicznego"; }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            OcenOdruchZreniczny();
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            OcenOdruchZreniczny();
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            OcenOdruchZreniczny();
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            OcenOdruchZreniczny();
        }
        private void OcenRuchOczu() {
            textBox13.Text = "";

            if (checkBox27.Checked == false || checkBox32.Checked == false || checkBox36.Checked == false || checkBox39.Checked == false) { textBox13.Text += " uszkodzenie prawego nerwu okoruchowego (NC III);"; }
            if (checkBox34.Checked == false || checkBox42.Checked == false || checkBox35.Checked == false || checkBox40.Checked == false) { textBox13.Text += " uszkodzenie lewego nerwu okoruchowego (NC III);"; }
            if (checkBox41.Checked == false) { textBox13.Text += " uszkodzenie prawego nerwu odwodzącego (NC VI);"; }
            if (checkBox43.Checked == false) { textBox13.Text += " uszkodzenie lewego nerwu odwodzącego (NC VI);"; }
            if (checkBox38.Checked == false) { textBox13.Text += " uszkodzenie prawego nerwu bloczkowego (NC IV);"; }
            if (checkBox37.Checked == false) { textBox13.Text += " uszkodzenie lewego nerwu bloczkowego (NC IV);"; }
        if (textBox13.Text == "") { textBox13.Text = " ruchy gałek ocznych prawidłowe (brak zauważalnych porażeń NC III, NC IV lub NC VI);"; }
        if (checkBox45.Checked==true) { textBox13.Text += " ruch skojarzony;"; } else { textBox13.Text += " ruch nie jest skojarzony;"; }
        
        
        
        
        
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu(); 
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            OcenRuchOczu();
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked) { panel5.Enabled = true; } else { panel5.Enabled = false; }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool wiemcośotym = false;
            if(wiemcośotym == false) {
                if (comboBox6.Text == "dół") { label15.Text = "Sugeruje zmianę w okolicy otworu wielkiego."; wiemcośotym = true; }
                if (comboBox6.Text == "górę") { label15.Text = "Sugeruje zmianę w okolicy wzgórka/ów górnego blaszki czworaczej."; wiemcośotym = true; }

            }
            if (wiemcośotym == false) { label15.Text = ""; }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox44.Checked) { comboBox5.Enabled = true; comboBox6.Enabled = true; textBox14.Enabled = true; checkBox46.Enabled = true; } else { comboBox5.Enabled = false; comboBox6.Enabled = false; textBox14.Enabled = false; comboBox5.Text = ""; comboBox6.Text = ""; textBox14.Text = ""; checkBox46.Enabled = false; }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox47.Checked) { checkedListBox1.Enabled = true; textBox15.Enabled = true; } else { checkedListBox1.Enabled = false; textBox15.Enabled = false; }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void zdjecie_polewidzenia(PictureBox p) {
            Rectangle bounds = this.Bounds;
            bounds.Location = pictureBox2.Location;
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
                int x = panel3.Location.X + tabControl1.Location.X + p.Location.X;
                int y = panel3.Location.Y + tabControl1.Location.Y + 60 + p.Location.Y;
                int w = p.Size.Width;
                int h = p.Size.Height - 10;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);
                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                MessageBox.Show(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //n.Save(katalogpacjenta + "\\obrazy\\pola_widzenia.jpg", ImageFormat.Jpeg);
               
                
            }
            
        
        
        
        }
        public string podstawaurl;
        public string katalogpacjenta;
        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //piszemy raport
            using (StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "b_czaszkowe.html"))
            {
                writer.Write("<HTML><meta  http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><font face=\"Segoe UI\"><strong><u>BADANIE NERWÓW CZASZKOWYCH:</strong></u>");
                if (checkBox1.Checked) {
                    writer.Write("<br><b>" + checkBox1.Text + "</b>: <u>" + comboBox2.Text + "</u>. ");
                    if (checkBox3.Checked) { writer.Write(" " + checkBox3.Text); }
                    if (checkBox2.Checked) { writer.Write(" " + checkBox2.Text); }if (comboBox1.Text != "") { writer.Write(" " + label1.Text + " " + comboBox1.Text); }
                    if (textBox1.Text != "") { writer.Write("<br />" + textBox1.Text); }
                }
                
                if (checkBox4.Checked)
                {
                    writer.Write("<br><b>" + checkBox4.Text + "</b>:"); 
                    if (checkBox6.Checked) { writer.Write(" Wykorzystano sprzęt: " + checkBox6.Text + "; określono ostrość wzroku dla oka prawego: " + numericUpDown2.Value + " i oka lewego: " + numericUpDown1.Value); }
                    //if (checkBox2.Checked) { writer.Write(" " + checkBox2.Text); }
                    writer.Write("<br /><img width= \"100%\" src=\"" + podstawaurl + "obrazki/ostrosc_NCII.jpg\">");
                    if (comboBox1.Text != "") { writer.Write(" " + label1.Text + " " + comboBox1.Text); }
                    if (textBox2.Text != "") { writer.Write("<br />" + textBox2.Text); }
                }
                if (checkBox5.Checked)
                {
                    writer.Write("<br><b>" + checkBox5.Text + "</b>:");
                    //if (checkBox6.Checked) { writer.Write(" Wykorzystano sprzęt: " + checkBox6.Text + "; określono ostrość wzroku dla oka prawego: " + numericUpDown2.Value + " i oka lewego: " + numericUpDown1.Value); }
                    //if (checkBox2.Checked) { writer.Write(" " + checkBox2.Text); }
                    writer.Write("<br /><table><tr><td><img width= \"100%\" src=\"" + podstawaurl + "obrazki/uszkodzenie_NCII.jpg\"></td>");
                    if (comboBox3.Text != "") { writer.Write("<td>" + comboBox3.Text + "</td></tr></table>"); }
                    writer.Write("<br /><table><tr><td><img width= \"100%\" src=\"" + podstawaurl + "obrazki/mapa_NCII.jpg\"></td>");
                    if (textBox3.Text != "") { writer.Write("<td>" + textBox3.Text + "</td></tr></table>");}
                }
                if (checkBox20.Checked)
                {
                    writer.Write("<br><b>" + checkBox20.Text + "</b>:");
                    if (textBox11.Text != "") { writer.Write(" " + textBox11.Text); }
                }
                if (checkBox17.Checked)
                {
                    writer.Write("<br><b>" + checkBox17.Text + "</b>:");
                    if (textBox4.Text != "") { writer.Write(" " + textBox4.Text); }
                }
                if (checkBox21.Checked)
                {
                    writer.Write("<br><b>" + checkBox21.Text + "</b>:");
                    if (textBox5.Text != "") { writer.Write(" " + textBox5.Text); }
                }
                if (checkBox22.Checked)
                {
                    writer.Write("<br><b>" + checkBox22.Text + "</b>:");
                    if (textBox6.Text != "") { writer.Write(" " + textBox6.Text); }
                }
                if (checkBox18.Checked)
                {
                    writer.Write("<br><b>" + checkBox18.Text + "</b>:");
                    if (comboBox4.Text != "") { writer.Write(" " + label8.Text + " " + comboBox4.Text); }
                    if (checkBox23.Checked) { writer.Write(", " + checkBox23.Text); }
                    if (checkBox24.Checked) { writer.Write(", " + checkBox23.Text); }
                    if (checkBox23.Checked) { writer.Write(", " + checkBox23.Text); }
                    if (textBox7.Text != "") { writer.Write(", " + textBox7.Text); }
                    if (checkBox25.Checked) { writer.Write(", " + checkBox25.Text + " - " + textBox9.Text); }
                    if (checkBox26.Checked) { writer.Write(", " + checkBox26.Text + " - " + textBox8.Text); }
                    writer.Write("<br><u>" + label7.Text + "</u>: oświetlone oko prawe - ");
                    if (checkBox18.Checked == true) { writer.Write("prawe (+) | "); } else { writer.Write("prawe (-) | "); }
                    if (checkBox29.Checked == true) { writer.Write("lewe (+),"); } else { writer.Write("lewe (-),"); }
                    writer.Write(" oświetlone oko lewe - ");
                    if (checkBox33.Checked == true) { writer.Write("prawe (+) | "); } else { writer.Write("prawe (-) | "); }
                    if (checkBox31.Checked == true) { writer.Write("lewe (+), czyli: "); } else { writer.Write("lewe (-), czyli: "); }
                    writer.Write(textBox10.Text);
                    if (checkBox19.Checked) { writer.Write("; " + checkBox19.Text + " - " + textBox12.Text); }
                }
                if (checkBox47.Checked)
                {
                    writer.Write("<br><b>" + checkBox47.Text + "</b>:");
                    if (checkedListBox1.SelectedItems.Count > 0)
                        
                    {
                        writer.Write(" możliwe przyczyny: ");
                        //foreach(var i in checkedListBox1.Items.) { 
                        //i.
                        
                        
                        
                        
                        //foreach (string i in checkedListBox1.SelectedItems) { 
                       for (int i = 0; i < checkedListBox1.Items.Count; i++)
  if (checkedListBox1.GetItemChecked(i)) { string text = checkedListBox1.Items[i].ToString(); writer.Write("<u>" + text + "</u>, ");  }
    // Do selected stuff
  //else{}
    // Do unselected stuff

                        }

                    
                    if (textBox15.Text != "") { writer.Write(" " + textBox15.Text); }
                }
                if (checkBox30.Checked)
                {
                    writer.Write("<br><b>" + checkBox30.Text + "</b>:");
                    //if (checkBox6.Checked) { writer.Write(" Wykorzystano sprzęt: " + checkBox6.Text + "; określono ostrość wzroku dla oka prawego: " + numericUpDown2.Value + " i oka lewego: " + numericUpDown1.Value); }
                    ////if (checkBox2.Checked) { writer.Write(" " + checkBox2.Text); }
                    //writer.Write("<br /><img width= \"100%\" src=\"" + podstawaurl + "obrazki/uszkodzenie_NCII.jpg\">");
                    //if (comboBox3.Text != "") { writer.Write("<br />" + comboBox3.Text); }
                    writer.Write("<img width= \"100%\" src=\"" + podstawaurl + "obrazki/ruchy_oczu.jpg\">");
                    if (textBox13.Text != "") { writer.Write("<br>" + textBox13.Text + "; "); }
                    if (checkBox44.Checked) { writer.Write("<u> " + checkBox44.Text + "</u>"); }
                    if (checkBox46.Checked) { writer.Write(" " + checkBox46.Text + ","); }
                    if (comboBox5.Text != "") { writer.Write(" " + label9.Text + " - " + comboBox5.Text); }
                    if (comboBox6.Text != "") { writer.Write(", " + label14.Text + " - " + comboBox6.Text + " <i>" + label15.Text + "</i>"); }
                    if (textBox14.Text != "") { writer.Write(", " + label16.Text + " - " + textBox14.Text); }
                }
                if (checkBox49.Checked)
                {
                    writer.Write("<br><b>" + checkBox49.Text + "</b>:");
                    writer.Write("<br><img width= \"100%\" src=\"" + podstawaurl + "obrazki/czucie_NCV.jpg\">");
                    if (textBox16.Text != "") { writer.Write("<br><u>Ocena części ruchowej:</u> " + textBox16.Text); }
                    if (textBox17.Text != "" || textBox18.Text != "" || textBox19.Text != "" || textBox20.Text != "" || textBox21.Text != "") 
                    {
                        writer.Write("<br><u>Ocena części ruchowej:</u> ");
                        if (checkBox55.Checked) { writer.Write("<br> - " + checkBox55.Text + " - " + textBox17.Text ); }
                        if (checkBox56.Checked) { writer.Write("<br> - " + checkBox56.Text + " - " + textBox18.Text); }
                        if (checkBox57.Checked) { writer.Write("<br> - " + checkBox57.Text + " " + label21.Text + " " + textBox17.Text + ", " + label22.Text + " " + textBox20.Text); }
                        if (textBox21.Text != "") { writer.Write("<br>adnotacje: " + textBox21.Text); }
                    
                    
                    }



                }
                if (checkBox60.Checked)
                {
                    writer.Write("<br><b>" + checkBox60.Text + "</b>:");
                    //if (checkBox6.Checked) { writer.Write(" Wykorzystano sprzęt: " + checkBox6.Text + "; określono ostrość wzroku dla oka prawego: " + numericUpDown2.Value + " i oka lewego: " + numericUpDown1.Value); }
                    ////if (checkBox2.Checked) { writer.Write(" " + checkBox2.Text); }
                    //writer.Write("<br /><img width= \"100%\" src=\"" + podstawaurl + "obrazki/uszkodzenie_NCII.jpg\">");
                    //if (comboBox3.Text != "") { writer.Write("<br />" + comboBox3.Text); }
                    writer.Write("<img width= \"100%\" src=\"" + podstawaurl + "obrazki/czucie_NCVII.jpg\">");
                    if (textBox22.Text != "") { writer.Write("<br>" + textBox22.Text + "; "); }
                    
                    if (checkBox71.Checked) { writer.Write("" + checkBox71.Text + " - " + textBox23.Text); }
                }
                if (checkBox75.Checked)
                {
                    //bool nieprawidłowe = false;
                    writer.Write("<br><b>" + checkBox75.Text + "</b>:");
                    if (checkBox74.Checked) { writer.Write("<br /> - " + checkBox74.Text + " - " + comboBox7.Text);  }
                    if (checkBox76.Checked) { writer.Write("<br /> - " + checkBox76.Text + " - " + comboBox8.Text);  }
                    if (checkBox77.Checked) { writer.Write("<br /> - " + checkBox77.Text + " - " + comboBox9.Text); }
                    if (checkBox78.Checked) { writer.Write("<br /> - " + checkBox78.Text + " - " + textBox27.Text); }
                }
                //else { writer.Write("<br><b>NC VIII (przedionkowo-ślimakowy)</b>: wyniki badania prawidłowe."); }
                if (checkBox83.Checked)
                {
                    bool n = false;
                    writer.Write("<br><b>" + checkBox83.Text + "</b>:");
                    //if (checkBox74.Checked) { writer.Write("<br /> - " + checkBox74.Text + " - " + comboBox7.Text); }
                    //if (checkBox76.Checked) { writer.Write("<br /> - " + checkBox76.Text + " - " + comboBox8.Text); }
                    if (checkBox82.Checked) { writer.Write("<br /> - " + checkBox82.Text + " - " + textBox26.Text); n = true; }
                    if (checkBox81.Checked) { writer.Write("<br /> - " + checkBox81.Text + " - " + comboBox11.Text); n = true; }
                    if (checkBox79.Checked) { writer.Write("<br /> - " + checkBox79.Text + " - " + textBox25.Text); n = true; }
                    if (n == false) { writer.Write(" wyniki badania prawidłowe."); }
                }
                //else {  }
                if (checkBox86.Checked)
                {
                    bool n = false;
                    writer.Write("<br><b>" + checkBox86.Text + "</b>:");
                    //if (checkBox74.Checked) { writer.Write("<br /> - " + checkBox74.Text + " - " + comboBox7.Text); }
                    //if (checkBox76.Checked) { writer.Write("<br /> - " + checkBox76.Text + " - " + comboBox8.Text); }
                    if (checkBox85.Checked) { writer.Write("<br /> - " + checkBox85.Text + " - " + textBox27.Text); n = true; }
                    //if (checkBox81.Checked) { writer.Write("<br /> - " + checkBox81.Text + " - " + comboBox11.Text); }
                    if (checkBox80.Checked) { writer.Write("<br /> - " + checkBox80.Text + " - " + textBox28.Text); n = true; }
                    if (n == false) { writer.Write(" wyniki badania prawidłowe."); }
                }
                //else {  }
                if (checkBox88.Checked)
                {
                    bool n = false;
                    writer.Write("<br><b>" + checkBox88.Text + "</b>:");
                    //if (checkBox74.Checked) { writer.Write("<br /> - " + checkBox74.Text + " - " + comboBox7.Text); }
                    //if (checkBox76.Checked) { writer.Write("<br /> - " + checkBox76.Text + " - " + comboBox8.Text); }
                    if (checkBox87.Checked) { writer.Write("<br /> - " + checkBox87.Text + " - " + textBox30.Text); n = true; }
                    //if (checkBox81.Checked) { writer.Write("<br /> - " + checkBox81.Text + " - " + comboBox11.Text); }
                    if (checkBox89.Checked) { writer.Write("<br /> - " + checkBox89.Text + " - " + textBox31.Text); n = true; }
                    if (checkBox84.Checked) { writer.Write("<br /> - " + checkBox84.Text + " - " + textBox29.Text); n = true; }
                    if (n == false) { writer.Write(" wyniki badania prawidłowe."); }
                }
                //else { writer.Write("<br><b>NC XII (podjęzykowy)</b>: wyniki badania prawidłowe."); }
                if (textBox32.Text != "") { writer.Write("<br><b>Dodatkowe adnotacje do badania: </b>" + textBox32.Text); }

                writer.Write("</HTML>");
            }



























































            if (MessageBox.Show("Zakończyć badanie?", "Potwierdź", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

                //System.Diagnostics.Process.Start(Application.StartupPath + "\\test.jpg");
            
        }

        public void zapiszfocie(Bitmap bitmap, int x, int y, int w, int h, string plik) { 
        Bitmap n = CropBitmap(bitmap, x, y, w, h);
        n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazy\\" + plik + ".jpg", ImageFormat.Jpeg);
        
        
        
        }


        public void ocenczucieNCV() {
            textBox16.Text="";
            if (checkBox48.Checked == true && checkBox50.Checked == true && checkBox51.Checked == true) { textBox16.Text += "prawidłowe czucie po stronie prawej"; }
            else
            {
                textBox16.Text += "nieprawidłowe czucie po stronie prawej (";
                if (checkBox48.Checked == true) { textBox16.Text += "obszar n. ocznego V1 - czucie prawidłowe"; } else { textBox16.Text += "obszar n. ocznego V1 - czucie nieprawidłowe!"; }
                if (checkBox50.Checked == true) { textBox16.Text += ", obszar n. szczękowego V2 - czucie prawidłowe"; } else { textBox16.Text += ", obszar n. szczękowego V2 - czucie nieprawidłowe!"; }
                if (checkBox51.Checked == true) { textBox16.Text += ", obszar n. żuchwowego V3 - czucie prawidłowe)"; } else { textBox16.Text += ", obszar n. żuchwowego V3 - czucie nieprawidłowe!)"; }
            }
            if (checkBox54.Checked == true && checkBox53.Checked == true && checkBox52.Checked == true) { textBox16.Text += ", prawidłowe czucie po stronie lewej"; }
            else
            {
                textBox16.Text += ", nieprawidłowe czucie po stronie lewej (";
                if (checkBox54.Checked == true) { textBox16.Text += "obszar n. ocznego V1 - czucie prawidłowe"; } else { textBox16.Text += "obszar n. ocznego V1 - czucie nieprawidłowe!"; }
                if (checkBox53.Checked == true) { textBox16.Text += ", obszar n. szczękowego V2 - czucie prawidłowe"; } else { textBox16.Text += ", obszar n. szczękowego V2 - czucie nieprawidłowe!"; }
                if (checkBox52.Checked == true) { textBox16.Text += ", obszar n. żuchwowego V3 - czucie prawidłowe)"; } else { textBox16.Text += ", obszar n. żuchwowego V3 - czucie nieprawidłowe!)"; }
            }
        
        }
        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            ocenczucieNCV();
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            ocenczucieNCV();
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            ocenczucieNCV();
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            ocenczucieNCV();
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            ocenczucieNCV();
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            ocenczucieNCV();
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox49.Checked == true) { panel6.Enabled = true; } else { panel6.Enabled = false; }
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox55.Checked == true) { textBox17.Enabled = true; } else { textBox17.Enabled = false; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox18.Text = "wzmożony odruch (wskazujący na uszkodzenie górnego neuronu)";
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox56.Checked == true) { textBox18.Enabled = true; button3.Enabled = true; } else { textBox18.Enabled = false; button3.Enabled = false; }
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox57.Checked == true) { textBox19.Enabled = true; } else { textBox19.Enabled = false; }
            if (checkBox57.Checked == true) { textBox20.Enabled = true; } else { textBox20.Enabled = false; }
        }

        public void ocenaNCV()
        {
            textBox22.Text = "OBSERWACJA: ";
            if (!checkBox70.Checked) { textBox22.Text += "bark ruchów mimowolnych"; } else { textBox22.Text += "obecne ruchy mimowolne!"; }
            if (!checkBox67.Checked) { } else { textBox22.Text += ", widoczne wygładzenie fałdu nosowo-wargowego"; }
            if (checkBox69.Checked == false && checkBox68.Checked == false)
            {
                textBox22.Text += ", nie stwierdzam opadania kącików ust";
            }
            else {
                if (checkBox69.Checked == true) { textBox22.Text += ", opadanie kącika ust po stronie prawej"; }
                if (checkBox68.Checked == true) { textBox22.Text += ", opadanie kącika ust po stronie lewej"; }
            }
            textBox22.Text += "; \nSPRAWDZENIE CZYNNOŚCI RUCHOWYCH: ";
            if (checkBox58.Checked == true && checkBox59.Checked == true)
            {
                textBox22.Text += "prawidłowe marszczenie czoła obustronne (m. potyliczno-czołowy)";
            }
            else {
                if (checkBox58.Checked == false) { textBox22.Text += ", nieprawidłowe marszczenie czoła po stronie prawej (m. potyliczno-czołowy)"; }
                if (checkBox59.Checked == false) { textBox22.Text += ", nieprawidłowe marszczenie czoła po stronie lewej (m. potyliczno-czołowy)"; }
            }



            if (checkBox61.Checked == true && checkBox62.Checked == true)
               {
                   textBox22.Text += ", prawidłowe obustronne zamykanie oczu (m. okrężny oka)";
               }
               else
               {
                   if (checkBox61.Checked == false) { textBox22.Text += ", nieprawidłowe zamykanie oczu po stronie prawej (m. okrężny oka)"; }
                   if (checkBox62.Checked == false) { textBox22.Text += ", nieprawidłowe zamykanie oczu po stronie lewej (m. okrężny oka)"; }
               }


            if (checkBox64.Checked == true && checkBox63.Checked == true)
            {
                textBox22.Text += ", prawidłowe obustronne zaciśnięcia warg, aż do momentu naciśnięcia policzków (m. policzkowy)";
            }
            else
            {
                if (checkBox64.Checked == false) { textBox22.Text += ", nieprawidłowe zaciśnięcia warg, aż do momentu naciśnięcia policzków po stronie prawej (m. policzkowy)"; }
                if (checkBox63.Checked == false) { textBox22.Text += ", nieprawidłowe zaciśnięcia warg, aż do momentu naciśnięcia policzków po stronie lewej (m. policzkowy)"; }
            }


            if (checkBox65.Checked == true && checkBox66.Checked == true)
            {
                textBox22.Text += ", prawidłowe obustronne pokazywanie zębów (m. okrężny ust)";
            }
            else
            {
                if (checkBox65.Checked == false) { textBox22.Text += ", nieprawidłowe pokazywanie zębów po stronie prawej (m. okrężny ust)"; }
                if (checkBox66.Checked == false) { textBox22.Text += ", nieprawidłowe pokazywanie zębów po stronie lewej (m. okrężny ust)"; }
            }

            if (checkBox73.Checked == true ) { textBox22.Text += ". Objaw Bella po stronie prawej"; }
            if (checkBox72.Checked == true ) { textBox22.Text += ". Objaw Bella po stronie lewej"; }
            
            if (checkBox58.Checked == true && checkBox59.Checked == true && checkBox61.Checked == true && checkBox62.Checked == true && checkBox64.Checked == false  && checkBox63.Checked == false  && checkBox65.Checked == false  && checkBox66.Checked == false )
            { textBox22.Text += ". Takie zestawnie sugeruje obustronne porażenie górnego neuronu ruchowego."; }
            if (checkBox58.Checked == true && checkBox59.Checked == true 
                && checkBox61.Checked == true && checkBox62.Checked == true
                && checkBox64.Checked == true   && checkBox63.Checked == false 
                && checkBox65.Checked == true && checkBox66.Checked == false)
            { textBox22.Text += ". Takie zestawnie sugeruje prawostronne porażenie górnego neuronu ruchowego."; }
            if (checkBox58.Checked == true && checkBox59.Checked == true
                    && checkBox61.Checked == true && checkBox62.Checked == true
                    && checkBox64.Checked == false  && checkBox63.Checked == true 
                    && checkBox65.Checked == false  && checkBox66.Checked == true )
            { textBox22.Text += ". Takie zestawnie sugeruje lewostronne porażenie górnego neuronu ruchowego."; }
            if (checkBox58.Checked == false  && checkBox59.Checked == true
                        && checkBox61.Checked == false && checkBox62.Checked == true
                        && checkBox64.Checked == false && checkBox63.Checked == true
                        && checkBox65.Checked == false && checkBox66.Checked == true)
            { textBox22.Text += ". Takie zestawnie sugeruje prawostronne porażenie dolnego neuronu ruchowego."; }
            if (checkBox58.Checked == true  && checkBox59.Checked == false 
                            && checkBox61.Checked ==true  && checkBox62.Checked == false 
                            && checkBox64.Checked ==true  && checkBox63.Checked == false 
                            && checkBox65.Checked == true && checkBox66.Checked == false )
            { textBox22.Text += ". Takie zestawnie sugeruje lewostronne porażenie dolnego neuronu ruchowego."; }

            
        
        }

        private void checkBox70_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox59_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox61_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox61.Checked == true) { checkBox73.Checked = false; }
            ocenaNCV();
        }

        private void checkBox62_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox62.Checked == true) { checkBox72.Checked = false; }
            ocenaNCV();
        }

        private void checkBox64_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox63_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox65_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox66_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox67_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox69_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox68_CheckedChanged(object sender, EventArgs e)
        {
            ocenaNCV();
        }

        private void checkBox60_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox60.Checked) { panel7.Enabled = true; } else { panel7.Enabled = false; }
        }

        private void checkBox71_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox71.Checked) { textBox23.Enabled = true; } else { textBox23.Enabled = false; }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked) { textBox4.Enabled = true; } else { textBox4.Enabled = false; }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked) { panel4.Enabled = true; } else { panel4.Enabled = false; }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked) { textBox9.Enabled = true; } else { textBox9.Enabled = false; }
        }

        private void checkBox75_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox75.Checked) { panel8.Enabled = true; } else { panel8.Enabled = false; }


        }

        private void checkBox74_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox74.Checked) { comboBox7.Enabled = true; } else { comboBox7.Enabled = false; }
            if (checkBox76.Checked) { comboBox8.Enabled = true; } else { comboBox8.Enabled = false; }
            if (checkBox77.Checked) { comboBox9.Enabled = true; } else { comboBox9.Enabled = false; }
            if (checkBox78.Checked) { textBox24.Enabled = true; } else { textBox24.Enabled = false; }
        }

        private void checkBox82_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox82.Checked) { textBox26.Enabled = true; } else { textBox26.Enabled = false; }
        }

        private void checkBox76_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox74.Checked) { comboBox7.Enabled = true; } else { comboBox7.Enabled = false; }
            if (checkBox76.Checked) { comboBox8.Enabled = true; } else { comboBox8.Enabled = false; }
            if (checkBox77.Checked) { comboBox9.Enabled = true; } else { comboBox9.Enabled = false; }
            if (checkBox78.Checked) { textBox24.Enabled = true; } else { textBox24.Enabled = false; }
        }

        private void checkBox77_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox74.Checked) { comboBox7.Enabled = true; } else { comboBox7.Enabled = false; }
            if (checkBox76.Checked) { comboBox8.Enabled = true; } else { comboBox8.Enabled = false; }
            if (checkBox77.Checked) { comboBox9.Enabled = true; } else { comboBox9.Enabled = false; }
            if (checkBox78.Checked) { textBox24.Enabled = true; } else { textBox24.Enabled = false; }
        }

        private void checkBox78_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox74.Checked) { comboBox7.Enabled = true; } else { comboBox7.Enabled = false; }
            if (checkBox76.Checked) { comboBox8.Enabled = true; } else { comboBox8.Enabled = false; }
            if (checkBox77.Checked) { comboBox9.Enabled = true; } else { comboBox9.Enabled = false; }
            if (checkBox78.Checked) { textBox24.Enabled = true; } else { textBox24.Enabled = false; }
        }

        private void checkBox81_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox81.Checked) { comboBox11.Enabled = true; } else { comboBox11.Enabled = false; }
        }

        private void checkBox79_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox79.Checked) { textBox25.Enabled = true; } else { textBox25.Enabled = false; }
        }

        private void checkBox85_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox85.Checked) { textBox27.Enabled = true; } else { textBox27.Enabled = false; }
        }

        private void checkBox80_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox80.Checked) { textBox28.Enabled = true; } else { textBox28.Enabled = false; }
        }

        private void checkBox83_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox83.Checked) { panel9.Enabled = true; } else { panel9.Enabled = false; }
        }

        private void checkBox86_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox86.Checked) { panel10.Enabled = true; } else { panel10.Enabled = false; }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox87_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox87.Checked) { textBox30.Enabled = true; } else { textBox30.Enabled = false; }
        }

        private void checkBox89_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox89.Checked) { textBox31.Enabled = true; } else { textBox31.Enabled = false; }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox84_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox84.Checked) { textBox29.Enabled = true; } else { textBox29.Enabled = false; }
        }

        private void checkBox88_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox88.Checked) { panel11.Enabled = true; } else { panel11.Enabled = false; }
        }

        private void tabPage1_MouseLeave(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            //zdjecie_polewidzenia(pictureBox2);
            //pole widzenia
            label6.Visible = false;
            Rectangle bounds = this.Bounds;
            bounds.Location = pictureBox2.Location;
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
                int x = panel3.Location.X + tabControl1.Location.X + pictureBox2.Location.X;
                int y = panel3.Location.Y + tabControl1.Location.Y + 60 + pictureBox2.Location.Y;
                int w = pictureBox2.Size.Width;
                int h = pictureBox2.Size.Height - 15;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);

                //MessageBox.Show(Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //string adres = Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg";
                //adres = adres.Replace("\\", "/");
                //adres = adres.Insert(3, "\\");

                //string adres = Path.Combine(Application.StartupPath, katalogpacjenta, "obrazy\\uszkodzenie_NCII.jpg"); //MessageBox.Show(adres);

                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                //bitmap.Dispose();
                //string adres=Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg";
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");
                label6.Visible = true;


            }
            //gdzie uszkodzone
            bounds = this.Bounds;
            bounds.Location = pictureBox2.Location;
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
                int x = panel3.Location.X + tabControl1.Location.X + pictureBox3.Location.X +2 ;
                int y = panel3.Location.Y + tabControl1.Location.Y + 60 + pictureBox3.Location.Y;
                int w = pictureBox3.Size.Width;
                int h = pictureBox3.Size.Height -3 ;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);

                //MessageBox.Show(Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //string adres = Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg";
                //adres = adres.Replace("\\", "/");
                //adres = adres.Insert(3, "\\");

                //string adres = Path.Combine(Application.StartupPath, katalogpacjenta, "obrazy\\uszkodzenie_NCII.jpg"); //MessageBox.Show(adres);

                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                //bitmap.Dispose();
                //string adres=Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg";
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\mapa_NCII.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");



            }
            //ostrość wzroku
            label6.Visible = true; bounds = this.Bounds;
            bounds.Location = pictureBox2.Location;
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
                int x = panel2.Location.X + tabControl1.Location.X + pictureBox1.Location.X +5;
                int y = panel2.Location.Y + tabControl1.Location.Y + 60 + pictureBox1.Location.Y - 5;
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
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\ostrosc_NCII.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");



            }
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            bounds.Location = pictureBox2.Location;
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
                int x = panel5.Location.X + tabControl1.Location.X + pictureBox6.Location.X +2;
                int y = panel5.Location.Y + tabControl1.Location.Y + 55 + pictureBox6.Location.Y;
                int w = pictureBox6.Size.Width;
                int h = pictureBox6.Size.Height - 10;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);

                //MessageBox.Show(Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //string adres = Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg";
                //adres = adres.Replace("\\", "/");
                //adres = adres.Insert(3, "\\");

                //string adres = Path.Combine(Application.StartupPath, katalogpacjenta, "obrazy\\uszkodzenie_NCII.jpg"); //MessageBox.Show(adres);

                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                //bitmap.Dispose();
                //string adres=Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg";
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\ruchy_oczu.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");
                //label6.Visible = true;


            }
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            bounds.Location = pictureBox2.Location;
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
                int x = panel6.Location.X + tabControl1.Location.X + pictureBox7.Location.X;
                int y = panel6.Location.Y + tabControl1.Location.Y + 55 + pictureBox7.Location.Y;
                int w = pictureBox7.Size.Width + pictureBox8.Size.Width;
                int h = pictureBox7.Size.Height;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);

                //MessageBox.Show(Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //string adres = Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg";
                //adres = adres.Replace("\\", "/");
                //adres = adres.Insert(3, "\\");

                //string adres = Path.Combine(Application.StartupPath, katalogpacjenta, "obrazy\\uszkodzenie_NCII.jpg"); //MessageBox.Show(adres);

                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                //bitmap.Dispose();
                //string adres=Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg";
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\czucie_NCV.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");
                //label6.Visible = true;


            }

        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            bounds.Location = pictureBox2.Location;
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
                int x = panel7.Location.X + tabControl1.Location.X ;
                int y = panel7.Location.Y + tabControl1.Location.Y + 55 ;
                int w = panel7.Width;
                int h = 373;
                //MessageBox.Show("x, y, w, h = " + x + "," + y + "," + w + "," + h);

                //MessageBox.Show(Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg");
                //string adres = Application.StartupPath + "\\" + katalogpacjenta + "obrazy\\uszkodzenie_NCII.jpg";
                //adres = adres.Replace("\\", "/");
                //adres = adres.Insert(3, "\\");

                //string adres = Path.Combine(Application.StartupPath, katalogpacjenta, "obrazy\\uszkodzenie_NCII.jpg"); //MessageBox.Show(adres);

                Bitmap n = CropBitmap(bitmap, x, y, w, h);
                //bitmap.Dispose();
                //string adres=Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg";
                n.Save(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "obrazki\\czucie_NCVII.jpg", ImageFormat.Jpeg);
                n.Dispose();
                //File.Move(Application.StartupPath + "\\img.jpg", Application.StartupPath + "\\" + katalogpacjenta + "obrazki\\uszkodzenie_NCII.jpg");
                //label6.Visible = true;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Wszystkie pliki :) (*.*)|*.*";
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
            //Console.WriteLine(result); // <-- For debugging use only.

            // Process input if the user clicked OK.
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked) { textBox11.Enabled = true; button2.Enabled = true; } else { textBox11.Enabled = false; button2.Enabled = false; }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked) { textBox5.Enabled = true; } else { textBox5.Enabled = false; }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked) { textBox6.Enabled = true; } else { textBox6.Enabled = false; }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked) { textBox8.Enabled = true; } else { textBox8.Enabled = false; }
        }

        private void Form20_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }
    }
}
