namespace Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using DTOs;
using Infrastructure.Interfaces;
using Application.Interfaces;

[ApiController]
[Route("api/statistics")]
public class StatisticsController(IZooStatisticsService statisticsService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(statisticsService.GetStatistics());
    }
}