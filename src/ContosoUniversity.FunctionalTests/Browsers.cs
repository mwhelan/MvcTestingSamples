using System.Diagnostics;
using System.Linq;
using Holf.AllForOne;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace ContosoUniversity.FunctionalTests
{
    public static class Browsers
    {
        private static RemoteWebDriver _chrome;
        public static RemoteWebDriver Chrome
        {
            get
            {
                if (_chrome == null) _chrome = new ChromeDriver();
                return _chrome;
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
