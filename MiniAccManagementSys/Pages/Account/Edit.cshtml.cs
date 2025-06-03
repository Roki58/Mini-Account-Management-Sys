using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccManagementSys.Models;
using MiniAccManagementSys.Services;
using System.Threading.Tasks;

namespace MiniAccManagementSys.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly AccountService _accountService;

        public EditModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public ChartOfAccount Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Account = await _accountService.GetAccountByIdAsync(id);
            if (Account == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

          
            await _accountService.SaveAccountAsync(Account, "Update");
            return RedirectToPage("/Index");  
        }
    }
}
