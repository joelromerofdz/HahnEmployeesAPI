using System.ComponentModel.DataAnnotations;

namespace HahnEmployeesAPI.DTOs.EmployeeDTOs
{
    public class EmployeeRequestDto
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(maximumLength: 20,
        MinimumLength = 1,
        ErrorMessage = "This field {0} should have a minimun {2} and a maximun of {1} of character.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(maximumLength: 20,
        MinimumLength = 1,
        ErrorMessage = "This field {0} should have a minimun {2} and a maximun of {1} of character.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [EmailAddress(ErrorMessage = "Bad emial format.")]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime DateHired { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public int RoleId { get; set; }
    }
}
