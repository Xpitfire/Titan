using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Plugin
{
    public static class PluginSecureCriticalExtension
    {
        [SecuritySafeCritical]
        public static string GetInfo(this IPlugin plugin)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sb = new StringBuilder();
            sb.Append($"SecurityRuleSet: {assembly.SecurityRuleSet}");
            sb.Append($"SecurityRuleSet: {assembly.IsFullyTrusted}");
            sb.Append($"PermissionSet: Count({assembly.PermissionSet.Count}) >> ");
            foreach (var t in assembly.GetTypes())
            {
                sb.Append($"  {t.Name}:");
                sb.Append($"    SecurityCritical: {t.IsSecurityCritical}");
                sb.Append($"    SecuritySafeCritical: {t.IsSecuritySafeCritical}");
                sb.Append($"    SecurityTransparent: {t.IsSecurityTransparent}");
            }
            return sb.ToString();
        }
    }
}
