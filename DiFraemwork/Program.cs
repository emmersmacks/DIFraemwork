
using DiFraemwork;

var builder = new ContainerBuilder();
var container = builder
        .RegisterSingleton<IService, Service>()
        .RegisterSingleton<IController, Controller>()
        .Build();
    
var scope = container.CreateScope();
var controller = scope.Resolve(typeof(IController));
Console.WriteLine(controller);