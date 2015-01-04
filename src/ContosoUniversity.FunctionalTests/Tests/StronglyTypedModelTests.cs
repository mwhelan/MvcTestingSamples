using System;
using ContosoUniversity.Controllers;
using ContosoUniversity.FunctionalTests.PageObjects;
using ContosoUniversity.ViewModels;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ContosoUniversity.FunctionalTests.Tests
{
    [TestFixture]
    public class StronglyTypedModelTests
    {
        [Test]
        public void CanPopulateAFormFieldFromModelProperty()
        {
            var student = Builder<CreateStudentForm>
                .CreateNew()
                .Build();
            var newStudentPage = Host.NavigateTo<StudentController, NewStudentPage>(x => x.Create());

            newStudentPage
                .InputFirstName(student.FirstMidName)
                .InputLastName(student.LastName)
                .InputEnrollmentDate(student.EnrollmentDate);

            Host.Browser.FindElement(By.Id("FirstMidName")).GetAttribute("value").Should().Be(student.FirstMidName);
            Host.Browser.FindElement(By.Id("LastName")).GetAttribute("value").Should().Be(student.LastName);
            Host.Browser.FindElement(By.Id("EnrollmentDate")).GetAttribute("value").Should().Be(student.EnrollmentDate.ToString());
        }

        [Test]
        public void CanPopulateFormFromModel()
        {
            var student = Builder<CreateStudentForm>
                .CreateNew()
                .Build();
            var newStudentPage = Host.NavigateTo<StudentController, NewStudentPage>(x => x.Create());

            newStudentPage.AddValidStudent(student);

            Host.Browser.FindElement(By.Id("FirstMidName")).GetAttribute("value").Should().Be(student.FirstMidName);
            Host.Browser.FindElement(By.Id("LastName")).GetAttribute("value").Should().Be(student.LastName);
            Host.Browser.FindElement(By.Id("EnrollmentDate")).GetAttribute("value").Should().Be(student.EnrollmentDate.ToString());
        }

        [Test]
        public void CanReadFormFieldFromModelProperty()
        {
            var studentDetailsPage = Host.NavigateTo<StudentController, StudentDetailsPage>(x => x.Details(1));

            studentDetailsPage
                .DisplayFor(x => x.LastName)
                .Should().Be("Alexander");
        }

        [Test]
        public void CanReadModelFromPage()
        {
            var studentDetailsPage = Host.NavigateTo<StudentController, StudentDetailsPage>(x => x.Details(1));

            var model = studentDetailsPage.ReadModel();

            model.FirstMidName.Should().Be("Carson");
            model.LastName.Should().Be("Alexander");
        }

    }
}
