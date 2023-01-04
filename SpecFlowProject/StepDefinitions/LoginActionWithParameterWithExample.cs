using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject.Utilities;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginActionWithParameterWithExample
    {
        private WebDriverWait? wait;

        [Given(@"III - User is on Login Page")]
        public void GivenIII_UserIsOnLoginPage()
        {
            wait = new WebDriverWait(WebDriverHandler.AutoDriver, TimeSpan.FromSeconds(10));
            string targetURL = "https://demoqa.com/login";
            Console.WriteLine("Navigating to: [" + targetURL + "]");
            WebDriverHandler.AutoDriver.Navigate().GoToUrl(targetURL);
        }

        [When(@"III - User enters '([^']*)' and '([^']*)'")]
        public void WhenIII_UserEntersAnd(string username, string password)
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

        [When(@"III - Click Login")]
        public void WhenIII_ClickLogin()
        {
            IWebElement Login = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='login']")));
            Console.WriteLine("Clicking login... ");
            Login.Click();
        }

        [Then(@"III - Userlabel with '([^']*)' will be displayed")]
        public void ThenIII_UserlabelWithWillBeDisplayed(string username)
        {
            Console.WriteLine("Verify logged user label... ");
            IWebElement Label = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@id='userName-value']")));
            string actualValue = Label.Text.Trim();
            Assert.AreEqual(actualValue, username);
        }
    }
}
