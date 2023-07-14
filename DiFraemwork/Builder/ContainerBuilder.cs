namespace DiFraemwork;

public class ContainerBuilder : IContainerBuilder
{
    private readonly List<ServiceDescriptor> _descriptors = new List<ServiceDescriptor>();
    
    public void Register(ServiceDescriptor descriptor)
    {
        _descriptors.Add(descriptor);
    }

    public IContainer Build()
    {
        return new Container(_descriptors);
    }
}