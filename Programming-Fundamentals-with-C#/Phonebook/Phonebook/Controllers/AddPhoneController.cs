using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class AddPhoneController : Controller
    {
        public IActionResult Index()
        {
            return View(DataContext.Contacts);
        }

        [HttpPost]
        public IActionResult Add(Contact model)
        {
            if (ModelState.IsValid)
            {
                DataContext.Contacts.Add(model);
            }
            else
            {
                TempData["Error"] = "Невалидни данни!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
