// See https://aka.ms/new-console-template for more information
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

IEnumerable<ExamSession> sessions = ExamSessionConnector.RetrieveExamSessions();
IEnumerable<Teacher> teachers = TeacherConnector.RetrieveTeachers();

List<Teacher> maleTeachers = teachers.Where(t => string.Equals(t.Gender, "male", StringComparison.CurrentCultureIgnoreCase) ).ToList<Teacher>();
foreach(Teacher teacher in maleTeachers)
{
    Console.WriteLine($"{teacher.Name} {teacher.Surname}");
}


