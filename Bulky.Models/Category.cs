using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Display Order should be between 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}
