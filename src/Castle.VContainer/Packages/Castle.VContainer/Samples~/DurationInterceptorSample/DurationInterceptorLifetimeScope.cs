using VContainer;
using VContainer.Unity;

namespace Castle.DynamicProxy.DurationInterceptorSample {
    public class DurationInterceptorLifetimeScope : LifetimeScope {
        protected override void Configure(IContainerBuilder builder) =>
            builder.RegisterInterceptor<IGreetService, GreetService, DurationInterceptor>(Lifetime.Singleton);
    }
}
