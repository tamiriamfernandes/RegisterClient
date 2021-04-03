using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegisterClient.Data;
using RegisterClient.Models;
using RegisterClient.Models.ViewModels;
using RegisterClient.Services;
using RegisterClient.Services.Exceptions;
using RegisterClient.Services.Interface;

namespace RegisterClient.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        #region GET
        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var listClient = await clientService.FindAllAsync();
            return View(listClient);
        }
        // GET: Clients/Create
        public IActionResult Create()
        {
            var list = new[]
            {
                new SelectListItem { Value = "F", Text = "Física" },
                new SelectListItem { Value = "J", Text = "Juridica" },
            };

            ViewBag.Lista = new SelectList(list, "Value", "Text");
            return View();
        }
        // GET: Clients/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var client = await clientService.FindByIdAsync((int)id);
            if (client == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cliente não encontrado!" });
            }

            var list = new[]
            {
                new SelectListItem { Value = "F", Text = "Física" },
                new SelectListItem { Value = "J", Text = "Juridica" },
            };

            ViewBag.Lista = new SelectList(list, "Value", "Text");
            return View(client);
        }
        // GET: Clients/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var client = await clientService.FindByIdAsync((int)id);
            if (client == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Cliente não encontrado!" });
            }

            var list = new[]
            {
                new SelectListItem { Value = "F", Text = "Física" },
                new SelectListItem { Value = "J", Text = "Juridica" },
            };
            ViewBag.Lista = new SelectList(list, "Value", "Text");

            return View(client);
        }
        // GET: Clients/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var client = await clientService.FindByIdAsync((int)id);
            if (client == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            var list = new[]
            {
                new SelectListItem { Value = "F", Text = "Física" },
                new SelectListItem { Value = "J", Text = "Juridica" },
            };
            ViewBag.Lista = new SelectList(list, "Value", "Text");

            return View(client);
        }
        #endregion

        #region POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            await clientService.InsertAsync(client);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Client client)
        {
            if (id != client.Id)
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde!" });

            try
            {
                await clientService.UpdateAsync(client);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await clientService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
