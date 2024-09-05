using Catalog.Application.Dtos.Category.Request;
using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Utilities.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Home.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyApplication _technologyApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public TechnologyController(ITechnologyApplication technologyApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _technologyApplication = technologyApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ReadTechnology([FromQuery] BaseFiltersRequest filters)
        {

            var response = await _technologyApplication.ReadTechnologies(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnTechnology();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);

                return File(fileBytes, ContentType.ContentTypeExcel);
            }
            return Ok(response);
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
