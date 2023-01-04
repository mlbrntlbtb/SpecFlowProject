using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject.Utilities;
using System.Data;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginActionWithTableToDataTable
    {
        private WebDriverWait? wait;

        [Given(@"V - User is on Login Page")]
        public void GivenV_UserIsOnLoginPage()
        {
            wait = new WebDriverWait(WebDriverHandler.AutoDriver, TimeSpan.FromSeconds(10));
            string targetURL = "https://demoqa.com/login";
            Console.WriteLine("Navigating to: [" + targetURL + "]");
            WebDriverHandler.AutoDriver.Navigate().GoToUrl(targetURL);
        }

        [When(@"V - User enters UserName and Password")]
        public void WhenV_UserEntersUserNameAndPassword(Table table)
        {
            var dataTable = TableHandler.ToDataTable(table);

            foreach (DataRow row in dataTable.Rows)
            {
                string username = row.ItemArray[0].ToString();
                string password = row.ItemArray[1].ToString();

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

        [When(@"V - Click Login")]
        public void WhenV_ClickLogin()
        {
            IWebElement Login = wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='login']")));
            Console.WriteLine("Clicking login... ");
            Login.Click();
        }

        [Then(@"V - Userlabel with UserName will be displayed")]
        public void ThenV_UserlabelWithUserNameWillBeDisplayed(Table table)
        {
            var dataTable = TableHandler.ToDataTable(table);

            foreach (DataRow row in dataTable.Rows)
            {
                string username = row.ItemArray[0].ToString();

                Console.WriteLine("Verify logged user label... ");
                IWebElement Label = wait.Until(ExpectedConditions.ElementExists(By.XPath("//label[@id='userName-value']")));
                string actualValue = Label.Text.Trim();
                Assert.AreEqual(actualValue, username);
            }
        }
    }
}
