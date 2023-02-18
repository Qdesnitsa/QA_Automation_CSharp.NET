using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface ICreateStudent : IPersonalDetails, ICreate<IStudents>, IBack<IStudents>
    {
        ICreateStudent EnrollementDate(DateTime enrollementDate);

        ICreateStudent FirstName(string firstName);

        ICreateStudent LastName(string lastName);
    }
}
