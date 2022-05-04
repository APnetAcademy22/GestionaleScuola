using GestionaleLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.SQL
{
    public class TeacherConnector
    {
        public static int PersistTeacher(Teacher teacher)
        {
            if (PersonConnector.RetrievePersonById(teacher.Id) != null)
            {
                return AddTeacher(teacher);
            }
            else
            {
                int id = PersonConnector.PersistPerson(teacher);
                teacher.Id = id;
                return AddTeacher(teacher);
            }

        }

        public static IEnumerable<Teacher> RetrieveTeachers()
        {
            var query = "SELECT Id, Name, Surname, BirthDay, Gender, Address, IdTeacher, Matricola, DataAssunzione FROM Teacher JOIN Person ON teacher.IdPerson = Person.id ";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    TeacherId = int.Parse(reader["IdTeacher"].ToString()),
                    Id = int.Parse(reader["Id"].ToString()),
                    Matricola = reader["Matricola"].ToString(),
                    HireDate = DateTime.Parse(reader["DataAssunzione"].ToString()),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDay"].ToString()),
                    Gender = reader["Gender"].ToString(),
                    Address = reader["Address"].ToString()
                };
                yield return teacher;
            }
        }

        public static Teacher? RetrieveTeacherById(int idTeacher)
        {
            var query = "SELECT Id, Name, Surname, BirthDay, Gender, Address, IdTeacher, Matricola, DataAssunzione FROM Teacher JOIN Person ON teacher.IdPerson = Person.id " +
                "WHERE Idteacher = @idTeacher ;";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("idTeacher", idTeacher);

            using var reader = command.ExecuteReader();
            Teacher teacher = null;
            while (reader.Read())
            {
                teacher = new Teacher()
                {
                    TeacherId = int.Parse(reader["IdTeacher"].ToString()),
                    Id = int.Parse(reader["Id"].ToString()),
                    Matricola = reader["Matricola"].ToString(),
                    HireDate = DateTime.Parse(reader["DataAssunzione"].ToString()),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDay"].ToString()),
                    Gender = reader["Gender"].ToString(),
                    Address = reader["Address"].ToString()
                };

            }
            return teacher;
        }

        private static int AddTeacher(Teacher teacher)
        {
            var query = "INSERT INTO Teacher(IdPerson, Matricola, DataAssunzione) " +
                        "OUTPUT inserted.IdTeacher " +
                        "VALUES(@IdPerson, @Matricola, @DataAssunzione); ";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.HireDate);
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
