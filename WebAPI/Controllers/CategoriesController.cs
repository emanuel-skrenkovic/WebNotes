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
    public class CategoriesController : ApiController
    {
        private INoteService _service;

        public CategoriesController(INoteService service)
        {
            _service = service;
        }

        // GET: api/Categories
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _service.GetCategoriesAsync());
        }

        // GET: api/Categories/5
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await _service.GetCategoryByIdAsync(id));
        }

        // POST: api/Categories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categories/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]string value)
        {
            var category = await _service.GetCategoryByIdAsync(id);

            if (category == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            await _service.UpdateCategoryAsync(category);
            return Ok();
        }

        // DELETE: api/Categories/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _service.DeleteNoteAsync(id);
            return Ok();
        }
    }
}
