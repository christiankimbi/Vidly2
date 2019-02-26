using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;
using AutoMapper;
using Microsoft.Ajax.Utilities;

namespace Vidly2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        public IHttpActionResult GetMovies()
        {
            return Ok (_context.Movies.Include(m=>m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>));

        }

        // GET api/<controller>/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);

            return Ok(movieDto);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movieInDB = Mapper.Map<MovieDto, Movie>(movieDto);
             _context.Movies.Add(movieInDB);
            _context.SaveChanges();
            movieDto.Id = movieInDB.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);

        }

        // PUT api/<controller>/5
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movideInDB = _context.Movies.Single(m => m.Id == id);
            if (movideInDB == null)
                return BadRequest();

            Mapper.Map(movieDto, movideInDB);

            _context.SaveChanges();

            return Ok();

        }

        // DELETE api/<controller>/5
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult Delete(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDB == null)
                return NotFound();

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return Ok();

        }
    }
}