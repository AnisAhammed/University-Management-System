﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string RegNo { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact is required!")]
        [DisplayName("Contact No.")]
        public string Contact { get; set; }
        [DisplayName("Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        public string Address { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
    }
}