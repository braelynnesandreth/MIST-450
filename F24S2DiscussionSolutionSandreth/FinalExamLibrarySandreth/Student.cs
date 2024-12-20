using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static FinalExamLibrarySandreth.Registers;

namespace FinalExamLibrarySandreth
{
    public class Student : AppUser
    {

        public string StudentId { get; set; }
        public List<Registers> Registrations { get; set; }

        public Student() : base()
        {
            Registrations = new List<Registers>();
        }

        public Student(string firstName, string lastName, string phoneNumber, string email, string password)
            : base(firstName, lastName, phoneNumber, email, password)
        {
            Registrations = new List<Registers>();
        }


        public bool CheckPrerequisitesForCourse(Course course)
        {

            foreach (var prereqCourse in course.RequiredCourses)
            {
                var prereqRegistration = Registrations
                    .FirstOrDefault(r => r.CourseOffering.Course == prereqCourse && r.Grade != Registers.LetterGrade.F);
                if (prereqRegistration == null) return false;
            }
            return true;
        }


        public string GenerateStudentTranscript(string semester)
        {
            var transcript = $"Transcript for {semester}:\n";


            var semesterRegistrations = Registrations.Where(r => r.Semester == semester).ToList();

            if (!semesterRegistrations.Any())
            {
                transcript += "No courses registered for this semester.";
                return transcript;
            }


            foreach (var registration in semesterRegistrations)
            {
                var course = registration.CourseOffering.Course;
                transcript += $"{course.CourseNumber} - {course.Title}: Grade {registration.Grade}\n";
            }

            return transcript;
        }
    }
}

