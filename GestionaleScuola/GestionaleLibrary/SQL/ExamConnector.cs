using GestionaleLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.SQL
{
    public class ExamConnector
    {
        public static int PersistExamSession(Exam exam)
        {
            if (TeacherConnector.RetrieveTeacherById(exam.SessionId) == null
                    || SubjectConnector.RetrieveSubjectById(exam.StudentId) == null)
            {
                throw new Exception("Invalid session or student in exam insertion into database.");
            }
            else
            {
                var query = "INSERT INTO ExamDetails(IdStudent, IdExam) " +
                        "OUTPUT inserted.IdExamDetails" +
                        "VALUES(@idStudent, @idExam); ";
                using var connection = new SqlConnection(Constants.SqlConnectionString);
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idStudent", exam.StudentId);
                command.Parameters.AddWithValue("@idExam", exam.IdExam);
                return Convert.ToInt32(command.ExecuteScalar());
            }

        }

        public static IEnumerable<Exam> RetrieveExam()
        {
            var query = "SELECT IdExamDetails, IdStudent, IdExam FROM ExamDetails ";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Exam ex = new Exam()
                {
                    SessionId = int.Parse(reader["IdExam"].ToString()),
                    IdExam = int.Parse(reader["IdExamDetails"].ToString()),
                    StudentId = int.Parse(reader["IdStudent"].ToString()),
                };
                yield return ex;
            }
        }

        public static Exam? RetrieveExamById(int examId)
        {
            var query = "SELECT IdExamDetails, IdStudent, IdExam FROM ExamDetails WHERE IdExamDetails = @examId";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
                command.Parameters.AddWithValue("@examId", examId);
            Exam ex = null;
            while (reader.Read())
            {
                ex = new Exam()
                {
                    SessionId = int.Parse(reader["IdExam"].ToString()),
                    IdExam = int.Parse(reader["IdExamDetails"].ToString()),
                    StudentId = int.Parse(reader["IdStudent"].ToString()),
                };

            }
            return ex;
        }

    }
}
