@Computation
Feature: Computation

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given you have the following numbers:
	| FirstNumber | SecondNumber |
	| 10          | 6            |
	When the two numbers are subtracted
	Then the result should be 4

Scenario Outline: Add two numbers a bunch of times
	Given the first number is <FirstNumber>
	And the second number is <SecondNumber>
	When the two numbers are added
	Then the result should be <Result>

	Examples:
	| FirstNumber | SecondNumber | Result |
	| 2           | 2            | 4      |
	| 20          | 5            | 25     |
	| 200         | 50           | 250    |

Scenario: Add two numbers but return the wrong answer
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should not be 400