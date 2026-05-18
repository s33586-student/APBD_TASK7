using APBD_TASK7.Dtos;
using APBD_TASK7.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TASK7.Controllers
{
    [ApiController]
    [Route("api/pcs")]
    public class PcsController : ControllerBase
    {
        private readonly IPcService _pcService;

        public PcsController(IPcService pcService)
        {
            _pcService = pcService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pcService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}/components")]
        public async Task<IActionResult> GetComponents(int id)
        {
            var result = await _pcService.GetComponentsAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PcRequestDto request)
        {
            var result = await _pcService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = result.Id },
                result
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, PcRequestDto request)
        {
            var result = await _pcService.UpdateAsync(id, request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pcService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
