﻿using HahnEmployeesAPI.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnEmployeesAPI.Domain.Entities
{
    public class Employee : BaseEntity
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
        public virtual Role Role { get; set; }
    }
}
