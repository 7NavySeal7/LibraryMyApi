using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class TokenDto
    {
        public string Token { get; set; }
        public double Expiration { get; set; }
    }
}
