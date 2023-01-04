@LoginActionUsingBackground
Feature: Login Action Using Background

This feature is about successful login on login page using valid credentials with background

Background: Print landing page
	Given User navigated on landing page
	Then Landing page should be displayed

Scenario: Successful Login with Valid Credentials
	Given User is on Login Page
	When User enters UserName and Password
	And Click Login
	Then Userlabel with UserName will be displayed
	
Scenario: II - Successful Login with Valid Credentials
    Given II - User is on Login Page
    When II - User enters "johnwick" and "Excommunicado123!"
    And II - Click Login
    Then II - Userlabel with "johnwick" will be displayed