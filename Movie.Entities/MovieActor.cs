using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Entities
{
    public class MovieActor
    {
        public int MovieID { get; set; }

        public Movies Movie { get; set; }

        public int ActorID { get; set; }

        public Actor Actor { get; set; }
    }
}
