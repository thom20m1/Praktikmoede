using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktikmoede.Data;
using Praktikmoede.Models;

namespace Praktikmoede.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MoedeDeltagerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MoedeDeltagerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var MoedeDeltagere = await _db.MoedeDeltager.Include(s => s.Moede).ToListAsync();
            return View(MoedeDeltagere);
        }
    }
}