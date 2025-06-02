namespace MiniAccManagementSys.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public string VoucherType { get; set; }
        public DateTime VoucherDate { get; set; }
        public string ReferenceNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<VoucherEntry> Entries { get; set; } = new();
    }
}
