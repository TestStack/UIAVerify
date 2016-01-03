using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using VisualUIAVerify.Configuration;
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

            LoadPluginsFromSubdirectory();
            LoadPluginsFromConfiguration();
        }

        private static void LoadPluginsFromSubdirectory()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var assemblyDir = Path.GetDirectoryName(assemblyPath);
            if (assemblyDir == null) return;

            var pluginsDir = Path.Combine(assemblyDir, "Plugins");
            if (!Directory.Exists(pluginsDir)) return;

            foreach (var pluginPath in Directory.GetFiles(pluginsDir, "*.dll", SearchOption.TopDirectoryOnly))
                LoadPluginsFromAssembly(pluginPath);
        }

        private static void LoadPluginsFromConfiguration()
        {
            foreach (var pluginAssemblyFilename in UiaVerifyConfiguration.Instance.Plugins)
                LoadPluginsFromAssembly(pluginAssemblyFilename);
        }

        private static void LoadPluginsFromAssembly(string assemblyFilename)
        {
            var a = Assembly.LoadFrom(assemblyFilename);
            LoadPluginsFromAssembly(a);
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