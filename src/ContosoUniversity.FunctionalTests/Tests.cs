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

        [Test]
        public void CanInjectEnvironmentVariables()
        {
            string url = string.Format("{0}/Home/TestingEnvVariable", Host.WebServer.BaseUrl);
            Host.Browser.Navigate().GoToUrl(url);
            Host.Browser.Title.Should().Be("Home Page - Contoso University");
        }

        [Test]
        public void CanApplyConfigTransformations()
        {
            string url = string.Format("{0}/Home/TestingConfigTransformVariable", Host.WebServer.BaseUrl);
            Host.Browser.Navigate().GoToUrl(url);
            Host.Browser.PageSource.Should().Be("<html xmlns=\"http://www.w3.org/1999/xhtml\"><head></head><body>Production</body></html>");
        }
    }
}
