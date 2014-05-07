using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace VisualUIAVerify.Plugin
{
    internal static class PluginLoader
    {
        internal static IList<IUiaVerifyPlugin> Plugins { get; private set; }
        internal static IList<IUiaVerifyCustomPatternDescriptor> CommonPatternDescriptors { get; private set; }
        internal static Dictionary<int, IUiaVerifyCustomPatternDescriptor> PatternDescriptorMap { get; private set; }

        internal static void Load()
        {
            Plugins = new List<IUiaVerifyPlugin>();
            CommonPatternDescriptors = new List<IUiaVerifyCustomPatternDescriptor>();
            PatternDescriptorMap = new Dictionary<int, IUiaVerifyCustomPatternDescriptor>();

            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDir = Path.GetDirectoryName(assemblyPath);
            if (assemblyDir == null) return;
            
            var pluginsDir = Path.Combine(assemblyDir, "Plugins");
            if (!Directory.Exists(pluginsDir)) return;

            foreach (var pluginPath in Directory.GetFiles(pluginsDir, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var a = Assembly.LoadFile(pluginPath);
                var pluginTypes = a.GetTypes().Where(t => typeof(IUiaVerifyPlugin).IsAssignableFrom(t));
                foreach (var pluginType in pluginTypes)
                {
                    var plugin = (IUiaVerifyPlugin)Activator.CreateInstance(pluginType);
                    plugin.Initialize();
                    Register(plugin);
                    Plugins.Add(plugin);
                }
            }
        }

        private static void Register(IUiaVerifyPlugin plugin)
        {
            foreach (var patternDesc in plugin.CustomPatterns)
            {
                PatternDescriptorMap[patternDesc.Id] = patternDesc;
                if (patternDesc.IsCommon)
                    CommonPatternDescriptors.Add(patternDesc);
            }
        }
    }
}