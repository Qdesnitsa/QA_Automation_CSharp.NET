using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace Automation.Core.Components
{
    public class FluentUI : FluentBase
    {
        public FluentUI(string driverParams) 
            : this(new WebDriverFactory(driverParams).Get()) { }

        public FluentUI(DriverParams driverParams)
            : this(new WebDriverFactory(driverParams).Get()) { }

        public FluentUI(WebDriverFactory webDriverFactory)
            : this(webDriverFactory.Get()) { }

        public FluentUI(IWebDriver driver)
            : this(driver, new TraceLogger()) { }

        public FluentUI(IWebDriver driver, ILogger logger) : base(logger)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public override T ChangeContext<T>(string application, ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null, logger);
        }

        public override T ChangeContext<T>(string application)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null, null);
        }

        public override T ChangeContext<T>(string type, string application)
        {
            var t = Utilities.GetTypeByName(type);
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(t, null);
        }

        internal override T Create<T>(Type type, ILogger logger)
        {
            if(type == null)
            {
                type = typeof(T);
            }
            return logger == null
                ? (T)Activator.CreateInstance(type, new object[] { Driver })
                : (T)Activator.CreateInstance(type, new object[] { Driver, logger });
        }
    }
}
