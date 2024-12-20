using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FinalExamLibrarySandreth
{
    public class Course
    {
        [Key]
        public string CourseNumber { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int MaxCapacity { get; set; }

      
        public List<CourseOffering> CourseOfferings { get; set; }
        public List<Course> RequiredCourses { get; set; }
        public List<Course> IsRequiredFor { get; set; }

        public Course()
        {
            CourseOfferings = new List<CourseOffering>();
            RequiredCourses = new List<Course>();
            IsRequiredFor = new List<Course>();
        }

        public Course(string courseNumber, string title, int credits, int maxCapacity) : this()
        {
            CourseNumber = courseNumber;
            Title = title;
            Credits = credits;
            MaxCapacity = maxCapacity;
        }
    }

}
