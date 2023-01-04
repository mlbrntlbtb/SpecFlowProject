using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SharingDataUsingScenarioContextSet
    {
        private readonly ScenarioContext scenarioContext;
        public SharingDataUsingScenarioContextSet(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"II - '([^']*)' and '([^']*)' are declared")]
        public void GivenII_AndAreDeclared(string username, string password)
        {
            Console.WriteLine("Storing Username: [{0}] and Password: [{1}]", username, password);
            scenarioContext.Add("Username", username);
            scenarioContext.Add("Password", password);
        }


        [Given(@"Scenario context functionalities are displayed")]
        public void GivenScenarioContextFunctionalitiesAreDisplayed()
        {
            Console.WriteLine("Title: [{0}]", scenarioContext.ScenarioInfo.Title);
            Console.WriteLine("Description: [{0}]", scenarioContext.ScenarioInfo.Description);
            Console.WriteLine("Tags: [{0}]", scenarioContext.ScenarioInfo.Tags);
            Console.WriteLine("Argument Example - Username: [{0}]", scenarioContext.ScenarioInfo.Arguments["username"]);
            Console.WriteLine("Argument Example - Password: [{0}]", scenarioContext.ScenarioInfo.Arguments["password"]);
        }

    }
}
