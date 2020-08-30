using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DepedencyInjectionUsingMVC.Service
{

    public interface IMyDependency
    {
        void WriteMessage(string message);
    }

    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage called. Message: {message}");
        }
    }



    public class LoggerDependencyService : IMyDependency, IDisposable
    {
        ILogger<LoggerDependencyService> _logger;
        public LoggerDependencyService(ILogger<LoggerDependencyService> logger)
        {
            _logger = logger;
            _logger.LogInformation("Instance Create by IOC");
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposed by IOC");
        }

        public void WriteMessage(string message)
        {
            //logger Service
            _logger.LogInformation(message);
        }
    }

}
