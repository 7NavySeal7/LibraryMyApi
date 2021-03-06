using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("Editorial", Schema = "Library")]
    public class EditorialEntity
    {
        [Key]
        public int IdEditorial { get; set; }

        [MaxLength(100)]
        public string Editorial { get; set; }

        [MaxLength(100)]
        public string Sede { get; set; }
    }
}
