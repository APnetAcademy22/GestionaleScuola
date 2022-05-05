
using GestionaleLibrary.Entities;
using GestionaleLibrary.SQL;

Console.WriteLine("Welcome!");
//add random shit to tables
/*
TeacherConnector.PersistTeacher( new Teacher
                                    {
                                        Address = "Via del progresso 93",
                                        BirthDate = DateTime.Now,
                                        Gender = "Male",
                                        HireDate = DateTime.Now,
                                        Matricola = "tc331",
                                        Name = "Guido",
                                        Surname = "Lavespa"
                                    });;
ExamSessionConnector.PersistExamSession( new ExamSession
                                        {
                                            Date = DateTime.Now,
                                            SubjectId = 1,
                                            TeacherId = 2
                                        });
*/

//PROVA DI QUERY IN LINQ (MOLTO INEFFICIENTE)
IEnumerable<ExamSession> sessions = ExamSessionConnector.RetrieveExamSessions();
IEnumerable<Teacher> teachers = TeacherConnector.RetrieveTeachers();
IEnumerable<Student> students = StudentConnector.RetrieveStudents();
IEnumerable<Subject> subjects = SubjectConnector.RetrieveSubjects();
IEnumerable<Exam> exams = ExamConnector.RetrieveExams();

List<Teacher> maleTeachers = teachers.Where(t => string.Equals(t.Gender, "male", StringComparison.CurrentCultureIgnoreCase) ).ToList<Teacher>();
foreach(Teacher teacher in maleTeachers)
{
    Console.WriteLine($"{teacher.Name} {teacher.Surname}");
}

var sessionsQuery = from teacher in teachers
                        join session in sessions on teacher.TeacherId equals session.TeacherId
                        join subject in subjects on session.SubjectId equals subject.IdSubject
                        select $"{teacher.Name}, {teacher.Surname}, {session.Date}, {subject.Name}";

Console.WriteLine($"List of sessions: ");
foreach(var sessionDetails in sessionsQuery)
{
    Console.WriteLine(sessionDetails);
}


