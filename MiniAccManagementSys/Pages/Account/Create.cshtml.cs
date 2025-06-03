using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniAccManagementSys.Models;
using MiniAccManagementSys.Services;
using System.Threading.Tasks;

namespace MiniAccManagementSys.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly AccountService _accountService;

        public CreateModel(AccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public ChartOfAccount Account { get; set; }

        public void OnGet()
        {
            // Optional: load dropdowns or parent list
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _accountService.SaveAccountAsync(Account, "Insert");
            return RedirectToPage("/Index");
        }
    }
}
