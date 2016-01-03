//---------------------------------------------------------------------------
//
// <copyright file="ScreenRectangle" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definition of class responsible to draw filled rectangle on the screen
//
// History:  
//  09/06/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using VisualUIAVerify.Win32;

namespace VisualUIAVerify.Utils
{
    /// <summary>
    /// Class for drawing screen rectangle.
    /// </summary>
    class ScreenRectangle : IDisposable
    {
        //we will remember visible, color and location properties
        private bool _visible;
        private Color _color;
        private Rectangle _location;

        //form used as a rectangle
        private Form _form;

        public ScreenRectangle()
        {
            //initialize the form
            this._form = new Form();

            _form.FormBorderStyle = FormBorderStyle.None;
            _form.ShowInTaskbar = false;
            _form.TopMost = true;
            _form.Visible = false;
            _form.Left = 0;
            _form.Top = 0;
            _form.Width = 1;
            _form.Height = 1;
            _form.Show();
            _form.Hide();
            _form.Opacity = 0.2;
            
            //set popup style
            int num1 = UnsafeNativeMethods.GetWindowLong(_form.Handle, -20);
            UnsafeNativeMethods.SetWindowLong(_form.Handle, -20, num1 | 0x80);

            this._color = Color.Black;
        }

        /// <summary>
        /// get/set visibility for the rectangle
        /// </summary>
        public bool Visible
        {
            get { return this._visible; }
            set
            {
                this._visible = value;

                if (value)
                    SafeNativeMethods.ShowWindow(_form.Handle, 8);
                else
                    _form.Hide();
            }
        }

        /// <summary>
        /// get/set color of the rectangle
        /// </summary>
        public Color Color
        {
            get { return this._color; }
            set
            {
                this._color = value;
                this._form.BackColor = value;
            }
        }

        /// <summary>
        /// get/set opacity for the rectangle
        /// </summary>
        public double Opacity
        {
            get { return this._form.Opacity; }
            set { this._form.Opacity = value; }
        }

        /// <summary>
        /// get/set location of the rectangle
        /// </summary>
        public Rectangle Location
        {
            get { return this._location; }
            set
            {
                this._location = value;
                this.Layout();
            }
        }

        /// <summary>
        /// this will set position of the rectangle when location has been changed
        /// </summary>
        private void Layout()
        {
//            SafeNativeMethods.SetWindowPos(this._leftForm.Handle, NativeMethods.HWND_TOPMOST, this._location.Left - this._width, this._location.Top, this._width, this._location.Height, 0x10);
            SafeNativeMethods.SetWindowPos(this._form.Handle, NativeMethods.HWND_TOPMOST, this._location.X, this._location.Y, this._location.Width, this._location.Height, 0x10);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this._form.Dispose();
        }

        #endregion
    }
}
