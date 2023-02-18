using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.UI.Pages
{
    public class CreateStudentUI : FluentUI, ICreateStudent
    {
        public CreateStudentUI(IWebDriver driver)
            : base(driver) { }

        public CreateStudentUI(IWebDriver driver, ILogger logger)
            : base(driver, logger) { }

        public IStudents BackToList()
        {
            throw new NotImplementedException();
        }

        public IStudents Create()
        {
            Driver.GetEnabledElement(By.XPath("//input[contains(@class, 'btn-primary')]"));
            return new StudentsUI(Driver);
        }

        public DateTime EnrollementDate()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent EnrollementDate(DateTime enrollementDate)
        {
            var script = $"document.getElementById('EnrollmentDate').setAttribute('value','{enrollementDate.ToString("yyyy-MM-dd")}');";
            Driver.ExecuteJavaScript(script);
            return this;
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent FirstName(string firstName)
        {
            Driver.GetEnabledElement(By.XPath("//input[@name='FirstMidName']")).SendKeys(firstName);
            return this;
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent LastName(string lastName)
        {
            Driver.GetEnabledElement(By.XPath("//input[@name='LastName']")).SendKeys(lastName);
            return this;
        }
    }
}
