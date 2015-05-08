using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentBootstrapPolicy
{
    public class DefaultAssemblyScanner : IAssemblyScanner
    {
        public IEnumerable<AbstractPolicyConfiguration> Scan(Assembly assembly)
        {
            IEnumerable<Type> types = assembly.DefinedTypes.Where(info => typeof(AbstractPolicyConfiguration).IsAssignableFrom(info)).Select(info => info.AsType());

            return types.Select(type => Activator.CreateInstance(type) as AbstractPolicyConfiguration);
        }
    }
}