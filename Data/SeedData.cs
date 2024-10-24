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
                    new Candidates {Name = "Zekiye", Surname = "Tekin", Email="zt@gmail.com", Phone="01111111111", ProfileImg="uploads/images/profil.png", ResumePath="uploads/resumes/ZekiyeTekin_CV.pdf", IsOpenToWork=true, Password="zekiye11"},
                    new Candidates {Name = "Münevver", Surname = "Tekin", Email="mt@gmail.com", Phone="02222222222", ProfileImg="uploads/images/profil_1.jpg", ResumePath="uploads/resumes/ZekiyeTekin_Ozgecmis.pdf", IsOpenToWork=true, Password="zekiye11"},
                    new Candidates {Name = "Hasan", Surname = "Karademir", Email="hk@gmail.com", Phone="03333333333", ProfileImg="uploads/images/profil_3.jpg", ResumePath="uploads/resumes/ZekiyeTekin_Ozgecmis.pdf", IsOpenToWork=true, Password="zekiye11"}
                );
                context.SaveChanges();
            }
            if(!context.Companies.Any()){
                context.Companies.AddRange(
                    new Companies{Name = "MT Design Studio", Description="Kişiye özel tasarımların yanı sıra özgün tasarımlarımız ile yenilikçilik anlayışını benimsiyoruz. Ürünlerimizle ilgileniyorsanız için bizimle iletişime geçebilirsiniz.", Email="mt.design@gmail.com", Phone="01111112222", Industry="Tasarım",Logo="uploads/images/logo_mt.jpg", Password="zekiye11"
                    },
                    new Companies{Name = "ZT Yazılım", Description="Ürün ve hizmet kalitemizi sürekli geliştirerek müşteri talep ve beklentilerini en üst seviyede karşılıyoruz, Güçlü bir iletişim ile müşterilerimizle aramızda duygusal bir bağ yaratmak ve müşteri sadakatini sağlamak, rekabet gücümüzü ve kârlılığımızı arttırmak adına kaliteli hizmet sunmayı amaçlıyoruz.", Email="zt.yazilim@gmail.com", Phone="01111113333", Industry="Yazılım", Logo="uploads/images/logo_zt.jpg", Password="zekiye11"
                    },
                    new Companies{Name = "HK Yapay Zeka", Description="Ülkemize ve tüm insanlığa fayda sağlayacak yapay zekâ sistemleri üretebilecek çalışanları bir araya toplayarak hem  bilimsel çalışmaları arttırmak hem de sanayinin ihtiyaç duyduğu sistemleri yapay zekâ çözümleri ile geliştirebilen ve bu alanda öncü bilimsel çalışmalar üreten bir merkez olmak amaçlıyoruz", Email="hk.ai@gmail.com", Phone="01111114444", Industry="Yapay Zeka", Logo="uploads/images/logo_hk.jpg", Password="zekiye11"
                    }
                );
                context.SaveChanges();
            }
           
            if(!context.JobPosting.Any()){
                context.JobPosting.AddRange(
                    new JobPosting{
                        Title = "Senior Java Developer",
                        Description = " Beklentilerimiz: 5+ yıl Java deneyimin (Java 8+) varsa, 5+ Spring-Boot deneyimin varsa, 5+ yıl ilişkisel veritabanı deneyimin olduysa (Oracle, DB2, PostGreSql ...), Distributed Cache, Queue/Broker deneyimin varsa, ReactJs konusunda deneyimin varsa,Unit test deneyimin varsa ve tercihen TDD ile geliştirme yapmışsan, Git, Maven kullanımına hakimsen, Çabuk öğrenirim, proaktifim ve inisiyatif alırım diyorsan, İyi derecede İngilizce biliyorsan, Ekip çalışmasına yatkınsan,",
                        Location= "Ankara",
                        Salary = 85000 ,
                        PostedDate = DateTime.Now,
                        ClosingDate = DateTime.Now.AddDays(5),
                        CompaniesId = 2
                    },
                    new JobPosting{
                        Title = "Endüstriyel Tasarımcı(Yeni Mezun)",
                        Description = "İŞ TANIMI: İşletmelerde, muhasebe ile koordineli çalışarak ay sonu verileri, fiziki masraf, stok alarak kontrollerini sağlama, Aylık fiili ve güncel maliyetler arasındaki sapmaları hesaplayıp ilgili birimlere raporlamak, Tüm birimlerin iş akış şemalarının çıkarılması, Tüm birimlerin iş akış şemaları doğrultusunda denetimlerinin gerçekleştirilmesi.",
                        Location= "Eskişehir",
                        Salary = 40000 ,
                        PostedDate = DateTime.Now,
                        ClosingDate = DateTime.Now.AddDays(3),
                        CompaniesId = 1
                    },
                    new JobPosting{
                        Title = "Yeni Mezun Java Developer",
                        Description = "Şirketimiz bünyesinde görevlendirilmek üzere; Üniversitelerin Bilgisayar, Yazılım, Elektronik, Endüstri, Matematik Mühendisliği bölümlerinde okuyan, yazılım geliştirme konusunda kendini yetiştirmiş, son sınıf öğrencisi veya mezun,Okul döneminde part-time olarak çalışabilecek veya mezun olunca işe başlama hedefi olan, Tercihen OOP, Design Patterns, TDD, Unit Testing, kod ve yazılım standartları konularında genel bilgi sahibi veya kısa zamanda yazılım geliştirme konusunda kendisini geliştirebilecek, Java, J2ee, Oracle, Spring, Hibernate ve benzeri teknolojilerde bilgi sahibi veya bu teknolojileri öğrenmeye açık, SQL veritabanı konusunda bilgi sahibi, İyi derecede İngilizce teknik doküman okuma bilgisine sahip, Literatürü takip eden, araştırma yönü kuvvetli ve problem çözme becerisi olan, Kendini geliştirme konusunda hevesli ve istekli.",
                        Location= "Uzaktan",
                        Salary = 45000 ,
                        PostedDate = DateTime.Now,
                        ClosingDate = DateTime.Now.AddDays(8),
                        CompaniesId = 2
                    },
                    new JobPosting{
                        Title = "Yapay Zeka ve Makine Öğrenmesi Uzmanı",
                        Description = "Üniversitelerin Bilgisayar, Endüstri Mühendisliği veya ilgili bölümlerinden mezunum, Alanımda en az 2 yıllık deneyime sahibim, Python dili ve AI/ML kütüphaneleri konusunda deneyime sahibim, R, Java gibi programlama dillerine hakimim, TensorFlow, PyTorch, Scikit-learn gibi derin öğrenme ve makine öğrenimi kütüphanelerini etkin bir şekilde kullanabilirim, RPA araçları (UiPath, Automation Anywhere vb.) konusunda deneyime sahibim, Analitik düşünme, problem çözme ve öğrenme yeteneğine sahibim, Takım çalışmasına ve proaktif yaklaşıma yatkınım, Ekip yönetebilirim,",
                        Location= "İstanbul",
                        Salary = 55000 ,
                        PostedDate = DateTime.Now,
                        ClosingDate = DateTime.Now.AddDays(1),
                        CompaniesId = 3
                    }
                );
                context.SaveChanges();
            }

            if(!context.JobApply.Any()){
                context.JobApply.AddRange(
                    new JobApply{
                        Status = "Başvurunuz alındı",
                        ApplyDate = DateTime.Now.AddDays(-5),
                        JobPostingId = 3,
                        CandidatesId = 2
                    }
                );
                context.SaveChanges();
            }
            


            

            }
        }
    }
}