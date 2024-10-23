using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace EFCoreFinalApp.Data{

    public class Candidates : IdentityUser { 

        [Key]
        public int Id { get; set;}
        public string? Name { get; set;}
        public string? Surname { get; set;}
        public string? Email { get; set;}
        public string? Password {get;set;}
        public string? Phone { get; set;}
        public string? ProfileImg { get; set; } = string.Empty;
        public string? ResumePath { get; set; } = string.Empty;

        public string Username{
            get{
                return this.Name + " " + this.Surname;
            }
        }
        public bool IsOpenToWork { get; set; }
        public ICollection<JobApply> JobApply { get; set; } = new List<JobApply>();

    }

}