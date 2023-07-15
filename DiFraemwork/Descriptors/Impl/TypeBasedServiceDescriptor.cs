using System;

namespace DiFraemwork.Descriptors
{
    public class TypeBasedServiceDescriptor : ServiceDescriptor
    {
        public Type ImplementationType { get; set; }
    }
}

