using System.Configuration;

namespace VisualUIAVerify.Configuration
{
    public class UiaVerifyConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("plugins")]
        public PluginsConfigurationElementCollection Plugins
        {
            get { return (PluginsConfigurationElementCollection)this["plugins"]; }
        }
    }
}