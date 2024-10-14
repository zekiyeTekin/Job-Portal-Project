using System.ComponentModel.DataAnnotations;

namespace EFCoreFinalApp.Data{

    public class Companies{
        
        [Key]
        public int Id {get; set;}
        public string? Name {get; set;}

        public string? Description {get; set;}
        public string? Email {get; set;}
        public string? Phone {get; set;}
        public string? Industry {get; set;}
    
        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
        
    }
}