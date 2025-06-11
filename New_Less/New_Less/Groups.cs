namespace New_less;
public class Groups: IEnumerable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public Student[]? Students { get; set; }

}
