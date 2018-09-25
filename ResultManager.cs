using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    
    public class ResultManager
    {
        ResultGateway resultGateway=new ResultGateway();

        public string Save(Result result)
        {
            Result results = GetAllResults().ToList().Find(st => st.StudentId == result.StudentId && st.CourseId == result.CourseId);
            if (results == null)
            {
                if (resultGateway.Insert(result) > 0)
                {
                    return "Saved sucessfull!";
                }
                return "Failed to save";

            }
            if (result.Status)
            {
                return "This course result already saved";
            }
            if (resultGateway.UpdateStudentResult(result) > 0)
            {
                return "Update sucessfull!";
            }

            return "This course result already saved";
        }

        public List<Result> GetAllResults()
        {
            return resultGateway.GetAllResults();
        }

        public List<Course> GetCoursesTakenByaStudentById(int courseId)
        {
            return resultGateway.GetCoursesTakeByaStudentByStudentId(courseId);
        } 


    }
}