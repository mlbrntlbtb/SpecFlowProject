@LoginActionWithTableToCreateSet
Feature: VII - Login Action With Table To CreateSet

This feature is about successful login on login page using valid credentials with table to create set(Horizontal format)

Scenario: VII - Successful Login with Valid Credentials
	Given VII - User is on Login Page
	When VII - User enters UserName and Password
	| Username | Password          |
	| johnwick | Excommunicado123! |
	And VII - Click Login
	Then VII - Userlabel with UserName will be displayed
	| Username |
	| johnwick |