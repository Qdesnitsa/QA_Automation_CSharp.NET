﻿using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        // fields
        private IDictionary<string, object> testParams;
        private int attempts;
        private ILogger logger;

        protected TestCase()
        {
            testParams = new Dictionary<string, object>();
            attempts = 1;
            logger = new TraceLogger();
        }

        // components       
        public abstract bool AutomationTest(IDictionary<string, object> testParams);

        public TestCase Execute()
        {
            for (int i = 0; i < attempts; i++)
            {
                Driver = Get();
                try
                {
                    Actual = AutomationTest(testParams);
                    if (Actual)
                    {
                        break;
                    }
                    logger.Debug($"[{GetType()?.FullName}] failed on attempt [{++i}]");
                }
                catch(AssertInconclusiveException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch(NotImplementedException ex)
                {
                    logger.Debug(ex, ex.Message);
                    break;
                }
                catch(Exception ex)
                {
                    logger.Debug(ex, ex.Message);
                }
                finally
                {
                    Driver?.Close();
                    Driver?.Dispose();
                }
            }         
            return this;
        }

        // properties
        public bool Actual { get; private set; }

        public IWebDriver Driver { get; private set; }

        //configuration
        public TestCase WithTestParams(IDictionary<string, object> testParams)
        {
            this.testParams = testParams;
            return this;
        }

        public TestCase WithNumberOfAttempts(int numberOfAttempts) 
        {
            attempts = numberOfAttempts;
            return this;
        }

        public TestCase WithLogger(ILogger logger)
        {
            this.logger = logger;
            return this;
        }

        // setup
        private IWebDriver Get()
        {
            // constants
            const string DRIVER = "driver";

            // default
            var driverParams = new DriverParams { Binaries = ".", Driver = "chrome" };

            // change driver if exists
            if (testParams?.ContainsKey("driver") == true)
            {
                driverParams.Driver = $"{testParams["driver"]}";
            }

            // create driver
            return new WebDriverFactory(driverParams).Get();
        }
    }
}
