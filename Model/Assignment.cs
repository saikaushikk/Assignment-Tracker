using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentTracker.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [Url]
        [Display(Name = "Submission link")]
        public string Link { get; set; }
    }
}