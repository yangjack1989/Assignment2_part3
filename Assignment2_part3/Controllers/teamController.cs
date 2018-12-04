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
    public class teamController : ControllerBase
    {
        //  db
        private NbaDataModel db;
        public teamController(NbaDataModel db)
        {
            this.db = db;
        }

        // GET: api/team
        [HttpGet]
        public IEnumerable<team> Get()
        {
            return db.teams.OrderBy(t => t.team_name);
        }

        // GET api/team/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            team t = db.teams.Find(id);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);
        }

        // POST api/team
        [HttpPost]
        public ActionResult Post([FromBody]team t)
        {
            if (ModelState.IsValid)
            {
                db.teams.Add(t);
                db.SaveChanges();
                return CreatedAtAction("Post", t);
            }
            return BadRequest(ModelState);
        }
        // PUT api/team/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]team t)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            db.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }

        // DELETE api/team/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            team t = db.teams.Find(id);
            if (t == null)
            {
                return NotFound();
            }
            db.teams.Remove(t);
            db.SaveChanges();
            return Ok();
        }
    }
}
