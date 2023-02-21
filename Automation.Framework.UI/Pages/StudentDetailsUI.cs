using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using OpenQA.Selenium;

namespace Automation.Framework.UI.Pages
{
    public class StudentDetailsUI : FluentUI, IStudentDetails
    {
        public StudentDetailsUI(IWebDriver driver) : base(driver)
        {
        }

        public StudentDetailsUI(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
        }

        public IEnrollment[] Enrollments()
        {
            throw new NotImplementedException();
        }

        public string FirstName()
        {
            return Driver.GetElement(By.XPath("//dl/dt[contains(text(), 'First Name')]/following::dd[1]")).Text.Trim();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }
    }
}
