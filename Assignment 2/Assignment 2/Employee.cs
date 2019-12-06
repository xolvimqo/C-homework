using System;

namespace Assignment_2
{
    public class Employee
    {
        // Attributes
        public string firstName, lastName, employeeID, designation;

        // Constructors
        public Employee(){ }
        public Employee(string fName, string lName, string empID, string designation)
        {
            firstName = fName;
            lastName = lName;
            employeeID = empID;
            this.designation = designation;
        }

        // Setter Methods
        public void SetFirstName(string fName)
        {
            firstName = fName;
        }

        public void SetLastName(string lName)
        {
            lastName = lName;
        }

        public void SetEmployeeID(string empID)
        {
            employeeID = empID;
        }

        public void SetDesignation(string designation)
        {
            this.designation = designation;
        }

        // Getter Methods
        public string GetFirstName() => firstName;

        public string GetLastName() => lastName;

        public string GetEmployeeID() => employeeID;

        public string GetDesignation() => designation;

        public void PresentInformation()
        {
            string info = "Name: " + firstName + " " + lastName + "\nEmployee ID: " + employeeID +
                "\nDesignation: " + designation;
            Console.WriteLine(info);
        }
    }
}
