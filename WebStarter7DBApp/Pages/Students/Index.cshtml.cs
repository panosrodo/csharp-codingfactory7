using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStarter7DBApp.DTO;
using WebStarter7DBApp.Models;
using WebStarter7DBApp.Services;

namespace WebStarter7DBApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List<StudentReadOnlyDTO> StudentsReadOnlyDTO { get; set; } = [];
        public Error ErrorObj { get; set; } = new();

        private readonly IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult OnGet()
        {
            try
            {
                ErrorObj = new();
                StudentsReadOnlyDTO = _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {
                ErrorObj = new Error("", ex.Message, "");
            }
            return Page();
        }
    }
}