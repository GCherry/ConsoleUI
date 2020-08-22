using ConsoleUI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleUI.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger<GreetingService> _log;
        private readonly IConfiguration _config;
        private readonly IComputationService _computationService;

        public GreetingService(ILogger<GreetingService> log, IConfiguration config, IComputationService computationService)
        {
            _log = log;
            _config = config;
            _computationService = computationService;
        }

        public void Run()
        {
            var loopTimes = _config.GetValue<int>("LoopTimes");
            for (int i = 0; i < loopTimes; i++)
            {
                _log.LogInformation("Run number {runNumber}", i);
            }

            _log.LogError("This is a log ERROR");
            _log.LogWarning("This is a log WARNING");

            _computationService.SampleLog();

            _log.LogInformation(_computationService.AddTwoNumbers(4,6).ToString());
            _log.LogInformation(_computationService.SubtractTwoNumbers(10,6).ToString());

            Log.CloseAndFlush();
        }
    }
}
