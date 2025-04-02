using FamilyTreeApi.Services;
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
        var people = _service.GetPeopleByTreeId(treeId);
        return Ok(people);
    }
}
