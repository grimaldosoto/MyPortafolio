using Catalog.Application.Dtos.TechStackApp.Request;
using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Commons.Bases.Request;
using Catalog.Utilities.Static;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TechStackAppController : ControllerBase
    {
        private readonly ITechStackAppApplication _techStackAppApplication;
        private readonly IGenerateExcelApplication _generateExcelApplication;

        public TechStackAppController(ITechStackAppApplication techStackAppApplication, IGenerateExcelApplication generateExcelApplication)
        {
            _techStackAppApplication = techStackAppApplication;
            _generateExcelApplication = generateExcelApplication;
        }

        [HttpGet]
        public async Task<IActionResult> ListTechStackApps([FromQuery] BaseFiltersRequest filters)
           {
            var response = await _techStackAppApplication.ListTechStackApps(filters);

            if ((bool)filters.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnTechStackApp();
                var fileBytes = _generateExcelApplication.GenerateToExcel(response.Data!, columnNames);

                return File(fileBytes, ContentType.ContentTypeExcel);
            }
            return Ok(response);
        }

        [HttpGet("{techStackAppId:int}")]
        public async Task<IActionResult> TechStackAppById(int techStackAppId)
        {
            return Ok(await _techStackAppApplication.TechStackAppById(techStackAppId));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTechStackApp([FromBody] TechStackAppRequestDto requestDto)
        {
            return Ok(await _techStackAppApplication.CreateTechStachApp(requestDto));
        }

        [HttpPut("Update/{techStackAppId:int}")]
        public async Task<IActionResult> UpdateTechStackApp(int techStackAppId, [FromBody] TechStackAppRequestDto requestDto)
        {
            return Ok(await _techStackAppApplication.UpdateTechStackApp(techStackAppId, requestDto));   
        }
        [HttpDelete("Delete/{techStackAppId:int}")]
        public async Task<IActionResult> DeleteTechStackApp(int techStackAppId)
        {
            return Ok(await _techStackAppApplication.DeleteTechStackApp(techStackAppId));
        }
    }
}
