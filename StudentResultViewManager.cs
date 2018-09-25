using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class StudentResultViewManager
    {
        StudentResultViewGateway studentResultViewGateway=new StudentResultViewGateway();

        public List<StudentResultView> GetStudentResultByStudentId(int studentId)
        {
            return studentResultViewGateway.GetStudentResultByStudentId(studentId);
        }

    }
}