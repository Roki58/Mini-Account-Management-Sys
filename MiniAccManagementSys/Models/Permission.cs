namespace MiniAccManagementSys.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Module { get; set; }
        public bool CanAccess { get; set; } 
    }
}
