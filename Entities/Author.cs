namespace Biblioteca.API.Entities;

public class Author
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    private static int nextId = 1;

    private Author()
    {

    }

    public static Author Create(string name)
    {
        
        Author author = new Author();
        author.ChangeName(name);
        author.Id = nextId++;
        return author;

    }
    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("O nome é obrigatório.");
        }
        Name = name.Trim();
    }
}