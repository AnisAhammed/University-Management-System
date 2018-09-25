using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AssignTeachers
    {
        public int AssignId { get; set; }        
        public int DepartmentId { get; set; }        
        public int TeacherId { get; set; }     
        public float CreditTaken { get; set; }
        public float RemainingCredit { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public float CourseCredit { get; set; }
        public bool Status { get; set; }
    }
}