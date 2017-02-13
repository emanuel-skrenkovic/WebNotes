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
    public class CategoriesController : ApiController
    {
        private INoteService _service;

        public CategoriesController(INoteService service)
        {
            _service = service;
        }

        // GET: api/Categories
        public async Task<IEnumerable<ICategory>> Get()
        {
            return await _service.GetCategoriesAsync();
        }

        // GET: api/Categories/5
        public async Task<ICategory> Get(int id)
        {
            return await _service.GetCategoryByIdAsync(id);
        }

        // POST: api/Categories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
            _service.DeleteCategoryAsync(id);
        }
    }
}
