﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBook.Models.ViewModels
{
    public class HomeEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Phone number (xxxx-xx-xx-xx)")]
        [Required(ErrorMessage = "Enter phone-number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Description (optional)")]
        public string Description { get; set; }

        public int[] SelectedSkills { get; set; }

        public SelectListItem[] Skills { get; set; }
    }
}
