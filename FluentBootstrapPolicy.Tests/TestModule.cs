using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace FluentBootstrapPolicy.Tests
{
    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StorageClient>().As<IStorageClient>().SingleInstance();
            builder.RegisterType<CurrencyProvider>().As<ICurrencyProvider>().SingleInstance();
            //builder.RegisterType<AutofacDependeyResolverAdapter>().As<IDependeyResolverAdapter>().SingleInstance();

            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<AbstractPolicyConfiguration>()
                .As<AbstractPolicyConfiguration>();
        }
    }
}