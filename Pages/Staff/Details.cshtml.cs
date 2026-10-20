using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rz.Data;
using rz.Models;

namespace rz.Pages.Staff;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Models.Staff Staff { get; set; } = null!;

    // The parameter 'id' automatically receives the value from the URL route
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var staff = await _context.Staff.FindAsync(id);

        // If no matching staff record is found in the database, return a 404 response
        if (staff == null)
        {
            return NotFound();
        }

        Staff = staff;
        return Page();
    }
}