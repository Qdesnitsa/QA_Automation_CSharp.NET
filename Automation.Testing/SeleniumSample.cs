using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing
{
    [TestClass]
    public class SeleniumSample
    {
        [TestMethod]
        public void WebDriverSample()
        {
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new FirefoxDriver();
            Thread.Sleep(1000);
            driver.Dispose();

            driver = new InternetExplorerDriver();
            Thread.Sleep(1000);
            driver.Dispose();
        }

        [TestMethod]
        public void WebElementSamle()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SelectElementSamle()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");
            var element = driver.FindElement(By.XPath("//select[@id='SelectedDepartment']"));
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
