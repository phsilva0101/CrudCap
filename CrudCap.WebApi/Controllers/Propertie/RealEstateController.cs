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
    }
}
