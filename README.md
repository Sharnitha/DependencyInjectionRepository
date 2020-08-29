# DependencyInjectionRepository
Sample Example using Asp.net core 

ASP.NET Core supports the dependency injection (DI) software design pattern, which is a technique for achieving Inversion of Control (IoC) between classes and their dependencies.

Through IOC container, we will achieve 
  1. loosely coupled class
  2. Manages lifetime of object
  3. injects dependencies to the class
  4. Easy to change the implementation
  5. Test driven development (TDD)
  
The following DI Lifecycle will be  
  1. Register:- 
      1. The Container Must know which type of object/dependency should instantiate. 
      2. In Asp.net core, services are registered using "IServiceCollection" (built in service container)
      3. this services are typically registered in the app's "Startup.ConfigureServices" method.
  2. Resolve:- 
      1. When using IOC container, we don't create objects manually, Container do for us.
      2. In Asp.net core, the framework takes on the responsibility of creating an instance of the dependency with support of built-in container(IServiceCollection)
  3. Dispose:- The lifetime of object/dependecy will be taken care by IOC container only

There are basically two types of services in ASP.NET Core:

Framework Services: Services which are a part of ASP.NET Core framework such as IApplicationBuilder, IHostingEnvironment, ILoggerFactory etc.
Application Services: The services (custom types or classes) which you as a programmer create for your application.


Depedency Injection into Controller(MVC): -
  Asp.Net Core MVC controller request dependencies explicitly via constructors
    1. Constructor Injection
    2. Method level injection
    3. Propery level Injection (not supported)
    4. View level injection
    
 1. Constructor Injection: -
 Services are added as a constructor parameter and runtime resolve the service from the service container (IServiceCollection-- DiContainer). Servicesa are typically defined  using non-concrete class (interfaces)


