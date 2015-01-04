using ContosoUniversity.Models;

namespace ContosoUniversity.FunctionalTests.PageObjects
{
    public class StudentDetailsPage : Page<StudentDetailsViewModel>
    {
    }

    public class StudentDetailsViewModel
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
    }
}