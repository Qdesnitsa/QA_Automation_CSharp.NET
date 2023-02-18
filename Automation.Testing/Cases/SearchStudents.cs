using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.UI.Pages;

namespace Automation.Testing.Cases
{
    public class SearchStudents : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        { 

            // students to find
            var keyword = $"{testParams["keyword"]}";

            // perform test case
            return new FluentUI(Driver)
                .ChangeContext<StudentsUI>($"{testParams["application"]}")
                .FindByName(keyword)
                .Students()
                .All(i => i.FirstName().Equals(keyword) || i.LastName().Equals(keyword));
        }
    }
}
