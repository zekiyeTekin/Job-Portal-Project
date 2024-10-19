using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFinalApp.Data{
    public class JobPosting{
        [Key]
        public int Id { get; set;}
        [Required(ErrorMessage = "Title is required")]        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required")]        
        public string? Description { get; set; }
        [Required(ErrorMessage = "Location is required")]        
        public string? Location { get; set; }

        public decimal Salary { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Closing Date is required")]        
        public DateTime ClosingDate { get; set; }


        [Required(ErrorMessage = "Companies field is required.")]
        public int CompaniesId { get; set; }

        [Required]
        public virtual Companies? Companies { get; set; } = null!;

        public ICollection<JobApply> JobApply { get; set; } = new List<JobApply>();
    }
}