using GestionaleLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.SQL
{
    public class StudentConnector
    {
        public static int PersistStudent(Student student)
        {
            if(PersonConnector.RetrievePersons().Any(person => person.Id == student.Id))
            {
                return AddStudent(student);
            }
            else
            {
                int id = PersonConnector.PersistPerson(student);
                student.Id = id;
                return AddStudent(student);
            }
            
        }

        public static IEnumerable<Student> RetrieveStudents()
        {
            var query = "SELECT IdStudente,IdPerson, Matricola, DataIscrizione FROM Student";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student()
                {
                    StudentId = int.Parse(reader["IdStudente"].ToString()),
                    Id = int.Parse(reader["IdPerson"].ToString()),
                    Matricola = reader["Matricola"].ToString(),
                    EnrollDate = DateTime.Parse(reader["DataIscrizione"].ToString())
                };
                yield return student;
            }
        }

        private static int AddStudent(Student student)
        {
            var query = "INSERT INTO Student(IdPerson, Matricola, DataIscrizione) " +
                        "OUTPUT inserted.IdStudente " +
                        "VALUES(@IdPerson, @Matricola, @DataIscrizione); ";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPerson", student.Id);
                command.Parameters.AddWithValue("@Matricola", student.Matricola);
                command.Parameters.AddWithValue("@DataIscrizione", student.EnrollDate);
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
