@SharingDataUsingContextInjection
Feature: Sharing data using Context Injection

This feature is for sharing data from a binding class to another binding class using context injection

Scenario: Storing username and password 
	Given "johnwick" and "Excommunicado123!" are declared
	Then Username and Password are displayed
