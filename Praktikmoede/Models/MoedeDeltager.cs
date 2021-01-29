using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Praktikmoede.Models
{
    public class MoedeDeltager
    {
        [Key]
        public int Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        [Required]
        [DisplayName("Moede")]
        public int MoedeId { get; set; }

        [ForeignKey("MoedeId")]
        public virtual Moede Moede { get; set; }

    }
}
