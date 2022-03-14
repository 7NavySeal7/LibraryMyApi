using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Library
{
    public class EditorialDto
    {
        public int IdEditorial { get; set; }
        public string Editorial { get; set; }
        public string Sede { get; set; }
    }
}
