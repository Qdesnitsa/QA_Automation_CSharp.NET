﻿using Automation.Api.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Api.Pages
{
    public interface ICreateStudent : IStudentDetails, ICreate<IStudents>, IBack<IStudents>
    {
        ICreateStudent EnrollementDate(DateTime enrollementDate);

        ICreateStudent FirstName(string firstName);

        ICreateStudent LastName(string lastName);
    }
}
