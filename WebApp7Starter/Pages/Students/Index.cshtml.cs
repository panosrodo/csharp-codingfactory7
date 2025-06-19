using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp7Starter.DTO;

namespace WebApp7Starter.Pages.Students
{
    public class IndexModel : PageModel
    {
        [BindProperty]  // Two-way binding
        public InsertStudentDTO InsertStudentDTO { get; set; } = new();

        public void OnGet()
        {
            //return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["Message"] = $"{InsertStudentDTO?.Firstname} {InsertStudentDTO?.Lastname} " +
                $"added successfully";

            return RedirectToPage("/Students/Success");
        }
    }
}