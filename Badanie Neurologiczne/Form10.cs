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
    public partial class Form10 : Form
    {
        public string szczegwynik = "4/5/6";
        public int wynik = 15;
        public Form10()
        {
            InitializeComponent();
        }
        private void ruszonypasek() {
            numericUpDown1.Value = trackBar1.Value;
            numericUpDown2.Value = trackBar2.Value;
            numericUpDown3.Value = trackBar3.Value; wyliczglasgow();
        }
        private void ruszonacyfra()
        {
            trackBar1.Value = Convert.ToInt32(numericUpDown1.Value);
            trackBar2.Value = Convert.ToInt32(numericUpDown2.Value);
            trackBar3.Value = Convert.ToInt32(numericUpDown3.Value); wyliczglasgow();
        }
        private void wyliczglasgow()
        {
            wynik = Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(numericUpDown2.Value) + Convert.ToInt32(numericUpDown3.Value);
            szczegwynik = Convert.ToString(numericUpDown1.Value) + "/" + Convert.ToString(numericUpDown2.Value) + "/" + Convert.ToString(numericUpDown3.Value);
            label8.Text = Convert.ToString(wynik) + " pkt. (" + szczegwynik + ")";
            
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ruszonypasek(); wyliczglasgow();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ruszonypasek(); wyliczglasgow();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            ruszonypasek(); wyliczglasgow();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            ruszonacyfra(); wyliczglasgow();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ruszonacyfra(); wyliczglasgow();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ruszonacyfra(); wyliczglasgow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wyliczglasgow(); DialogResult = DialogResult.OK;
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 1; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 2; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape3_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 3; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape4_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 4; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape6_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 1; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape7_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 2; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape8_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 3; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape9_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 4; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape10_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 5; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape12_Click(object sender, EventArgs e)
        {
            trackBar3.Value = 1; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape13_Click(object sender, EventArgs e)
        {
            trackBar3.Value = 2; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape14_Click(object sender, EventArgs e)
        {
            trackBar3.Value = 3; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape15_Click(object sender, EventArgs e)
        {
            trackBar3.Value = 4; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape16_Click(object sender, EventArgs e)
        {
            trackBar3.Value = 5; ruszonypasek(); wyliczglasgow();
        }

        private void ovalShape17_Click(object sender, EventArgs e)
        {
            trackBar3.Value = 6; ruszonypasek(); wyliczglasgow();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
