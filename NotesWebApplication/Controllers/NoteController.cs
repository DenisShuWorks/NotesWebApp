using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotesWebApplication.DataAccess;
using NotesWebApplication.DataAccess.Providers;
using NotesWebApplication.Models;
using NotesWebApplication.ViewModels;

namespace NotesWebApplication.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteProvider _noteProvider;

        public NoteController(NoteProvider noteProvider)
        {
            _noteProvider = noteProvider;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _noteProvider.GetAll();

            return View(notes.Select(x => new NoteViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Text = x.Text.Length < 90 ? x.Text : x.Text.Substring(0, x.Text.Length - (x.Text.Length - 90)) + "...",
                UpdationDate = x.UpdationDate
            }).OrderBy(x=>x.UpdationDate).Reverse());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Text,Id,CreationDate,UpdationDate")] Note note)
        {
            await _noteProvider.Add(note);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _noteProvider.GetById(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(new NoteViewModel
            {
                Id = note.Id,
                Name = note.Name,
                Text = note.Text,
                UpdationDate = note.UpdationDate
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Text,Id,CreationDate,UpdationDate")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }
            note.UpdationDate = DateTime.Now;
            await _noteProvider.Edit(note);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _noteProvider.GetById(id);
            if (note == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _noteProvider.Remove(await _noteProvider.GetById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
