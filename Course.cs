using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCredit { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int SemisterId { get; set; }
    }
}