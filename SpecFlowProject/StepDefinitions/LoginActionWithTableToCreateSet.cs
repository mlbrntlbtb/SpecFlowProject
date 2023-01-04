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
    public class LoginActionWithTableToCreateSet
    {
        private WebDriverWait? wait;

        [Given(@"VII - User is on Login Page")]
        public void GivenVII_UserIsOnLoginPage()
        {
            wait = new WebDriverWait(WebDriverHandler.AutoDriver, TimeSpan.FromSeconds(10));
            string targetURL = "https://demoqa.com/login";
            Console.WriteLine("Navigating to: [" + targetURL + "]");
            WebDriverHandler.AutoDriver.Navigate().GoToUrl(targetURL);
        }

        [When(@"VII - User enters UserName and Password")]
        public void WhenVII_UserEntersUserNameAndPassword(Table table)
        {
            var credentials = table.CreateSet<Credentials>();

            foreach (var userData in credentials)
            {
                string username = userData.Username;
                string password = userData.Password;

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
        }

        [When(@"VII - Click Login")]
        public void WhenVII_ClickLogin()
        {
            IWebElement Login = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='login']")));
            Console.WriteLine("Clicking login... ");
            Login.Click();
        }

        [Then(@"VII - Userlabel with UserName will be displayed")]
        public void ThenVII_UserlabelWithUserNameWillBeDisplayed(Table table)
        {
            var credentials = table.CreateSet<Credentials>();

            foreach (var userData in credentials)
            {
                string username = userData.Username;

                Console.WriteLine("Verify logged user label... ");
                IWebElement Label = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@id='userName-value']")));
                string actualValue = Label.Text.Trim();
                Assert.AreEqual(actualValue, username);
            }
        }
    }
}
