using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rz.Data;
using rz.Models;

namespace rz.Pages.Staff;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    // Dependency Injection via constructor
    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Models.Staff> StaffMembers { get; set; } = [];
    public int ActiveCount { get; set; }

    // SupportsGet = true allows property binding from URL query strings (e.g., ?SearchTerm=johnson)
    [BindProperty(SupportsGet = true)]
    public string? SearchTerm { get; set; }

    public async Task OnGetAsync()
    {
        // 1. Initialize an unexecuted query definition
        var query = _context.Staff.AsQueryable();

        // 2. Conditionally apply a filter if a search term was provided
       if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            var term = SearchTerm.Trim().ToLower();
            query = query.Where(s => 
                s.LastName.ToLower().Contains(term) ||
                s.FirstName.ToLower().Contains(term));
        }

        // 3. Execute the SQL query asynchronously against the database
        StaffMembers = await query.ToListAsync();

        // 4. Calculate active count from filtered memory list
        ActiveCount = StaffMembers.Count(s => s.IsActive == 1);
    }
}
