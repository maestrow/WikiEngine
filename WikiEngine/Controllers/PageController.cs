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
using CodeFirstStoredProcs;
using FiletableDataContext.Domain;
using PagedList;
using WikiEngine.Dal.Models;
using WikiEngine.Dto;
using WikiEngine.Dto.Page;

namespace WikiEngine.Controllers
{
    public class PageController : ApiController
    {
        private WikiEngineContext db = new WikiEngineContext();
        private FileDbContext files = new FileDbContext();

        // GET: api/Page
        public GetPagesOutput GetPages(int p = 1, string q = "", int pSize = 20)
        {
            IQueryable<File> query = db.Set<File>();

            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(file => file.Name.Contains(q));

            query = query.OrderBy(file => file.Last_write_time);

            var pagedList = query.ToPagedList(p, pSize);

            return new GetPagesOutput()
            {
                Items = pagedList.Select(file => new PageInList()
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
        [ResponseType(typeof(PageDto))]
        public IHttpActionResult GetPage(Guid id)
        {
            File file = db.Set<File>().Find(id);
            if (file == null)
            {
                return NotFound();
            }

            var result = new PageDto()
            {
                Id = file.Stream_id,
                Title = file.Name,
                CreatedAt = file.Creation_time.DateTime,
                LastEditAt = file.Last_access_time.DateTime,
                Content = Encoding.UTF8.GetString(file.File_stream)
            };

            return Ok(result);
        }

        // PUT: api/Page/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPage(Guid id, PageDto page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != page.Id)
            {
                return BadRequest();
            }

            var file = db.Set<File>().Single(f => f.Stream_id == id);

            if (file.Name != page.Title)
            {
                file.Name = page.Title;
                files.Rename.CallStoredProc(file);
            }

            if (Encoding.UTF8.GetString(file.File_stream) != page.Content)
            {
                file.File_stream = Encoding.UTF8.GetBytes(page.Content);
                files.Update.CallStoredProc(file);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Page
        [ResponseType(typeof(PageDto))]
        public IHttpActionResult PostPage(PageDto page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var file = new File()
            {
                Name = page.Title,
                File_stream = Encoding.UTF8.GetBytes(page.Content),
                Creation_time = page.CreatedAt.ToLocalTime(),
                Last_write_time = page.LastEditAt.ToLocalTime()
            };

            ResultsList spResult = files.CreateFile.CallStoredProc(file);
            CreateResult createResult = spResult.ToList<CreateResult>().First();

            page.Id = createResult.Stream_id;
            return CreatedAtRoute("DefaultApi", new { id = createResult.Stream_id }, page);
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