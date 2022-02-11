using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("TypeBook", Schema = "Library")]
    public class TypeBookEntity
    {
        [Key]
        public int IdTypeBook { get; set; }

        [MaxLength(100)]
        public string TypeBook { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }                                                                       
    }
}
