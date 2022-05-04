using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    internal class Class
    {
        public int IdClass { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public Class (int idClass, Student student, Lesson lesson)
        {
            IdClass = idClass;
            Student = student;
            Lesson = lesson;
        }
    }
}
