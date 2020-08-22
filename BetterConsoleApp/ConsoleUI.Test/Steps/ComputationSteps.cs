using ConsoleUI.Interfaces;
using ConsoleUI.Test.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ConsoleUI.Test.Steps
{
    [Binding]
    public class ComputationSteps
    {
        private readonly IComputationService _computationService;
        private readonly ScenarioContext _scenarioContext;
        private readonly ComputationContext _computationContext;

        public ComputationSteps(ScenarioContext scenarioContext, ComputationContext computationContext, IComputationService computationService)
        {
            _computationService = computationService;
            _scenarioContext = scenarioContext;
            _computationContext = computationContext;
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(double numberOne)
        {
            _scenarioContext.Add("numberOne", numberOne);
            _computationContext.NumberOne = numberOne;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(double numberTwo)
        {
            _scenarioContext.Add("numberTwo", numberTwo);
            _computationContext.NumberTwo = numberTwo;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //var numberOne = (double)_scenarioContext["numberOne"];
            //var numberTwo = (double)_scenarioContext["numberTwo"];
            //_scenarioContext.Add("additionCalculation", _computationService.AddTwoNumbers(numberOne, numberTwo));

            var numberOne = _computationContext.NumberOne;
            var numberTwo = _computationContext.NumberTwo;

            _computationContext.Answer = _computationService.AddTwoNumbers(numberOne, numberTwo);            
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //Assert.AreEqual(result, _scenarioContext["additionCalculation"]);
            //Assert.AreEqual(result, 15);
            Assert.AreEqual(result, _computationContext.Answer);
            

        }
    }
}
