using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using ContosoUniversity.FunctionalTests.Config;
using ContosoUniversity.FunctionalTests.Navigation;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ContosoUniversity.FunctionalTests
{
    [SetUpFixture]
    public class Host
    {
        public static IisExpressWebServer WebServer;
        public static IWebDriver Browser;
        private static MvcUrlHelper _mvcUrlHelper ;

        [SetUp]
        public void SetUp()
        {
            var app = new WebApplication(ProjectLocation.FromFolder("ContosoUniversity"), 12365);
            app.AddEnvironmentVariable("FunctionalTests");
            WebServer = new IisExpressWebServer(app);
            WebServer.Start("Release");

            Browser = Browsers.Chrome;
            _mvcUrlHelper = new MvcUrlHelper(RouteConfig.RegisterRoutes(new RouteCollection()));
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Quit();
            WebServer.Stop();
        }

        public static TPage NavigateTo<TController, TPage>(Expression<Action<TController>> action)
            where TController : Controller
            where TPage : new()
        {
            string relativeUrl = _mvcUrlHelper.GetRelativeUrlFor(action);
            string url = string.Format("{0}{1}", WebServer.BaseUrl, relativeUrl);
            Browser.Navigate().GoToUrl(url);
            return new TPage();
        }
    }
}