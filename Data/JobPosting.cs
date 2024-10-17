using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreFinalApp.Data{
    public class JobPosting{
        [Key]
        public int Id { get; set;}
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public decimal Salary { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ClosingDate { get; set; }

        [ForeignKey("Companies")]
        public int CompaniesId { get; set; }

        [Required]
        public Companies Companies { get; set; } = null!;

        public ICollection<JobApply> JobApply { get; set; } = new List<JobApply>();
    }
}