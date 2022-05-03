using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    public class Person
    {
       public int Id { get; set; }
       public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public Person(int id, string name, string surname, DateOnly birthDay, string gender, string address)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDay = birthDay;
            Gender = gender;
            Address = address;
        }
    }
}
