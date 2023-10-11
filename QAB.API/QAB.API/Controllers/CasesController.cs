using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAB.Services.Models.Dtos.Case;
using QAB.Services.Services.Interfaces;

namespace QAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ICaseService _caseService;

        public CasesController(ICaseService caseService)
        {
            _caseService = caseService;
        }

        /// <summary>
        /// Get all cases.
        /// </summary>
        /// <returns>Returns an object with list of case dtos - cases</returns>
        /// <response code="200">Returns the object with cases</response>
        /// <response code="500">If an error occurs, returns the error details.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCases()
        {
            var cases = (await _caseService.GetAllCasesAsync()).ToList();
            return new JsonResult(cases);
        }

        /// <summary>
        /// Get case by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns an object with case dto by its id - case</returns>
        /// <response code="200">Returns the case - case dto by id</response>
        /// <response code="500">If an error occurs, returns the error details</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCaseById(int id)
        {
            CaseDto caseEntity = await _caseService.GetCaseByIdAsync(id);
            return new JsonResult(caseEntity);
        }

        /// <summary>
        /// Create a new case
        /// </summary>
        /// <param name="caseRequestDto"></param>
        /// <returns>Returns an abject with new case dto - caseDto and message</returns>
        /// <response code="200">Returns a case dto</response>
        /// <response code="500">If an error occurs, returns the error details</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCase(CaseRequestDto caseRequestDto)
        {
            CaseDto caseDto = await _caseService.AddCaseAsync(caseRequestDto);
            return new JsonResult(new { CaseDto = caseDto, Message = "Created successfully!" });
        }

        /// <summary>
        /// Update an existed case
        /// </summary>
        /// <param name="caseRequestDto"></param>
        /// <returns>Returns an object with the updated case of type CaseDto - caseDto and message</returns>
        /// <response code="200">Returns the updated caseDto</response>
        /// <response code="500">If an error occurs, returns the error details</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCase(CaseRequestDto caseRequestDto)
        {
            CaseDto caseDto = await _caseService.UpdateCase(caseRequestDto);
            return new JsonResult(new { CaseDto = caseDto, Message = "Updated successfully!"});
        }

        /// <summary>
        /// Delete a case
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns an object with message response</response>
        /// <response code="500">If an error occurs, returns the error</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCase(int id)
        {
            _caseService.RemoveCase(id);
            return new JsonResult(new { Message = "Deleted successfully!"});
        }
    }
}
