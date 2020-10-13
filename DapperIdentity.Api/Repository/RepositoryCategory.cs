using Dapper;
using DapperIdentity.Api.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperIdentity.Api.Repository
{
    public class RepositoryCategory : IRepositoryCategory
    {

        private readonly IConfiguration _configuration;

        public RepositoryCategory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Category entity)
        {
            string sql = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName) RETURNING CategoryId";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            return await connection.ExecuteAsync(sql, entity);
        }

        public async void Delete(int id)
        {
            string sql = "DELETE FROM Categories WHERE CategoryId = @CategoryId";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            await connection.QueryAsync(sql, new { CategoryId = id });
        }

        public async Task<IEnumerable<Category>> Get()
        {
            string sql = "SELECT * FROM Categories";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            return await connection.QueryAsync<Category>(sql);
        }

        public async Task<Category> Get(int id)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            var result = connection.QueryAsync<Category>(sql, new { CategoryId = id }).Result.FirstOrDefault();

            return result;
        }

        public async Task<int> Update(Category entity)
        {
            string sql = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            return await connection.ExecuteAsync(sql, entity);
        }
    }
}
