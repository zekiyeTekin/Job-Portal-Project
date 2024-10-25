using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalApp.Data{

    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Candidates> Candidates => Set<Candidates>();
        public DbSet<Companies> Companies => Set<Companies>();
        public DbSet<JobApply> JobApply => Set<JobApply>();
        public DbSet<JobPosting> JobPosting => Set<JobPosting>();
       

        


    }
}