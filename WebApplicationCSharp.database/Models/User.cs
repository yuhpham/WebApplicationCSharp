﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCSharp.database.Models
{
    [Table("users")]
    public class User
    {
        public Guid Id { get; set; }
        [Column("Name")]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
