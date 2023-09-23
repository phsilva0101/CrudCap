using CrudCap.Domain.ViewModels.Base;
using CrudCap.Domain.ViewModels.Propertie;
using CrudCap.Services.Interfaces.Propertie;
using Microsoft.AspNetCore.Mvc;

namespace CrudCap.WebApi.Controllers.Propertie
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertiesService _propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            _propertiesService = propertiesService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PropertiesResponseFullModel), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _propertiesService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginationItemsResponse<PropertiesResponseFullModel>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProperties([FromQuery] PropertiesRequestFilterModel request, CancellationToken cancellationToken)
        {
            var result = await _propertiesService.GetAllProperties(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertProperty([FromBody] PropertiesInsertModel model, CancellationToken cancellationToken)
        {
            var createdId = await _propertiesService.InsertProperty(model, cancellationToken);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdId }, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProperties([FromBody] PropertiesUpdateModel model, CancellationToken cancellationToken)
        {
            await _propertiesService.UpdateProperties(model, cancellationToken);
            return NoContent();
        }

        [HttpDelete("inativar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SoftDelete(Guid id, CancellationToken cancellationToken)
        {
            await _propertiesService.SoftDelete(id, cancellationToken);
            return NoContent();
        }
    }
}
