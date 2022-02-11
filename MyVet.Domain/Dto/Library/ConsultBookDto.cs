using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto.Library
{
    public class ConsultBookDto : BookDto
    {
        public string NameEditorial { get; set; }
        public string NameAuthor { get; set; }
        public string NameTypeBook { get; set; }
        public string NameState { get; set; }
        public string StrDateRelease { get; set; }
    }
}
