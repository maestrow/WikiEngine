﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WikiEngine.Models;

namespace WikiEngine.Controllers
{
    public class PageController : ApiController
    {
        private WikiEngineContext db = new WikiEngineContext();

        // GET: api/Page
        public IQueryable<Page> GetPages()
        {
            return db.Pages;
        }

        // GET: api/Page/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult GetPage(int id)
        {
            Page page = db.Pages.Find(id);
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

            db.Pages.Add(page);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = page.Id }, page);
        }

        // DELETE: api/Page/5
        [ResponseType(typeof(Page))]
        public IHttpActionResult DeletePage(int id)
        {
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return NotFound();
            }

            db.Pages.Remove(page);
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
            return db.Pages.Count(e => e.Id == id) > 0;
        }
    }
}