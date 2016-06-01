using System;
using System.Collections.Concurrent;

namespace FluentBootstrapPolicy
{
    public abstract class AbstractPolicyConfiguration
    {
        private readonly IServiceLocator _dependencyResolver;

        protected ConcurrentDictionary<string, Func<bool>> ConcurrentDictionary =
            new ConcurrentDictionary<string, Func<bool>>();

        protected AbstractPolicyConfiguration(IServiceLocator dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        protected void Check<T>(Func<T, bool> policyFunc)
        {
            Func<bool> func = () => policyFunc((T) _dependencyResolver.GetService(typeof (T)));

            ConcurrentDictionary.TryAdd(typeof (T).FullName, func);
        }

        public void Appyly()
        {
            foreach (var pair in ConcurrentDictionary)
            {
                try
                {
                    var result = pair.Value();
                    if (!result)
                    {
                        throw new Exception("Policy :(");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}