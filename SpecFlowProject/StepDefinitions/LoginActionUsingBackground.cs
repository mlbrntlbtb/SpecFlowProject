using SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginActionUsingBackground
    {
        public string landingPage;
        [Given(@"User navigated on landing page")]
        public void GivenUserNavigatedOnLandingPage()
        {
            landingPage = WebDriverHandler.AutoDriver.Url;
        }

        [Then(@"Landing page should be displayed")]
        public void ThenLandingPageShouldBeDisplayed()
        {
            Console.WriteLine("Landing page: [" + landingPage + "]");
        }
    }
}
