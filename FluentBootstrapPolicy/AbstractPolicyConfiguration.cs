using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FluentBootstrapPolicy
{
    public abstract class AbstractPolicyConfiguration
    {
        private readonly IDependeyResolverAdapter _dependencyResolver;

        protected AbstractPolicyConfiguration(IDependeyResolverAdapter dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        protected ConcurrentDictionary<string, Func<bool>> ConcurrentDictionary = new ConcurrentDictionary<string, Func<bool>>();

        protected void Check<T>(Func<T, bool> policyFunc)
        {
            Func<bool> func = () => policyFunc((T)_dependencyResolver.GetService(typeof(T)));

            ConcurrentDictionary.TryAdd(typeof(T).FullName, func);
        }

        public void Appyly()
        {
            foreach (KeyValuePair<string, Func<bool>> pair in ConcurrentDictionary)
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