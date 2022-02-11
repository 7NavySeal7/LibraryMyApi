﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("UserBook", Schema = "Library")]
    public class UserBookEntity
    {
        [Key]
        public int IdUserBook { get; set; }

        [ForeignKey("BookEntity")]
        public int IdBook { get; set; }
        public BookEntity BookEntity { get; set; }

        [ForeignKey("UserEntity")]
        public int IdUser { get; set; }
        public UserEntity UserEntity { get; set; }

    }
}
