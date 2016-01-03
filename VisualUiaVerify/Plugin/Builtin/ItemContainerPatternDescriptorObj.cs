using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Automation;
using VisualUIAVerify.Features;
using VisualUiaVerify.Integration;

namespace VisualUIAVerify.Plugin
{
    internal class ItemContainerPatternDescriptorObj
    {
        private readonly ItemContainerPattern _pattern;

        public ItemContainerPatternDescriptorObj(ItemContainerPattern pattern)
        {
            _pattern = pattern;
        }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Editor(typeof(InvokeMethodButtonEditor), typeof(UITypeEditor))]
        public object FindItemById
        {
            set { }
            get { return new object(); }
        }
    }
}