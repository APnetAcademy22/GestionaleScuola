namespace GestionaleLibrary.Entities
{
    public class Student : Person
    {
        public int StudentId { get; set; }
        public string Matricola { get; set; }
        public DateTime EnrollDate { get; set; }
    }
}
