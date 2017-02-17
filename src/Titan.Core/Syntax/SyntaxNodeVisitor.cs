using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Syntax;

namespace Titan.Core.Syntax
{
    public sealed class SyntaxNodeVisitor
    {
        private static readonly object LockObject = new object();
        private static readonly Type[] NodeTypes;
        private static readonly IDictionary<Type, ConcurrentBag<MethodInfo>> PreAction = new ConcurrentDictionary<Type, ConcurrentBag<MethodInfo>>();
        private static readonly IDictionary<Type, ConcurrentBag<MethodInfo>> InAction = new ConcurrentDictionary<Type, ConcurrentBag<MethodInfo>>();
        private static readonly IDictionary<Type, ConcurrentBag<MethodInfo>> PostAction = new ConcurrentDictionary<Type, ConcurrentBag<MethodInfo>>();


        static SyntaxNodeVisitor()
        {
            lock (LockObject)
            {
                NodeTypes = GetTypesWith<TraversableAttribute>(inherit: true).ToArray();
                foreach (var visitorType in NodeTypes)
                {
                    PreAction[visitorType] = new ConcurrentBag<MethodInfo>();
                    InAction[visitorType] = new ConcurrentBag<MethodInfo>();
                    PostAction[visitorType] = new ConcurrentBag<MethodInfo>();
                }
            }
        }

        public static void Register(Assembly assembly)
        {
            lock (LockObject)
            {
                foreach (var visitorType in GetTypesWith<SyntaxNodeVisitorAttribute>(new[] { assembly }))
                {
                    var methodInfos = visitorType.GetMethods(BindingFlags.Public
                        | BindingFlags.Static);
                    foreach (var methodInfo in methodInfos)
                    {
                        foreach (var type in NodeTypes)
                        {
                            if (ContainsNodeTypeNoArg(type, methodInfo, nameof(PreAction)))
                            {
                                PreAction[type].Add(methodInfo);
                            }
                            else if (ContainsNodeType(type, methodInfo, nameof(InAction)))
                            {
                                InAction[type].Add(methodInfo);
                            }
                            else if (ContainsNodeTypeNoArg(type, methodInfo, nameof(PostAction)))
                            {
                                PostAction[type].Add(methodInfo);
                            }
                        }
                    }
                }
            }
        }

        public static void Visit(SyntaxNode node)
        {
            foreach (var methodInfo in PreAction[node.GetType()])
            {
                methodInfo.Invoke(null, null);
            }
            foreach (var methodInfo in InAction[node.GetType()])
            {
                methodInfo.Invoke(null, new[] { node });
            }
            foreach (var methodInfo in PostAction[node.GetType()])
            {
                methodInfo.Invoke(null, null);
            }
        }

        private static bool ContainsNodeType(Type type, MethodInfo methodInfo, string postfix)
        {
            return methodInfo.Name == $"{type.Name}{postfix}"
                && methodInfo.GetParameters().Count() == 1
                && type.Name == methodInfo.GetParameters()[0].ParameterType.Name;
        }
        private static bool ContainsNodeTypeNoArg(Type type, MethodInfo methodInfo, string postfix)
        {
            return methodInfo.Name == $"{type.Name}{postfix}"
                && methodInfo.GetParameters().Count() == 0;
        }

        private static IEnumerable<Type> GetTypesWith<TAttribute>(Assembly[] assemblies = null, bool inherit = false) where TAttribute : Attribute
        {
            return from assembly in (assemblies ?? AppDomain.CurrentDomain.GetAssemblies())
                   from types in assembly.GetTypes()
                   where types.IsDefined(typeof(TAttribute), inherit)
                   select types;
        }
    }
}
