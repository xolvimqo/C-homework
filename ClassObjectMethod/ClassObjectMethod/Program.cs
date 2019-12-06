using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using System.Data;

namespace ClassObjectMethod
{
    class Program
    {
        public static int studentId = 200410610;
        public static string firstName = "Terry";
        public static string lastName = "Gu";
        public static string course = "C#";

        static void Main(string[] args)
        {
            Student stu1 = new Student();
            stu1.SetStudent(stuId: studentId, fName: firstName, lName: lastName, course: course);
            Console.WriteLine("\n ======== Serialization \n");
            // JSON Serialization
            string JsonResult = JsonConvert.SerializeObject(stu1);
            Console.WriteLine(JsonResult);

            Console.WriteLine("\n ======== Deserialization \n");
            Student stu2 = JsonConvert.DeserializeObject<Student>(JsonResult);
            Console.WriteLine(stu2.GetStudentId());
            Console.WriteLine(stu2.GetFirstName());
            Console.WriteLine(stu2.GetLastName());
            Console.WriteLine(stu2.GetCourse());

            // use File to save the.JSON file at the given path.
            string path2 = @"C:\path\employee2.json";
            File.WriteAllText(path2, JsonResult);

            // use StreamWriter to save the.JSON file at the given path.
            string path = @"C:\path\employee.json";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JsonResult.ToString());
                tw.Close();
            }

            if (File.Exists(path))
            {
                File.Delete(path);
                File.WriteAllText(path, JsonResult);
            } else if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonResult);
            }

            // Read data from URL
            string jsondataFromUrl;
            string URL = "https://jsonplaceholder.typicode.com/users";
            string path1 = @"D:\Nital\College\Fall 2019\C# Practical\JSON_WithCSharp\jsondataFromUrl.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                // Console.WriteLine(reader.ReadToEnd());
                jsondataFromUrl = reader.ReadToEnd();
            }
            Console.WriteLine(jsondataFromUrl);
            File.WriteAllText(path1, jsondataFromUrl);
            Console.Read();
        }
    }
}
