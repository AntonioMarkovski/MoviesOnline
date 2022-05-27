using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movie.Entities
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
