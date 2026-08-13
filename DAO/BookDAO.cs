using System.Reflection.Metadata.Ecma335;
using Biblioteca.API.Entities;
using Npgsql;
using Npgsql.Internal;

namespace Biblioteca.API.DAO;

public class BookDAO
{
    private readonly string connectionString;

    public BookDAO(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<Book>GetAll()
    {
        List<Book> books = new();

        using var connection = new NpgsqlConnection(connectionString);

        connection.Open();

        string sql = @"SELECT Id, Title, Year FROM Books";

        using var command = new NpgsqlCommand(sql, connection);

        using var reader = command.ExecuteReader();

        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            int year = reader.GetInt32(2);
            Book book = Book.Load(id, title, year);
            books.Add(book);
        }

        return books;
    }

    public void Add(Book book)
		{
			using var connection = new NpgsqlConnection(connectionString);
			
			connection.Open();
			
			string sql = @"INSERT INTO Books (Title) VALUES (@title)";
			
			using var command = new NpgsqlCommand(sql, connection);

			command.Parameters.AddWithValue("@title", book.Title);

			command.ExecuteNonQuery();
		}
}