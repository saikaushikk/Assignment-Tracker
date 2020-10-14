using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssignmentTracker.Data;
using AssignmentTracker.Models;

namespace AssignmentTracker.Pages.Assignments
{
    public class DeleteModel : PageModel
    {
        private readonly AssignmentTracker.Data.AssignmentTrackerContext _context;

        public DeleteModel(AssignmentTracker.Data.AssignmentTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignment.FirstOrDefaultAsync(m => m.ID == id);

            if (Assignment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignment.FindAsync(id);

            if (Assignment != null)
            {
                _context.Assignment.Remove(Assignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
