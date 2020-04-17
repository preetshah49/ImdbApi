using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImdbApi.Data
{
    public class Movie
    {
        public Movie()
        {

        }
        public int Rank;
        public string Title;
        public string Genre;
        public string Description;
        public string Director;
        public string Actors;
        public int Year;
        public int Runtime;
        public float Rating;
        public int Votes;
        public float Revenue;
        public int? Metascore;

    }
}
