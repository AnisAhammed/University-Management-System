﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ClassSchedule
    {
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string ScheduleInfo { get; set; }
    }
}