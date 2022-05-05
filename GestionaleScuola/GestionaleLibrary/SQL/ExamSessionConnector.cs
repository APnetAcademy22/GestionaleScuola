using GestionaleLibrary.Entities;
using System.Data.SqlClient;

namespace GestionaleLibrary.SQL
{
    public class ExamSessionConnector
    {
        public static int PersistExamSession(ExamSession examSession)
        {
            if (TeacherConnector.RetrieveTeacherById(examSession.TeacherId) == null
                    || SubjectConnector.RetrieveSubjectById(examSession.SubjectId) == null)
            {
                throw new Exception("Invalid teacher or subject in subject insertion into database.");
            }
            else
            {
                var query = "INSERT INTO Exam (IdTeacher, Date, IdSubject) " +
                        "OUTPUT inserted.IdExam " +
                        "VALUES(@IdTeacher, @date, @SubjectId); ";
                using var connection = new SqlConnection(Constants.SqlConnectionString);
                connection.Open();
                using var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdTeacher", examSession.TeacherId);
                    command.Parameters.AddWithValue("@date", examSession.Date);
                    command.Parameters.AddWithValue("@SubjectId", examSession.SubjectId);
                return Convert.ToInt32(command.ExecuteScalar());
            }

        }

        public static IEnumerable<ExamSession> RetrieveExamSessions()
        {
            var query = "SELECT IdExam, idTeacher, Date, IdSubject FROM Exam";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new ExamSession()
                {
                    IdSession = int.Parse(reader["IdExam"].ToString()),
                    TeacherId = int.Parse(reader["IdTeacher"].ToString()),
                    Date = DateTime.Parse(reader["Date"].ToString()),
                    SubjectId = int.Parse(reader["IdSubject"].ToString()),
                };
            }
        }

        public static ExamSession? RetrieveExamSessionById(int sessionId)
        {
            var query = "SELECT IdExam, idTeacher, Date, IdSubject FROM Exam WHERE IdExam = @sessionId";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
                command.Parameters.AddWithValue("@sessionId", sessionId);
            ExamSession exSession = null;
            while (reader.Read())
            {
                exSession = new ExamSession()
                {
                    IdSession = int.Parse(reader["IdExam"].ToString()),
                    TeacherId = int.Parse(reader["IdTeacher"].ToString()),
                    Date = DateTime.Parse(reader["Date"].ToString()),
                    SubjectId = int.Parse(reader["IdSubject"].ToString()),
                };
                
            }
            return exSession;
        }

    }
}
