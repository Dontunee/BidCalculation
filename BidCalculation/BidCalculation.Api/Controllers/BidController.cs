using BidCalculation.Api.Models;
using BidCalculation.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("AllowSpecificOrigin")] // Apply CORS policy at the controller level
public class BidController(FeeCalculatorService feeCalculatorService) : Controller
{
    [HttpPost]
    public IActionResult Calculate([FromBody]BidModel model)
    {
        Vehicle vehicle = model.VehicleType == "Common" ? new CommonVehicle { BasePrice = model.BasePrice } : new LuxuryVehicle { BasePrice = model.BasePrice } as Vehicle;
        var calculatedVehicle = feeCalculatorService.CalculateFees(vehicle);
        return Ok(calculatedVehicle);
    }
}