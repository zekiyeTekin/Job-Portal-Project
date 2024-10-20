using System.ComponentModel.DataAnnotations;

namespace EFCoreFinalApp.Data{
    public class JobApply{

        [Key]
        public int Id { get; set; }

        
        public string? Status { get; set; }

        
        public DateTime ApplyDate {get;set;}

        [Required(ErrorMessage = "JobPosting field is required.")]
        public int JobPostingId { get; set; }

        [Required]
        public virtual JobPosting JobPosting { get; set; } = null!;

        [Required(ErrorMessage = "Candidates field is required.")]
        public int CandidatesId { get; set; }

        [Required]
        public virtual Candidates Candidates { get; set; } = null!;
        
    }
}