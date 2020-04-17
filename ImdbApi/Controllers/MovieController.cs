using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImdbApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace ImdbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        List<Movie> movies = new List<Movie>();
        Movie movie = new Movie();
        public MovieController()
        {
            setupData();
        }

        // GET: api/Movie
        [HttpGet]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(movies);
        }

        // GET: api/Movie/5
        [HttpGet("{rank}")]
        public string Get(int rank)
        {
            return JsonConvert.SerializeObject(movies.Find(m => m.Rank == rank));
        }
        //Setup Data
        private void setupData()
        {
            movies = new List<Movie>();
            Movie movie = new Movie();

            string data = System.IO.File.ReadAllText(@"Data/imdb.json");
            
            movies = JsonConvert.DeserializeObject<List<Movie>>(data);

        }

    }
}
