using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    public class Subject
    {
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }

        public Subject (int idSubject, string name, string description, int credits, int hours)
        {
            IdSubject = idSubject;
            Name = name;
            Description = description;
            Credits = credits;
            Hours = hours;
        }
    }
}
