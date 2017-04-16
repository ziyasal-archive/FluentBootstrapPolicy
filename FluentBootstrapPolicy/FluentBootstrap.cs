using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentBootstrapPolicy
{
    public class FluentBootstrap : IFluentBootstrap, IConfigurationContext
    {
        private static readonly Lazy<FluentBootstrap> LazyInstance =
            new Lazy<FluentBootstrap>(() => new FluentBootstrap(), true);

        private IServiceLocator _dependeyResolver;


        public static IFluentBootstrap Instance => LazyInstance.Value;

        public IUseNlog Use(IServiceLocator serviceLocator)
        {
            _dependeyResolver = serviceLocator;
            return this;
        }

        public void UseNlog()
        {

        }

        public void Scan(Assembly assembly)
        {
        }

        public void Configure(Action<IConfigurationContext> configurator)
        {
            configurator(this);
        }

        public void Execute()
        {
            var abstractPolicyConfigurations = ScanImpl();

            foreach (var policyConfiguration in abstractPolicyConfigurations)
            {
                policyConfiguration.Appyly();
            }
        }

        private IEnumerable<AbstractPolicyConfiguration> ScanImpl()
        {
            var configurations = _dependeyResolver
                .GetServicesByParameter(typeof(AbstractPolicyConfiguration), typeof(IServiceLocator),
                    _dependeyResolver)
                as IEnumerable<AbstractPolicyConfiguration>;

            return configurations;
        }
    }
}