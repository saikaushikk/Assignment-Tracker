using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssignmentTracker.Data;
using AssignmentTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace AssignmentTracker.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly AssignmentTracker.Data.AssignmentTrackerContext _context;

        public IndexModel(AssignmentTracker.Data.AssignmentTrackerContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Subjects { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Subject { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            // Assignment = await _context.Assignment.ToListAsync();
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            IQueryable<string> subjectQuery = from m in _context.Assignment
                                    orderby m.Subject
                                    select m.Subject;
            var assignments = from m in _context.Assignment
                 select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                assignments = assignments.Where(s => s.Title.ToLower().Contains(SearchString.ToLower()));
            }
            if (!string.IsNullOrEmpty(Subject))
            {
                assignments = assignments.Where(x => x.Subject.ToLower() == Subject.ToLower());
            }
            Subjects = new SelectList(await subjectQuery.Distinct().ToListAsync());
            switch(sortOrder)
            {
                case "Date":
                    assignments = assignments.OrderBy(s => s.DueDate);
                    break;
                case "date_desc":
                    assignments = assignments.OrderByDescending(s => s.DueDate);
                    break;
                default:
                    assignments = assignments.OrderBy(s => s.Title);
                    break;
            }
            Assignment = await assignments.ToListAsync();
        }
    }
}
