namespace Implementation;

public record class EnableToEqualsOperator(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}