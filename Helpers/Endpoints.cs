


using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityApp.Helpers
{

        public class Endpoints
    {
        #region Courses
        public static string GET_COURSES = "api/Courses/GetCourses/";
        public static string GET_COURSE = "api/Courses/GetCourse/";
        public static string GET_COURSE_BY_STUDENT = "api/Courses/GetCoursesByStudentId/";
        public static string GET_COURSE_BY_INSTRUCTOR = "api/Courses/GetCoursesByInstructorId/";


        public static string POST_COURSES = "api/Courses/";
        public static string PUT_COURSES = "api/Courses/";
        public static string DELETE_COURSES = "api/Courses/";
        #endregion

        #region CourseInstructors
        public static string GET_COURSE_INSTRUCTORS = "/api/CourseInstructors/";
        #endregion


        #region Instructors
        public static string GET_INSTRUCTORS = "/api/Instructors/GetInstructors/";
        public static string POST_INSTRUCTORS = "/api/Instructors/";
        public static string PUT_INSTRUCTORS = "/api/Instructors/";
        public static string DELETE_INSTRUCTORS = "/api/Instructors/";
        #endregion

        #region Students
        public static string GET_STUDENTS = "/api/Students/GetStudents/";
        public static string POST_STUDENTS = "/api/Students/";
        public static string PUT_STUDENTS = "/api/Students/";
        public static string DELETE_STUDENTS = "/api/Students/";

        #endregion
                     

        #region Departments
        public static string GET_DEPARTMENTS = "/api/Departments/";
        #endregion

        #region OfficeAssignments
        public static string GET_OFFICE_ASSIGNMENTS = "/api/OfficeAssignments/";
        #endregion

        #region Enrollments
        public static string GET_ENROLLMENTS = "/api/Enrollments/";
        #endregion

        
    }
}