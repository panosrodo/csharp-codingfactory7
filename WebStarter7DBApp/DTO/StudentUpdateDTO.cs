using System.ComponentModel.DataAnnotations;

namespace WebStarter7DBApp.DTO
{
    public class StudentUpdateDTO : BaseDTO
    {
        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(1, ErrorMessage = "Firstname must be at least one character long.")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(1, ErrorMessage = "Firstname must be at least one character long.")]
        public string? Lastname { get; set; }

        public StudentUpdateDTO() { }

        public StudentUpdateDTO(int id, string? firstname, string? lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}