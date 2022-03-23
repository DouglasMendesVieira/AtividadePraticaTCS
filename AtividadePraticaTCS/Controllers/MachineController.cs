using AtividadePraticaTCS.Services;
using Microsoft.AspNetCore.Mvc;
using AtividadePraticaTCS.Models;
using AtividadePraticaTCS.Models.ViewModels;
using System.Collections.Generic;
using AtividadePraticaTCS.Services.Exceptions;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace AtividadePraticaTCS.Controllers
{
    public class MachineController : Controller
    {
        private readonly MachineService _machineService;
        private readonly StatusService _statusService;
        public MachineController(MachineService machineService, StatusService statusService)
        {
            _machineService = machineService;
            _statusService = statusService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _machineService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var status = await _statusService.FindAllAsync();
            var viewModel = new MachineFormViewModel { Status = status };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Machine machine)
        {
            if (!ModelState.IsValid)
            {
                var status = await _statusService.FindAllAsync();
                var viewModel = new MachineFormViewModel { Machine = machine, Status = status };
                return View(viewModel);
            }
            await _machineService.InsertAsync(machine);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }
            var obj = await _machineService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found." });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _machineService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }
            var obj = await _machineService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found." });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });
            }
            var obj = await _machineService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found." });
            }

            List<Status> Status = await _statusService.FindAllAsync();
            MachineFormViewModel viewModel = new MachineFormViewModel { Machine = obj, Status = Status };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Machine machine)
        {
            if (!ModelState.IsValid)
            {
                var status = await _statusService.FindAllAsync();
                var viewModel = new MachineFormViewModel { Machine = machine, Status = status };
                return View(viewModel);
            }
            if (id != machine.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch." });
            }
            try
            {
                await _machineService.UpdateAsync(machine);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
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
