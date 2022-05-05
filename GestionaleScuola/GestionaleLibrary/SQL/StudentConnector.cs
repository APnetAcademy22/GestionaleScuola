using GestionaleLibrary.Entities;
using System.Data.SqlClient;

namespace GestionaleLibrary.SQL
{
    public class StudentConnector
    {
        public static int PersistStudent(Student student)
        {
            if(PersonConnector.RetrievePersonById(student.Id)!=null)
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
            var query = "SELECT Id, Name, Surname, BirthDay, Gender, Address, IdStudente, Matricola, DataIscrizione FROM Student JOIN Person ON student.IdPerson = Person.id ";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student()
                {
                    StudentId = int.Parse(reader["IdStudente"].ToString()),
                    Id = int.Parse(reader["Id"].ToString()),
                    Matricola = reader["Matricola"].ToString(),
                    EnrollDate = DateTime.Parse(reader["DataIscrizione"].ToString()),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDay"].ToString()),
                    Gender = reader["Gender"].ToString(),
                    Address = reader["Address"].ToString()
                };
                yield return student;
            }
        }

        public static Student? RetrieveStudentById(int idStudent)
        {
            var query = "SELECT Id, Name, Surname, BirthDay, Gender, Address, IdStudente, Matricola, DataIscrizione FROM Student JOIN Person ON student.IdPerson = Person.id " +
                "WHERE IdStudente = @idStudent ;";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("idStudent", idStudent);

            using var reader = command.ExecuteReader();
            Student student = null;
            while (reader.Read())
            {
                student = new Student()
                {
                    StudentId = int.Parse(reader["IdStudente"].ToString()),
                    Id = int.Parse(reader["Id"].ToString()),
                    Matricola = reader["Matricola"].ToString(),
                    EnrollDate = DateTime.Parse(reader["DataIscrizione"].ToString()),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDay"].ToString()),
                    Gender = reader["Gender"].ToString(),
                    Address = reader["Address"].ToString()
                };
                
            }
            return student;
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
