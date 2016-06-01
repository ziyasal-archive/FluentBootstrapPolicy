using System;
using System.Collections.Generic;

namespace FluentBootstrapPolicy
{
    public interface IServiceLocator
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
        IEnumerable<object> GetServicesByParameter(Type serviceType, Type type, object parameterInstance);
    }
}