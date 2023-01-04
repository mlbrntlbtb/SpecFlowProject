using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject.Utilities;
using SpecFlowProject.Models;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginActionWithTableToCreateInstance
    {
        private WebDriverWait? wait;

        [Given(@"VI - User is on Login Page")]
        public void GivenVI_UserIsOnLoginPage()
        {
            wait = new WebDriverWait(WebDriverHandler.AutoDriver, TimeSpan.FromSeconds(10));
            string targetURL = "https://demoqa.com/login";
            Console.WriteLine("Navigating to: [" + targetURL + "]");
            WebDriverHandler.AutoDriver.Navigate().GoToUrl(targetURL);
        }

        [When(@"VI - User enters UserName and Password")]
        public void WhenVI_UserEntersUserNameAndPassword(Table table)
        {
            var credentials = table.CreateInstance<Credentials>();
            string username = credentials.Username;
            string password = credentials.Password;

            IWebElement Username = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='userName']")));
            IWebElement Password = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='password']")));

            Console.WriteLine("Clearing login fields... ");
            Username.Clear();
            Password.Clear();

            Console.WriteLine("Setting username: [" + username + "]...");
            Username.SendKeys(username);

            Console.WriteLine("Setting password: [" + password + "]...");
            Password.SendKeys(password);
        }

        [When(@"VI - Click Login")]
        public void WhenVI_ClickLogin()
        {
            IWebElement Login = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='login']")));
            Console.WriteLine("Clicking login... ");
            Login.Click();
        }

        [Then(@"VI - Userlabel with UserName will be displayed")]
        public void ThenVI_UserlabelWithUserNameWillBeDisplayed(Table table)
        {
            var credentials = table.CreateInstance<Credentials>();
            string username = credentials.Username;

            Console.WriteLine("Verify logged user label... ");
            IWebElement Label = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@id='userName-value']")));
            string actualValue = Label.Text.Trim();
            Assert.AreEqual(actualValue, username);
        }
    }
}
