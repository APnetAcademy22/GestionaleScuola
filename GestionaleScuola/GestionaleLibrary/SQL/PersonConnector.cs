using GestionaleLibrary.Entities;
using System.Data.SqlClient;

namespace GestionaleLibrary.SQL
{
    public static class PersonConnector
    {
        public static int PersistPerson(Person person)
        {
            var query = @"INSERT INTO Person ( Name, Surname, BirthDay, Gender, Address) 
                        OUTPUT Inserted.ID 
                        VALUES(@Name, @Surname, @BirthDate, @Gender, @Address)";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDate", person.BirthDate);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static IEnumerable<Person> RetrievePersons()
        {
            var query = "SELECT Id, Name, Surname, BirthDay, Gender, Address FROM Person";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new Person()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDay"].ToString()),
                    Gender = reader["Gender"].ToString(),
                    Address = reader["Address"].ToString()
                };
            }
        }


        public static Person? RetrievePersonById(int idPerson)
        {
            var query = "SELECT Id, Name, Surname, BirthDay, Gender, Address FROM Person WHERE Id=@IdPerson";
            using var connection = new SqlConnection(Constants.SqlConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdPerson", idPerson);
            Person person = null;
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                person = new Person()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDay"].ToString()),
                    Gender = reader["Gender"].ToString(),
                    Address = reader["Address"].ToString()
                };
            }
            return person;
        }
    }
}
