using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStarter7DBApp.DTO;
using WebStarter7DBApp.Models;
using WebStarter7DBApp.Services;

namespace WebStarter7DBApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public StudentUpdateDTO StudentUpdateDTO { get; set; } = new();

        public List<Error> ErrorArray { get; set; } = [];

        private readonly IStudentService _studentService;

        public UpdateModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                StudentReadOnlyDTO? studentReadOnlyDTO = _studentService.GetStudent(id);
                StudentUpdateDTO = new StudentUpdateDTO()
                {
                    Id = studentReadOnlyDTO.Id,
                    Firstname = studentReadOnlyDTO.Firstname,
                    Lastname = studentReadOnlyDTO.Lastname
                };
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));
            }
            return Page();
        }

        public void OnPost(int id)
        {
            try
            {
                StudentUpdateDTO.Id = id;
                _studentService.UpdateStudent(StudentUpdateDTO);
                Response.Redirect("/Students/getall");
            }
            catch (Exception e)
            {
                ErrorArray.Add(new Error("", e.Message, ""));
            }
        }
    }
}