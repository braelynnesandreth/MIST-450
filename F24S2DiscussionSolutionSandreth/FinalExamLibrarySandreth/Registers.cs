using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FinalExamLibrarySandreth
{
    public class Registers
    {
        [Key]
        public int Id { get; set; }
        public string Semester { get; set; }
        public LetterGrade Grade { get; set; }
        public double GradePoints { get; set; }

        public string StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseOfferingId { get; set; }
        public CourseOffering CourseOffering { get; set; }

        public Registers() { }

        public Registers(Student student, CourseOffering courseOffering, string semester)
        {
            Student = student;
            CourseOffering = courseOffering;
            Semester = semester;
        }
       
        public enum LetterGrade
        {
            A,
            B,
            C,
            D,
            F
        }
    }

}
