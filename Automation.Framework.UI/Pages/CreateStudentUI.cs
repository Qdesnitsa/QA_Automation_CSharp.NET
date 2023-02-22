using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

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
            Driver.GetEnabledElement(By.XPath("//input[contains(@class, 'btn-primary')]")).Click();
            return new StudentsUI(Driver);
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent EnrollmentDate(DateTime enrollmentDate)
        {
            var script = $"document.getElementById('EnrollmentDate').setAttribute('value','{enrollmentDate.ToString("yyyy-MM-dd")}');";
            Driver.ExecuteJavaScript(script);
            return this;
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent FirstName(string firstName)
        {
            Driver.GetEnabledElement(By.XPath("//input[@id='FirstMidName']")).SendKeys(firstName);
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
