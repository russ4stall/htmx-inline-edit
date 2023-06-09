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
        var rows = new List<CalculateRowViewModel>();
        rows.Add(new CalculateRowViewModel
        {
            StaticValueOne = "Russell",
            StaticValueTwo = 100,
            ValueOne = 34,
            ValueTwo = 12,
            ValueThree = 100
        });
        
        rows.Add(new CalculateRowViewModel
        {
            StaticValueOne = "Steven",
            StaticValueTwo = 150,
            ValueOne = 11,
            ValueTwo = 12,
            ValueThree = 69
        });
        
        return Request.IsHtmx() ? PartialView(rows) : View(rows);
    }

    [HttpGet("/calculator/edit")]
    public IActionResult EditField([FromQuery] EditFieldViewModel viewModel)
    {
        return PartialView(viewModel);
    }
    
    [HttpPost("/calculator/calculate-row")]
    public IActionResult CalculateRow(CalculateRowViewModel calculateRow)
    {
        return PartialView(calculateRow);
    }
}