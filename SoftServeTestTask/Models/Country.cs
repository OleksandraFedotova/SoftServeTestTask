using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeTestTask.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "CountryName must be up to 30 characters or less"), MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }


        public virtual Organization Organization { get; set; }
        public virtual ICollection<Business> BusinessList { get; set; } 

    }
}
