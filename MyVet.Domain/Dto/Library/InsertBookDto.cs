using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Library
{
    public class InsertBookDto
    {
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateRelease { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public int IdEditorial { get; set; }

        public int IdAuthor { get; set; }

        public int IdTypeBook { get; set; }

        public int IdState { get; set; }
    }
}
