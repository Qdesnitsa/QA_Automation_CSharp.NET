using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface ICreateStudent : IPersonalDetails, ICreate<IStudents>, IBack<IStudents>
    {
        ICreateStudent EnrollmentDate(DateTime enrollmentDate);

        ICreateStudent FirstName(string firstName);

        ICreateStudent LastName(string lastName);
    }
}
