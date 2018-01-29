using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace AutoSystems.Controllers
{
    public class TelegramController : Controller
    {
        private readonly ITelegramRepository _tRepo;

        public TelegramController(ITelegramRepository tRepo)
        {
            _tRepo = tRepo;
        }
        // GET: Telegram
        public ActionResult Index()
        {
            return View(_tRepo.ListAll());
        }

        // GET: Telegram/Details/5
        public ActionResult Details(int id)
        {
            return View(_tRepo.GetById(id));
        }

        // GET: Telegram/Create
        public ActionResult Create()
        {
            return View(new Telegram());
        }

        // POST: Telegram/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Telegram newTelegram)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tRepo.Add(newTelegram);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // TODO Log the error
                //return View(newTelegram);
            }

            return View(newTelegram);
        }

        // GET: Telegram/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_tRepo.GetById(id));
        }

        // POST: Telegram/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Telegram editedTelegram)
        {
            try
            {
                _tRepo.Edit(editedTelegram);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(editedTelegram);
        }

        // GET: Telegram/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_tRepo.GetById(id));
        }

        // POST: Telegram/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Telegram telegramToDelete)
        {
            try
            {
                _tRepo.Delete(telegramToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // TODO Log the exception
            }
            return View(telegramToDelete);
        }
    }
}