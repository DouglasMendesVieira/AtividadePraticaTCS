using AtividadePraticaTCS.Models.ViewModels;
using AtividadePraticaTCS.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AtividadePraticaTCS.Controllers
{
    public class StatusEventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Events()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatusEvent(StatusEventFormViewModel model)
        {
            if (model.Segundos < 10)
            {
                return RedirectToAction(nameof(Error), new { message = "The minimum interval accepted is 10 seconds." });
            }
            if (!ModelState.IsValid)
            {
                var viewModel = new StatusEventFormViewModel { Segundos = model.Segundos };
                return View(viewModel);
            }
            TimedHostedService._timer.Change(model.Segundos * 1000, model.Segundos * 1000);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
