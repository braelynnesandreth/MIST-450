using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalExamLibrarySandreth;

namespace FinalExamTestSandreth
{
    public class StudentTests
    {
        [Fact]
        public void CheckPrerequisitesForCourse_ReturnsTrueIfPrerequisitesMet()
        {
            // AAA Pattern

            //Arrange
            string courseToCheck = "CS201";
            bool expectedCanTake = true;
            List<Student> testStudents = CreateTestData();
            Student testStudent = testStudents[0];
            Course course = testStudent.Registrations
           .First(r => r.CourseOffering.Course.CourseNumber == courseToCheck)
           .CourseOffering.Course;

            //Act
            bool actualCanTake = testStudent.CheckPrerequisitesForCourse(course);

            // Assert
            Assert.Equal(expectedCanTake, actualCanTake);
        }

        [Fact]
        public void GenerateStudentTranscript_ReturnsNoCoursesRegisteredMessageIfNoCoursesForSemester()
        {
            // AAA Pattern

            //Arrange 
            string semester = "Spring2025";
            string expectedTranscript = $"Transcript for {semester}:\nNo courses registered for this semester.";
            List<Student> testStudents = CreateTestData();
            Student testStudent = testStudents[0];

            //Act
            string actualTranscript = testStudent.GenerateStudentTranscript(semester);

            //Assert
            Assert.Equal(expectedTranscript, actualTranscript);
        }

        public List<Student> CreateTestData()
        {
            
            var course101 = new Course("CS101", "Introduction to Programming", 3, 30);
            var course201 = new Course("CS201", "Data Structures", 3, 25);
            var course301 = new Course("CS301", "Algorithms", 3, 20);

           
            course201.RequiredCourses.Add(course101);
            
            course301.RequiredCourses.Add(course201);

           
            var student = new Student("John", "Doe", "555-0001", "john.doe@university.edu", "Password123!");

            var registration101 = new Registers(student, new CourseOffering(course101, "Fall2024", 1, "MWF 10:00-10:50"), "Fall2024")
            {
                Grade = Registers.LetterGrade.A,
                GradePoints = 4.0
            };
            student.Registrations.Add(registration101);

            
            var registration201 = new Registers(student, new CourseOffering(course201, "Fall2024", 2, "TTh 2:00-3:30"), "Fall2024")
            {
                Grade = Registers.LetterGrade.B,
                GradePoints = 3.0
            };
            student.Registrations.Add(registration201);

            
            var registration301 = new Registers(student, new CourseOffering(course301, "Fall2024", 3, "TTh 3:30-5:00"), "Fall2024")
            {
                Grade = Registers.LetterGrade.B,
                GradePoints = 3.0
            };
            student.Registrations.Add(registration301);

           
            return new List<Student> { student };
        }
    }
}