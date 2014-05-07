using System;
using System.Windows.Automation;

namespace VisualUIAVerify.Plugin
{
    internal class RelayPatternDescriptor : IUiaVerifyPatternDescriptor
    {
        private readonly Func<object, object> _descObjFactory;

        public bool IsCommon { get; private set; }

        public int Id { get; private set; }

        public string DisplayName { get; private set; }

        public RelayPatternDescriptor(AutomationPattern pattern, bool isCommon, Func<object, object> descObjFactory)
            :this(pattern.ProgrammaticName, pattern.Id, isCommon, descObjFactory)
        {
        }

        public RelayPatternDescriptor(string displayName, int id, bool isCommon, Func<object, object> descObjFactory)
        {
            DisplayName = displayName;
            Id = id;
            IsCommon = isCommon;
            _descObjFactory = descObjFactory;
        }

        public bool TryGetPatternInstanceDescribingObject(object patternInstance, out object descriptor)
        {
            descriptor = _descObjFactory(patternInstance);
            return descriptor != null;
        }
    }
}
