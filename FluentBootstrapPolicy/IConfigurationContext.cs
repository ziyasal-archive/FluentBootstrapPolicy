using System.Reflection;

namespace FluentBootstrapPolicy
{
    public interface IConfigurationContext : IUseNlog
    {
        IUseNlog Use(IServiceLocator serviceLocator);
        void Scan(Assembly assembly);
    }

    public interface IUseNlog
    {
        void UseNlog();
    }
}