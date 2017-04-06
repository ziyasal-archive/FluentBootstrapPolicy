# FluentBootstrapPolicy

Execute pre-checks before running your application!

[![Build status](https://ci.appveyor.com/api/projects/status/5erlwhdxa78grl83?svg=true)](https://ci.appveyor.com/project/ziyasal/fluentbootstrappolicy)

**Define policy**
```csharp
public class MyAppPolicyConfiguration : AbstractPolicyConfiguration
{
    public MyAppPolicyConfiguration(IServiceLocator serviceLocator)
        : base(serviceLocator)
    {
        Check<ICurrencyProvider>(provider =>
        {
           //do sth
            return false;
        });

        Check<IStorageClient>(client =>
        {
            return client.CheckAccessControl();
        });
    }
}
```

**Init policy context**
```csharp
IPolicyContext _policyContext;

ContainerBuilder builder = new ContainerBuilder();

builder.RegisterType<StorageClient>().As<IStorageClient>().SingleInstance();
builder.RegisterType<CurrencyProvider>().As<ICurrencyProvider>().SingleInstance();
builder
       .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
       .AssignableTo<AbstractPolicyConfiguration>()
       .As<AbstractPolicyConfiguration>();
                
var container = builder.Build();
_policies = PolicyContext.Instance;

_policies.Configure(x =>
{
    x.Use(new AutofacServiceLocator(container));
});
```

**Run policies**
```csharp
  _policies.Execute();
```
