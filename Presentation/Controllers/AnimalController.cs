namespace Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interfaces;
using DTOs;
using Domain.Entities;
using Domain.ValueObjects;
using Application.Interfaces;



[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalRepository _animalRepo;
    private readonly IAnimalTransferService _animalTransferService;

    public AnimalsController(IAnimalRepository animalRepo, IAnimalTransferService animalTransferService, IFeedingOrganizationService feedingOrganizationService)
    {
        _animalRepo = animalRepo;
        _animalTransferService = animalTransferService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_animalRepo.GetAll());
    }

    [HttpPost]
    public IActionResult Create(AnimalDto dto)
    {
        var animal = new Animal(dto.Species, dto.Name, dto.BirthDate, dto.Gender, new Food(dto.FavoriteFood));
        _animalRepo.Add(animal);
        return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var animal = _animalRepo.GetById(id);
        return animal is null ? NotFound("Animal not found") : Ok(animal);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _animalRepo.Remove(id);
            return Ok($"Animal {id} has been deleted");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("{id}/treat")]
    public IActionResult Treat(int id)
    {
        try
        {
            _animalRepo.Treat(id);
            return Ok($"Animal {id} has been treated");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("{id}/feed")]
    public IActionResult Feed(int id)
    {
        try
        {
            _animalRepo.Feed(id);
            return Ok($"Animal {id} has been fed");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPut("{id}/transfer/{newEnclosureId}")]
    public IActionResult Transfer(int id, int newEnclosureId)
    {
        try
        {
            _animalTransferService.TransferAnimal(id, newEnclosureId);
            return Ok($"Animal {id} has been moved to enclosure {newEnclosureId}");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
}

