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
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }

    }
}
