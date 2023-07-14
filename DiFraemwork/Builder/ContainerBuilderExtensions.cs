using DiFraemwork.Descriptors;

namespace DiFraemwork;

public static class ContainerBuilderExtensions
{
    private static IContainerBuilder RegisterType(this IContainerBuilder builder, Type service, Type implementation, Lifetime lifetime)
    {
        var descriptor = new TypeBasedServiceDescriptor()
        { 
            ImplementationType = implementation, 
            Lifetime = lifetime,
            ServiceType = service 
        };
        builder.Register(descriptor);
        return builder;
    }

    private static IContainerBuilder RegisterFactory(this IContainerBuilder builder, Type type,
        Func<IScope, object> factory, Lifetime lifetime)
    {
        var descriptor = new FactoryBasedServiceDescriptor()
        {
            Factory = factory,
            Lifetime = lifetime,
            ServiceType = type
        };
        builder.Register(descriptor);
        return builder;
    }

    private static IContainerBuilder RegisterInstance(this IContainerBuilder builder, Type type, object instance)
    {
        var descriptor = new InstanceBasedServiceDescriptor(type, instance);
        builder.Register(descriptor);
        return builder;
    }

    #region ByType

    public static IContainerBuilder RegisterSingleton(
        this IContainerBuilder builder,
        Type @serviceInterface,
        Type serviceImplementation)
        => builder.RegisterType(serviceInterface, serviceImplementation, Lifetime.Singleton);

    public static IContainerBuilder RegisterTransient(
        this IContainerBuilder builder,
        Type @serviceInterface,
        Type serviceImplementation)
        => builder.RegisterType(serviceInterface, serviceImplementation, Lifetime.Transient);
    
    public static IContainerBuilder RegisterScoped(
        this IContainerBuilder builder,
        Type @serviceInterface,
        Type serviceImplementation)
        => builder.RegisterType(serviceInterface, serviceImplementation, Lifetime.Scoped);

    #endregion
    
    #region ByTypeGeneric

    public static IContainerBuilder RegisterSingleton<TInterface, TImplementation>(
        this IContainerBuilder builder) 
        => builder.RegisterType(typeof(TInterface), typeof(TImplementation), Lifetime.Singleton);
    
    public static IContainerBuilder RegisterTransient<TInterface, TImplementation>(
        this IContainerBuilder builder) 
        => builder.RegisterType(typeof(TInterface), typeof(TImplementation), Lifetime.Transient);
    
    public static IContainerBuilder RegisterScoped<TInterface, TImplementation>(
        this IContainerBuilder builder) 
        => builder.RegisterType(typeof(TInterface), typeof(TImplementation), Lifetime.Scoped);

    #endregion

    #region ByFunc
    
    public static IContainerBuilder RegisterSingleton(this IContainerBuilder builder, Type type, Func<IScope, object> function)
        => builder.RegisterFactory(type, function, Lifetime.Singleton);

    public static IContainerBuilder RegisterTransient(this IContainerBuilder builder, Type type, Func<IScope, object> function)
        => builder.RegisterFactory(type, function, Lifetime.Transient);
    
    public static IContainerBuilder RegisterScoped(this IContainerBuilder builder, Type type, Func<IScope, object> function)
        => builder.RegisterFactory(type, function, Lifetime.Scoped);

    #endregion
    
    #region ByFuncGeneric
    
    public static IContainerBuilder RegisterSingleton<T>(this IContainerBuilder builder, Func<IScope, object> function)
        => builder.RegisterFactory(typeof(T), function, Lifetime.Singleton);

    public static IContainerBuilder RegisterTransient<T>(this IContainerBuilder builder, Func<IScope, object> function)
        => builder.RegisterFactory(typeof(T), function, Lifetime.Transient);
    
    public static IContainerBuilder RegisterScoped<T>(this IContainerBuilder builder, Func<IScope, object> function)
        => builder.RegisterFactory(typeof(T), function, Lifetime.Scoped);

    #endregion
    
    #region ByInstance

    public static IContainerBuilder RegisterSingleton(
        this IContainerBuilder builder,
        Type type, object instance)
        => builder.RegisterInstance(type, instance);

    public static IContainerBuilder RegisterSingleton<T>(
        this IContainerBuilder builder,
        object instance)
        => builder.RegisterInstance(typeof(T), instance);

    #endregion
}