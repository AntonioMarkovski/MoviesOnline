using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movie.Entities
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Actors")]
        public string ActorNames { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }

        [StringLength(100)]
        [Display(Name = "Director")]
        public string DirectorName { get; set; }

        [Display(Name = "Director")]
        public int DirectorId { get; set; }

        [StringLength(100)]
        [Display(Name = "Genre")]

        public string Categories { get; set; }

        [Display(Name = "Producer")]
        public Publisher Publisher { get; set; }

        [Display(Name = "Producer")]
        public int PublisherId { get; set; }

        [StringLength(100)]
        [Display(Name = "Producer")]
        public string PublisherName { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [DisplayName("Runtime")]
        public string WatchTime { get; set; }

        [Display(Name = "Release date")]
        public string ReleaseDate { get; set; }

        [StringLength(50)]
        public string CountryOfOrigin { get; set; }

        public double Rating { get; set; }
        [StringLength(1500)]

        public string ShortDescription { get; set; }
        [StringLength(100)]

        public string TrailerURL { get; set; }

        public string PhotoURL { get; set; }

        public bool Popularity { get; set; }



    }
}
