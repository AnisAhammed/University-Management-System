using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class AssignTeacherGateway : Gateway
    {
        TeacherManager aTeacherManager = new TeacherManager();
        //public int Save(AssignTeachers assigns)
        //{
        //    Query = "INSERT INTO Assign(DepartmentId,TeacherId,CourseId,IsActive) Values(@deptId,@teacherId,@courseId,@status)";
        //    Command = new SqlCommand(Query, Connection);
        //    Command.Parameters.AddWithValue("@deptId", assigns.DepartmentId);
        //    Command.Parameters.AddWithValue("@teacherId", assigns.TeacherId);
        //    Command.Parameters.AddWithValue("@courseId", assigns.CourseId);
        //    Command.Parameters.AddWithValue("@status", 1);
        //    Connection.Open();
        //    int rowCount = Command.ExecuteNonQuery();
        //    Connection.Close();
        //    return rowCount;
        //}

        //private int UpdateTeacher(AssignTeachers assignTeachers)
        //{
        //    Teacher teacher = aTeacherManager.GetAllTeachers().ToList().Find(t => t.TeacherId == assignTeachers.TeacherId);

        //    double creditTakenbyTeacher = Convert.ToDouble(teacher.CreditTaken) + Convert.ToDouble(assignTeachers.CourseCredit);
        //    Query = "Update Teacher Set RemainingCredit='" + creditTakenbyTeacher + "' WHERE TeacherId='" +
        //                             assignTeachers.TeacherId + "'";
        //    return Command.ExecuteNonQuery();
        //}

        //public List<AssignTeachers> GetAllAssignTeachers()
        //{            
        //            Query = "SELECT * FROM Assign";
        //            List<AssignTeachers> assignList = new List<AssignTeachers>();
        //            Connection.Open();
        //            Reader = Command.ExecuteReader();
        //            while (Reader.Read())
        //            {
        //                AssignTeachers assignToTeacher = new AssignTeachers
        //                {
        //                    AssignId = Convert.ToInt32(Reader["AssignId"].ToString()),
        //                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString()),
        //                    TeacherId = Convert.ToInt32(Reader["TeacherId"].ToString()),
        //                    CourseId = Convert.ToInt32(Reader["CourseId"].ToString()),
        //                    Status = Convert.ToBoolean(Reader["IsActive"].ToString())

        //                };
        //                assignList.Add(assignToTeacher);
        //            }
        //            Reader.Close();
        //            Connection.Close();
        //            return assignList;               
        //    }


        //public int Update(AssignTeachers assignTeachers)
        //{           
        //        Query = "UPDATE Assign SET IsActive=1 WHERE TeacherId='" + assignTeachers.TeacherId + "' AND CourseId='" + assignTeachers.CourseId + "'";
        //        Command=new SqlCommand(Query,Connection);
        //        Command.ExecuteNonQuery();

        //        int updateResult = UpdateTeacher(assignTeachers);
        //        return updateResult;
        //    }


        public int Save(AssignTeachers courseAssign)
        {
            Query = "INSERT INTO Assign(DepartmentId,TeacherId,CourseId,IsActive) VALUES(@deptId,@teacherId,@courseId,@status)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@deptId", courseAssign.DepartmentId);
            Command.Parameters.AddWithValue("@teacherId", courseAssign.TeacherId);
            Command.Parameters.AddWithValue("@courseId", courseAssign.CourseId);
            Command.Parameters.AddWithValue("@status", 1);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            int updateResult = UpdateTeacher(courseAssign);
            Connection.Close();
            return rowAffected;

        }



        private int UpdateTeacher(AssignTeachers courseAssign)
        {
            Teacher teacher = aTeacherManager.GetAllTeachers().ToList().Find(t => t.TeacherId == courseAssign.TeacherId);

            double creditTakenbyTeacher = Convert.ToDouble(teacher.RemainingCredit) + Convert.ToDouble(courseAssign.CourseCredit);
            Command.CommandText = "Update Teacher Set RemainingCredit='" + creditTakenbyTeacher + "' WHERE TeacherId='" +
                                     courseAssign.TeacherId + "'";
            return Command.ExecuteNonQuery();
        }

        public List<AssignTeachers> GetAllAssignTeachers()
        {
            Query = "SELECT * FROM Assign";
            Command = new SqlCommand(Query, Connection);
            List<AssignTeachers> assignList = new List<AssignTeachers>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                AssignTeachers assignToTeacher = new AssignTeachers
                {
                    AssignId = Convert.ToInt32(Reader["AssignId"].ToString()),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"].ToString()),
                    TeacherId = Convert.ToInt32(Reader["TeacherId"].ToString()),
                    CourseId = Convert.ToInt32(Reader["CourseId"].ToString()),
                    Status = Convert.ToBoolean(Reader["IsActive"].ToString())

                };
                assignList.Add(assignToTeacher);
            }
            Reader.Close();
            Connection.Close();
            return assignList;
        }

        public int Update(AssignTeachers courseAssign)
        {
            Query = "UPDATE Assign SET IsActive=1 WHERE TeacherId='" + courseAssign.TeacherId + "' AND CourseId='" + courseAssign.CourseId + "'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            int updateResult = UpdateTeacher(courseAssign);
            Connection.Close();
            return updateResult;
        }

    }
}