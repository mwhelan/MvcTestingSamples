using ContosoUniversity.Controllers;
using ContosoUniversity.FunctionalTests.PageObjects;
using ContosoUniversity.ResourceFiles;
using FluentAssertions;
using NUnit.Framework;

namespace ContosoUniversity.FunctionalTests.Tests
{
    [TestFixture]
    public class MagicStringTests
    {
        [Test]
        public void CanNavigateToPageViaControllerAction()
        {
            var newStudentPage = Host.NavigateTo<StudentController, NewStudentPage>(x => x.Create());
            newStudentPage.Url.Should().Be(Host.WebServer.BaseUrl + "/Student/Create");
        }

        [Test]
        public void CanAccessResourceFilesFromTests()
        {
            var newStudentPage = Host.NavigateTo<StudentController, NewStudentPage>(x => x.Create());
            newStudentPage.HeaderTitle.Should().Be(Resources.Student_CreateForm_Title);
        }

        [Test]
        public void CanIdentifyPageWithHiddenIdentifier()
        {
            var newStudentPage = Host.NavigateTo<StudentController, NewStudentPage>(x => x.Create());
            newStudentPage.PageId.Should().Be(LocalSiteMap.Pages.Student.Create);
        }
    }
}
