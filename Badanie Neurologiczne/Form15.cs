using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Badanie_Neurologiczne
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent(); listView1.Items.Clear(); jednostek = 0; jednostekdziennie = 0; label4.Text = ""; label5.Text = ""; label7.Text = "";
        }
public decimal jednostek = 0;
public decimal jednostekdziennie = 0;
        private void button23_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = Convert.ToString(numericUpDown1.Value);
            //.numericUpDown1.lvi.Group = listView1.Groups[kategoria];
            //aktywność

            lvi.SubItems.Add(Convert.ToString(numericUpDown2.Value));
            //opis
            //lvi.SubItems.Add(opis);
            //lvi.ToolTipText = opis;
            listView1.Items.Add(lvi);

            jednostek = 0;
            foreach (ListViewItem lstItem in listView1.Items)
            {
                //MessageBox.Show("%: " + lstItem.Text + " obj: " + lstItem.SubItems[1].Text);

                jednostek += decimal.Parse(lstItem.Text) * decimal.Parse(lstItem.SubItems[1].Text) / 1000;
                
            }
            jednostekdziennie = jednostek / 7; Decimal.Round(jednostek, 2); Decimal.Round(jednostekdziennie, 2);
            label4.Text = "To znaczy " + Convert.ToString(Decimal.Round(jednostek, 2)) + " jednostek w ciągu tygodnia, czyli";
            label5.Text = Convert.ToString(Decimal.Round(jednostekdziennie, 2)) + " jednostek dziennie.";
            if (comboBox1.Text != "")
            {
                if (comboBox1.Text == "ocena dla mężczyzny")
                {

                    if (jednostek <= 21) { label7.Text = "odpowiedzialny poziom ryzka"; } else {
                        if (jednostek <= 50) { label7.Text = "ryzykowny poziom ryzyka"; } else { label7.Text = "zagrażający poziom ryzyka"; }
                    
                    
                    
                    }





                }
                if (comboBox1.Text == "ocena dla kobiety")
                {

                    if (jednostek <= 14) { label7.Text = "odpowiedzialny poziom ryzka"; }
                    else
                    {
                        if (jednostek <= 35) { label7.Text = "ryzykowny poziom ryzyka"; } else { label7.Text = "zagrażający poziom ryzyka"; }



                    }



                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); jednostek = 0; jednostekdziennie = 0; label4.Text = ""; label5.Text = ""; label7.Text = ""; Decimal.Round(jednostek, 2); Decimal.Round(jednostekdziennie, 2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (comboBox1.Text == "ocena dla mężczyzny")
                {

                    if (jednostek <= 21) { label7.Text = "odpowiedzialny poziom ryzka"; }
                    else
                    {
                        if (jednostek <= 50) { label7.Text = "ryzykowny poziom ryzyka"; } else { label7.Text = "zagrażający poziom ryzyka"; }



                    }





                }
                if (comboBox1.Text == "ocena dla kobiety")
                {

                    if (jednostek <= 14) { label7.Text = "odpowiedzialny poziom ryzka"; }
                    else
                    {
                        if (jednostek <= 35) { label7.Text = "ryzykowny poziom ryzyka"; } else { label7.Text = "zagrażający poziom ryzyka"; }



                    }



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W dokumencie 'Guide to Mental Health in Primary Care' (Przewodnik Zdrowia Psychicznego w Zakresie Podstawowym) wydanym przez Swiatowa Organizacje Zdrowia, gdzie zalecenia podzielone sa na trzy poziomy ryzyka: „odpowiedzialny”, „ryzykowny” i „zagrazajacy”. „Odpowiedzialny” lub „niski” poziom ryzyka dla mezczyzn to 3 jednostki dziennie, maksymalnie 21 jednostek tygodniowo rozlozone na caly tydzien (w tym dwa dni bezalkoholowe tygodniowo), podczas gdy dla kobiet poziom obnizony jest do 2 jednostek dziennie i 14 jednostek tygodniowo. (Jednostka to ekwiwalent 8g alkoholu etylowego). Poziom „ryzykowny” taki, przy którym zwieksza sie ryzyko zaistnienia problemów takich jak podwyzszone cisnienie, wylew i marskosc watroby ustalony jest na 3 do 7 jednostek dziennie i 22 do 49 jednostek tygodniowo dla mezczyzn i 2 do 5 jednostek dziennie i 15 do 35 jednostek tygodniowo dla kobiet. Poziom „zagrazajacy” taki, przy którym „utrzymywanie spozycia alkoholu na tym poziomie najprawdopodobniej spowoduje fizyczne, mentalne i spoleczne problemy”, to 7 lub wie cej jednostek dziennie lub ponad 50 jednostek tygodniowo dla mezczyzn i ponad 5 jednostek dziennie i ponad 35 jednostek tygodniowo dla kobiet.","Informacja");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
