using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    public class Lesson
    {
        public int IdLesson { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }

        public Lesson(int idLesson, Teacher teacher, Subject subject)
        {
            IdLesson = idLesson;
            Teacher = teacher;
            Subject = subject;
        }
    }
}
