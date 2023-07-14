namespace DiFraemwork.Descriptors;

public class FactoryBasedServiceDescriptor : ServiceDescriptor
{
    public Func<IScope, object> Factory { get; set; }
}