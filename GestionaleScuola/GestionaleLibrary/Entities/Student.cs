using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    public class Student : Person
    {
        public int StudentId { get; set; }
        public string Matricola { get; set; }
        public DateTime EnrollDate { get; set; }

        public static void AddStudent(Student student)
        {

        }
    }
}
