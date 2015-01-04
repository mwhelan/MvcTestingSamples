using OpenQA.Selenium;

namespace ContosoUniversity.FunctionalTests.PageObjects
{
    public class NewStudentPage : Page
    {
        public string HeaderTitle
        {
            get
            {
                var header = Host.Browser.FindElement(By.Id("title"));
                return header.Text;
            }
        }
    }
}