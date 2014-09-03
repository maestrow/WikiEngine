using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using PagedList;
using WikiEngine.Dal.Models;
using WikiEngine.Dto;

namespace WikiEngine.Controllers
{
    public class PageController : ApiController
    {
        private WikiEngineContext db = new WikiEngineContext();
        private FileDbContext files = new FileDbContext();

        // GET: api/Page
        public GetPagesOutput GetPages(int p = 1, string q = "", int pSize = 20)
        {
            IEnumerable<File> query = db.Set<File>();

            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(file => file.Name.Contains(q));

            query = query.OrderBy(file => file.Last_access_time);

            return new GetPagesOutput()
            {
                Items = query.ToPagedList(p, pSize).Select(file => new PageInList()
                {
                    Id = file.Stream_id,
                    CreatedAt = file.Creation_time.DateTime,
                    LastEditAt = file.Last_access_time.DateTime,
                    Title = file.Name,
                    Excerpt = getExcerpt(file.File_stream)
                }),
                Count = query.Count()
            };
        }

        // GET: api/Page/5
        [ResponseType(typeof(File))]
        public IHttpActionResult GetPage(Guid id)
        {
            File file = db.Set<File>().Find(id);
            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        // PUT: api/Page/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPage(Guid id, File file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != file.Stream_id)
            {
                return BadRequest();
            }

            files.Update.CallStoredProc(file);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Page
        [ResponseType(typeof(File))]
        public IHttpActionResult PostPage(File file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            files.CreateFile.CallStoredProc(file);

            return CreatedAtRoute("DefaultApi", new { id = file.Stream_id }, file);
        }

        // DELETE: api/Page/5
        [ResponseType(typeof(File))]
        public IHttpActionResult DeletePage(Guid id)
        {
            File file = db.Set<File>().Find(id);
            if (file == null)
            {
                return NotFound();
            }

            files.Delete.CallStoredProc(new File() {Stream_id = id});

            return Ok(file);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Private Methods

        private string getExcerpt(byte[] bytes)
        {
            string content = Encoding.UTF8.GetString(bytes);
            return content.Substring(0, Math.Min(100, content.Length));
        }

        #endregion
    }
}