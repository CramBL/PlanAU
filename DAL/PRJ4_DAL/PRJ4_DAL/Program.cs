using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRJ4_DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<List<Student>> task = DAL_Student.GetStudents();
            List<Student> test = task.Result;

            foreach (Student student in test)
            {
                Console.WriteLine(student.Email);
            }

            Task<Student> task2 = DAL_Student.GetStudent("AU999999");
            Student test2 = task2.Result;

            Console.WriteLine(test2.Au_id);

            Student postStudent = new Student();
            postStudent.Au_id = "AU1234";
            postStudent.Email = "dal@gmail.com";
            postStudent.Password = "Fisk";

            string result = DAL_Student.PostStudent(postStudent).Result;
            Console.WriteLine(result);

            bool result2 = DAL_Student.LoginAttemptAuthorize(postStudent.Au_id, postStudent.Password).Result;
            Console.WriteLine("Authorized: " + result2);
        }
    }
}
