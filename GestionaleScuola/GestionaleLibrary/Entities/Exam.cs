using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Entities
{
    // represents 'examDetails' of the DB
    public class Exam
    {
        public int IdExam { get; set; }
        public ExamSession Session { get; set; }
        public Student Student { get; set; }

        public Exam(int idExam, ExamSession session, Student student)
        {
            IdExam = idExam;
            Session = session;
            Student = student;
        }

    }
}
