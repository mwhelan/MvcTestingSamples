using System.Diagnostics;
using System.Linq;
using Holf.AllForOne;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace ContosoUniversity.FunctionalTests
{
    public static class Browsers
    {
        private static RemoteWebDriver _firefox;
        public static RemoteWebDriver Firefox
        {
            get
            {
                if (_firefox == null) _firefox = new FirefoxDriver();
                return _firefox;
            }
        }

        private static RemoteWebDriver _phantom;
        public static RemoteWebDriver Phantom
        {
            get
            {
                if (_phantom == null)
                {
                    _phantom = new PhantomJSDriver();
                    var process = Process.GetProcessesByName("phantomjs").FirstOrDefault();
                    process.TieLifecycleToParentProcess();
                }

                return _phantom;
            }
        }
    }
}
