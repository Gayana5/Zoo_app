using System.Net.Mime;

namespace Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using DTOs;
using Infrastructure.Interfaces;
using Application.Interfaces;

[ApiController]
[Route("api/feeding-schedule")]
public class FeedingScheduleController(IFeedingScheduleRepository repo, IFeedingOrganizationService feedingOrganizationService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(feedingOrganizationService.GetFeedingSchedule());
    }

    [HttpPost]
    public IActionResult Create(FeedingDto dto)
    {
        try
        {
            var feeding = feedingOrganizationService.AddFeeding(dto.AnimalId, dto.FeedingTime, dto.Food);
            return CreatedAtAction(nameof(GetById), new { id = feeding.Id }, feeding);
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var schedule = repo.GetById(id);
        return schedule is null ? NotFound($"Feeding {id} not found") : Ok(schedule);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            repo.Remove(id);
            return Ok($"Feeding {id} was deleted");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, FeedingDto dto)
    {
        try
        {
            var feeding = new FeedingSchedule(dto.AnimalId, dto.FeedingTime, dto.Food);
            repo.Update(id, feeding);
            return Ok($"Feeding {id} updated");
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("{id}/done")]
    public IActionResult Done(int id)
    {
        try
        {
            feedingOrganizationService.MarkFeedingCompleted(id);
            return Ok($"Feeding {id} done");
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

