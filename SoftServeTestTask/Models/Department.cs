using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftServeTestTask.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "DepartmentName must be up to 30 characters or less"), MinLength(2)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Offering")]


        public int OfferingId { get; set; }
        public virtual Offering Offering { get; set; }
    }
}

