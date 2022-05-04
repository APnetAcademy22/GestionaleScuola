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
        public DateTime HireDate { get; set; }

    }
}
