namespace InterfaceAndProperties.Base;
public abstract class Human
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public override string ToString()
    => 
$@"Name: {Name}
Surname: {Surname}
Birth Date: {BirthDate.ToShortDateString()}";
}
