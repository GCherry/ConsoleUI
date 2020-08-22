using ConsoleUI.Interfaces;
using ConsoleUI.Test.Context;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [Given(@"you have the following numbers:")]
        public void GivenYouHaveTheFollowingNumbers(Table table)
        {
            var numbers = table.CreateInstance<Numbers>();

            _computationContext.NumberOne = numbers.FirstNumber;
            _computationContext.NumberTwo = numbers.SecondNumber;

        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _computationContext.Answer = _computationService.SubtractTwoNumbers(_computationContext.NumberOne, _computationContext.NumberTwo);
        }


        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //Assert.AreEqual(result, _scenarioContext["additionCalculation"]);
            //Assert.AreEqual(result, _computationContext.Answer);
            _computationContext.Answer
                .Should()
                .Be(result, $"Because this is what we asked it to be when using the numbers { _computationContext.NumberOne} and { _computationContext.NumberTwo}");
        }

        [Then(@"the result should not be (.*)")]
        public void ThenTheResultShouldNotBe(int result)
        {
            _computationContext.Answer
                .Should()
                .NotBe(result, $"The answer should not be {_computationContext.Answer} when using the numbers { _computationContext.NumberOne} and { _computationContext.NumberTwo}");
        }

    }

    public class Numbers
    {
        public double FirstNumber { get; set;}
        public double SecondNumber { get; set; }
    }
}
