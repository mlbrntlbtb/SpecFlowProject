@LoginActionWithTableToDictionary
Feature: IV - Login Action With Table To Dictionary

This feature is about successful login on login page using valid credentials with table to dictionary (Vertical format)

Scenario: IV - Successful Login with Valid Credentials
	Given IV - User is on Login Page
	When IV - User enters UserName and Password
	| Key      | Value             |
	| Username | johnwick          |
	| Password | Excommunicado123! |
	And IV - Click Login
	Then IV - Userlabel with UserName will be displayed
	| Key      | Value    |
	| Username | johnwick |