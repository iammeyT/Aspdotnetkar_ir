
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aspdotnetkar.Models;
using Aspdotnetkar.Context;

public class BlogCategoryController : Controller
{
    private readonly SiteContext _context;

    public BlogCategoryController(SiteContext context)
    {
        _context = context;
    }

    // GET: BLOGCATEGORYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.blogCategories.ToListAsync());
    }

    // GET: BLOGCATEGORYS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogcategory = await _context.blogCategories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogcategory == null)
        {
            return NotFound();
        }

        return View(blogcategory);
    }

    // GET: BLOGCATEGORYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BLOGCATEGORYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,BlogCategoryTitle,blogs")] BlogCategory blogcategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(blogcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(blogcategory);
    }

    // GET: BLOGCATEGORYS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogcategory = await _context.blogCategories.FindAsync(id);
        if (blogcategory == null)
        {
            return NotFound();
        }
        return View(blogcategory);
    }

    // POST: BLOGCATEGORYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,BlogCategoryTitle,blogs")] BlogCategory blogcategory)
    {
        if (id != blogcategory.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(blogcategory);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogCategoryExists(blogcategory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(blogcategory);
    }

    // GET: BLOGCATEGORYS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogcategory = await _context.blogCategories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogcategory == null)
        {
            return NotFound();
        }

        return View(blogcategory);
    }

    // POST: BLOGCATEGORYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var blogcategory = await _context.blogCategories.FindAsync(id);
        if (blogcategory != null)
        {
            _context.blogCategories.Remove(blogcategory);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BlogCategoryExists(int? id)
    {
        return _context.blogCategories.Any(e => e.Id == id);
    }
}
