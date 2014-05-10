namespace VisualUiaVerify.Integration
{
    public interface IUiaVerifyPatternDescriptor
    {
        /// <summary>
        /// If true, pattern is shown always in general "Patterns" section on Property grid;
        /// otherwise, it is shown only when present, and in section "Custom patterns".
        /// 
        /// In general, non-windows provided patterns should return false here.
        /// </summary>
        bool IsCommon { get; }

        /// <summary>
        /// Should return Id of the described pattern
        /// </summary>
        int Id { get; }

        /// <summary>
        /// String representing the pattern in the PropertyGrid (property name)
        /// </summary>
        /// <remarks>
        /// In case of common patterns there's sometimes no pattern instance object to ask
        /// programmatic name of the pattern if the object does not implement it, but common
        /// patterns should be always shown even if empty, so this property is used to determine
        /// pattern name.
        /// </remarks>
        string DisplayName { get; }

        /// <summary>
        /// This method should return object representing the pattern instance in the PropertyGrid as
        /// if it was one of PropertyGrid.SelectedObject's public properties decorated with 
        /// [TypeConverter(typeof(ExpandableObjectConverter))].
        /// </summary>
        bool TryGetPatternInstanceDescribingObject(object patternInstance, out object descriptor);
    }
}