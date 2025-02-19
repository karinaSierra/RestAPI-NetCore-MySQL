using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IDepartamentRepository _depRepository;

        public DepartamentController(IDepartamentRepository departamentoRepository)
        {
            _depRepository = departamentoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepart()
        {
            return Ok(await _depRepository.GetAllDep());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartById(int id)
        {
            return Ok(await _depRepository.GetDetailsDep(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepart([FromBody] Departamento dep)
        {
            if (dep == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _depRepository.InsertDep(dep);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepart([FromBody] Departamento dep)
        {
            if (dep == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _depRepository.UpdateDep(dep);

            return Ok(new { message = "Successful modification", departamento = dep });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepart(int id)
        {
            var delete =await _depRepository.DeleteDep(new Departamento { IdDepartamento = id });

            if (!delete)
                return NotFound(new { message = "The apartment was not found or has already been removed." });

            return Ok(new { message = "Department successfully removed." });
        }
    }
}
