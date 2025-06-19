using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp7Starter.DTO;
using WebApp7Starter.Models;

namespace WebApp7Starter.Pages.Students
{
    public class ViewStudentsModel : PageModel
    {
        public List<StudentReadOnlyDTO> StudentsReadOnlyDTOs { get; set; } = [
            MapStudentToDTO(new Student() {Id = 1, Firstname = "Giorgos", Lastname = "Fragkos"}),
            MapStudentToDTO(new Student() {Id = 1, Firstname = "Kostas", Lastname = "Androutsos"}),
            MapStudentToDTO(new Student() {Id = 1, Firstname = "Anna", Lastname = "Gianoutsou"})
        ];




        public IActionResult OnGet()
        {
            if (Request.Query.TryGetValue("lastname", out var lastname))
            {
                StudentsReadOnlyDTOs = StudentsReadOnlyDTOs.Where(s => s.Lastname == lastname).ToList();
                return Page();
            }
            return Page();
        }

        private static StudentReadOnlyDTO MapStudentToDTO(Student student)
        {
            return new StudentReadOnlyDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }


}