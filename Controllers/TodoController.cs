using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? prioridad)
        {
            var userId = _userManager.GetUserId(User);
            var query = _context.TodoItems.Where(t => t.UserId == userId);

            if (!string.IsNullOrEmpty(prioridad))
                query = query.Where(t => t.Prioridad == prioridad);

            var list = await query.OrderByDescending(t => t.FechaCreacion).ToListAsync();
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItem item)
        {
            if (!ModelState.IsValid) return View(item);

            item.UserId = _userManager.GetUserId(User);
            item.FechaCreacion = DateTime.UtcNow;

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();
            if (item.UserId != _userManager.GetUserId(User)) return Forbid();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoItem item)
        {
            if (!ModelState.IsValid) return View(item);
            var existing = await _context.TodoItems.AsNoTracking().FirstOrDefaultAsync(t => t.Id == item.Id);
            if (existing == null) return NotFound();
            if (existing.UserId != _userManager.GetUserId(User)) return Forbid();

            item.UserId = existing.UserId;
            _context.TodoItems.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();
            if (item.UserId != _userManager.GetUserId(User)) return Forbid();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();
            if (item.UserId != _userManager.GetUserId(User)) return Forbid();

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
