﻿using MyBookstore.Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A author name is required")]
        public string Name { get; set; } = string.Empty;
        [CustomDate(errorMessage: "A birthdate is required")]
        public DateTime BirthDay { get; set; }

        public Author()
        {

        }
    }
}
