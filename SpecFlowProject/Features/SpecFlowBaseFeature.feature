@LoginAction
Feature: Login Action

This feature is about successful login on login page using valid credentials

Scenario: Successful Login with Valid Credentials
	Given User is on Login Page
	When User enters UserName and Password
	And Click Login
	Then Userlabel with UserName will be displayed
	