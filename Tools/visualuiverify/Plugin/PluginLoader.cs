using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using VisualUiaVerify.Integration;

namespace VisualUIAVerify.Plugin
{
    internal static class PluginLoader
    {
        internal static IList<IUiaVerifyPlugin> Plugins { get; private set; }
        internal static IList<IUiaVerifyPatternDescriptor> CommonPatternDescriptors { get; private set; }
        internal static Dictionary<int, IUiaVerifyPatternDescriptor> PatternDescriptorMap { get; private set; }

        internal static void Load()
        {
            Plugins = new List<IUiaVerifyPlugin>();
            CommonPatternDescriptors = new List<IUiaVerifyPatternDescriptor>();
            PatternDescriptorMap = new Dictionary<int, IUiaVerifyPatternDescriptor>();
            RegisterPlugin(new InternalPlugin());

            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDir = Path.GetDirectoryName(assemblyPath);
            if (assemblyDir == null) return;
            
            var pluginsDir = Path.Combine(assemblyDir, "Plugins");
            if (!Directory.Exists(pluginsDir)) return;

            foreach (var pluginPath in Directory.GetFiles(pluginsDir, "*.dll", SearchOption.TopDirectoryOnly))
            {
                var a = Assembly.LoadFile(pluginPath);
                LoadPluginsFromAssembly(a);
            }
        }

        private static void LoadPluginsFromAssembly(Assembly assembly)
        {
            var pluginTypes = assembly.GetTypes().Where(t => typeof(IUiaVerifyPlugin).IsAssignableFrom(t));
            foreach (var pluginType in pluginTypes)
            {
                var plugin = (IUiaVerifyPlugin)Activator.CreateInstance(pluginType);
                RegisterPlugin(plugin);
            }
        }

        private static void RegisterPlugin(IUiaVerifyPlugin plugin)
        {
            plugin.Initialize();
            foreach (var patternDesc in plugin.PatternDescriptors)
            {
                PatternDescriptorMap[patternDesc.Id] = patternDesc;
                if (patternDesc.IsCommon)
                    CommonPatternDescriptors.Add(patternDesc);
            }
            Plugins.Add(plugin);
        }
    }
}