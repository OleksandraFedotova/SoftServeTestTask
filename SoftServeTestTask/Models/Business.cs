using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeTestTask.Models
{
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BusinessId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "BusinessName must be up to 50 characters or less"), MinLength(2)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int CountryId { get; set; }


        public virtual Country Country { get; set; }
        public virtual ICollection<Family> Families { get; set; } 
    }
}
