using System.Collections.Generic;
using System.Windows.Automation;
using VisualUiaVerify.Integration;

namespace VisualUIAVerify.Plugin
{
    /// <summary>
    /// Describes built-in functionality
    /// </summary>
    internal class InternalPlugin : IUiaVerifyPlugin
    {
        private IUiaVerifyPatternDescriptor[] _patternDescriptors;

        public void Initialize()
        {
            _patternDescriptors = new[]
                                  {
                                      new RelayPatternDescriptor(ItemContainerPattern.Pattern,
                                                                 true,
                                                                 pi => new ItemContainerPatternDescriptorObj((ItemContainerPattern)pi)),
                                      new RelayPatternDescriptor(LegacyIAccessiblePattern.Pattern,
                                                                 true,
                                                                 pi => new LegacyIAccessiblePatternDescriptorObj((LegacyIAccessiblePattern)pi)),
                                  };
        }

        public IEnumerable<IUiaVerifyPatternDescriptor> PatternDescriptors
        {
            get { return _patternDescriptors; }
        }
    }
}
