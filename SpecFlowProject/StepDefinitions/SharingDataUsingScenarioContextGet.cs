using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SharingDataUsingScenarioContextGet
    {
        private readonly ScenarioContext scenarioContext;
        public SharingDataUsingScenarioContextGet(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Then(@"II - Username and Password are displayed")]
        public void ThenII_UsernameAndPasswordAreDisplayed()
        {
            string username = scenarioContext.Get<string>("Username");
            string password = scenarioContext.Get<string>("Password");
            Console.WriteLine("Retrieving Username: [{0}] and Password: [{1}]", username, password);
        }
    }
}
