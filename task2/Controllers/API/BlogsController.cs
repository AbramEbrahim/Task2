using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;
using task2.Models.data;

namespace task2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(ApplicationDbContext _db) : ControllerBase
    {

        [HttpGet]
        public List<Blog> getBlog()
        {
            var blogs = _db.blogs.Include(m => m.type).ToList();
            return blogs;

        }

        [HttpGet("{id}")]
        public ActionResult<Blog> getBlog(int id)
        {
        if (id <= 0) { return BadRequest(); }
            var blog = _db.blogs.Include(m => m.type).FirstOrDefault(m => m.Id == id);
            if (blog == null) { return NotFound(); }
            return Ok(blog);
        }

        [HttpPost]
        public ActionResult<Blog> Addblog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBLog(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var blog = _db.blogs.Include(x => x.type).FirstOrDefault(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBlog(Blog blog)
        {
            if (blog.Id <= 0 || !ModelState.IsValid)
            { return BadRequest(); }

            var blog2 = _db.blogs.Include(_ => _.type).FirstOrDefault(m => m.Id == blog.Id);
            if (blog2 == null) { return NotFound(); }

            blog2.Name = blog.Name;
            blog2.Description = blog.Description;
            blog2.TypeId = blog.TypeId;

            _db.SaveChanges();
            return Ok();
        }

    }
}
