using BidCalculation.Models;
using BidCalculation.services;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Controllers;

public class BidController(FeeCalculatorService feeCalculatorService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new CommonVehicle());
    }

    [HttpPost]
    public IActionResult Calculate(decimal basePrice, string vehicleType)
    {
        Vehicle vehicle = vehicleType == "Common" ? new CommonVehicle { BasePrice = basePrice } : new LuxuryVehicle { BasePrice = basePrice } as Vehicle;
        var calculatedVehicle = feeCalculatorService.CalculateFees(vehicle);
        return View("Index", calculatedVehicle);
    }
}