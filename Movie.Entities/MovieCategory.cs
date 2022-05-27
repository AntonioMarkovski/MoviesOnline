using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Entities
{
    public class MovieCategory
    {
        public int MovieID { get; set; }

        public Movies Movie { get; set; }

        public int CategoryID { get; set; }

        public Category Category  { get; set; }
    }
}
