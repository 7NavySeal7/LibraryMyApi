using MyVet.Domain.Dto.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class BookDto : InsertBookDto
    {
        public int IdBook { get; set; }
        public int IdAuthorBook { get; set; }
    }
}
