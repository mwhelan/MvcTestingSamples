using OpenQA.Selenium;

namespace ContosoUniversity.FunctionalTests.PageObjects
{
    public abstract class Page
    {
        public string Title
        {
            get { return Host.Browser.Title; }
        }

        public string Url { get { return Host.Browser.Url; } }

        public string PageId
        {
            get
            {
                return Host.Browser.FindElement(By.Id("pageId")).Text;
            }
        }
    }
}
