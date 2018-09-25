using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class EnrollStudentManager
    {
        EnrollStudentGateway enrollStudentGateway=new EnrollStudentGateway();
        public string Save(EnrollStudent enrollStudent)
        {
            EnrollStudent enrollStudents = GetEnrollCourses().ToList().Find(st => (st.StudentId == enrollStudent.StudentId && st.CourseId == enrollStudent.CourseId) && (st.Status));
            if (enrollStudents == null)
            {
                if (enrollStudentGateway.Insert(enrollStudent) > 0)
                {
                    return "Saved Successfully!";
                }
                return "Failed to save";
            }

            return "This course already taken by the student";
        }

        public List<EnrollStudent> GetEnrollCourses()
        {
            return enrollStudentGateway.GetEnrollCourses();
        }

        public StudentView GetStudentInformationById(int studentId)
        {
            return enrollStudentGateway.GetStudentInformationById(studentId);
        }
    }
}