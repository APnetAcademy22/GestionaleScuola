﻿using System;
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
        public int SessionId { get; set; }
        public int StudentId { get; set; }


    }
}
