using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto.Library
{
    public class AuthorBookDto
    {
        public int IdAuthorBook { get; set; }

        public int IdBook { get; set; }

        public int IdAuthor { get; set; }
    }
}
