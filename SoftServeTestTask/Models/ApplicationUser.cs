using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SoftServeTestTask.Models;

namespace SoftServeTestTask.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "FirstName must be up to 30 characters or less"), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "LastName must be up to 50 characters or less"), MinLength(3)]
        public string LastName { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }


    }
}

