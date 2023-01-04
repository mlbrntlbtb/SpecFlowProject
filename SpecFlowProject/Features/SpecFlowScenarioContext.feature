@SharingDataUsingScenarioContext
Feature: Sharing data using Scenario Context

This feature is for sharing data or state from a binding class to another binding class using scenario context

@SampleTag
Scenario Outline: II - Storing username and password 

This is a sample description

	Given II - <username> and <password> are declared
	And Scenario context functionalities are displayed
	Then II - Username and Password are displayed
	
	Examples:
	| username   | password           |
	| 'johnwick' | 'Excommunicado123' |