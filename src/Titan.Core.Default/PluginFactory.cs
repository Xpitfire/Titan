using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using Titan.Plugin;

namespace Titan.Core.Default
{
    public static class PluginFactory
    {
        private const string BaseDirectory = ".";
        private const string FileExtension = ".dll";

            private static TModule LoadAddIn<TModule>(string assemblyName, AppDomain sandboxDomain) where TModule : class
        {
            var assembly = Assembly.Load(assemblyName);
            foreach (var type in assembly.GetTypes())
            {
                if (!type.GetInterfaces().Contains(typeof(TModule))) continue;
                return sandboxDomain.CreateInstanceAndUnwrap(
                    assembly.FullName,
                    type.FullName) as TModule;
            }
            return default(TModule);
        }

        public static TModule Get<TModule>() where TModule : class, IPlugin
        {
            var permSet = new PermissionSet(PermissionState.None);
            permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            var ptInfo = new AppDomainSetup
            {
                ApplicationBase = BaseDirectory
            };
            var strongName = typeof(TModule).Assembly.Evidence.GetHostEvidence<StrongName>();
            var sandboxDomain = AppDomain.CreateDomain(typeof(TModule).FullName,
                AppDomain.CurrentDomain.Evidence,
                ptInfo,
                permSet,
                strongName);
            foreach (var file in new DirectoryInfo(BaseDirectory).GetFiles($"*{FileExtension}"))
            {
                var assemblyName = file.Name.Replace(FileExtension, string.Empty);
                Console.WriteLine($@"Loaded DLL: {assemblyName}");
                var plugin = LoadAddIn<TModule>(assemblyName, sandboxDomain);
                if (plugin == null) continue;
                if (plugin.GetType() != typeof(TModule) 
                    && !typeof(TModule).IsAssignableFrom(typeof(TModule))) continue;
                return plugin;
            }
            return default(TModule);
        }
    }
}
