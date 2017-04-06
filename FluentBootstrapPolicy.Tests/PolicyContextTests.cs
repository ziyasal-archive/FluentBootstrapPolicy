using System;
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

            _policyContext = PolicyContext.Instance;

            _policyContext.Configure(x =>
            {
                var builder = new ContainerBuilder();

                builder.RegisterModule<TestModule>();

                var container = builder.Build();
                x.Use(new AutofacServiceLocator(container))
                 .UseNlog();

            });
        }

        [Test]
        public void Start_Test()
        {
            Assert.Throws<Exception>(() => _policyContext.Execute());
        }
    }
}