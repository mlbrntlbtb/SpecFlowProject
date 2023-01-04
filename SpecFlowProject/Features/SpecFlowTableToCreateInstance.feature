@LoginActionWithTableToCreateInstance
Feature: VI - Login Action With Table To CreateInstance

This feature is about successful login on login page using valid credentials with table to create instance (Vertical format)

Scenario: VI - Successful Login with Valid Credentials
	Given VI - User is on Login Page
	When VI - User enters UserName and Password
	| Field      | Value             |
	| Username | johnwick          |
	| Password | Excommunicado123! |
	And VI - Click Login
	Then VI - Userlabel with UserName will be displayed
	| Field      | Value    |
	| Username | johnwick |