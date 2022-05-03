using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    public class Teacher : Person
    {
        public int TeacherId { get; set; }
        public string Matricola { get; set; }
        public DateOnly HireDate { get; set; }

        public Teacher(int teacherId, string matricola, DateOnly hireDate, int id, string name, string surname, DateOnly birthDay, string gender, string address) : base(id, name, surname, birthDay, gender, address)
        {
            TeacherId = teacherId;
            Matricola = matricola;
            HireDate = hireDate;
        }
    }
}
