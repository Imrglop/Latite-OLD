/*
 * 
 * Latite - A minecraft: Windows 10 Edition PVP mod.
 * Copyright (c) 2021 Imrglop
 * 
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latite
{
    class DragUtils
    {
        private Form form;
        private Point MouseLocation;

        public DragUtils(Form form)
        {
            this.form = form;
        }

        #region drag utils
        public void StartDrag(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLocation = e.Location;
            }
        }

        public void DragProc(Control c, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                c.Location = new Point(e.X + c.Left - MouseLocation.X,
                    e.Y + c.Top - MouseLocation.Y);
                c.Anchor = this.CalcPositionSnap(c);
            }
        }

        public AnchorStyles CalcPositionSnap(Control control)
        {
            AnchorStyles FAS = 0;
            var x = this.form.Height / 3;
            if (control.Location.Y > x)
            {
                if (control.Location.Y > x * 2)
                {
                    // bottom
                    FAS |= AnchorStyles.Bottom;
                }
                else
                {
                    // center
                    FAS = AnchorStyles.None;
                }
            }
            else
            {
                // top
                FAS |= AnchorStyles.Top;
            }

            x = this.form.Width / 3;
            if (control.Location.X > x)
            {
                if (control.Location.X > x * 2)
                {
                    FAS |= AnchorStyles.Right;
                }
            }
            else
            {
                FAS |= AnchorStyles.Left;
            }
            return FAS;
        }
        #endregion
    }
}
