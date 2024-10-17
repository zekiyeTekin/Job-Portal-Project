using EFCoreFinalApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFinalApp.Data.EFCoreFinalApp{

    public static class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<DataContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                
             if(!context.Candidates.Any()){
                context.Candidates.AddRange(
                    new Candidates {Name = "zek", Surname = "tek", Email="zek@gmail.com", Phone="11111", ProfileImg="uploads/images/pp.png", ResumePath="uploads/resumes/ZekiyeTekin_Ozgecmis.pdf", IsOpenToWork=true},
                    new Candidates {Name = "nur", Surname = "tek", Email="nur@gmail.com", Phone="2222", ProfileImg="uploads/images/profil.png", ResumePath="uploads/resumes/ZekiyeTekin_CV.pdf", IsOpenToWork=true}
                );
                context.SaveChanges();
            }
            if(!context.Companies.Any()){
                context.Companies.AddRange(
                    new Companies{Name = "web programlama", Description="Deneme şirketi", Email="denem@gmail.com", Phone="5723672", Industry="Yazılım"
                    },
                    new Companies{Name = "GIB", Description="Gib şirketi ", Email="gibId@gib.com", Phone="322232", Industry="Hizmet"
                    },
                    new Companies{Name = "ZT yazılım", Description="Zekiye tekin tarafından kuruldu şirketi", Email="zt@gmail.com", Phone="5723672", Industry="Teknoloji"
                    }
                );
                context.SaveChanges();
            }
           
            if(!context.JobPosting.Any()){
                context.JobPosting.AddRange(
                    new JobPosting{
                        Title = "Asp.net Core",
                        Description = "Bu alanda çalışabilirsiniz.",
                        Location= "Ankara",
                        Salary = 78263 ,
                        PostedDate = DateTime.Now,
                        ClosingDate = DateTime.Now.AddDays(5),
                        CompaniesId = 1
                    },
                    new JobPosting{
                        Title = "Java Bootcamp",
                        Description = "Bu alanda çalışabilirsiniz.",
                        Location= "Eskişehir",
                        Salary = 40000 ,
                        PostedDate = DateTime.Now,
                        ClosingDate = DateTime.Now.AddDays(8),
                        CompaniesId = 2
                    },
                    new JobPosting{
                        Title = "Full Stack",
                        Description = "Bu alanda çalışabilirsiniz.",
                        Location= "İstanbul",
                        Salary = 36000 ,
                        PostedDate = DateTime.Now,
                        ClosingDate = DateTime.Now.AddDays(2),
                        CompaniesId = 1
                    }
                );
                context.SaveChanges();
            }
            }
        }
    }
}