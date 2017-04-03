using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeTestTask.Models
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizationId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Name must be up to 30 characters or less"), MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
