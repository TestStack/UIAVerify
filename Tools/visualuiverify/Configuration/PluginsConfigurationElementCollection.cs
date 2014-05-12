using System.Configuration;

namespace VisualUIAVerify.Configuration
{
    public class PluginsConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PluginConfigurationElement)element).AssemblyFile;
        }
    }
}
