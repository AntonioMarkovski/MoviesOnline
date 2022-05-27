using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movie.Entities
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public string DateBirth { get; set; }

        [StringLength(1500)]
        public string ShortDescription { get; set; }

        [StringLength(100)]
        public string Language { get; set; }

        [StringLength(100)]
        public string Gender { get; set; }

        public bool Popularity { get; set; }

        public string PhotoURL { get; set; }

        //public string NameInMovie { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }



    }
}
