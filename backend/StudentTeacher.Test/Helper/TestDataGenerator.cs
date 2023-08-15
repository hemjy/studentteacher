using Bogus;
using StudentTeacher.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Test.Helper
{
    internal static class TestDataGenerator
    {
        internal static NewStudent GenerateInvalidStudent()
        {
            var minDate = new DateTime(1980, 1, 1);
            var maxDate = new DateTime(2000, 12, 31);
            var faker = new Faker<NewStudent>()
           .RuleFor(s => s.DateOfBirth, f => f.Date.Between(minDate, maxDate))
           .RuleFor(s => s.StudentNumber, f => f.Random.AlphaNumeric(12))
           .RuleFor(s => s.NationalIdNumber, f => f.Random.Int(1).ToString())
           .RuleFor(s => s.Surname, f => f.Person.LastName)
           .RuleFor(s => s.Name, f => f.Person.FullName);

            var fakeStudent = faker.Generate();
            return fakeStudent;
        }
        internal static NewStudent GenerateValidStudent()
        {
            var minDate = new DateTime(2002, 1, 1);
            var maxDate = DateTime.UtcNow;
            var faker = new Faker<NewStudent>()
           .RuleFor(s => s.DateOfBirth, f => f.Date.Between(minDate, maxDate))
           .RuleFor(s => s.StudentNumber, f => f.Random.AlphaNumeric(12))
           .RuleFor(s => s.NationalIdNumber, f => f.Random.Int(1).ToString())
           .RuleFor(s => s.Surname, f => f.Person.LastName)
           .RuleFor(s => s.Name, f => f.Person.FullName);

            var fakeStudent = faker.Generate();
            return fakeStudent;
        }
    }
}
