using System;
using System.IO;
using System.Xml.Serialization;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new object
            Employees emps = new Employees(); // object
            emps.CollectionName = "Employees";
            
            // Create three Employee objects
            Employee emp1 = new Employee("Terry", "Gu", "emp001", "computer programmer");
            Employee emp2 = new Employee("Emma", "Watson", "emp002", "actress");
            Employee emp3 = new Employee("Sherlock", "Holmes", "emp003", "detective");

            // Add Employee objects to emps
            emps.Add(emp1);
            emps.Add(emp2);
            emps.Add(emp3);

            // XML Serialization
            XmlSerializer xmlSer = new XmlSerializer(typeof(Employees));

            // use StreamWriter to save xml file
            string path = @"C:\path\employee.xml";
            TextWriter writer = new StreamWriter(path);
            xmlSer.Serialize(writer, emps);
            writer.Close();

            Console.Read();
        }
    }
}
