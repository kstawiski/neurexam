using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using HTMLWYSIWYG;

namespace Badanie_Neurologiczne
{
    public partial class Form21 : Form
    {
        public bool wizyta = false;
        public Form21()
        {
            InitializeComponent(); toolStripTextBox1.Text = "ilość kolumn"; toolStripTextBox2.Text = "ilość wierszy";
        }
        public string html;
        private void Form21_Load(object sender, EventArgs e)
        {
            //htmlwysiwyg1.allowEdit(true); htmlwysiwyg1.setHTML(html);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (wizyta == false)
            {
                if (MessageBox.Show("Zapisać? Ta akcja nadpisze poprzednią wersje, co wiąże się z jej utratą.", "Potwierdź", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (MessageBox.Show("Zakończyć wprowadzanie rezulatu kolejnej wizyty?", "Potwierdź", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DialogResult = DialogResult.OK;
                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private void Form21_Shown(object sender, EventArgs e)
        {
            htmlwysiwyg1.allowEdit(true); htmlwysiwyg1.setHTML(html);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string kolumn = toolStripTextBox1.Text.Trim();
            int intkolumn;
            bool isNum = int.TryParse(kolumn, out intkolumn);
            int blad = 0;
            if (!isNum) { MessageBox.Show("to nie cyfry..."); blad = 1; }
            string wierszy = toolStripTextBox2.Text.Trim();
            int intwierszy;
            isNum = int.TryParse(wierszy, out intwierszy);
            if (!isNum) { MessageBox.Show("to nie cyfry..."); blad = 1; }
            if (blad == 0)
            {
                string newhtml = "<table><tbody>";
                int umiescilemrzedow = 0;
                while (umiescilemrzedow == intwierszy)
                {
                    newhtml += "<tr>";
                    int umiescilemkolumn = 0;
                    while (umiescilemkolumn == intkolumn)
                    {
                        newhtml += "<td>...</td>";
                        umiescilemkolumn++


                    ;


                    }
                    newhtml += "</tr>";
                    umiescilemrzedow++;

                }
                newhtml += "</tbody></table>";




                html = htmlwysiwyg1.getHTML() + newhtml;
                htmlwysiwyg1.allowEdit(true);

                htmlwysiwyg1.dopisz2(html);
                htmlwysiwyg1.Refresh();
                htmlwysiwyg1.Update();
                this.Refresh();

            }

        }

        private void zapiszJakoInnyPlikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kolumn = toolStripTextBox1.Text.Trim();
            int intkolumn;
            bool isNum = int.TryParse(kolumn, out intkolumn);
            int blad = 0;
            if (!isNum) { MessageBox.Show("to nie cyfry..."); blad = 1; }
            string wierszy = toolStripTextBox2.Text.Trim();

            kolumn = "3"
                ; wierszy = "4";

            int intwierszy;
            isNum = int.TryParse(wierszy, out intwierszy);
            if (!isNum) { MessageBox.Show("to nie cyfry..."); blad = 1; }
            if (blad == 0)
            {
                string newhtml = "<table style=\" width: 100%; border: thin; font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif; \">";
                int umiescilemrzedow = 0;
                //while (umiescilemrzedow == intwierszy)
                //{
                    newhtml += "<tr>";
                    int umiescilemkolumn = 0;
                    while (umiescilemkolumn == intkolumn)
                    {
                        newhtml += "<td></td>";
                        umiescilemkolumn++


                    ;


                    }
                    newhtml += "</tr>";
                    umiescilemrzedow++;

                //}
                newhtml += "</table>";




                html = htmlwysiwyg1.getHTML() + newhtml;
                htmlwysiwyg1.allowEdit(true);

                htmlwysiwyg1.dopisz(html);
                htmlwysiwyg1.Refresh();
                htmlwysiwyg1.Update();
                this.Refresh();
            }
        }

        private void wstawTabelęToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
