﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInformation.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get; set;
        }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name
        {
            get; set;
        }
    }
}
