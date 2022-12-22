using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
//unfortunate naming, if ill have time ill change it to Children controller so get children would be localhost:xxx/children
//todo refactor to children controller
public class ChildController : ControllerBase
{
    private IChildService childService;

    public ChildController(IChildService childService)
    {
        this.childService = childService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IList<Child>>> GetChildren()
    {
        try
        {
            IList<Child> children = await childService.GetChildrenAsync();
            return Ok(children);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Child>> AddChild([FromBody] Child child)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Child added = await childService.SaveChildAsync(child);
            return Created($"/{child.Id}", added); // return newly added child, to get the auto generated id
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}