# Dependency Injection
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


# Dependency Injection into Controller(MVC): -
  Asp.Net Core MVC controller request dependencies explicitly via constructors
    1. Constructor Injection
    2. Method Injection (Action level)
    3. Propery Injection (not supported)
    4. View Injection
    
 1. Constructor Injection: -
 Services are added as a constructor parameter and runtime resolve the service from the service container (IServiceCollection-- DiContainer). Servicesa are typically defined  using non-concrete class (interfaces)
 
 2. Method Injection : -
 Using [FromService] attribute enables injecting service directly into an action method without using controller injection
 
 3. Property Injection
 Currently(Asp.net core) bulit-in IOC container doesn't support property injection.For this you might go for third-party built-in service containers (IOC).
 
 4. View Injection
  Using [Inject] directive enables injecting service directly into view page without using controller or method injection
  
  
# Service Lifetime
The built-in IOC container support three kinds of lifetime:
1. Singleton:  
    1. Singleton lifetime services(State service) are created the first time they're requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the "same instance", through out the application lifetime
    2. Core provides you bulit-in extension methods 
        1. Add() 
        2. AddSingleton()
2. Transisent :  
    1. Transient lifetime services are created each time they're requested. This lifetime works best for
lightweight, "stateless services".
    2. Core provides you bulit-in extension methods 
        1. Add() with (ServiceLifetime.Transient)
        2. AddTransient()    
3. Scoped : 
    1. Scoped lifetime services are created once per request and will be shared in a single request.
    2. Core provides you bulit-in extension methods 
        1. Add() with (ServiceLifetime.Scoped)
        2. AddScoped()  
        3. AddDBContext()
  
  
# Registering Simple Application Service

In the sample example, "IMyDependency" service interface defines "WriteMessage" method

      public interface IMyDependency
      {
          void WriteMessage(string message);
      }

This interface is implemented by a concrete type, MyDependency:

      public class MyDependency : IMyDependency
      {
          public void WriteMessage(string message)
          {
              Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
          }
      }

Now, Registers the "IMyDependency" service with the concrete type "MyDependency" (in startup.cs)

      public class Startup
      {
          public void ConfigureServices(IServiceCollection services)
          {
              services.Add(new ServiceDescriptor(typeof(IMyDependency), new MyDependency()));        
          }

      }

Here Add() method of "IServiceCollection" instance is used to register a service with an IoC container. The "ServiceDescriptor" is used to specify the type of service and concrete implementation. This will register our service in container with default as "Singleton"

Now, let's inject services with different life times
1. Singleton (Use case : when we need to create state service) :

    services.Add(new ServiceDescriptor(typeof(IMyDependency), new MyDependency()));//default life time is Singleton
    
                                                          or 
                                                          
    services.Add(new ServiceDescriptor(typeof(IMyDependency), new MyDependency(),ServiceLifetime.Singleton));
    
 2. Transisent (Use case : when we need to create stateless service):    
 
     services.Add(new ServiceDescriptor(typeof(IMyDependency), new MyDependency(),ServiceLifetime.Transient));
  
 3. Scoped  (Use case : Database service):   
 
      services.Add(new ServiceDescriptor(typeof(IMyDependency), new MyDependency(),ServiceLifetime.Scoped));
 
 When can also inject the services using bulit-in extension methods
 
 1. Singleton
 
       services.AddSingleton<IMyDependency, MyDependency>();
                         or
       services.AddSingleton(typeof(IMyDependency), typeof(MyDependency));      
       
  2. Transisent
  
       services.AddTransisent<IMyDependency, MyDependency>();
                         or
       services.AddTransisent(typeof(IMyDependency), typeof(MyDependency));
       
   3. Scoped    
   
       services.AddScoped<IMyDependency, MyDependency>();
                         or
       services.AddScoped(typeof(IMyDependency), typeof(MyDependency)); 
       
  # Example with Constructor Injection
  
  public class HomeController : Controller
  {
    private readonly IMyDependency _service;

    public HomeController(IMyDependency service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        _service.WriteMessage("Constructor level injection")
       
        return View();
    }
  }
  
  # Example With Action Injection
  
    public class HomeController : Controller
    {
      //Fromservice attribute
      public IActionResult Index([FromService]IMyDependency service)
      {
          service.WriteMessage("Action level injection")
          return View();
      }
    }
  
  # Example With View Injection 
  
   public class HomeController : Controller
  {
   
    public IActionResult Index()
    {
        return View();
    }
  }
  
  In Index.cshtml
  
   @{
    ViewData["Title"] = "Home Page";
    }
    
    //using Inject directive
    
    @inject IMyDependency service
    
    //code block
    @{
      service.WriteMessage("View level Injection");
    }
  

