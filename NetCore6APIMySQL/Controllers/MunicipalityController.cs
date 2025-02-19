using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore6APIMySQL.Data.Repositories;
using NetCore6APIMySQL.Model;
using System.Runtime.Intrinsics.Arm;

namespace NetCore6APIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityRepository _munRepository;
        private readonly IDepartamentRepository _depRepository;

        public MunicipalityController(IMunicipalityRepository municipioRepository, IDepartamentRepository departamentoRepository)
        {
            _munRepository = municipioRepository;
            _depRepository = departamentoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMunici()
        {
            return Ok(await _munRepository.GetAllMun());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMuniciById(int id)
        {
            return Ok(await _munRepository.GetDetailsMun(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMunici([FromBody] Municipio mun )
        {
            if (mun == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var departamento = _depRepository.GetDetailsDep(mun.Departamento_Id);

            if (departamento == null)
                return BadRequest();

            var created = await _munRepository.InsertMun(mun);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMunici([FromBody] Municipio mun)
        {
            if (mun == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _munRepository.UpdateMun(mun);

            return Ok(new { message = "Successful modification", municipio = mun });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMunici(int id)
        {
            var delete = await _munRepository.DeleteMun(new Municipio { IdMunicipio = id });

            if (!delete)
                return NotFound(new { message = "The municipality was not found or has already been removed." });

            return Ok(new { message = "Municipality succesfully removed."});
        }
    }
}
