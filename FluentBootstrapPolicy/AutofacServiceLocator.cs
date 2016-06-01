using System;
using System.Collections.Generic;
using Autofac;

namespace FluentBootstrapPolicy
{
    public class AutofacServiceLocator : IServiceLocator
    {
        private readonly IContainer _container;

        /// <summary>
        ///     C'tor
        /// </summary>
        /// <param name="container">Autofac container instance</param>
        public AutofacServiceLocator(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// </summary>
        /// <param name="serviceType">Type to resolve.</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        /// <summary>
        /// </summary>
        /// <param name="serviceType">Type to resolve.</param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            var enumerableServiceType = typeof (IEnumerable<>).MakeGenericType(serviceType);
            var instance = _container.Resolve(enumerableServiceType);

            return (IEnumerable<object>) instance;
        }

        public IEnumerable<object> GetServicesByParameter(Type serviceType, Type type, object parameterInstance)
        {
            var enumerableServiceType = typeof (IEnumerable<>).MakeGenericType(serviceType);

            var instance = _container.Resolve(enumerableServiceType, new TypedParameter(type, parameterInstance));

            return (IEnumerable<object>) instance;
        }
    }
}