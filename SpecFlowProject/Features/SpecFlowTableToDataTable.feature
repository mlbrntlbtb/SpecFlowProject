@LoginActionWithTableToDataTable
Feature: V - Login Action With Table To DataTable

This feature is about successful login on login page using valid credentials with table to data table (Horizontal format)

Scenario: V - Successful Login with Valid Credentials
	Given V - User is on Login Page
	When V - User enters UserName and Password
	| Username | Password          |
	| johnwick | Excommunicado123! |
	And V - Click Login
	Then V - Userlabel with UserName will be displayed
	| Username |
	| johnwick |