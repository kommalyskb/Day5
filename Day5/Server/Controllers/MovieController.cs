using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day5.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day5.Server.Controllers
{
    // http://localhost:134/api/Movie
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET, POST, PUT, Delete, Patch
        // http://localhost:134/api/movie/getallmovie
        [HttpGet]
        [Route("GetAllMovie")]
        public IActionResult GetAllMovie()// Get, Post
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie(){ Title = "Spider-Man: Far From Home", ReleaseDate = new DateTime(2019,7,2), Poster = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg"},
                new Movie(){ Title = "Moana", ReleaseDate = new DateTime(2018,3,2), Poster = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg"},
                new Movie(){ Title = "Inception", ReleaseDate = new DateTime(2016,5,2), Poster = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"},
            };

            //return BadRequest(); // code 400
            //return NotFound();// code = 404
            return Ok(movies);// code = 200
        }

        [HttpPost]
        [Route("CreateMovie")]
        public IActionResult Create(Movie movie)
        {
            // Save to database
            DefaultResponse<Movie> res = new DefaultResponse<Movie>()
            {
                Code = 200,
                Message = "Goo evening",
                Response = movie
            };
            return Ok(res);
        }
    }
}
