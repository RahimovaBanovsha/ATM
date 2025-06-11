using System.Security.Principal;

namespace New_less;
public class Student
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public Student(Guid ıd, string? name, string? surname, DateTime birthDate)
    {
        Id = ıd;
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
    }
    public override string ToString()
    => $"Id: {Id}   | Name: {Name}  |  Surname: {Surname}  | Birthdate: {BirthDate} ";
}
