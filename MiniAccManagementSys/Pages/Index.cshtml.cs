using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccManagementSys.Models;
using MiniAccManagementSys.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniAccManagementSys.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AccountService _accountService;
        public List<ChartOfAccount> Accounts { get; set; } = new();

        public IndexModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task OnGetAsync()
        {
            Accounts = await _accountService.GetAllAccountsAsync();
        }
    }
}