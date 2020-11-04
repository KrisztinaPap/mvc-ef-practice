using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInformation.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get; set;
        }

        [Column(TypeName = "varchar(50)")]
        public string Name
        {
            get; set;
        }

        [Column(TypeName = "int(10")]
        public int CategoryID
        {
            get; set;
        }

        [ForeignKey(nameof(CategoryID))]
        [InverseProperty(nameof(Models.Category.ID))]

        public virtual 
    }
}
