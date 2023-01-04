@LoginActionParameterWithExample
Feature: III - Login Action With Parameter With Example

This feature is about successful login on login page using valid credentials using parameters with example

Scenario Outline: III - Successful Login with Valid Credentials
    Given III - User is on Login Page
    When III - User enters <username> and <password>
    And III - Click Login
    Then III - Userlabel with <username> will be displayed

Examples: 
    | username      | password            |
    | 'johnwick'    | 'Excommunicado123!' |
    | 'tonystark'   | 'Ironman123!'       |
