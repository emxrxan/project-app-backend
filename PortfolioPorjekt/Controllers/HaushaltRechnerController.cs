using Microsoft.AspNetCore.Mvc;
using PortfolioPorjekt.IServices;
using PortfolioPorjekt.Resources;
using PortfolioPorjekt.Services;

namespace PortfolioPorjekt.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/HaushaltRechner")]
    public class HaushaltRechnerController : Controller
    {
        public readonly DatabaseContext _Database;
        public readonly IHaushaltRechnerService _HaushaltRechnerService;
        public HaushaltRechnerController(DatabaseContext database, IHaushaltRechnerService haushaltRechnerService)
        {
            _Database = database;
            _HaushaltRechnerService = haushaltRechnerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<HaushaltRechnerResource>), 200)]
        public async Task<IActionResult> GellAll() {
            try
            {
                IEnumerable<HaushaltRechnerResource> ListOfHaushaltRechner = await _HaushaltRechnerService.getAll();
                return Ok(ListOfHaushaltRechner);
            }
            catch
            {
                throw new Exception("Can't get all HaushaltRechner from Controller");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(HaushaltRechnerResource), 201)]
        public async Task<IActionResult> Create([FromBody] HaushaltRechnerResource neuHaushaltRechner)
        {
            try
            {
                if (neuHaushaltRechner == null)
                {
                    return BadRequest("Request has an invalid format");
                }
                HaushaltRechnerResource haushaltRechner = await _HaushaltRechnerService.Create(neuHaushaltRechner);
                return CreatedAtAction(nameof(Create), haushaltRechner);
            }
            catch
            {
                throw new Exception("Can't create new HaushaltRechner from Controller");
            }
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(HaushaltRechnerResource), 204)]
        public async Task<IActionResult> Update(int Id, HaushaltRechnerResource updateHaushaltRechner)
        {
            try
            {
                if (updateHaushaltRechner == null || updateHaushaltRechner.Id != Id) return BadRequest("Request has an invalid format");
                await _HaushaltRechnerService.Update(Id,updateHaushaltRechner);
                return NoContent();
            }
            catch
            {
                throw new Exception("Can't update HaushaltRechner from Controller");
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                string result = await _HaushaltRechnerService.Delete(Id);
                return NoContent();
            }
            catch
            {
                throw new Exception("Can't update HaushaltRechner from Controller");
            }
        }
    }
}
