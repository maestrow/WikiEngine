using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PagedList;
using WikiEngine.Dto;
using WikiEngine.Models;

namespace WikiEngine.Controllers
{
    public class PageController : ApiController
    {
        private WikiEngineContext db = new WikiEngineContext();

        // GET: api/Page
        public GetPagesOutput GetPages(int p = 1, string q = "", int pSize = 20)
        {
            IEnumerable<Page> query = db.Set<Page>();

            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(page => page.Title.Contains(q));

            query = query.OrderBy(page => page.LastEditAt);

            return new GetPagesOutput()
            {
                Items = query.ToPagedList(p, pSize).Select(page => new PageInList()
                {
                    Id = page.Id,
                    CreatedAt = page.CreatedAt,
                    LastEditAt = page.LastEditAt,
                    Title = page.Title,
                    Excerpt = page.Content.Substring(0, Math.Min(100, page.Content.Length))
                }),
                Count = query.Count()
            };
        }

        // GET: api/Page/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult GetPage(int id)
        {
            Page page = db.Set<Page>().Find(id);
            if (page == null)
            {
                return NotFound();
            }

            return Ok(page);
        }

        // PUT: api/Page/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPage(int id, Page page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != page.Id)
            {
                return BadRequest();
            }

            db.Entry(page).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(id))
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

        // POST: api/Page
        [ResponseType(typeof(Page))]
        public IHttpActionResult PostPage(Page page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Set<Page>().Add(page);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = page.Id }, page);
        }

        // DELETE: api/Page/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult DeletePage(int id)
        {
            Page page = db.Set<Page>().Find(id);
            if (page == null)
            {
                return NotFound();
            }

            db.Set<Page>().Remove(page);
            db.SaveChanges();

            return Ok(page);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PageExists(int id)
        {
            return db.Set<Page>().Count(e => e.Id == id) > 0;
        }
    }
}