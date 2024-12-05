using Homework.API.Contracts;
using Homework.Application.Services;
using Homework.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Homework.Core.Models;


namespace Homework.API.Controllers;
[ApiController]
[Route("[controller]")]
public class HomesController : ControllerBase
{
    private readonly IHomesService _homesService;

    public HomesController(IHomesService homesService)
    {
        _homesService = homesService;
    }

    [HttpGet]
    public async Task<ActionResult<List<HomesResponse>>> GetHomes()
    {
        var homes = await _homesService.GetAllHomes();
        var response = homes.Select(b => new HomesResponse(b.Id, b.Title, b.Description, b.PhotoPath,
            b.FirstName, b.LastName, b.PhoneNumber, b.Price));
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateHome([FromBody] HomesRequest request)
    {
        var (home, error) = Home.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.PhotoPath,
            request.FirstName,
            request.LastName,
            request.PhoneNumber,
            request.Price);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var homeId = await _homesService.CreateHome(home);

        return Ok(homeId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateHomes(Guid id, [FromBody] HomesRequest request)
    {
        var homeId = await _homesService.UpdateHome(id, request.Title, request.Description,
            request.PhotoPath, request.FirstName, request.LastName, request.PhoneNumber, request.Price);
        return Ok(homeId);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteHome(Guid id)
    {
        return Ok(await _homesService.DeleteHome(id));
    }
}