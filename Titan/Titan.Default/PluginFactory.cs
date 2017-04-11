using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Titan.Service;

namespace Titan.Default
{
    public static class PluginFactory
    {
        private const string BaseDirectory = ".";
        private const string FileExtension = ".dll";

            private static TModule LoadAddIn<TModule>(string assemblyName) where TModule : class
        {
            var assembly = Assembly.Load(assemblyName);
            foreach (var type in assembly.GetTypes())
            {
                if (!type.GetInterfaces().Contains(typeof(TModule))) continue;
                return Activator.CreateInstance(
                    assembly.FullName,
                    type.FullName) as TModule;
            }
            return default(TModule);
        }

        public static TModule Get<TModule>() where TModule : class, IPlugin
        {
            foreach (var file in new DirectoryInfo(BaseDirectory).GetFiles($"*{FileExtension}"))
            {
                var assemblyName = file.Name.Replace(FileExtension, string.Empty);
                Console.WriteLine($@"Loaded DLL: {assemblyName}");
                var plugin = LoadAddIn<TModule>(assemblyName);
                if (plugin == null) continue;
                if (plugin.GetType() != typeof(TModule) 
                    && !typeof(TModule).IsAssignableFrom(typeof(TModule))) continue;
                return plugin;
            }
            return default(TModule);
        }
    }
}
