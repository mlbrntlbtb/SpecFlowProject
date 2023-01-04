using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginAction
    {
        private WebDriverWait? wait;
        private string username = "johnwick";
        private string password = "Excommunicado123!";

        [Given(@"User is on Login Page")]
        public void GivenUserIsOnLoginPage()
        {
            wait = new WebDriverWait(WebDriverHandler.AutoDriver, TimeSpan.FromSeconds(10));
            string targetURL = "https://demoqa.com/login";
            Console.WriteLine("Navigating to: [" + targetURL + "]");
            WebDriverHandler.AutoDriver.Navigate().GoToUrl(targetURL);
        }

        [When(@"User enters UserName and Password")]
        public void WhenUserEntersUserNameAndPassword()
        {
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

        [When(@"Click Login")]
        public void WhenClickLogin()
        {
            IWebElement Login = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='login']")));
            Console.WriteLine("Clicking login... ");
            Login.Click();
        }

        [Then(@"Userlabel with UserName will be displayed")]
        public void ThenUserlabelWithUserNameWillBeDisplayed()
        {
            Console.WriteLine("Verify logged user label... ");
            IWebElement Label = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@id='userName-value']")));
            string actualValue = Label.Text.Trim();
            Assert.AreEqual(actualValue, username);
        }
    }
}
