using ConsoleUI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;


namespace ConsoleUI.Services
{
    public class ComputationService : IComputationService
    {
        private readonly ILogger<GreetingService> _log;
        private readonly IConfiguration _config;

        public ComputationService(ILogger<GreetingService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void SampleLog()
        {
            _log.LogWarning("Warning from my Computation Service");
        }

        public double AddTwoNumbers(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }

        public double SubtractTwoNumbers(double numberOne, double numberTwo)
        {
            return numberOne - numberTwo;
        }
    }
}
