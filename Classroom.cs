using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required]
        [DisplayName("Course")]
        public int CourseId { get; set; }
        [Required]
        [DisplayName("Room")]
        public int RoomId { get; set; }
        [Required]
        [DisplayName("Day")]

        public int DayId { get; set; }
        [Required]
        [DisplayName("From")]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayName("To")]
        public DateTime Endtime { get; set; }
        public bool AlloctionStaus { get; set; }
    }
}