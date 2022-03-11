using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("Author", Schema = "Library")]
    public class AuthorEntity
    {
        [Key]
        public int IdAuthor { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
