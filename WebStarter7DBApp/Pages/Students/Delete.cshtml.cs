using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStarter7DBApp.Models;
using WebStarter7DBApp.Services;

namespace WebStarter7DBApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        public List<Error> ErrorArray { get; set; } = [];
        private readonly IStudentService _studentService;

        public DeleteModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet(int id)
        {
            try
            {
                _studentService.DeleteStudent(id);
                Response.Redirect("/Students/getall");
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));
            }
        }
    }
}