using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToyController : ControllerBase
{
    private IToyService toyService;

    public ToyController(IToyService toyService)
    {
        this.toyService = toyService;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IList<Toy>>> GetToys()
    {
        try
        {
            IList<Toy> toys = await toyService.GetToysAsync();
            return Ok(toys);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    [Route("/toy/owner/{childId:int}")]
    public async Task<ActionResult<Toy>> AddToy([FromBody] Toy toy, [FromRoute] int childId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            Toy added = await toyService.SaveToyAsync(toy, childId);
            return Created($"/{toy.Id}", added); // return newly added toy, to get the auto generated childId
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    [Route("{Id:int}")]
    public async Task<ActionResult> DeleteToy([FromRoute] int id)
    {
        try
        {
            var returnValue = await toyService.DeleteToyAsync(id);
            return Ok(returnValue);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}