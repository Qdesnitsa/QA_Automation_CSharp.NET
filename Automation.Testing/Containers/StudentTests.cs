﻿using Automation.Core.Components;
using Automation.Framework.RestApi.Pages;
using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentTests
    {
        [DataTestMethod]
        [DataRow("" +
                 "{" +
                 "'driver':'chrome'," +
                 "'keyword':'Alexander'," +
                 "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
                 "'fluent':'Automation.Core.Components.FluentUI'," +
                 "'students':'Automation.Framework.UI.Pages.StudentsUI'}"
                 )]
        [DataRow("" +
                 "{" +
                 "'driver':'HTTP'," +
                 "'keyword':'Alexander'," +
                 "'application':'https://gravitymvctestapplication.azurewebsites.net'," +
                 "'fluent':'Automation.Core.Components.FluentRest'," +
                 "'students':'Automation.Framework.RestApi.Pages.StudentsRest'}"
        )]
        public void SearchStudentTest(string testParams)
        {
            //generate test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new SearchStudents().WithTestParams(parameters).Execute().Actual;

            // assert results
            Assert.IsTrue(actual);
        }
        
        [DataTestMethod]
        [DataRow("" +
                 "{" +
                 "'driver':'chrome'," +
                 "'keyword':'Alexander'," +
                 "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
                 "'fluent':'Automation.Core.Components.FluentUI'," +
                 "'students':'Automation.Framework.UI.Pages.StudentsUI'" +
                 "}"
        )]
        [DataRow("" +
                 "{" +
                 "'driver':'HTTP'," +
                 "'keyword':'Alexander'," +
                 "'application':'https://gravitymvctestapplication.azurewebsites.net'," +
                 "'fluent':'Automation.Core.Components.FluentRest'," +
                 "'students':'Automation.Framework.RestApi.Pages.StudentsRest'" +
                 "}"
        )]
        public void StudentDetailsTest(string testParams)
        {
            //generate test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new StudentDetails().WithTestParams(parameters).Execute().Actual;

            // assert results
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        // [DataRow("" +
        //          "{" +
        //          "'driver':'chrome'," +
        //          "'firstName':'csharp'," +
        //          "'lastName':'student'," +
        //          "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
        //          "'fluent':'Automation.Core.Components.FluentUI'," +
        //          "'students':'Automation.Framework.UI.Pages.StudentsUI'" +
        //          "}")]
        [DataRow("" +
                 "{" +
                 "'driver':'HTTP'," +
                 "'firstName':'csharp'," +
                 "'lastName':'student'," +
                 "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
                 "'fluent':'Automation.Core.Components.FluentRest'," +
                 "'students':'Automation.Framework.RestApi.Pages.StudentsRest'" +
                 "}")]
        public void CreateStudentUiTest(string testParams)
        {
            //generate test-paameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new CreateStudent().WithTestParams(parameters).Execute().Actual;

            // assert results
            Assert.IsTrue(actual);
        }
    }
}
