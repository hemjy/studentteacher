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
using Newtonsoft.Json;

namespace StudentTeacher.Test.IntegrationTest
{
    public class TeacherTests : IDisposable
    {
        private readonly StudentTeacherApplication<TeacherController> _application;
        private readonly HttpClient _client;
        private readonly StudentTeacherContext _studentTeacherContext;


        public TeacherTests()
        {
            _application = new StudentTeacherApplication<TeacherController>();
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
        public async Task InvalidDateOBirth_ShouldReturn_BadRequest()
        {
            var payload = TestDataGenerator.GenerateInvalidTeacher();
            payload.Title = "Mr";
            var response = await _client
                .PostAsJsonAsync("/api/teacher", payload);

            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.True(problemDetails?.Errors.Any(x => x.Key.Contains("Date of Birth")));
            Assert.Equal(StatusCodes.Status400BadRequest, problemDetails?.Status);
        }

        [Fact]
        public async Task TeacherCreatedInvalidTitle_ShouldReturn_BadRequest()
        {
            var payload = TestDataGenerator.GenerateInvalidTeacher();
            var response = await _client
                .PostAsJsonAsync("/api/teacher", payload);

            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        
            Assert.True(problemDetails?.Errors.Any(x => x.Key.Contains("Title")));
            Assert.Equal(StatusCodes.Status400BadRequest, problemDetails?.Status);
        }
        [Fact]
        public async Task TeacherCreated_ShouldReturn_Success()
        {
            var payload = TestDataGenerator.GenerateValidTeacher();
            var response = await _client
                .PostAsJsonAsync("/api/teacher", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Succeeds_WithValidData()
        {
            int pageNumber = 1;
            var payload = TestDataGenerator.GenerateValidTeacher();
             await _client
                .PostAsJsonAsync("/api/teacher", payload);
            await Task.Delay(2000);
            var response = await _client
               .GetAsync($"/api/teacher/all?pageNumber={pageNumber}");

            var content = await response.Content.ReadAsStringAsync();
           
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var students = JsonConvert.DeserializeObject<PagedList<StudentToReturn>>(content);
            students.Should().NotBeNull();
            students.MetaData.TotalCount.Should().Be(1);
            students.Data.Should().NotBeNull();
            students.Data.Should().HaveCountGreaterThanOrEqualTo(1);

        }
    }
}
