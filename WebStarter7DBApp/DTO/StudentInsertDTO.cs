using System.ComponentModel.DataAnnotations;

namespace WebStarter7DBApp.DTO
{
    public class StudentInsertDTO
    {
        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(1, ErrorMessage = "Firstname must be at least one character long.")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(1, ErrorMessage = "Firstname must be at least one character long.")]
        public string? Lastname { get; set; }

        public StudentInsertDTO() { }

        public StudentInsertDTO(string? firstname, string? lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}