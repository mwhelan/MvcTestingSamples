using ContosoUniversity.FunctionalTests.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ContosoUniversity.FunctionalTests
{
    [SetUpFixture]
    public class Host
    {
        public static IisExpressWebServer WebServer;
        public static IWebDriver Browser;

        [SetUp]
        public void SetUp()
        {
            var app = new WebApplication(ProjectLocation.FromFolder("ContosoUniversity"), 12365);
            app.AddEnvironmentVariable("FunctionalTests");
            WebServer = new IisExpressWebServer(app);
            WebServer.Start();

            Browser = Browsers.Firefox;
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Quit();
            WebServer.Stop();
        }
    }
}