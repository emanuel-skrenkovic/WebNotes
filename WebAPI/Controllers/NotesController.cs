using Model.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class NotesController : ApiController
    {
        private INoteService _service;

        public NotesController(INoteService service)
        {
            _service = service;
        }

        // GET api/values
        public async Task<IHttpActionResult> Get()
        {
            var result = await _service.GetNotesAsync();
            return Ok(result);
        }

        public async Task<IHttpActionResult> Get(int pageNumber, int pageSize)
        {
            var result = await _service.GetPagedNotesAsync(pageNumber, pageSize);
            return Ok(result);
        }

        // GET api/values/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await _service.GetNoteByIdAsync(id);
            return Ok(result);
        }

        // POST api/values
        public async Task<IHttpActionResult> Post([FromBody]INote value)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatus‌​Code.BadRequest, this.ModelState));
            }

            await _service.CreateNoteAsync(value);
            return Ok();
        }

        // PUT api/values/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]INote value)
        {
            var note = await _service.GetNoteByIdAsync(id);

            if (note == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            await _service.UpdateNoteAsync(value);
            return Ok();
        }

        // DELETE api/values/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _service.DeleteNoteAsync(id);
            return Ok();
        }
    }
}