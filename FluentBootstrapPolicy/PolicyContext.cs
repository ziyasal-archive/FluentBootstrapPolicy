using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FluentBootstrapPolicy
{
    public class PolicyContext : IPolicyContext, IConfigurationContext
    {
        private Assembly _assembly;
        private IDependeyResolverAdapter _dependeyResolver;
        private readonly IAssemblyScanner _assemblyScanner;
        static readonly Lazy<PolicyContext> LazyInstance = new Lazy<PolicyContext>(() => new PolicyContext(new DefaultAssemblyScanner()), true);

        public PolicyContext(IAssemblyScanner assemblyScanner)
        {
            _assemblyScanner = assemblyScanner;
        }

        public void Configure(Action<IConfigurationContext> configurator)
        {
            configurator(this);
        }

        public void Bootstrap()
        {
            IEnumerable<AbstractPolicyConfiguration> abstractPolicyConfigurations = ScanImpl();

            foreach (AbstractPolicyConfiguration policyConfiguration in abstractPolicyConfigurations)
            {
                policyConfiguration.Appyly();
            }
        }


        public static IPolicyContext Instance
        {
            get { return LazyInstance.Value; }
        }

        public void Use(IDependeyResolverAdapter dependeyResolverAdapter)
        {
            _dependeyResolver = dependeyResolverAdapter;
        }

        public void UseNlog()
        {

        }

        public void Scan(Assembly assembly)
        {
            _assembly = assembly;
        }

        private IEnumerable<AbstractPolicyConfiguration> ScanImpl()
        {
            IEnumerable<AbstractPolicyConfiguration> configurations = _dependeyResolver
                .GetServicesByParameter(typeof(AbstractPolicyConfiguration), typeof(IDependeyResolverAdapter), _dependeyResolver)
                as IEnumerable<AbstractPolicyConfiguration>;

            return configurations;
        }
    }
}