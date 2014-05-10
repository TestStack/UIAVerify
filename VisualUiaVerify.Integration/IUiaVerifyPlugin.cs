using System.Collections.Generic;

namespace VisualUiaVerify.Integration
{
    public interface IUiaVerifyPlugin
    {
        /// <summary>
        /// This method will be called once before using other plugin members
        /// </summary>
        void Initialize();
        
        IEnumerable<IUiaVerifyPatternDescriptor> PatternDescriptors { get; }
    }
}