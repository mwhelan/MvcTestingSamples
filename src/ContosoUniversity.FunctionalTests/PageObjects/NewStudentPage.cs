using System;
using ContosoUniversity.ViewModels;
using OpenQA.Selenium;

namespace ContosoUniversity.FunctionalTests.PageObjects
{
    public class NewStudentPage : Page<CreateStudentForm>
    {
        public string HeaderTitle
        {
            get
            {
                var header = Host.Browser.FindElement(By.Id("title"));
                return header.Text;
            }
        }

        public StudentDetailsPage AddValidStudent(CreateStudentForm student)
        {
            InputModel(student);
            return new StudentDetailsPage();
        }

        public NewStudentPage InputLastName(string lastName)
        {
            TextBoxFor(x => x.LastName, lastName);
            return this;
        }

        public NewStudentPage InputFirstName(string firstName)
        {
            TextBoxFor(x => x.FirstMidName, firstName);
            return this;
        }

        public NewStudentPage InputEnrollmentDate(DateTime enrollmentDate)
        {
            TextBoxFor(x => x.EnrollmentDate, enrollmentDate);
            return this;
        }

        public void Save()
        {
            //Form.Save();
        }
    }
}