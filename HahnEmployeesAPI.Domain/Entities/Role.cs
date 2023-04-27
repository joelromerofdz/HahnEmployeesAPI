using HahnEmployeesAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnEmployeesAPI.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(maximumLength: 20,
            MinimumLength = 1,
            ErrorMessage = "This field {0} should have a minimun {2} and a maximun of {1} of character.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
