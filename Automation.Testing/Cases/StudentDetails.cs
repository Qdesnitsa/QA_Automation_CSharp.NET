﻿using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing.Cases
{
    public class StudentDetails : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams)
        {
            // students to find
            var firstName = $"{testParams["firstName"]}";

            // perform test case
            var student = new FluentUI(Driver)
                .ChangeContext<StudentsUI>($"{testParams["application"]}")
                .FindByName(firstName)
                .Students()
                .First();

            // extract expected
            var expected = student.FirstName();

            // assert
            return student.Details().FirstName().Equals(expected, StringComparison.OrdinalIgnoreCase);
        }
    }
}
