using FamilyTreeApi.Exceptions;
using FamilyTreeApi.Services;
using FamilyTreeApi.Utils.Constants;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly PeopleService _service;

    public PeopleController(PeopleService service)
    {
        _service = service;
    }

    [HttpGet("{treeId}")]
    public IActionResult GetPeople(string treeId)
    {
        try
        {
            var people = _service.GetPeopleByTreeId(treeId);
            return Ok(people);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ErrorMessages.UnExpectedError });
        }
    }
}