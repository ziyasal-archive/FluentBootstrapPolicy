using System;
using Autofac;
using Common.Testing.NUnit;
using NUnit.Framework;

namespace FluentBootstrapPolicy.Tests
{
    public class FluentBootstrapTests : TestBase
    {
        private IFluentBootstrap _fluentBootstrap;

        protected override void FinalizeSetUp()
        {

            _fluentBootstrap = FluentBootstrap.Instance;

            _fluentBootstrap.Configure(context =>
            {
                var builder = new ContainerBuilder();

                builder.RegisterModule<TestModule>();

                var container = builder.Build();
                context
                    .Use(new AutofacServiceLocator(container))
                    .UseNlog();

            });
        }

        [Test]
        public void Start_Test()
        {
            Assert.Throws<Exception>(() => _fluentBootstrap.Execute());
        }
    }
}