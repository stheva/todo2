using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class AssignmentsController : ApiController
    {
        private TodoListContext db = new TodoListContext();

        // GET: api/Assignments
        public IQueryable<Assignment> GetAssignments()
        {
            return db.Assignments;
        }

        //public IQueryable<AssignmentDto> GetAssignments()
        //{
        //    var assignments = from a in db.Assignments
        //                      select new AssignmentDto()
        //                      {
        //                          Id = a.Id,
        //                          Description = a.Description,
        //                          Completed = a.Completed
        //                      };

        //    return assignments;
        //}

        // GET: api/Assignments/5
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> GetAssignment(int id)
        {
            Assignment assignment = await db.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // PUT: api/Assignments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssignment(int id, Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.Id)
            {
                return BadRequest();
            }

            db.Entry(assignment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Assignments
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> PostAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assignments.Add(assignment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = assignment.Id }, assignment);
        }

        // DELETE: api/Assignments/5
        [ResponseType(typeof(Assignment))]
        public async Task<IHttpActionResult> DeleteAssignment(int id)
        {
            Assignment assignment = await db.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            db.Assignments.Remove(assignment);
            await db.SaveChangesAsync();

            return Ok(assignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignmentExists(int id)
        {
            return db.Assignments.Count(e => e.Id == id) > 0;
        }
    }
}