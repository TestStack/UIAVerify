namespace VisualUIAVerify.Plugin
{
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Automation;

    using VisualUiaVerify.Integration;

    internal class LegacyIAccessiblePatternDescriptorObj
    {
        private readonly LegacyIAccessiblePattern _pattern;
        private readonly SelectMethodArgs _selectMethodArgs = new SelectMethodArgs();

        public LegacyIAccessiblePatternDescriptorObj(LegacyIAccessiblePattern pattern)
        {
            _pattern = pattern;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public object Current
        {
            get
            {
                return _pattern.Current;
            }
        }

        [Editor(typeof(InvokeMethodButtonEditor), typeof(UITypeEditor))]
        public object DoDefaultAction
        {
            get { return "(invoke method)"; }
            set { _pattern.DoDefaultAction(); }
        }

        public string SetValue
        {
            get { return _pattern.Current.Value; }
            set { _pattern.SetValue(value); }
        }

        [Editor(typeof(InvokeMethodButtonEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public object Select
        {
            get { return _selectMethodArgs; }
            set { _pattern.Select(_selectMethodArgs.FlagsSelect); }
        }

        private class SelectMethodArgs
        {
            public int FlagsSelect { get; set; }
        }
    }
}