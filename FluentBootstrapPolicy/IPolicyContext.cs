using System;

namespace FluentBootstrapPolicy
{
    public interface IPolicyContext
    {
        void Configure(Action<IConfigurationContext> configurator);
        void Bootstrap();
    }
}