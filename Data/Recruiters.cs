using System.ComponentModel.DataAnnotations;

namespace EFCoreFinalApp.Data{
    public class Recruiters{
        
        [Key]
        public int Id { get; set; }
        public string? Position { get; set; }
        public string? Desription { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public Companies Companies { get; set; } = null!;
        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();

    }
}