namespace DiFraemwork;

//contained dependency information
public abstract class ServiceDescriptor
{
    public Type ServiceType { get; set; }
    public Lifetime Lifetime { get; set; }
}