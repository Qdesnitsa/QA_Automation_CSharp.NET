﻿using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;

namespace Automation.Framework.RestApi.Pages;

public class StudentDetailsRest : FluentRest, IStudentDetails
{
    public StudentDetailsRest(HttpClient httpClient) 
        : this(httpClient, new TraceLogger()) { }

    public StudentDetailsRest(HttpClient httpClient, ILogger logger) 
        : this(httpClient, logger, 0) { }

    public StudentDetailsRest(HttpClient httpClient, ILogger logger, int id)
        : base(httpClient, logger)
    {
        Build(id);
    }

    public string FirstName()
    {
        throw new NotImplementedException();
    }

    public string LastName()
    {
        throw new NotImplementedException();
    }

    public DateTime EnrollmentDate()
    {
        throw new NotImplementedException();
    }

    public IEnrollment[] Enrollments()
    {
        throw new NotImplementedException();
    }
    
    // build pipeline
    private void Build(int id)
    {
        var response = HttpClient.GetAsync($"/api/Students/{id}").GetAwaiter().GetResult();
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
        var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }
}