using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {

        // Creating a private readonly field for the database context
        private readonly MyAppContext _context;

        // Constructor to initialize the database context
        public ItemsController(MyAppContext context)
        {
            _context = context;
        }


        // GET: Items
        public async Task<IActionResult> Index()
        {
            // Retrieve all items from the database and pass them to the view
            var item = await _context.Item.Include(s => s.SerialNumber).ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Models.Item item)
        {
            if (ModelState.IsValid)
            {
                // Add the new item to the database context
                _context.Item.Add(item);
                // Save changes to the database
                await _context.SaveChangesAsync();
                // Redirect to the Index action to display the list of items
                return RedirectToAction(nameof(Index));
            }
            // If the model state is not valid, return to the Create view with the current item data
            return View(item);

        }

        // Get Edit
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Models.Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // Get Delete   
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
