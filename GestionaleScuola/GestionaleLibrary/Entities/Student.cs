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
        public DateOnly EnrollDate { get; set; }

        public Student( int studentId, string matricola, DateOnly enrollDate, int id, string name, string surname, DateOnly birthDay, string gender, string address) : base(id,name, surname, birthDay, gender, address)
        {
            StudentId = studentId;
            Matricola = matricola;
            EnrollDate = enrollDate;
        }
    }
}
