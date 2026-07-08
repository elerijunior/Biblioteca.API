using System.Reflection.Metadata.Ecma335;
using Biblioteca.API.Entities;
using Npgsql;
using Npgsql.Internal;

namespace Biblioteca.API.DAO;

public class AuthorDAO
{
	private readonly string connectionString;

		public AuthorDAO(string connectionString)
		{
			this.connectionString = connectionString;
		}


		public List<Author> GetAll()
		{
			List<Author> authors = new();

			using var connection = new NpgsqlConnection(connectionString);

			connection.Open();

			string sql = @"SELECT Id, Name FROM Authors";

			using var command = new NpgsqlCommand(sql, connection);

			using var reader = command.ExecuteReader();

			while (reader.Read())
			{
				int id = reader.GetInt32(0);
				string name = reader.GetString(1);
				Author author = Author.Load(id, name);
				authors.Add(author);
			}

			return authors;
		}


		public void Add(Author author)
		{
			using var connection = new NpgsqlConnection(connectionString);
			
			connection.Open();
			
			string sql = @"INSERT INTO Authors (Name) VALUES (@name)";
			
			using var command = new NpgsqlCommand(sql, connection);

			command.Parameters.AddWithValue("@name", author.Name);

			command.ExecuteNonQuery();
		}

		public Author? GetById(int id)
		{

			using var connection = new NpgsqlConnection(connectionString);

			connection.Open();

			string sql = @"SELECT Id, Name FROM Authors WHERE Id = @id";

			using var command = new NpgsqlCommand(sql, connection);

			command.Parameters.AddWithValue("@id", id);

			using var reader = command.ExecuteReader();

			if (reader.Read())
			{
			int authorId = reader.GetInt32(0);
				string name = reader.GetString(1);
				return Author.Load(authorId, name);
			}
			return null;
		}

		public void Update(Author author)
		{
			using var connection = new NpgsqlConnection(connectionString);

			connection.Open();

			string sql = @"UPDATE Authors SET Name = @name WHERE Id = @id";

			using var command = new NpgsqlCommand(sql, connection);

			command.Parameters.AddWithValue("@name", author.Name);

			command.Parameters.AddWithValue("@id", author.Id);

			command.ExecuteNonQuery();
		}

		public void Delete(int id)
		{
			using var connection = new NpgsqlConnection(connectionString);

			connection.Open();

			string sql = @"DELETE FROM Authors WHERE Id = @id";

			using var command = new NpgsqlCommand(sql, connection);

			command.Parameters.AddWithValue("@id", id);

			command.ExecuteNonQuery();
			
		}
}