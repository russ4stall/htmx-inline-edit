using Htmx;
using InlineEdit.Models;
using Microsoft.AspNetCore.Mvc;

namespace InlineEdit.Controllers;

// [Route("calculator")]
public class CalculatorController : Controller
{

    [HttpGet("/calculator")]
    public IActionResult Index()
    {
        return Request.IsHtmx() ? PartialView() : View();
    }

    [HttpGet("/calculator/edit")]
    public IActionResult EditField([FromQuery] EditFieldViewModel viewModel)
    {
        return PartialView(viewModel);
    }
    
    [HttpPost("/calculator/calculate-row")]
    public IActionResult CalculateRow(CalculateRowViewModel calculateRow)
    {
        calculateRow.Total = calculateRow.StaticValueTwo + calculateRow.ValueOne + calculateRow.ValueTwo + calculateRow.ValueThree;
        
        return PartialView(calculateRow);
    }
    
}