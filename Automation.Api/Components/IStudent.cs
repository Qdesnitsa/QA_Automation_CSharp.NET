using Automation.Api.Pages;

namespace Automation.Api.Components
{
    public interface IStudent : IPersonalDetails, IDetails<IStudentDetails>, IEdit<object>, IDelete<object> { }
}
