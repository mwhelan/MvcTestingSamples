using FluentAssertions;
using NUnit.Framework;

namespace ContosoUniversity.FunctionalTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Can_go_to_home_page()
        {
            Host.Browser.Navigate().GoToUrl(Host.WebServer.BaseUrl);
            Host.Browser.Title.Should().Be("Home Page - Contoso University");
        }
    }
}
