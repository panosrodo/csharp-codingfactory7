using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp7Starter.Pages.Students
{
    public class SuccessModel : PageModel
    {
        public string? Message { get; set; }

        public void OnGet()
        {
            Message = TempData["Message"] as string ?? "Operation completed successfully";
        }
    }
}