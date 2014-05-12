using System.Configuration;

namespace VisualUIAVerify.Configuration
{
    public class PluginConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("assemblyFile", IsKey = true, IsRequired = true)]
        public string AssemblyFile
        {
            get { return (string)this["assemblyFile"]; }
        }
    }
}