using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Framework.UI.Pages;
using OpenQA.Selenium;

namespace Automation.Framework.UI.Components
{
    public class StudentUI : FluentUI, IStudent
    {
        private readonly IWebElement dataRow;
        private string firstName;
        private string lastName;
        private DateTime enrollmentDate;
        public StudentUI(IWebDriver driver, IWebElement dataRow) 
            : this(driver, new TraceLogger()) 
        {
            this.dataRow = dataRow;
            Build(dataRow);
        }

        private StudentUI(IWebDriver driver, ILogger logger) 
            : base(driver, logger) { }

        // actions
        public object Delete()
        {
            throw new NotImplementedException();
        }

        public IStudentDetails Details()
        {
            dataRow.FindElement(By.XPath("//a[contains(@href, '/Student/Details/')]")).Click();
            return new StudentDetailsUI(Driver);
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        // data
        public DateTime EnrollmentDate()
        {
            return enrollmentDate;
        }

        public string FirstName()
        {
            return firstName;
        }

        public string LastName()
        {
            return lastName;
        }

        // processing
        private void Build(IWebElement dataRow)
        {
            lastName = dataRow.FindElement(By.XPath("./td[contains(@id, 'student_last_name')]")).Text.Trim();
            firstName = dataRow.FindElement(By.XPath("./td[contains(@id, 'student_first_name')]")).Text.Trim();

            // parse date
            var dateString = dataRow.FindElement(By.XPath("./td[contains(@id, 'student_enroll_date')]")).Text.Trim();
            DateTime.TryParse(dateString, out enrollmentDate);
        }
    }
}
