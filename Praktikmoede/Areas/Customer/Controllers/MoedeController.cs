using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktikmoede.Data;
using Praktikmoede.Models;
using Praktikmoede.ViewModels;

namespace Praktikmoede.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MoedeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MoedeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.Moede.ToListAsync());
        }
        //GET Create
        public IActionResult Create()
        {
            return View();
        }

        //Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var moede = await _db.Moede.FindAsync(id);
            if(moede==null)
            {
                return NotFound();
            }
            return View(moede);
        }
        //Get Details
        public async Task<IActionResult> Details(int? id)
        {

            MoedeDetails moedeDetails = new MoedeDetails();
            moedeDetails.moede = await _db.Moede.FindAsync(id);
            moedeDetails.moedeDeltagere = await _db.MoedeDeltager.Include(s => s.Moede).Where(s => s.MoedeId == id).ToListAsync();
            return View(moedeDetails);


        }

        //POST
        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(Moede moede)
        {
            if(ModelState.IsValid)
            {
                _db.Moede.Add(moede);
                await _db.SaveChangesAsync() ;

                return RedirectToAction(nameof(Index));
            }
            return View(moede);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moede = await _db.Moede.FindAsync(id);
            _db.Moede.Remove(moede);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET - Edit

        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var moede = await _db.Moede.FindAsync(id);
            if(moede==null)
            {
                return NotFound();
            }
            return View(moede); 
        }

        //POST -Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Moede moede)
        {
            if (ModelState.IsValid)
            {
                _db.Update(moede);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(moede);
        }
    }
}