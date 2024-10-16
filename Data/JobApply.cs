using System.ComponentModel.DataAnnotations;

namespace EFCoreFinalApp.Data{
    public class JobApply{

        [Key]
        public int Id { get; set; }

        
        public string? Status { get; set; }

        
        public DateTime ApplyDate {get;set;}

        [Required]
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = null!;

        [Required]
        public int CandidatesId { get; set; }
        public Candidates Candidates { get; set; } = null!;
        
    }
}