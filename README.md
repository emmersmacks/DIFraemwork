## Dependency Injection Framework in C#

Implementation of a Dependency Injection (DI) framework for educational purposes. This project should be considered as my understanding of how DI works, rather than a standalone project.

## Let's get started!
Example of service registration:

```csharp
var builder = new ContainerBuilder();
var container = builder
        .RegisterSingleton<IService, Service>()
        .RegisterSingleton<IController, Controller>()
        .Build();
    
var scope = container.CreateScope();
var controller = scope.Resolve(typeof(IController));
```

## Methods
* **RegisterSingleton** - registers an object as a Singleton. This means that the instance of the object will be shared across the entire application.

* **RegisterTransient (under development)** - registers an object as a transient object. This means that the instance of the object will be created individually for each request and will not be stored in the container.

* **RegisterScoped (under development)** - registers an object specifically for the current scope.

Written thanks to the tutorial: https://www.youtube.com/watch?v=dCkYP03lXOs&t=1919s
