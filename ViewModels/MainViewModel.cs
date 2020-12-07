using System.Threading.Tasks;
using UniversityApp.Views;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class MainViewModel
    {
       // public CourseViewModel Courses { get; set; }
        public CourseInstructorsViewModel CourseInstructors { get; set; }
        public MoviesViewModel Movies { get; set; }
        public StudentsViewModel Students { get; set; }
        public DepartmentsViewModel Departments { get; set; }
        public InstructorViewModel Instructors { get; set; }
        public EnrollmentViewModel Enrollments { get; set; }
        public OfficeAssignmentViewModel OfficeAssignments { get; set; }
        public CreateCourseViewModel CreateCourse { get; set; }
        public CreateStudentViewModel CreateStudent { get; set; }
        public CreateInstructorViewModel CreateInstructor { get; set; }
        public LoginViewModel Login { get; set; }
        public HomeViewModel Home { get; set; }
        public EditStudentViewModel EditStudent { get; set; }
        public EditInstructorViewModel EditInstructor { get; set; }




        public MainViewModel()
        {
            instance = this;
            //Courses = new CourseViewModel();
            Departments = new DepartmentsViewModel();
            CourseInstructors = new CourseInstructorsViewModel();
            Students = new StudentsViewModel();
            OfficeAssignments = new OfficeAssignmentViewModel();
            Instructors = new InstructorViewModel();
            Enrollments = new EnrollmentViewModel();            
            CreateCourse = new CreateCourseViewModel();
            CreateInstructor = new CreateInstructorViewModel();
            CreateStudent = new CreateStudentViewModel();
            
            Login = new LoginViewModel();
            Home = new HomeViewModel();


            CreateInstructorCommand = new Command(async () => await GoToCreateInstructor());
            CreateStudentCommand = new Command(async () => await GoToCreateStudent());
            
            //Movies = new MoviesViewModel();
            //CreateCourseCommand = new Command(async () => await GoToCreateCourse());

        }



        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();

            return instance;
        }

        public Command CreateInstructorCommand { get; set; }
        async Task GoToCreateInstructor()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateInstructorPage());
        }

        public Command CreateStudentCommand { get; set; }
        async Task GoToCreateStudent()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateStudentPage());
        }




        //public Command CreateCourseCommand { get; set; }
        //async Task GoToCreateCourse()
        //{
        //    await Application.Current.MainPage.Navigation.PushAsync(new CreateCoursePage());
        //}
        


    }
}
