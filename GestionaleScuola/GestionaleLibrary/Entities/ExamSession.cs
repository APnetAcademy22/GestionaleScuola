using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    // corrisponde a elementi exam del DB
    public class ExamSession
    {
        public int IdSession { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime Date { get; set; }
        public Subject Subject { get; set; }

        public ExamSession(int idSession, Teacher teacher, DateTime date, Subject subject)
        {
            IdSession = idSession;
            Teacher = teacher;
            Date = date;
            Subject = subject;
        }
    }
}
