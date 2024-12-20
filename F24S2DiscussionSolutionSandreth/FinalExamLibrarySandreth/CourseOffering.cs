using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FinalExamLibrarySandreth
{
    public class CourseOffering
    {
        [Key]
        public int Id { get; set; }
        public string Semester { get; set; }
        public int SectionNumber { get; set; }
        public string Schedule { get; set; }
        public int AvailableOpenings { get; set; }

        public string CourseNumber { get; set; }
        public Course Course { get; set; }
        public List<Registers> Registrations { get; set; }

        public CourseOffering()
        {
            Registrations = new List<Registers>();
        }

        public CourseOffering(Course course, string semester, int sectionNumber, string schedule)
         : this()
        {
            Course = course;
            Semester = semester;
            SectionNumber = sectionNumber;
            Schedule = schedule;
            AvailableOpenings = course.MaxCapacity;
        }
    }
}
