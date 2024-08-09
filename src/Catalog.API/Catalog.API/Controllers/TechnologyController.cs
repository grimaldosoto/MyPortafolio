using Catalog.Application.Dtos.Category.Request;
using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace Home.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyApplication _technologyApplication;

        public TechnologyController(ITechnologyApplication technologyApplication)
        {
            _technologyApplication = technologyApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ReadTechnology([FromBody] BaseFiltersRequest filters)
        {
            return Ok(await _technologyApplication.ReadTechnologies(filters));
        }

        [HttpGet("select")]
        public async Task<IActionResult> ListSelectCategories()
        {
            return Ok(await _technologyApplication.ListSelectTechnologies()); 
        }

        [HttpGet("{technologyId:int}")]
        public async Task<IActionResult> TechnologyById(int technologyId)
        {
            return Ok( await _technologyApplication.TechnologyById(technologyId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTechnology([FromBody] TechnologyRequestDto requestDto)
        {
            return Ok( await _technologyApplication.CreateTechnology(requestDto));
        }

        [HttpPut("update/{technologyId:int}")]
        public async Task<IActionResult> UpdateTechnology([FromBody] TechnologyRequestDto requestDto, int technologyId)
        {
            return Ok( await _technologyApplication.UpdateTechnology(technologyId, requestDto));
        }

        [HttpDelete("Delete/{technologyId:int}")]
        public async Task<IActionResult> DeleteTechnology(int technologyId)
        {
            return Ok(await _technologyApplication.DeleteTechnology(technologyId));
        }
    }
}
