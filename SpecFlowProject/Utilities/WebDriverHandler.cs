using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Utilities
{
    public class WebDriverHandler
    {
        public static WebDriver? AutoDriver;
        public static WebDriver CreateBrowser(string browserName)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    AutoDriver = new ChromeDriver();
                    break;
                case "firefox":
                    AutoDriver = new FirefoxDriver();
                    break;
                default:
                    throw new Exception("Browser: [" + browserName + "] does not exist.");
            }
            return AutoDriver;
        }
    }
}
