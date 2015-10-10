using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Badanie_Neurologiczne.Forms
{
    public partial class ListBox : System.Windows.Forms.ListBox
    {
        public ListBox()
        {
            InitializeComponent();

            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            if (this.Items.Count == 0)
                return;

            e.DrawBackground();

            SolidBrush txtBrush = new SolidBrush(this.ForeColor);

            SizeF S = new SizeF(this.Width, 0);
            SizeF size = e.Graphics.MeasureString(this.Items[e.Index].ToString(), this.Font, S);

            RectangleF R = new RectangleF(new PointF(e.Bounds.X, e.Bounds.Y), size);

            e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, txtBrush, R, StringFormat.GenericDefault);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            SizeF itmSize;
            SizeF S = new SizeF(this.Width, 0);

            itmSize = e.Graphics.MeasureString(this.Items[e.Index].ToString(), this.Font, S);

            e.ItemHeight = Convert.ToInt32(itmSize.Height);
            e.ItemWidth = Convert.ToInt32(itmSize.Width);
        }
    }
}
