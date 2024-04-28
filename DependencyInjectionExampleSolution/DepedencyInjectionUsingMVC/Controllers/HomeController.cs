using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DepedencyInjectionUsingMVC.Models;
using DepedencyInjectionUsingMVC.Service;

namespace DepedencyInjectionUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
namespace DepedencyInjectionUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly IMyDependency _dependencyService;

        //controller-base Injection
        //public HomeController(ILogger<HomeController> logger,IMyDependency myDependency)
        //{
        //    _logger = logger;
        //    _dependencyService = myDependency;
        //}


        public HomeController(ILogger<HomeController> logger)
        {
             _logger = logger;
        }
        //using constructor injection
        //public IActionResult Index()
        //{
        //    _dependencyService.WriteMessage("this from Index action method");
        //    return View();
        //}

        ////method level injection
        //public IActionResult Index([FromServices]IMyDependency dependencyService)
        //{
        //    dependencyService.WriteMessage("this from Index action method");
        //    return View();
        //}

        //View level injection
        //public IActionResult Index()
        //{
        //    return View();
        //}


        //without injection, accessing dependent services
        public IActionResult Index()
        {
            var services = HttpContext.RequestServices;
            var dependencyservice = (IMyDependency)services.GetService(typeof(IMyDependency));
            dependencyservice.WriteMessage("without injection, accessing dependent services");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
