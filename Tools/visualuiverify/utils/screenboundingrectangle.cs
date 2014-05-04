//---------------------------------------------------------------------------
//
// <copyright file="ScreenBoundingRectangle" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definition of class responsible to draw line a top-most bounding rectangle on the screen.
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
    /// This class is responsible to draw bounding rectangle around some location on the screen.
    /// </summary>
    class ScreenBoundingRectangle: IDisposable
    {
        //we will remember values for properties Width, Visible, Color, Location, ToolTipText
        private int _width;
        private bool _visible;
        private Color _color;
        private Rectangle _location;

        private string _tooltipText;

        //for bounding rect we will use 4 rectangles
        private ScreenRectangle _leftRectangle, _bottomRectangle, _rightRectangle, _topRectangle;
        private ScreenRectangle[] _rectangles;

        public ScreenBoundingRectangle()
        {
            //initialize instance
            this._width = 3;

            this._leftRectangle = new ScreenRectangle();
            this._topRectangle = new ScreenRectangle();
            this._rightRectangle = new ScreenRectangle();
            this._bottomRectangle = new ScreenRectangle();

            this._rectangles = new ScreenRectangle[] { this._leftRectangle, this._topRectangle, this._rightRectangle, this._bottomRectangle };
        }

        public bool Visible
        {
            get { return this._visible; }
            set { this._visible = this._leftRectangle.Visible = this._rightRectangle.Visible = 
                this._topRectangle.Visible = this._bottomRectangle.Visible = value;}
        }

        public Color Color
        {
            get { return this._color; }
            set
            {
                this._color = this._leftRectangle.Color = this._rightRectangle.Color =
              this._topRectangle.Color = this._bottomRectangle.Color = value;
            }
        }

        public double Opacity
        {
            get { return this._leftRectangle.Opacity; }
            set
            {
                this._leftRectangle.Opacity = this._rightRectangle.Opacity =
              this._topRectangle.Opacity = this._bottomRectangle.Opacity = value;
            }
        }

        public int LineWidth
        {
            get { return this._width; }
        }

        public Rectangle Location
        {
            get { return this._location; }
            set
            {
                this._location = value;
                this.Layout();
            }
        }


        public string ToolTipText
        {
            get { return this._tooltipText; }
            set
            {
                //TODO: not used yet
                this._tooltipText = value;
            }
        }

        private void Layout()
        {
            this._leftRectangle.Location = new Rectangle(this._location.Left - this._width, this._location.Top, this._width, this._location.Height);
            this._topRectangle.Location = new Rectangle(this._location.Left - this._width, this._location.Top - this._width, this._location.Width + (2 * this._width), this._width);
            this._rightRectangle.Location = new Rectangle(this._location.Left + this._location.Width, this._location.Top, this._width, this._location.Height);
            this._bottomRectangle.Location = new Rectangle(this._location.Left - this._width, this._location.Top + this._location.Height, this._location.Width + (2 * this._width), this._width);
        }

        #region IDisposable Members

        public void Dispose()
        {
            foreach (ScreenRectangle rectangle in this._rectangles)
                rectangle.Dispose();
        }

        #endregion
    }
}
