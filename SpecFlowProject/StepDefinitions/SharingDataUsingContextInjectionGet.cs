using SpecFlowProject.Models;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SharingDataUsingContextInjectionGet
    {
        private readonly Credentials credentials;
        public SharingDataUsingContextInjectionGet(Credentials credentials)
        {
            this.credentials = credentials;
        }

        [Then(@"Username and Password are displayed")]
        public void ThenUsernameAndPasswordAreDisplayed()
        {
            string username = credentials.Username;
            string password = credentials.Password;
            Console.WriteLine("Retrieving Username: [{0}] and Password: [{1}]", username, password);
        }
    }
}
