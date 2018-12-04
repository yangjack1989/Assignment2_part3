using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_part3.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2_part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class playerController : ControllerBase
    {    //  db
        private NbaDataModel db;
        public playerController(NbaDataModel db)
        {
            this.db = db;
        }

        // GET: api/player
        [HttpGet]
        public IEnumerable<player> Get()
        {
            return db.players.OrderBy(p => p.first_name).ToList();
        }

        // GET api/player/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {  player p= db.players.Find(id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]player p)
        {
            if (ModelState.IsValid)
            {
                db.players.Add(p);
                db.SaveChanges();
                return CreatedAtAction("Post",p);
            }
            return BadRequest(ModelState);
        }

        // PUT api/player/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]player p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
                
        }

        // DELETE api/player/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            player p = db.players.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            db.players.Remove(p);
            db.SaveChanges();
            return Ok();

        }
    }
}
