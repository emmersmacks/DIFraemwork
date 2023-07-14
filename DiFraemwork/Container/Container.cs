using System.Reflection;
using DiFraemwork.Descriptors;

namespace DiFraemwork;

class Container : IContainer
{
    private class Scope : IScope
    {
        private readonly Container _container;
        
        public Scope(Container container)
        {
            _container = container;
        }

        public object Resolve(Type service) 
            => _container.CreateInstance(service, this);
    }

    private object CreateInstance(Type service, Scope scope)
    {
        if (!_descriptors.TryGetValue(service, out var descriptor))
            throw new InvalidOperationException();

        if (descriptor is InstanceBasedServiceDescriptor instanceDescriptor)
            return instanceDescriptor;
        if (descriptor is FactoryBasedServiceDescriptor factoryDescriptor)
            return factoryDescriptor.Factory(scope);

        var typeDescriptor = descriptor as TypeBasedServiceDescriptor;

        var constructors = service.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        if (constructors.Length == 0)
            return Activator.CreateInstance(typeDescriptor.ImplementationType);

        var constructor = constructors.Single();
        var args = constructor.GetParameters();
        var argsForConstructor = new object[args.Length];
        for (int i = 0; i < args.Length; i++)
        {
            argsForConstructor[i] = CreateInstance(args[i].ParameterType, scope);
        }

        return constructor.Invoke(argsForConstructor);
    }

    private Dictionary<Type, ServiceDescriptor> _descriptors;

    public Container(IEnumerable<ServiceDescriptor> descriptors)
    {
        _descriptors = descriptors.ToDictionary(x => x.ServiceType);
    }
    
    public IScope CreateScope()
    {
        return new Scope(this);
    }
}