using Model.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
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

        // GET api/values/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await _service.GetNoteByIdAsync(id);
            return Ok(result);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]INote value)
        {
            _service.CreateNote(value);
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

            await _service.UpdateNote(value);
            return Ok();
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            _service.DeleteNote(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}