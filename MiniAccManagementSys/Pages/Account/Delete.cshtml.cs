using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccManagementSys.Models;
using MiniAccManagementSys.Services;
using System.Threading.Tasks;

namespace MiniAccManagementSys.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly AccountService _accountService;

        
        public DeleteModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public ChartOfAccount Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Account = await _accountService.GetAccountByIdAsync(id);
            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Account?.Id > 0)
            {
                await _accountService.DeleteAccountAsync(Account.Id);
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
