using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CinemaAPI.Models;

namespace CinemaAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class MovieController : ControllerBase {
    private readonly ApplicationDbContext ctx = new ApplicationDbContext();

    [HttpGet]
    public ActionResult<List<Movie>> GetAll() => ctx.Movies.ToList();

    [HttpGet("{id}", Name = "GetMovie")]
    public ActionResult<Movie> GetById(int id) {
      var movie = ctx.Movies.Find(id);
      if (movie == null)
        return NotFound();
      return movie;
    }

    [HttpPost]
    public IActionResult Create(Movie movie) {
      ctx.Movies.Add(movie);
      ctx.SaveChanges();
      return CreatedAtRoute("GetMovie", new { Id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Movie updatedMovie) {
      var movie = ctx.Movies.Find(id);
      if (movie == null)
        return NotFound();
      movie.Name = updatedMovie.Name;
      movie.Director = updatedMovie.Director;
      movie.Description = updatedMovie.Description;
      movie.Duration = updatedMovie.Duration;
      movie.Year = updatedMovie.Year;
      movie.Category = updatedMovie.Category;
      ctx.Movies.Update(movie);
      ctx.SaveChanges();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
      var movie = ctx.Movies.Find(id);
      if (movie == null)
        return NotFound();
      ctx.Movies.Remove(movie);
      ctx.SaveChanges();
      return NoContent();
    }
  }
}