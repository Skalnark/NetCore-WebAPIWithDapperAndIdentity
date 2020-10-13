using Dapper;
using DapperIdentity.Api.Context;
using DapperIdentity.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperIdentity.Api.Repository
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly IConfiguration _configuration;

        public RepositoryProduct(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(Product entity)
        {
            string sql = "INSERT INTO Products (ProductName, Price, CategoryId) VALUES (@ProductName, @Price, @CategoryId) RETURNING ProductId";
            
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            return await connection.ExecuteAsync(sql, entity);
        }

        public async void Delete(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId = @ProductId";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            var result = connection.QueryAsync<Product>(sql, new { ProductId = id });
        }


        public async Task<IEnumerable<Product>> Get()
        {
            string sql = "SELECT * FROM Products";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            return await connection.QueryAsync<Product>(sql);
        }

        public async Task<Product> Get(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductId = @ProductId";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            var result = connection.QueryAsync<Product>(sql, new { ProductId = id }).Result.FirstOrDefault();

            return result;
        }

        public async Task<int> Update(Product entity)
        {
            var sql = @"UPDATE Product SET " +
                "ProductName = @ProductName, " +
                "Price = @Price, " +
                "CategoryId = @CategoryId, " +
                "Phone = @Phone " +
                "WHERE ProductId = @ProductId";

            using var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            return await connection.ExecuteAsync(sql, entity);
        }
    }
}
