using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public string Save(Student aStudent)
        {
            int counter;
            Departments department = departmentGateway.GetAllDepartments().Single(depid => depid.DepartmentId == aStudent.DepartmentId);
            string searchKey = department.DepartmentCode + "-" + aStudent.Date.Year + "-";
            string lastAddedRegistrationNo = GetLastAddedStudentRegistration(searchKey);

            if (lastAddedRegistrationNo == null)
            {
                aStudent.RegNo = searchKey + "001";

            }

            if (lastAddedRegistrationNo != null)
            {
                string tempId = lastAddedRegistrationNo.Substring((lastAddedRegistrationNo.Length - 3), 3);
                counter = Convert.ToInt32(tempId);
                string studentSl = (counter + 1).ToString();


                if (studentSl.Length == 1)
                {

                    aStudent.RegNo = searchKey + "00" + studentSl;

                }
                else if (studentSl.Count() == 2)
                {

                    aStudent.RegNo = searchKey + "0" + studentSl;
                }
                else
                {

                    aStudent.RegNo = searchKey + studentSl;
                }

            }
            var listOfEmailAddress = from student in GetAllStudents()
                                     select student.Email;
            string tempEmail = listOfEmailAddress.ToList().Find(email => email.Contains(aStudent.Email));

            if (tempEmail != null)
            {
                return "Email address must be unique";
            }
            if (IsEmailAddressValid(aStudent.Email))
            {
                if (studentGateway.Insert(aStudent) > 0)
                {
                    return "Saved Successfully!;Registration No:" + aStudent.RegNo + ";Name:" + aStudent.Name + ";Email:" + aStudent.Email + ";Contact Number:" + aStudent.Contact;
                }

                return "Failed to save";
            }
            return "Please! enter a valid email address";
        }

        private bool IsEmailAddressValid(string email)
        {
            if (email.Contains(".com") && ((email.Contains("@gmail")) || (email.Contains("@yahoo")) || (email.Contains("@live")) || (email.Contains("@outlook"))))
            {
                return true;
            }
            return false;


        }

        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }
    

        public string GetLastAddedStudentRegistration(string searchKey)
        {
            return studentGateway.GetLastAddedStudentRegistration(searchKey);

        }
    }
}