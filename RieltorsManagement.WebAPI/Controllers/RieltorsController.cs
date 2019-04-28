using Microsoft.AspNetCore.Mvc;
using RieltorsManagement.BLL;
using System.Collections.Generic;
using System.Linq;

namespace RieltorsManagement.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RieltorsController : Controller
    {
        public RieltorsController()
        {
            RieltorService = new RieltorService();
        }

        public RieltorService RieltorService { get; set; }

        // GET api/rieltors
        [HttpGet]
        public List<RieltorDTO> Get(string lastName = null, string division = null, int? page = null, int? pageSize = 5)
        {
            var rieltors = RieltorService.GetRieltors();
            var result = new List<RieltorDTO>();

            if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(division) && !page.HasValue)
            {
                return rieltors.ToList();
            }

            result = rieltors.Where(x => x.LastName.Contains(lastName ?? "") && x.Division.Contains(division ?? "")).
                ToList();

            if (!page.HasValue)
            {
                return result;
            }

            return result.Skip(((int)page - 1) * (int)pageSize).
                Take((int)pageSize).
                ToList();
        }

        // GET api/rieltors/5
        [HttpGet("{id}")]
        public RieltorDTO Get(int id)
        {
            return RieltorService.GetRieltor(id);
        }

        // POST api/rieltors
        [HttpPost]
        public IActionResult Post([FromBody] RieltorDTO rieltor)
        {
            RieltorService.AddRieltor(rieltor);
            return Ok(rieltor);
        }

        // PUT api/rieltors/
        [HttpPut]
        public IActionResult Put([FromBody] RieltorDTO rieltor)
        {
            RieltorService.UpdateRieltor(rieltor);
            return Ok(rieltor);
        }

        // DELETE api/rieltors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            RieltorService.DeleteRieltor(id);
            return Ok(id);
        }
    }
}
