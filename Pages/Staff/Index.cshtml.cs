using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages.Staff;

public class IndexModel : PageModel
{
    // -------------------------------------------------------------------------
    // LAB 2 - STEP 01: Database Integration
    // -------------------------------------------------------------------------
    // In Step 01, you will:
    // 1. Install Microsoft.EntityFrameworkCore.Sqlite
    // 2. Create Models/Staff.cs and Data/ApplicationDbContext.cs
    // 3. Register ApplicationDbContext in Program.cs
    // 4. Inject ApplicationDbContext via constructor dependency injection:
    //
    //    private readonly ApplicationDbContext _context;
    //
    //    public IndexModel(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //
    //    public List<Models.Staff> StaffMembers { get; set; } = [];
    //    public int ActiveCount { get; set; }
    //
    //    public async Task OnGetAsync()
    //    {
    //        StaffMembers = await _context.Staff.ToListAsync();
    //        ActiveCount = StaffMembers.Count(s => s.IsActive == 1);
    //    }
    // -------------------------------------------------------------------------

    public string StatusMessage { get; set; } = "Database connection not yet configured. Follow Step 01 in the tutorial!";

    public void OnGet()
    {
        // Executes when student visits /Staff or /Staff/Index before Step 01 is completed
    }
}
