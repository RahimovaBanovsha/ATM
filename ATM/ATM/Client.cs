namespace ATM;
public class Client
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public BankCard BankAccount { get; set; }
    public Client(Guid id, string name, string surname, int age, decimal salary, BankCard bankAccount)
    {
        ID = id;
        Name = name;
        Surname = surname;
        Age = age;
        Salary = salary;
        BankAccount = bankAccount;
    }
    public string GetFullName() => $"{Name} {Surname}";
    public override string ToString()
    {
        return $"Name: {Name}, Surname: {Surname}, Age: {Age}, Bank: {BankAccount.BankName}";
    }
}