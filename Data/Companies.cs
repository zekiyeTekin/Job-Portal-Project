using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EFCoreFinalApp.Data{

    public class Companies{
        
        [Key]
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Logo { get; set; } = string.Empty;
        public string? Description {get; set;}
        public string? Email {get; set;}
        public string? Password {get; set;}
        public string? Phone {get; set;}
        public string? Industry {get; set;}

        public Role Role { get; set; } = Role.Company;
    
        [JsonIgnore]
        public ICollection<JobPosting> JobPostings { get; set; } = new List<JobPosting>();
        
    }
}