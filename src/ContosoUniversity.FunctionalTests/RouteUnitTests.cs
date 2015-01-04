using System.Web.Routing;
using ContosoUniversity.Controllers;
using ContosoUniversity.FunctionalTests.Navigation;
using FluentAssertions;
using NUnit.Framework;

namespace ContosoUniversity.FunctionalTests
{
    [TestFixture]
    public class RouteUnitTests
    {
    [Test]
    public void MvcUrlHelper_should_return_correct_route_for_controller_action()
    {
        var routes = RouteConfig.RegisterRoutes(new RouteCollection());
        var sut = new MvcUrlHelper(routes);

        sut.GetRelativeUrlFor<StudentController>(x => x.Details(1))
            .Should().Be("/Student/Details/1");
    }
    }
}
