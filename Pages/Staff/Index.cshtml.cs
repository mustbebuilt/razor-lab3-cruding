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

    public async Task OnGetAsync()
    {
        StaffMembers = await _context.Staff.ToListAsync();
        ActiveCount = StaffMembers.Count(s => s.IsActive == 1);
    }
}