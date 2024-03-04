using Microsoft.AspNetCore.Mvc;
using Drivers.Api.Services;
using Drivers.Api.Models;

namespace Drivers.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrerasController : ControllerBase
{
    
    private readonly ILogger<CarrerasController> _logger;
    private readonly CarrerasServices _carrerasServices;

    public CarrerasController(
        ILogger<CarrerasController> logger,
        CarrerasServices driverServices)
    {
        _logger= logger;
        _carrerasServices = driverServices;
    }

    [HttpGet]

    public async Task <IActionResult> GetDrivers()
    {
            var drivers=await _carrerasServices.GetAsync();
            return Ok(drivers);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetDriversByID(string Id)
    {

        return Ok(await _carrerasServices.GetDriverById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] Carreras carrera)
    {
        if (carrera == null)
            return BadRequest();
        if (carrera.Name == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        await _carrerasServices.InsertDriver(carrera);
        return Created("Created", true);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver([FromBody] Carreras carrera, string id)
    {
        if (carrera == null)
            return BadRequest();
        if (carrera.Name == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        carrera.Id = id;

        await _carrerasServices.UpdateDriver(carrera);
        return Created("Created", true);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Deletedriver(string Id)
    {

        await _carrerasServices.DelateDriver(Id);
        return NoContent();
    }
}
