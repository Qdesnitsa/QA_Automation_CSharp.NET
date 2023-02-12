using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        [TestMethod]
        public void WebDriverFactorySample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "edge", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.FindElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GoToUrlSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.GetElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void AsSelectSample() 
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Course");
            driver.FindElement(By.XPath("//select[@id='SelectedDepartment']")).AsSelect().SelectByValue("4");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            var elements = driver.GetElements(By.XPath("//li[@class='nav-item']"));
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisibleElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            // to make element invisible write on HTML page style="display: none;" - test will fail
            driver.GetVisibleElement(By.XPath("//a[.='Students']")).Click();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetVisibleElementsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            var elements = driver.GetVisibleElements(By.XPath("//li[@class='nav-item']"));
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void GetEnabledElementSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            // to make element disabled write on HTML page disabled - test will fail
            driver.GetEnabledElement(By.XPath("//input[@name='SearchString']")).SendKeys("hello");
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void VerticalWindowScrollSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.Manage().Window.Size = new Size(100, 350);
            driver.VerticalWindowScroll(1000);
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ActionsSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.GetVisibleElement(By.XPath("//a[.='Students']")).Actions().Click().Build().Perform();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ForceClickSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/");
            driver.GetElement(By.XPath("//a[.='Students']")).ForceClick();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SendKeysIntervalSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@name='SearchString']")).SendKeys("hello", 1000);
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void ForceClearSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            var element = driver.GetEnabledElement(By.XPath("//input[@name='SearchString']"));
            element.SendKeys("hello", 100);
            element.SendKeys(Keys.Home);
            element.ForceClear();
            Thread.Sleep(2000);
            driver.Dispose();
        }

        [TestMethod]
        public void SubmitFormSample()
        {
            var driver = new WebDriverFactory(new DriverParams { Driver = "chrome", Binaries = @"C:\Users\User\CSharpProjects\AutomationRoot\Automation.Testing\Resources" }).Get();
            driver.GoToUrl("https://gravitymvctestapplication.azurewebsites.net/Student");
            driver.GetEnabledElement(By.XPath("//input[@name='SearchString']")).SendKeys("Alexander");
            driver.SubmitForm(0);
            Thread.Sleep(2000);
            driver.Dispose();
        }
    }
}
