using System;

namespace FluentBootstrapPolicy.Tests
{
    public class MyAppPolicyConfiguration : AbstractPolicyConfiguration
    {
        public MyAppPolicyConfiguration(IDependeyResolverAdapter dependencyResolver)
            : base(dependencyResolver)
        {
            Check<ICurrencyProvider>(provider =>
            {
                Console.WriteLine("ICurrencyProvider");
                return false;
            });

            Check<IStorageClient>(provider =>
            {
                Console.WriteLine("IStorageClient");
                return true;
            });
        }
    }
}