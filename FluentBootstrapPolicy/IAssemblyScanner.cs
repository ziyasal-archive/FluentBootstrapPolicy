using System.Collections.Generic;
using System.Reflection;

namespace FluentBootstrapPolicy
{
    public interface IAssemblyScanner
    {
        IEnumerable<AbstractPolicyConfiguration> Scan(Assembly assembly);
    }
}