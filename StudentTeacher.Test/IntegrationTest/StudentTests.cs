using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Controllers;
using StudentTeacher.Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StudentTeacher.Infrastructure.Data.Context;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Test.Helper;
using System.Net.Http.Headers;
using StudentTeacher.Core.Models;
using FluentAssertions;

namespace StudentTeacher.Test.IntegrationTest
{
    public class StudentTests : IDisposable
    {
        private readonly StudentTeacherApplication<StudentController> _application;
        private readonly HttpClient _client;
        private readonly StudentTeacherContext _studentTeacherContext;


        public StudentTests()
        {
            _application = new StudentTeacherApplication<StudentController>();
            _client = _application.CreateClient();
            _studentTeacherContext = _application.Services.CreateScope().ServiceProvider
                .GetRequiredService<StudentTeacherContext>();
        }

        public void Dispose()
        {
            _client.Dispose();
            _application.Dispose();
        }

        [Fact]
        public async Task StudentCreated_ShouldReturn_BadRequest()
        {
            var payload = TestDataGenerator.GenerateInvalidStudent();
            var response = await _client
                .PostAsJsonAsync("/api/student", payload);

            var expecteErrorMessage = "Something is wrong on the information provided, please review.";
            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.True(problemDetails?.Errors.Any(x => x.Key.Contains("Date of Birth")));
            Assert.Equal(StatusCodes.Status400BadRequest, problemDetails?.Status);
        }
        [Fact]
        public async Task StudentCreated_ShouldReturn_Success()
        {
            var payload = TestDataGenerator.GenerateValidStudent();
            var response = await _client
                .PostAsJsonAsync("/api/student", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Succeeds_WithValidData()
        {
            int pageNumber = 1;
            var payload = TestDataGenerator.GenerateValidStudent();
             await _client
                .PostAsJsonAsync("/api/student", payload);
            await Task.Delay(2000);
            var response = await _client
               .GetAsync($"/api/student/all?pageNumber={pageNumber}");

            var content = await response.Content.ReadAsStringAsync();
            var students = await response.Content.ReadFromJsonAsync<PagedList<StudentToReturn>>();

            response.Should().BeSuccessful();
            students.Data.Should().NotBeNull();
            students.Data.Should().HaveCount(1);

        }
    }
}
