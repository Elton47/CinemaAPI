using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CinemaAPI.Models;

namespace CinemaAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase {
    private readonly ApplicationDbContext ctx = new ApplicationDbContext();

    [HttpGet]
    public ActionResult<List<Category>> GetAll() => ctx.Categories.ToList();

    [HttpGet("{id}", Name = "GetCategory")]
    public ActionResult<Category> GetById(int id) {
      var category = ctx.Categories.Find(id);
      if (category == null)
        return NotFound();
      return category;
    }

    [HttpPost]
    public IActionResult Create(Category category) {
      ctx.Categories.Add(category);
      ctx.SaveChanges();
      return CreatedAtRoute("GetCategory", new { Id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Category updatedCategory) {
      var category = ctx.Categories.Find(id);
      if (category == null)
        return NotFound();
      category.Name = updatedCategory.Name;
      ctx.Update(category);
      ctx.SaveChanges();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
      var category = ctx.Categories.Find(id);
      if (category == null)
        return NotFound();
      ctx.Categories.Remove(category);
      ctx.SaveChanges();
      return NoContent();
    }
  }
}