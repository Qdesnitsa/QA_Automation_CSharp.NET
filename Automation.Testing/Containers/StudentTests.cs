using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentTests
    {
        [DataTestMethod]
        [DataRow("{'driver':'chrome','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void SearchStudentUITest(string testParams)
        {
            //generate test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new SearchStudents().WithTestParams(parameters).Execute().Actual;

            // assert results
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("{'driver':'chrome','firstName':'csharp','lastName':'student','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void CreateStudentUITest(string testParams)
        {
            //generate test-paameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new CreateStudent().WithTestParams(parameters).Execute().Actual;

            // assert results
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("{'driver':'chrome','firstName':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void StudentDetailsTest(string testParams)
        {
            //generate test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new StudentDetails().WithTestParams(parameters).Execute().Actual;

            // assert results
            Assert.IsTrue(actual);
        }
    }
}
