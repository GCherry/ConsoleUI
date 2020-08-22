using BoDi;
using ConsoleUI.Interfaces;
using ConsoleUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow;

namespace ConsoleUI.Test.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            var log = new Mock<ILogger<GreetingService>>();
            var config = new Mock<IConfiguration>();

            IComputationService computationService = new ComputationService(log.Object, config.Object);
            _container.RegisterInstanceAs(computationService);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
