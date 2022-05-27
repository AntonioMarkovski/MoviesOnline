using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movie.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Year { get; set; }
        public string Gender { get; set; }
        public string ShortDescription { get; set; }
        public virtual ICollection<Movies> Movies { get; set; }
        //*** extra field
    }
}
