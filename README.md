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
- Adaylar ilana bir kez başvuru yapabilir, aynı ilana ikinci kez başvuru yapamaz.
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
| **Tüm Şirketleri Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_companyList.png)  |
| **Şirketleri Detaylarını Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_companyDetail.png)  |
| **Şirketleri Alanına Göre Filtreleme**  | ![CreatePost](/wwwroot/img/readme_companiesFilter.png)  |
| **Tüm Adayları Görüntüleme**  | ![CreatePost](/wwwroot/img/reame_candidateList.png)  |
| **Adayların Güncelleme Ekranı ve Başvuruları**  | ![CreatePost](/wwwroot/img/readme_candidateDetail.png)  |
| **Adayların Başvuru Detayı**  | ![CreatePost](/wwwroot/img/readme_jobPostingDetail.png)  |
| **Şirket Oluşturması**  | ![CreatePost](/wwwroot/img/readme_companyCreate.png)  |
| **Aday Oluşturması**  | ![CreatePost](/wwwroot/img/readme_createCandidate.png)  |
| **Şirketlerin İş Postlarını Oluşturması**  | ![CreatePost](/wwwroot/img/readme_createdJobPosting.png)  |
| **Şirketleri İş Postlarını Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_companyViewPost.png)  |
| **Şirketleri İş Postlarını Başlığa göre Arama**  | ![CreatePost](/wwwroot/img/readme_companySearchByTitle.png)  |
| **Şirketleri İş Postlarının Detaylarını Görüntüleme**  | ![CreatePost](/wwwroot/img/readme_companyPostDetail.png)  |
| **İş Postuna Başvuru yapmak**  | ![CreatePost](/wwwroot/img/readme_applyPage.png)  |
| **İş Postuna Başvuru yapılması**  | ![CreatePost](/wwwroot/img/readme_appiedPosts.png)  |
| **Bir Şirketin Paylaştığı İş İlanları**  | ![CreatePost](/wwwroot/img/readme_listPostByCompany.png)  |
| **Bir Şirketin İlanına Başvuran aday ile Mülakat Aşamasına Geçmesi**  | ![CreatePost](/wwwroot/img/readme_evaluateApply.png)  |
| **Bir Şirketin İlanına Başvuran adayın Başvurusunu Reddetmesi**  | ![CreatePost](/wwwroot/img/readme_rejectApply.png)  |
| **Bir Şirketin İlanına Başvuran adayın Başvurusunu Kabul Edilmesi**  | ![CreatePost](/wwwroot/img/readme_positiveApply.png)  |





## Kullanım 
-Video hazırlanıp konulacak(TODO)
