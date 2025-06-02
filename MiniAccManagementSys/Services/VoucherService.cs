using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MiniAccManagementSys.Models;
using System.Data;

namespace MiniAccManagementSys.Services
{
    public class VoucherService
    {
        private readonly IConfiguration _config;
        public VoucherService(IConfiguration config) => _config = config;

        public async Task SaveVoucherAsync(Voucher voucher)
        {
            using var con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            using var cmd = new SqlCommand("sp_SaveVoucher", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VoucherType", voucher.VoucherType);
            cmd.Parameters.AddWithValue("@VoucherDate", voucher.VoucherDate);
            cmd.Parameters.AddWithValue("@ReferenceNo", voucher.ReferenceNo);
            cmd.Parameters.AddWithValue("@CreatedBy", voucher.CreatedBy);

            var table = new DataTable();
            table.Columns.Add("AccountId", typeof(int));
            table.Columns.Add("Debit", typeof(decimal));
            table.Columns.Add("Credit", typeof(decimal));
            table.Columns.Add("Narration", typeof(string));

            foreach (var entry in voucher.Entries)
            {
                table.Rows.Add(entry.AccountId, entry.Debit, entry.Credit, entry.Narration);
            }

            var param = cmd.Parameters.AddWithValue("@Entries", table);
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = "VoucherEntryType";

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}