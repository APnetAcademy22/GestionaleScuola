// See https://aka.ms/new-console-template for more information
using GestionaleLibrary.Entities;
using GestionaleLibrary.SQL;

Console.WriteLine("Welcome!");

/*Person cappuccio = new Person()
{
    Name = "Cappuccetto",
    Surname = "Rosso",
    Address = "Via del Bosco 13",
    BirthDate = new DateTime(1981, 06, 19),
    Gender = "Female"
};

Console.WriteLine($"id of inserted person: {PersonConnector.PersistPerson(cappuccio)}");*/

/*Student student = new Student()
{
    Id = 2,
    Matricola = "ad42314",
    EnrollDate = DateTime.Now
};
Console.WriteLine($"id of inserted student: {StudentConnector.PersistStudent(student)}");*/

IEnumerable<Student> sts = StudentConnector.RetrieveStudents();
foreach (Student s in sts)
{
    Console.WriteLine($"{s.Id} {s.EnrollDate}");
}

/*IEnumerable<Person> people = PersonConnector.RetrievePersons();
foreach(Person person in people)
{
    Console.WriteLine($"{person.Name} {person.BirthDate}");
}*/