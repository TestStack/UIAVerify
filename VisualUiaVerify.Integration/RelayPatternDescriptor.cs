using System;
using System.Windows.Automation;

namespace VisualUiaVerify.Integration
{
    public class RelayPatternDescriptor : IUiaVerifyPatternDescriptor
    {
        private readonly Func<object, object> _descObjFactory;

        public bool IsCommon { get; private set; }

        public int Id { get; private set; }

        public string DisplayName { get; private set; }

        public RelayPatternDescriptor(AutomationPattern pattern, bool isCommon, Func<object, object> descObjFactory)
            : this(CleanName(pattern.ProgrammaticName), pattern.Id, isCommon, descObjFactory)
        {
        }

        private static string CleanName(string programmaticName)
        {
            const string ending = "PatternIdentifiers.Pattern";
            if (programmaticName.EndsWith(ending))
                return programmaticName.Remove(programmaticName.Length - ending.Length);
            return programmaticName;
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
