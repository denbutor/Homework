using Homework.Application.Services;
using Homework.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers;
[ApiController]
[Route("[controller]")]
public class HomeworksController : ControllerBase
{
    private readonly IHomeworksService _homeworksService;

    public HomeworksController(IHomeworksService homeworksService)
    {
        _homeworksService = _homeworksService;
    }

    [HttpGet]
    public async Task<ActionResult<List<HomeworksResponse>>> GetHomeworks()
    {
        var homeworks = await _homeworksService.GetAllHomeworks();
        var response = homeworks.Select(b => new HomeworksResponse(b.Id, b.Title, b.Description, b.PhotoPath,
            b.FirstName, b.LastName, b.PhoneNumber, b.Price));
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateHomework([FromBody] HomeworksRequest request)
    {
        var (homework, error) = Homework.Create(
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

        var homeworkId = await _homeworksService.CreateHomework(homework);

        return Ok(homeworkId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateHomeworks(Guid id, [FromBody] HomeworksRequest request)
    {
        var homeworkId = await _homeworksService.UpdateHomework(id, request.Title, request.Description,
            request.PhotoPath, request.FirstName, request.LastName, request.PhoneNumber, request.Price);
        return Ok(homeworkId);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteHomeworks(Guid id)
    {
        return Ok(await _homeworksService.DeleteHomework(id));
    }
}