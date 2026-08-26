
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aspdotnetkar.Models;
using Aspdotnetkar.Context;

public class BlogController : Controller
{
    private readonly SiteContext _context;

    public BlogController(SiteContext context)
    {
        _context = context;
    }

    // GET: BLOGS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.blogs.ToListAsync());
    }

    // GET: BLOGS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blog = await _context.blogs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }

    // GET: BLOGS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BLOGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,BlogTitle,BlogShortdescription,BlogText,BlogCreateDate,BlogImage,Tags,BlogVisitCount,CategoryId,BlogCategory")] Blog blog)
    {
        if (ModelState.IsValid)
        {
            _context.Add(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(blog);
    }

    // GET: BLOGS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blog = await _context.blogs.FindAsync(id);
        if (blog == null)
        {
            return NotFound();
        }
        return View(blog);
    }

    // POST: BLOGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,BlogTitle,BlogShortdescription,BlogText,BlogCreateDate,BlogImage,Tags,BlogVisitCount,CategoryId,BlogCategory")] Blog blog)
    {
        if (id != blog.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(blog);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(blog.Id))
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
        return View(blog);
    }

    // GET: BLOGS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blog = await _context.blogs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }

    // POST: BLOGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var blog = await _context.blogs.FindAsync(id);
        if (blog != null)
        {
            _context.blogs.Remove(blog);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BlogExists(int? id)
    {
        return _context.blogs.Any(e => e.Id == id);
    }
}
