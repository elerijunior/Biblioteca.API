namespace Biblioteca.API.Entities;

public class Author
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private Author()
    {

    }

    public static Author Create(string name)
    {
        
        Author author = new Author();
        author.ChangeName(name);
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

    public static Author Load(int id, string name)
    {
        Author author = new Author();
        author.Id = id;
        author.ChangeName(name);
        return author;
    }
}