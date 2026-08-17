using System.Reflection.Metadata.Ecma335;
using Biblioteca.API.Entities;
using Npgsql;
using Npgsql.Internal;
using Biblioteca.API.DAO.Interface;

namespace Biblioteca.API.DAO;

public class AuthorDAO : IAuthorDAO
{

	private readonly string _connectionString;

	public AuthorDAO(IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("DefaultConnection")
		?? throw new Exception("Connection String não encontrada.");
	}


	public List<Author> GetAll()
	{
		List<Author> authors = new();

		using var connection = new NpgsqlConnection(_connectionString);

		connection.Open();

		string sql = @"SELECT Id, Name FROM Authors";

		using var command = new NpgsqlCommand(sql, connection);

		using var reader = command.ExecuteReader();

		while (reader.Read())
		{
			int id = reader.GetInt32(0);
			string name = reader.GetString(1);
			Author author = new Author(id, name);
			authors.Add(author);
		}

		return authors;
	}


	public void Add(Author author)
	{
		using var connection = new NpgsqlConnection(_connectionString);

		connection.Open();

		string sql = @"INSERT INTO Authors (Name) VALUES (@name) RETURNING Id";

		using var command = new NpgsqlCommand(sql, connection);

		command.Parameters.AddWithValue("@name", author.Name);

        int id = Convert.ToInt32(command.ExecuteScalar());
        author.SetId(id);
    }

	public Author? GetById(int _id)
	{
		using var connection = new NpgsqlConnection(_connectionString);

		connection.Open();

		string sql = @"SELECT Id, Name FROM Authors WHERE Id = @id";

		using var command = new NpgsqlCommand(sql, connection);

		command.Parameters.AddWithValue("@id", _id);

		using var reader = command.ExecuteReader();

		if (reader.Read())
		{
			int id = reader.GetInt32(0);
			string name = reader.GetString(1);
			//return Author.Load(authorId, name);
			return new Author(id, name);
		}
		return null;
	}

	public void Update(Author author)
	{
		using var connection = new NpgsqlConnection(_connectionString);

		connection.Open();

		string sql = @"UPDATE Authors SET Name = @name WHERE Id = @id";

		using var command = new NpgsqlCommand(sql, connection);

		command.Parameters.AddWithValue("@name", author.Name);

		command.Parameters.AddWithValue("@id", author.Id);

		command.ExecuteNonQuery();
	}

	public void Delete(int id)
	{
		using var connection = new NpgsqlConnection(_connectionString);

		connection.Open();

		string sql = @"DELETE FROM Authors WHERE Id = @id";

		using var command = new NpgsqlCommand(sql, connection);

		command.Parameters.AddWithValue("@id", id);

		command.ExecuteNonQuery();
	}
}