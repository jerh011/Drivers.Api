using Microsoft.AspNetCore.Mvc;
using Drivers.Api.Services;
using Drivers.Api.Models;

namespace Drivers.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{

    private readonly ILogger<DriversController> _logger;
    private readonly DriverServices _driverServices;

    public DriversController(
        ILogger<DriversController> logger,
        DriverServices driverServices)
    {
        _logger = logger;
        _driverServices = driverServices;
    }

    [HttpGet]

    public async Task<IActionResult> GetDrivers()
    {
        var drivers = await _driverServices.GetAsync();
        return Ok(drivers);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetDriversByID(string Id)
    {

        return Ok(await _driverServices.GetDriverById(Id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] Driver drive)
    {
        if (drive == null)
            return BadRequest();
        if (drive.Name == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        await _driverServices.InsertDriver(drive);
        return Created("Created", true);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver([FromBody] Driver drive, string id)
    {
        if (drive == null)
            return BadRequest();
        if (drive.Name == string.Empty)
            ModelState.AddModelError("Name", "El driver no debe estar vacio");

        drive.Id = id;

        await _driverServices.UpdateDriver(drive);
        return Created("Created", true);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Deletedriver(string Id)
    {

        await _driverServices.DelateDriver(Id);
        return NoContent();
    }
}