﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace net_il_mio_fotoalbum.Models.DatabaseModels
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Message { get; set; }

        [MaxLength(500)]
        public string Subject { get; set; }



        // empty constructor

        public Contact() { }

    }
}
