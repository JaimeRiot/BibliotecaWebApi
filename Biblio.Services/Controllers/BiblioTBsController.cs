using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Biblio.Services;

namespace Biblio.Services.Controllers
{
    public class BiblioTBsController : ApiController
    {
        private BibliotecaEntities db = new BibliotecaEntities();

        // GET: api/BiblioTBs
        public IQueryable<BiblioTB> GetBiblioTBs()
        {
            return db.BiblioTBs;
        }

        // GET: api/BiblioTBs/5
        [ResponseType(typeof(BiblioTB))]
        public IHttpActionResult GetBiblioTB(int id)
        {
            BiblioTB biblioTB = db.BiblioTBs.Find(id);
            if (biblioTB == null)
            {
                return NotFound();
            }

            return Ok(biblioTB);
        }

        // PUT: api/BiblioTBs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBiblioTB(int id, BiblioTB biblioTB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != biblioTB.ID)
            {
                return BadRequest();
            }

            db.Entry(biblioTB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiblioTBExists(id))
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

        // POST: api/BiblioTBs
        [ResponseType(typeof(BiblioTB))]
        public IHttpActionResult PostBiblioTB(BiblioTB biblioTB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BiblioTBs.Add(biblioTB);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BiblioTBExists(biblioTB.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = biblioTB.ID }, biblioTB);
        }

        // DELETE: api/BiblioTBs/5
        [ResponseType(typeof(BiblioTB))]
        public IHttpActionResult DeleteBiblioTB(int id)
        {
            BiblioTB biblioTB = db.BiblioTBs.Find(id);
            if (biblioTB == null)
            {
                return NotFound();
            }

            db.BiblioTBs.Remove(biblioTB);
            db.SaveChanges();

            return Ok(biblioTB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BiblioTBExists(int id)
        {
            return db.BiblioTBs.Count(e => e.ID == id) > 0;
        }
    }
}