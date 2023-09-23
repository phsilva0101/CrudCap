using CrudCap.Domain.ViewModels.Base;
using CrudCap.Domain.ViewModels.RealEstate;
using CrudCap.Services.Interfaces.Propertie;
using Microsoft.AspNetCore.Mvc;

namespace CrudCap.WebApi.Controllers.Propertie
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;

        public RealEstateController(IRealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginationItemsResponse<RealEstateResponseModel>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRealEstate([FromQuery] RealEstateRequestFilterModel request, CancellationToken cancellationToken)
        {
            var result = await _realEstateService.GetAllRealEstate(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsertRealEstate([FromBody] RealEstateInsertModel model, CancellationToken cancellationToken)
        {
            await _realEstateService.InsertRealEstateAsync(model, cancellationToken);
            return CreatedAtAction(nameof(GetAllRealEstate), model);
        }

        [HttpDelete("inativar/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SoftDelete(Guid id, CancellationToken cancellationToken)
        {
            await _realEstateService.SoftDelete(id, cancellationToken);
            return NoContent();
        }
    }
}
