using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccManagementSys.Models;
using MiniAccManagementSys.Services;

namespace MiniAccManagementSys.Pages.Account
{
    public class IndexModel : PageModel
    {
        [Authorize(Roles = "Admin,Accountant")]
        public class IndexModel : PageModel
        {
            private readonly AccountService _accountService;
            public IndexModel(AccountService accountService) => _accountService = accountService;

            public List<ChartOfAccount> Accounts { get; set; } = new();

            public async Task OnGetAsync()
            {
                Accounts = await _accountService.GetAllAccountsAsync();
            }
        }
    }
}
