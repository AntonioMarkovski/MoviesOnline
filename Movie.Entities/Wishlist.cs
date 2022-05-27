using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movie.Entities
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int MovieId { get; set; }

        public int ActorId { get; set; }

        public string CategoryId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
