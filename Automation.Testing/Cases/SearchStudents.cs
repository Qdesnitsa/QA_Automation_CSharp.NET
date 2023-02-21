using Automation.Api.Pages;
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
            var fluent = $"{testParams["fluent"]}";
            var students = $"{testParams["students"]}";

            // perform test case
            return CreateFluentApi(fluent)
                .ChangeContext<IStudents>(students, $"{testParams["application"]}")
                .FindByName(keyword)
                .Students()
                .All(i => i.FirstName().Equals(keyword) || i.LastName().Equals(keyword));
        }
    }
}
