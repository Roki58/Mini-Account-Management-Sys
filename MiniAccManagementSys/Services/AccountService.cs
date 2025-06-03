using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MiniAccManagementSys.Models;
using System.Data;

namespace MiniAccManagementSys.Services
{
    public class AccountService
    {
        private readonly IConfiguration _config;
        public AccountService(IConfiguration config) => _config = config;

        public async Task<List<ChartOfAccount>> GetAllAccountsAsync()
        {
            var list = new List<ChartOfAccount>();
            using var con = new SqlConnection(_config.GetConnectionString("DbConnection"));
            using var cmd = new SqlCommand("sp_ManageChartOfAccounts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "GetAll");

            await con.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new ChartOfAccount
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ParentId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                    AccountType = reader.GetString(3)
                });
            }
            return list;
        }

        public async Task<ChartOfAccount> GetAccountByIdAsync(int id)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DbConnection"));
            using var cmd = new SqlCommand("SELECT * FROM ChartOfAccounts WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            await con.OpenAsync();

            var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new ChartOfAccount
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ParentId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                    AccountType = reader.GetString(3)
                };
            }

            return null;
        }

        public async Task SaveAccountAsync(ChartOfAccount account, string action)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DbConnection"));
            using var cmd = new SqlCommand("sp_ManageChartOfAccounts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@Id", account.Id);
            cmd.Parameters.AddWithValue("@Name", account.Name);
            cmd.Parameters.AddWithValue("@ParentId", (object)account.ParentId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AccountType", account.AccountType);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DbConnection"));
            using var cmd = new SqlCommand("sp_ManageChartOfAccounts", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@Id", id);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
