using System;

namespace FluentBootstrapPolicy.Tests
{
    public class MyAppPolicyConfiguration : AbstractPolicyConfiguration
    {
        public MyAppPolicyConfiguration(IServiceLocator serviceLocator)
            : base(serviceLocator)
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