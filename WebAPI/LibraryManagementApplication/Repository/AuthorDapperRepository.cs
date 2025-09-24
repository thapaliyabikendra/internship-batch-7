using System.Data;
using Contract.Repository;
using Dapper;
using Domain.DTO;
using Domain.Entities.Application;
using Microsoft.Data.Sqlite;

namespace LibraryManagementApplication.Repository;

public class AuthorDapperRepository : IAuthorRepository
{
    private readonly string _connectionString;

    public AuthorDapperRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default");
    }

    private IDbConnection CreateConnection()
    {
        return new SqliteConnection(_connectionString);
    }

    public async Task<Guid> AddAsync(Author entity)
    {
        entity.Id = Guid.NewGuid();

        const string sql =
            @"
        INSERT INTO Authors (Id, Name, Country)
        VALUES (@Id, @Name, @Country);";
        using var connection = CreateConnection();
        await connection.ExecuteAsync(sql, entity);
        return entity.Id;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM Authors WHERE Id = @Id";

        using var connection = CreateConnection();
        var rows = await connection.ExecuteAsync(sql, new { Id = id });

        return rows > 0;
    }

    public async Task<IEnumerable<GetAuthorDto>> GetAllAsync()
    {
        const string sql = "SELECT  Name, Country FROM Authors";

        using var connection = CreateConnection();
        return await connection.QueryAsync<GetAuthorDto>(sql);
    }

    public async Task<GetAuthorDto?> GetByIdAsync(Guid id)
    {
        const string sql = "SELECT  Name, Country FROM Authors WHERE Id = @Id";

        using var connection = CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<GetAuthorDto>(sql, new { Id = id });
    }

    public async Task<bool> UpdateAsync(Author entity)
    {
        const string sql =
            @"
            UPDATE Authors 
            SET Name = @Name, Country = @Country 
            WHERE Id = @Id;";

        using var connection = CreateConnection();
        var affectedRows = await connection.ExecuteAsync(sql, entity);
        return affectedRows > 0;
    }
}
