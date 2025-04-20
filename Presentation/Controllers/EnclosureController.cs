namespace Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using DTOs;
using Infrastructure.Interfaces;

[ApiController]
[Route("api/enclosures")]
public class EnclosuresController(IEnclosureRepository repo) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(repo.GetAll());
    }

    [HttpPost]
    public IActionResult Create(EnclosureDto dto)
    {
        var enclosure = new Enclosure(dto.Type, dto.Size, dto.Capacity);
        repo.Add(enclosure);
        return CreatedAtAction(nameof(GetById), new { id = enclosure.Id }, enclosure);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var enclosure = repo.GetById(id);
        return enclosure is null ? NotFound("Enclosure not found") : Ok(enclosure);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            repo.Remove(id);
            return Ok("Enclosure was deleted");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPost("{id}/clean")]
    public IActionResult Clean(int id)
    {
        try
        {
            repo.Clean(id);
            return Ok($"Enclosure {id} has been cleaned");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}

