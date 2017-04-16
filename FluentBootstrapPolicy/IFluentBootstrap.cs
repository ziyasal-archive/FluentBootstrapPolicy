using System;

namespace FluentBootstrapPolicy
{
    public interface IFluentBootstrap
    {
        void Configure(Action<IConfigurationContext> configurator);
        void Execute();
    }
}