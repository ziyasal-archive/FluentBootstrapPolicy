using System.Reflection;

namespace FluentBootstrapPolicy
{
    public interface IConfigurationContext
    {
        void Use(IDependeyResolverAdapter dependeyResolverAdapter);
        void UseNlog();
        void Scan(Assembly assembly);
    }
}