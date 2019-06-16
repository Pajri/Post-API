using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private PostContext _context;
        public PostController(PostContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Posts>> Get()
        {
            return _context.Posts;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Posts> Get(string id)
        {
            Guid postGuid = new Guid();
            if (!Guid.TryParse(id,out postGuid)) return BadRequest();

            var postItem = _context.Posts.Where(p => p.Id == postGuid);
            if (postItem.Count() == 0) return NotFound();
            return postItem.SingleOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Posts> Post([FromBody]Posts postItem)
        {
            _context.Posts.Add(postItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = postItem.Id }, postItem);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]Posts postItem)
        {
            Guid postGuid = new Guid();
            if (!Guid.TryParse(id, out postGuid)) return BadRequest();
            if (postGuid != postItem.Id) return BadRequest();

            _context.Entry(postItem).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            Guid postGuid = new Guid();
            if (!Guid.TryParse(id, out postGuid)) return BadRequest();

            var queryPostItem = _context.Posts.Where(p => p.Id == postGuid);
            if (queryPostItem.Count() == 0) return NotFound();

            var postItem = queryPostItem.SingleOrDefault();
            _context.Posts.Remove(postItem);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
