using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Automation.Framework.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            // creating driver for this case
            var driver = new WebDriverFactory(new DriverParams { Driver = $"{testParams["driver"]}", Binaries = "." }).Get();

            // students to find
            var keyword = $"{testParams["keyword"]}";

            // perform test case
            return new FluentUI(driver)
                .ChangeContext<StudentsUI>($"{testParams["application"]}")
                .FindByName(keyword)
                .Students()
                .All(i => i.FirstName().Equals(keyword) || i.LastName().Equals(keyword));
        }
    }
}
