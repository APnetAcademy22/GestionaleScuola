using GestionaleLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.SQL
{
    public class SubjectConnector
    {
        public static int PersistSubject(Subject subject)
        {
            var query = "INSERT INTO subject ( Name, Description, Credits, Hours ) " +
                            "OUTPUT inserted.IdSubject " +
                            "VALUES(@Name, @Description, @Credits, @Hours); ";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", subject.Name);
                command.Parameters.AddWithValue("@Description", subject.Description);
                command.Parameters.AddWithValue("@Credits", subject.Credits);
                command.Parameters.AddWithValue("@Hours", subject.Hours);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static IEnumerable<Subject> RetrieveSubjects()
        {
            var query = "SELECT IdSubject, Name, Description, Credits, Hours FROM Subject";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Subject subject = new Subject()
                {
                    IdSubject = int.Parse(reader["IdSubject"].ToString()),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Credits = int.Parse(reader["Credits"].ToString()),
                    Hours = int.Parse(reader["Hours"].ToString())
                };
                yield return subject;
            }
        }

        public static Subject? RetrieveSubjectById(int subjectId)
        {
            var query = "SELECT IdSubject, Name, Description, Credits, Hours FROM Subject WHERE IdSubject = @subjectId ";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@subjectId", subjectId);

            using var reader = command.ExecuteReader();
            Subject subject = null;
            while (reader.Read())
            {
                subject = new Subject()
                {
                    IdSubject = int.Parse(reader["IdSubject"].ToString()),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Credits = int.Parse(reader["Credits"].ToString()),
                    Hours = int.Parse(reader["Hours"].ToString())
                };
               
            }
            return subject;
        }
    }
}
