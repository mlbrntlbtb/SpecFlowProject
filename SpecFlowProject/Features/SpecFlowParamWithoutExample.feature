@LoginActionParameterWithoutExample
Feature: II - Login Action With Parameter Without Example

This feature is about successful login on login page using valid credentials using parameters without example

Scenario: II - Successful Login with Valid Credentials
    Given II - User is on Login Page
    When II - User enters "johnwick" and "Excommunicado123!"
    And II - Click Login
    Then II - Userlabel with "johnwick" will be displayed
