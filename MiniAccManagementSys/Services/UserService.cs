using Microsoft.Data.SqlClient;
using MiniAccManagementSys.Models;
using System.Data;

namespace MiniAccManagementSys.Services
{
    public class UserService
    {
        private readonly IConfiguration _config;
        public UserService(IConfiguration config) => _config = config;

        public async Task AssignPermissionAsync(string userId, string module, bool canAccess)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("sp_AssignUserRolePermissions", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Module", module);
            cmd.Parameters.AddWithValue("@CanAccess", canAccess);

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<List<Permission>> GetPermissionsAsync(string userId)
        {
            var list = new List<Permission>();
            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("sp_GetUserPermissions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);

            await con.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Permission
                {
                    UserId = userId,
                    Module = reader.GetString(0),
                    CanAccess = reader.GetBoolean(1)
                });
            }
            return list;
        }
    }
}
