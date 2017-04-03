using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeTestTask.Models
{
    public class Offering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferingId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Offering Description must be up to 30 characters or less"), MinLength(2)]
        public string OfferingDescr { get; set; }

        [Required]
        [ForeignKey("Family")]
        public int FamilyId { get; set; }


        public virtual Family Family { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
