using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace VisualUIAVerify.Configuration
{
    public class UiaVerifyConfiguration
    {
        private const string ConfigSectionName = "uiaVerify";

        public static readonly UiaVerifyConfiguration Instance = new UiaVerifyConfiguration();

        public UiaVerifyConfiguration()
        {
            var config = ConfigurationManager.GetSection(ConfigSectionName) as UiaVerifyConfigurationSection;
            if (config == null)
            {
                Plugins = Enumerable.Empty<string>();
                return;
            }
            Plugins = config.Plugins
                            .Cast<PluginConfigurationElement>()
                            .Select(p => p.AssemblyFile)
                            .ToArray();
        }

        public IEnumerable<string> Plugins { get; set; }
    }
}