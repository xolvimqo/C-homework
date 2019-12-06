using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFinalProject
{
    public class User
    {
        // Attributes
        public string firstName, lastName, email, phoneNumber;
        public List<string> schools = new List<string>();
        public List<string> programs = new List<string>();
        public List<string> degrees = new List<string>();
        public List<string> companies = new List<string>();
        public List<string> positions = new List<string>();
        public List<int> years = new List<int>();

        // Constructors
        public User() { }

        public User(string fName, string lName, string email, string phoNum)
        {
            firstName = fName;
            lastName = lName;
            this.email = email;
            phoneNumber = phoNum;
        }

        // Setters
        public void AddEducation(string school, string program, string degree)
        {
            this.schools.Add(school);
            this.programs.Add(program);
            this.degrees.Add(degree);
        }

        public void AddWorkHistory(string company, string position, int years)
        {
            this.companies.Add(company);
            this.positions.Add(position);
            this.years.Add(years);
        }

        // Getters
        public string GetFirstName() => firstName;
        public string GetLastName() => lastName;
        public string GetEmail() => email;
        public string GetPhoneNumber() => phoneNumber;
        public void PresentInformation()
        {
            string info = "Name: " + firstName
                + " " + lastName + "\nEmail: " 
                + email + "\nPhone Number: ";
            for (int i = 0; i < schools.Count; i++)
            {
                info += "\nSchool: " + schools[i]
                    + "\nProgram: " + programs[i]
                    + "\nDegree: " + degrees[i];
            }
            for (int i = 0; i < companies.Count; i++)
            {
                info += "\nCompany: " + companies[i]
                    + "\nPosition: " + positions[i]
                    + "\nYears: " + years[i];
            }
        }
    }
}
