using System.ComponentModel.DataAnnotations;

namespace HahnEmployeesAPI.DTOs.RoleDTOs
{
    public class RoleRequestDto
    {
        [StringLength(maximumLength: 20,
            MinimumLength = 1,
            ErrorMessage = "This field {0} should have a minimun {2} and a maximun of {1} of character.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
