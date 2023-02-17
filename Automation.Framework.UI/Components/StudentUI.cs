using Automation.Api.Components;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.UI.Components
{
    public class StudentUI : FluentUI, IStudent
    {
        private readonly IWebElement dataRow;
        private string firstName;
        private string lastName;
        private DateTime enrollementDate;
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

        public object Details()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        // data
        public DateTime EnrollementDate()
        {
            return enrollementDate;
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
            DateTime.TryParse(dateString, out enrollementDate);
        }
    }
}
