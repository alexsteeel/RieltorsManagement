using Microsoft.AspNetCore.Mvc;
using RieltorsManagement.BLL;
using System.Collections.Generic;
using System.Linq;

namespace RieltorsManagement.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : Controller
    {
        public DivisionsController()
        {
            DivisionService = new DivisionService();
        }

        public DivisionService DivisionService { get; set; }

        // GET api/divisions
        [HttpGet]
        public List<DivisionDTO> Get(string name = null, int? page = null, int? pageSize = 5)
        {
            var divisions = DivisionService.GetDivisions();
            var result = new List<DivisionDTO>();

            if (string.IsNullOrEmpty(name) && !page.HasValue)
            {
                return divisions.ToList();
            }

            result = divisions.Where(x => x.Name.Contains(name ?? "")).
                ToList();

            if (!page.HasValue)
            {
                return result;
            }

            return result.Skip(((int)page - 1) * (int)pageSize).
                Take((int)pageSize).
                ToList();
        }

        // GET api/divisions/5
        [HttpGet("{id}")]
        public DivisionDTO Get(int id)
        {
            return DivisionService.GetDivision(id);
        }

        // POST api/divisions
        [HttpPost]
        public IActionResult Post([FromBody] DivisionDTO division)
        {
            DivisionService.AddDivision(division);
            return Ok(division);
        }

        // PUT api/divisions/
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DivisionDTO division)
        {
            DivisionService.UpdateDivision(division);
            return Ok(division);
        }

        // DELETE api/divisions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DivisionService.DeleteDivision(id);
        }
    }
}
