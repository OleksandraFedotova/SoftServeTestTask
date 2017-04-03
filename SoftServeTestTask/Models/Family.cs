using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeTestTask.Models
{
    public class Family
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "FamilyName must be up to 30 characters or less"), MinLength(2)]
        public  string Name { get; set; }

        [Required]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }


        public virtual Business Business { get; set; }
        public virtual ICollection<Offering> Offerings { get; set; } 
    }
}
