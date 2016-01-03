//---------------------------------------------------------------------------
//
// <copyright file="ElementHighlighter" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: implementation of automation element highlighting mechanizm
//
// History:  
//  09/06/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Drawing = System.Drawing;
using System.Windows;
using System.Windows.Automation;
using System.Diagnostics;
using VisualUIAVerify.Controls;
using VisualUIAVerify.Utils;
using VisualUIAVerify.Misc;

namespace VisualUIAVerify.Features
{
    /// <summary>
    /// this class implements AbstractFactory design pattern
    /// </summary>
    static class ElementHighlighterFactory
    {
        public const string BoundingRectangle = "RECTANGLE";
        public const string BoundingRectangleAndRays = "RAYS";
        public const string FadingBoundingRectangle = "FADINGRECTANGLE";
        public const string None = "NONE";

        /// <summary>
        /// creates appropriate ElementHighLighter according to the id
        /// </summary>
        /// <returns>new instance of ElementHighLighter</returns>
        public static ElementHighlighter CreateHighlighterById(string id, AutomationElementTreeControl treeControl)
        {
            Debug.Assert(id != null);

            switch (id.ToUpper())
            {
                case BoundingRectangle: return new BoundingRectangleElementHighLighter(treeControl);
                case FadingBoundingRectangle: return new FadingBoundingRectangleElementHighLighter(treeControl);
                case BoundingRectangleAndRays: return new RaysAndBoundingRectangleElementHighlighter(treeControl);

                default:
                    throw new ArgumentException(String.Format("Invalid argument value {0}", id));
            }
        }
    }

    /// <summary>
    /// Base class for element highlighters.
    /// </summary>
    abstract class ElementHighlighter: IDisposable
    {
        //tree which SelectedNodeChanged method will the highlighter listen to
        AutomationElementTreeControl _treeControl;

        //indicating if is now highlighting
        bool _isHighlighting;

        //indicating if this class was disposed
        bool _isDisposed;

        public ElementHighlighter(AutomationElementTreeControl treeControl)
        {
            Debug.Assert(treeControl != null);
            this._treeControl = treeControl;
        }

        /// <summary>
        /// Starts to highlighting SelectedNode of AutomationElementTreeControl
        /// </summary>
        public void StartHighlighting()
        {
            if (_isDisposed)
                throw new InvalidOperationException("cannot call StartHightlighting after Dispose");

            if (!_isHighlighting)
            {
                SetEventHandler();
                OnSelectedNodeChanged();

                _isHighlighting = true;
            }
        }

        /// <summary>
        /// Stops highlighting and hide highlighting rectangle.
        /// </summary>
        public void StopHighlighting()
        {
            if (_isDisposed)
                throw new InvalidOperationException("cannot call StartHightlighting after Dispose");

            if (_isHighlighting)
            {
                SetHighlightingElement(null);
                ReleaseEventHandler();
                _isHighlighting = false;
            }
        }

        /// <summary>
        /// this will stop highlighting, release all handlers and references.
        /// </summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                StopHighlighting();
                OnDispose();

                _treeControl = null;
                _isDisposed = true;
            }
        }

        /// <summary>
        /// this property enables setting possition of highlighting rectangle
        /// </summary>
        abstract protected Drawing.Rectangle Location { get; set; }

        /// <summary>
        /// this method enables to show or hide highlighting rectangle
        /// </summary>
        abstract protected void SetVisibility(bool show);

        /// <summary>
        /// this method enables setting ToolTip message about selected automation element
        /// </summary>
        abstract protected void SetToolTip(string toolTipMessage);

        /// <summary>
        /// this method is to acknowledge that Dispose was called so it is good to release everything
        /// </summary>
        abstract protected void OnDispose();

        /// <summary>
        /// this method will cause the selection of SelectedNode of a tree
        /// </summary>
        private void OnSelectedNodeChanged()
        {
            //TODO: check that window is not minimized

            //pick up the selected element
            AutomationElement selectedElement = null;
            AutomationElementTreeNode selectedNode = _treeControl.SelectedNode;

            if (selectedNode != null)
                selectedElement = selectedNode.AutomationElement;

            //highlight the element
            SetHighlightingElement(selectedElement);
        }
       

        private void SetEventHandler()
        {
            this._treeControl.SelectedNodeChanged += new SelectedNodeChangedEventDelegate(_treeControl_SelectedNodeChanged);
        }

        private void ReleaseEventHandler()
        {
            this._treeControl.SelectedNodeChanged -= new SelectedNodeChangedEventDelegate(_treeControl_SelectedNodeChanged);
        }

        /// <summary>
        /// this will set the highlighting rectangle upon automation element.
        /// </summary>
        /// <param name="selectedElement"></param>
        private void SetHighlightingElement(AutomationElement selectedElement)
        {
            if (selectedElement == null)
                SetVisibility(false); //if we do net have selected element then hide hilightling rectangle
            else
            {
                Rect rectangle = Rect.Empty;
                try
                {
                    //we will try to get bounding rectangle
                    rectangle = (Rect)selectedElement.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty, true);
                }
                catch (Exception ex)
                {
                    //if it failed then log exception
                    ApplicationLogger.LogException(ex);
                }

                if (rectangle != Rect.Empty)
                {
                    //if we have rectangle then set the highlighting rectangle
                    this.Location = new Drawing.Rectangle((int)rectangle.Left, (int)rectangle.Top, (int)rectangle.Width, (int)rectangle.Height);
                    SetToolTip(selectedElement);
                    SetVisibility(true);
                }
                else
                {
                    //if we don't then hide hilightting rectangle
                    SetVisibility(false);
                }
            }
        }

        /// <summary>
        /// this method will create and set tooltip message of automation element to highlighting rectangle
        /// </summary>
        /// <param name="element"></param>
        private void SetToolTip(AutomationElement element)
        {
            // we will compose the tooltip text in builder
            StringBuilder builder = new StringBuilder();

            builder.Append("AutomationElement.Name = ");
            try
            {
                builder.Append(element.Current.Name);
            }
            catch (Exception ex)
            {
                builder.Append("(not available)");
                ApplicationLogger.LogException(ex);
            }
            
            builder.Append("\nAutomationElement.LocalizedControlType = ");

            try
            {
                builder.Append(element.Current.LocalizedControlType);
            }
            catch (Exception ex)
            {
                builder.Append("(not available)");
                ApplicationLogger.LogException(ex);
            }

            builder.Append("\nAutomationElement.AutomationId = ");

            try
            {
                builder.Append(element.Current.AutomationId);
            }
            catch (Exception ex)
            {
                builder.Append("(not available)");
                ApplicationLogger.LogException(ex);
            }

            //set the tooltip text
            SetToolTip(builder.ToString());
        }

        /// <summary>
        /// when SelectedNode is changed then highlight it
        /// </summary>
        private void _treeControl_SelectedNodeChanged(object sender, EventArgs e)
        {
            OnSelectedNodeChanged();
        }
    }

    /// <summary>
    /// this class is implementation of highlighter. It will draw a bounding rectangle
    /// around the control of selected automation element.
    /// </summary>
    class BoundingRectangleElementHighLighter : ElementHighlighter
    {
        protected ScreenBoundingRectangle _rectangle = new ScreenBoundingRectangle();

        public BoundingRectangleElementHighLighter(AutomationElementTreeControl treeControl) : base(treeControl)
        {
            _rectangle.Color = Drawing.Color.Red;
            _rectangle.Opacity = 0.8;
        }

        protected override Drawing.Rectangle Location
        {
            get { return this._rectangle.Location;}
            set { this._rectangle.Location = value; }
        }

        protected override void SetVisibility(bool show)
        {
            this._rectangle.Visible = show;
        }

        protected override void SetToolTip(string toolTipMessage)
        {
            //TODO
        }

        protected override void OnDispose()
        {
            this._rectangle.Dispose();
        }
    }

    /// <summary>
    /// this class is implementation of highlighter. It will draw a fading bounding rectangle
    /// around the control of selected automation element. It means that the bounding rectangle
    /// will disappear in short time (like 5 seconds).
    /// </summary>
    class FadingBoundingRectangleElementHighLighter : BoundingRectangleElementHighLighter
    {
        Timer _timer;

        public FadingBoundingRectangleElementHighLighter(AutomationElementTreeControl treeControl) : base(treeControl) { }

        protected override void SetVisibility(bool show)
        {
            base.SetVisibility(show);

            if (show)
                SetHidingTimer();
        }

        private void SetHidingTimer()
        {
            if (this._timer == null)
            {
                this._timer = new Timer();
                this._timer.Interval = 2000;
                this._timer.Tick += new EventHandler(_timer_Tick);
            }

            //restart timer
            this._timer.Stop();
            this._timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            base.SetVisibility(false);
            this._timer.Stop();
        }

        protected override void OnDispose()
        {
            if (this._timer != null)
            {
                this._timer.Stop();
                this._timer.Tick -= new EventHandler(_timer_Tick);
                this._timer = null;
            }

            base.OnDispose();
        }

    }

    /// <summary>
    /// this class is implementation of highlighter. It will draw a bounding rectangle
    /// around the control of selected automation element and rays from the corners of the screen
    /// to the corners of the rectangle.
    /// </summary>
    class RaysAndBoundingRectangleElementHighlighter : BoundingRectangleElementHighLighter
    {
        int _rayLength = 25;

        ScreenRectangle _topLeftVerticalRay, _topLeftHorizontalRay;
        ScreenRectangle _topRightVerticalRay, _topRightHorizontalRay;
        ScreenRectangle _bottomLeftVerticalRay, _bottomLeftHorizontalRay;
        ScreenRectangle _bottomRightVerticalRay, _bottomRightHorizontalRay;

        ScreenRectangle[] _rays;

        public RaysAndBoundingRectangleElementHighlighter(AutomationElementTreeControl treeControl) : base(treeControl)
        {
            _topLeftVerticalRay = new ScreenRectangle();
            _topLeftHorizontalRay = new ScreenRectangle();
            _topRightVerticalRay = new ScreenRectangle();
            _topRightHorizontalRay = new ScreenRectangle();
            _bottomLeftVerticalRay = new ScreenRectangle();
            _bottomLeftHorizontalRay = new ScreenRectangle();
            _bottomRightVerticalRay = new ScreenRectangle();
            _bottomRightHorizontalRay = new ScreenRectangle();

            this._rays = new ScreenRectangle[] { _topLeftVerticalRay , _topLeftHorizontalRay ,
                _topRightVerticalRay , _topRightHorizontalRay ,
                _bottomLeftVerticalRay , _bottomLeftHorizontalRay ,
                _bottomRightVerticalRay , _bottomRightHorizontalRay };

            double boundingRectOpacity = base._rectangle.Opacity;

            foreach (ScreenRectangle ray in this._rays)
            {
                ray.Color = Drawing.Color.Blue;
                ray.Opacity = boundingRectOpacity;
            }
        }

        protected override Drawing.Rectangle Location
        {
            set
            {
                int lineWidth = base._rectangle.LineWidth;

                _topLeftVerticalRay.Location = new Drawing.Rectangle(value.X - lineWidth, value.Y - _rayLength - lineWidth, lineWidth, _rayLength);
                _topLeftHorizontalRay.Location = new Drawing.Rectangle(value.X - _rayLength - lineWidth, value.Y - lineWidth, _rayLength, lineWidth);

                _topRightVerticalRay.Location = new Drawing.Rectangle(value.X + value.Width, value.Y - _rayLength - lineWidth, lineWidth, _rayLength);
                _topRightHorizontalRay.Location = new Drawing.Rectangle(value.X + value.Width + lineWidth, value.Y - lineWidth, _rayLength, lineWidth);

                _bottomLeftVerticalRay.Location = new Drawing.Rectangle(value.X - lineWidth, value.Y + value.Height + lineWidth, lineWidth, _rayLength);
                _bottomLeftHorizontalRay.Location = new Drawing.Rectangle(value.X - lineWidth - _rayLength, value.Y + value.Height, _rayLength, lineWidth);

                _bottomRightVerticalRay.Location = new Drawing.Rectangle(value.X + value.Width, value.Y + value.Height + lineWidth, lineWidth, _rayLength);
                _bottomRightHorizontalRay.Location = new Drawing.Rectangle(value.X + value.Width + lineWidth, value.Y + value.Height, _rayLength, lineWidth);
            
                base.Location = value;
            }
        }

        protected override void SetVisibility(bool show)
        {
            foreach (ScreenRectangle ray in this._rays)
                ray.Visible = show;
                    
            base.SetVisibility(show);
        }

        protected override void OnDispose()
        {
            foreach (ScreenRectangle ray in this._rays)
                ray.Dispose();

            base.OnDispose();
        }
    }
}
