using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Automation;
using VisualUiaVerify.Integration;

namespace VisualUIAVerify.Plugin
{
    internal class LegacyIAccessiblePatternDescriptorObj
    {
        [Flags]
        private enum LegacyState
        {
            Normal = 0,
            Unavailable = 0x1,
            Selected = 0x2,
            Focused = 0x4,
            Pressed = 0x8,
            Checked = 0x10,
            Mixed = 0x20,
            Readonly = 0x40,
            HotTracked = 0x80,
            Default = 0x100,
            Expanded = 0x200,
            Collapsed = 0x400,
            Busy = 0x800,
            Floating = 0x1000,
            Marqueed = 0x2000,
            Animated = 0x4000,
            Invisible = 0x8000,
            Offscreen = 0x10000,
            Sizeable = 0x20000,
            Moveable = 0x40000,
            SelfVoicing = 0x80000,
            Focusable = 0x100000,
            Selectable = 0x200000,
            Linked = 0x400000,
            Traversed = 0x800000,
            Multiselectable = 0x1000000,
            Extselectable = 0x2000000,
            AlertLow = 0x4000000,
            AlertMedium = 0x8000000,
            AlertHigh = 0x10000000,
            Protected = 0x20000000,
        }

        private enum LegacyRole
        {
            TitleBar = 0x1,
            MenuBar = 0x2,
            ScrollBar = 0x3,
            Grip = 0x4,
            Sound = 0x5,
            Cursor = 0x6,
            Caret = 0x7,
            Alert = 0x8,
            Window = 0x9,
            Client = 0xa,
            MenuPopup = 0xb,
            MenuItem = 0xc,
            Tooltip = 0xd,
            Application = 0xe,
            Document = 0xf,
            Pane = 0x10,
            Chart = 0x11,
            Dialog = 0x12,
            Border = 0x13,
            Grouping = 0x14,
            Separator = 0x15,
            Toolbar = 0x16,
            Statusbar = 0x17,
            Table = 0x18,
            ColumnHeader = 0x19,
            RowHeader = 0x1a,
            Column = 0x1b,
            Row = 0x1c,
            Cell = 0x1d,
            Link = 0x1e,
            HelpBalloon = 0x1f,
            Character = 0x20,
            List = 0x21,
            ListItem = 0x22,
            Outline = 0x23,
            OutlineItem = 0x24,
            Pagetab = 0x25,
            PropertyPage = 0x26,
            Indicator = 0x27,
            Graphic = 0x28,
            StaticText = 0x29,
            Text = 0x2a,
            PushButton = 0x2b,
            CheckButton = 0x2c,
            RadioButton = 0x2d,
            ComboBox = 0x2e,
            DropList = 0x2f,
            ProgressBar = 0x30,
            Dial = 0x31,
            HotkeyField = 0x32,
            Slider = 0x33,
            SpinButton = 0x34,
            Diagram = 0x35,
            Animation = 0x36,
            Equation = 0x37,
            ButtonDropdown = 0x38,
            ButtonMenu = 0x39,
            ButtonDropdownGrid = 0x3a,
            Whitespace = 0x3b,
            PageTabList = 0x3c,
            Clock = 0x3d,
            SplitButton = 0x3e,
            IpAddress = 0x3f,
            OutlineButton = 0x40,
        }

        private readonly LegacyIAccessiblePattern _pattern;
        private readonly SelectMethodArgs _selectMethodArgs = new SelectMethodArgs();

        public LegacyIAccessiblePatternDescriptorObj(LegacyIAccessiblePattern pattern)
        {
            _pattern = pattern;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public object Current
        {
            get { return _pattern.Current; }
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

        public override string ToString()
        {
            var cr = new CacheRequest();
            cr.AutomationElementMode = AutomationElementMode.None;
            cr.TreeScope = TreeScope.Element;
            
            var pairs = new[]
                            {
                                new { name = "Name", value = Get(x => x.Current.Name) },
                                new { name = "Description", value = Get(x => x.Current.Description) },
                                new { name = "State", value = Get(x => string.Format("({0})", (LegacyState)x.Current.State)) },
                                new { name = "Shortcut", value = Get(x => x.Current.KeyboardShortcut) },
                                new { name = "Help", value = Get(x => x.Current.Help) },
                                new { name = "Role", value = Get(x => ((LegacyRole)x.Current.Role).ToString()) }
                            }
                .Where(x => !string.IsNullOrEmpty(x.value))
                .Select(x => string.Format("{0}={1}", x.name, x.value));

            return string.Join(", ", pairs);
        }

        private string Get(Func<LegacyIAccessiblePattern, string> rawAccessor)
        {
            try
            {
                return rawAccessor(_pattern);
            }
            catch (Exception)
            {
                return "<error>";
            }
        }
    }
}
