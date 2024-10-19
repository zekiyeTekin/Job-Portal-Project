# JOB PORTAL PROJECT

## İçindekiler
- [Proje Amacı](#proje-amacı)
- [Projeyi Kurma](#projeyi-kurma)
- [Özellikler](#özellikler)
- [Teknik Detaylar](#teknik-detaylar)
- [Proje Görünümü](#proje-görünümü)
- [Kullanım](#kullanım)

## Proje Amacı
**Job Portal Application**, iş bulma sürecini kolaylaştırarak, iş arayanlar ile işverenler arasında etkili bir iletişim platformu oluşturmayı hedefler. Bu sayede her iki tarafın ihtiyaçlarını karşılayarak, kariyer gelişimine katkı sağlar.

## Projeyi Kurma
### Url'i terminale kopyalayınız:
-git clone https://github.com/zekiyeTekin/Job-Portal-Project.git
### Projenin Olduğu dizine gidiniz:
- cd Job-Portal-Project
### Projenin VS Code'da çalıştırınız:
- code .
### Projenin incelemeye başlayabilirsiniz:
- http://localhost:{yourListenPort}/

## Özellikler

## Teknik Detaylar
### 1. İş İlanı Paylaşımı
- Şirketler, iş ilanları oluşturabilir ve yayınlayabilir.
- Her iş ilanı, bir başlık (title), içerik (description), ilanı veren kişi (postedBy), ve tarih (date) bilgilerini içerir.

### 2. İş İlanına Başvuru
- Giriş yapmış adaylar, iş ilanlarına başvurabilir.
- Giriş yapmamış kullanıcılar, iş ilanlarını yalnızca görüntüleyebilir ancak başvuru yapamaz. (TODO)

### 3. İş İlanı Detayları
- Her iş ilanının başvuru sayısı (applicationCount) ve görüntülenme sayısı (viewCount) tutulur. (TODO)
- Detay sayfasına tıklandığında, iş ilanının başlığı, içeriği, ilanı veren kişinin adı, ilan tarihi gösterilir.

### 4. Filtreleme İşlevi
- Şirketler alanına göre filtrelenir.

### 5. İş İlanlarını Yönetme
- Adaylar başvuruda bulunduğu ilanı silebilir.

### 7. Aday ve Şirket Bilgileri
- Adaylar ve şirketler kayıt olup giriş yapabilir ve giriş yapanlar ise bilgilerini güncelleyebilirler.
- Adaylar bilgilerini güncellerken cv ve profil fotoğrafı koyabilir. Başvurulan ilan detayında cv ve ilan içeriği gösterilir.

## Teknik Detaylar
- Programlama Dili: C#
- Framework: ASP.NET Core
- Mimari Yapısı: **MVC**
- Frontend: **HTML/CSS/JavaScript**
- Veritabanı: **SQLite**

## Proje Görünümü

| Description    | Screenshot                    |
|----------------|-------------------------------|
| **Giriş ve Kayıt Sayfası**  | ![Login and Register Page](/wwwroot/img/readme_login.jpg)  |
| **Tüm Şirketleri Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_comaniesList.png)  |
| **Şirketleri Detaylarını Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_companyDeatil.png)  |
| **Şirketleri Alanına Göre Filtreleme**  | ![CreatePost](/wwwroot/img/readme_companiesFilter.png)  |
| **Tüm Adayları Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_candidateList.png)  |
| **Adayların Güncelleme Ekranı ve Başvuruları**  | ![CreatePost](/wwwroot/img/readme_candidateDetail.png)  |
| **Adayların Başvuru Detayı**  | ![CreatePost](/wwwroot/img/readme_jobPostingDetail.png)  |
| **Şirketlerin İş Postlarını Oluşturması**  | ![CreatePost](/wwwroot/img/readme_createdJobPosting.png)  |
| **Şirketleri İş Postlarını Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_companyViewPost.png)  |
| **Şirketleri İş Postlarının Detaylarını Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_companyPostDetail.png)  |
| **Şirketleri İş Postlarına Başvuruda Bulunma**  | ![CreatePost](/wwwroot/img/readme_jobApply.png)  |

## Kullanım 
-Video hazırlanıp konulacak ve Yüklenen görseller düzenlenecek (TODO)
