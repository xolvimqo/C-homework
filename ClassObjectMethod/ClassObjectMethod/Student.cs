using System;
using System.Collections.Generic;
using System.Text;

namespace ClassObjectMethod
{
    class Student
    {
        public string firstName, lastName, course;
        public int studentId;

        public void SetStudent(int stuId, string fName, string lName, string course)
        {
            studentId = stuId;
            firstName = fName;
            lastName = lName;
            this.course = course;
        }

        // Getters
        public int GetStudentId()
        {
            return studentId;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetCourse()
        {
            return course;
        }
    }
}
