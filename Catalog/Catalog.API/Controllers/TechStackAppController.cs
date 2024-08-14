using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechStackAppController : ControllerBase
    {
        private readonly ITechStackAppApplication _techStackAppApplication;

        public TechStackAppController(ITechStackAppApplication techStackAppApplication)
        {
            _techStackAppApplication = techStackAppApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListTechStackApps([FromBody] BaseFiltersRequest filters)
        {
            return Ok(await _techStackAppApplication.ListTechStackApps(filters));
        }
    }
}
