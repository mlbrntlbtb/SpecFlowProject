using System;
using TechTalk.SpecFlow;
using SpecFlowProject.Models;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class SharingDataUsingContextInjectionSet
    {
        private readonly Credentials credentials;
        public SharingDataUsingContextInjectionSet(Credentials credentials)
        {
            this.credentials = credentials;
        }

        [Given(@"""([^""]*)"" and ""([^""]*)"" are declared")]
        public void GivenAndAreDeclared(string username, string password)
        {
            Console.WriteLine("Storing Username: [{0}] and Password: [{1}]", username, password);
            credentials.Username = username;
            credentials.Password = password;
        }
    }
}
