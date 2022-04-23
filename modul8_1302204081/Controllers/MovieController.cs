using Microsoft.AspNetCore.Mvc;

namespace modul8_1302204081.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {

        private static List<Movies> MovieList = new List<Movies>
            {
            new Movies()
                {
                    Title = "The Shawshank Redemption ",
                    Director = "Frank Darabont",
                    Stars = new[] { " Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler" },
                    Description="test"

                },
            new Movies()
                {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Stars= new[] { "Marlon Brando", "Al Pacino", "James Caan", "Diane Keaton" },
                    Description="The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son."
                },
            new Movies(){
                    Title = "The Dark Knight ",
                    Director="Christopher Nolan ",
                    Stars= new[] { " Christian Bale", "Heath Ledger", "Aaron Eckhart", "Michael Caine" },
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
            }

            };


        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            // output mengembalikan semua buah
            return MovieList;
        }

        [HttpGet("{id}")]
        public Movies Get(int id)
        {

            return MovieList[id];
        }


        [HttpPost]
        public void Post([FromBody] Movies value)
        {
            MovieList.Add(value);

        }

        // TBD - untuk praktikum
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MovieList.RemoveAt(id);
        }
    }

}