namespace MiniAccManagementSys.Models
{
    public class VoucherEntry
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public int AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Narration { get; set; }

        public string AccountName { get; set; }
    }
}
