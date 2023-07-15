using System;

public interface IScope 
{
    object Resolve(Type service);
}