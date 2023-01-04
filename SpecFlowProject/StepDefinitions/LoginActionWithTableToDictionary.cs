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
    public class LoginActionWithTableToDictionary
    {
        private WebDriverWait? wait;

        [Given(@"IV - User is on Login Page")]
        public void GivenIV_UserIsOnLoginPage()
        {
            wait = new WebDriverWait(WebDriverHandler.AutoDriver, TimeSpan.FromSeconds(10));
            string targetURL = "https://demoqa.com/login";
            Console.WriteLine("Navigating to: [" + targetURL + "]");
            WebDriverHandler.AutoDriver.Navigate().GoToUrl(targetURL);
        }

        [When(@"IV - User enters UserName and Password")]
        public void WhenIV_UserEntersUserNameAndPassword(Table table)
        {
            var dictionary = TableHandler.ToDictionary(table);
            string username = dictionary["Username"];
            string password = dictionary["Password"];

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

        [When(@"IV - Click Login")]
        public void WhenIV_ClickLogin()
        {
            IWebElement Login = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='login']")));
            Console.WriteLine("Clicking login... ");
            Login.Click();
        }

        [Then(@"IV - Userlabel with UserName will be displayed")]
        public void ThenIV_UserlabelWithUserNameWillBeDisplayed(Table table)
        {
            var dictionary = TableHandler.ToDictionary(table);
            string username = dictionary["Username"];

            Console.WriteLine("Verify logged user label... ");
            IWebElement Label = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@id='userName-value']")));
            string actualValue = Label.Text.Trim();
            Assert.AreEqual(actualValue, username);
        }
    }
}
