using System.ComponentModel.DataAnnotations;

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
        public int CompanyId { get; set; }
        public Companies Companies { get; set; } = null!;
        public int RecruiterId { get; set; }

        public Recruiters Recruiters { get; set; } = null!;

        public ICollection<JobApply> JobApply { get; set; } = new List<JobApply>();
    }
}