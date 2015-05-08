using Autofac;
using Common.Testing.NUnit;
using NUnit.Framework;

namespace FluentBootstrapPolicy.Tests
{
    public class PolicyContextTests : TestBase
    {
        private IPolicyContext _policyContext;
        protected override void FinalizeSetUp()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<TestModule>();

            var container = builder.Build();
            _policyContext = PolicyContext.Instance;

            _policyContext.Configure(x =>
             {
                 x.Use(new AutofacDependeyResolverAdapter(container));
             });
        }

        [Test]
        public void Start_Test()
        {
            _policyContext.Bootstrap();
        }
    }
}
