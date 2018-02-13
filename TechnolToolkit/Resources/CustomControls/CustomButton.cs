using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit.Resources.CustomControls
{
    class CustomButton : Control
    {
        //Variables
        private SolidBrush borderBrush, textBrush;
        private Rectangle borderRectanhle;
        private bool active = false;
        private StringFormat stringFormat = new StringFormat();

        //Properties
        /*public override Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }

            set
            {
                base.Cursor = value;
            }
        }
        */

        public float BorderThickness { get; set; } = 2;

        //Constructor
        public CustomButton()
        {
            borderBrush = new SolidBrush(Color.FromArgb(255, 150, 30));
            textBrush = new SolidBrush(Color.RoyalBlue);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            this.Paint += CustomButton_Paint;
        }
        //Events
        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            borderRectanhle = new Rectangle(0, 0, Width, Height);
            e.Graphics.DrawRectangle(new Pen(borderBrush, BorderThickness), borderRectanhle);
            e.Graphics.DrawString(this.Text, this.Font, (active) ? textBrush : borderBrush, borderRectanhle, stringFormat);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            base.BackColor = Color.FromArgb(123, 132, 146);
            active = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.BackColor = Color.FromArgb(44, 197, 22);
            active = false;
        }

    }
}
