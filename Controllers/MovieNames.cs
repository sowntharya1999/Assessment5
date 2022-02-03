using Assessment5.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assessment5.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MovieNames : ControllerBase
    {
        private readonly MovieNamesDb_Context dbcontext;
        public MovieNames(MovieNamesDb_Context dbcontexts)
        {
            dbcontext = dbcontexts;
        }



        [HttpGet]
        public IEnumerable<Movies> GetMovies()
        {
            return dbcontext.movies.ToList();
        }
        [HttpGet("GetMovieById")]
        public Movies GetMovieById(int Id)
        {
            return dbcontext.movies.Find(Id);
        }

        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie([FromBody] Movies movie)
        {
            if (movie.id.ToString() != "")
            {

                dbcontext.movies.Add(movie);
                dbcontext.SaveChanges();
                return Ok("Movie details saved successfully");
            }
            else
                return BadRequest();
        }

        /*update*/
        [HttpPut("UpdateMovies")]
        public IActionResult UpdateMovies([FromBody] Movies movie)
        {
            if (movie.id.ToString() != "")
            {

                dbcontext.Entry(movie).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return Ok("Updated successfully");
            }
            else
                return BadRequest();
        }

        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            //select * from tutorial where tutorialId=3
            var result = dbcontext.movies.Find(id);
            dbcontext.movies.Remove(result);
            dbcontext.SaveChanges();
            return Ok("Deleted successfully");
        }
    }
}
