using System.Runtime.CompilerServices;
using VContainer;

namespace Castle.DynamicProxy {
    public static class ContainerBuilderExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RegistrationBuilder RegisterInterceptor<TInterface, TImplement, TInterceptor>(
            this IContainerBuilder builder,
            Lifetime lifetime)
            where TInterface : class
            where TImplement : class, TInterface
            where TInterceptor : class, IInterceptor {
            builder.TryRegister(_ => new ModuleScope(), Lifetime.Transient);
            builder.TryRegister<IProxyBuilder, DefaultProxyBuilder>(Lifetime.Transient);
            builder.TryRegister<ProxyGenerator>(Lifetime.Singleton);
            builder.TryRegister<TInterceptor>(Lifetime.Transient);
            builder.TryRegister<TImplement>(lifetime);
            return builder.Register(resolver => {
                var proxyGenerator = resolver.Resolve<ProxyGenerator>();
                var implement = resolver.Resolve<TImplement>();
                var interceptor = resolver.Resolve<TInterceptor>();
                return proxyGenerator.CreateInterfaceProxyWithTarget((TInterface)implement, interceptor);
            }, lifetime);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterInterceptor<TInterface, TImplement, TInterceptor>(
            this IContainerBuilder builder,
            Lifetime lifetime)
            where TInterface : class
            where TImplement : class, TInterface
            where TInterceptor : class, IInterceptor {
            if (builder.Exists(typeof(TInterface))) return false;
            builder.RegisterInterceptor<TInterface, TImplement, TInterceptor>(lifetime);
            return true;
        }
    }
}
