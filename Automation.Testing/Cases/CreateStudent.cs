using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.UI.Pages;

namespace Automation.Testing.Cases
{
    public class CreateStudent : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {

            // students to find
            var firstName = $"{testParams["firstName"]}";
            var lastName = $"{testParams["lastName"]}";
            var fluent = $"{testParams["fluent"]}";
            var students = $"{testParams["students"]}";

            // perform test case
            return CreateFluentApi(fluent)
                .ChangeContext<IStudents>(students, $"{testParams["application"]}")
                .Create()
                .FirstName(firstName)
                .LastName(lastName)
                .EnrollmentDate(DateTime.Now)
                .Create()
                .FindByName(firstName)
                .Students()
                .Any();
                //.All(i => i.FirstName().Equals(keyword) || i.LastName().Equals(keyword));
        }
    }
}
