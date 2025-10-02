NaxcivanPOS – TAM VƏ YEKUN LAYİHƏ SƏNƏDİ (Project Charter)
MƏQSƏD VƏ STRATEJİYA
Qısa Məqsəd: .NET 8, WinForms (MaterialSkin.2) və EF Core (Code-First) əsasında, Azərbaycan dilində, Çoxlaylı (Multi-Layer) Memarlıq və SOLID prinsiplərinə uyğun gələn, Çox-Filiallı (Multi-Branch) və Premium CRM/Analitika funksiyalarını dəstəkləyən, istehsalata hazır POS sistemi qurmaq.

Memarlıq: Təmiz, test edilə bilən və genişləndirilə bilən kod bazası üçün Çoxlaylı Memarlıq (Varlıqlar, Verilənlər, Məntiq, Təqdimat) və MVP (Model-View-Presenter) patterni tətbiq ediləcək.

I. FAZALAR VƏ PRIORİTETLƏŞDİRMƏ
Layihə dörd əsas versiyaya (Faza/Sprint Qrupu) bölünür:

Faza	Mərhələ Adı	Əsas Hədəf (MVP)	Prioritet
Faza 1	Təməl Sistem (Core)	Satış, Məhsul CRUD, Nisyə İdarəsi, Verilənlər Qatı (Bütün sistemin skeleti).	Critical
Faza 2	Bazar Girişi	Qarışıq Ödəniş, Z-Report/Kassa Bağlanışı, Barkod/Çap İnteqrasiyası, İcazələr Matrisi.	High
Faza 3	Korporativ Genişlənmə	Multi-Branch, Seriya/Partiya İzləmə, Ətraflı Analitika, Loyallıq Sistemi (CRM).	High
Faza 4	Premium Həllər	Offline Sync, Çoxvalyuta, REST API/Web Dashboard, 2FA və Bulud dəstəyi.	Medium


II. TEXNİKİ TƏLƏBLƏR VƏ MEMARLIQ
2.1. Layihə Strukturu
NaxcivanPOS.Varlıqlar: Domain Entity-lər (Mehsul, Satis, Musteri, Isci, Filial, Valyuta).

NaxcivanPOS.Verilənlər: EF Core DbContext, Repository və UnitOfWork patterni, Miqrasiyalar.

NaxcivanPOS.Məntiq: Manager-lər (Biznes Məntiqi), OperationResult<T> patterni.

NaxcivanPOS.Təqdimat: WinForms UI (MaterialSkin.2), MVP Patterni (View-lar və Presenter-lər).

NaxcivanPOS.Tests: Unit və İnteqrasiya Testləri (xUnit/NUnit).

2.2. Əsas Patternlər
Pattern	Tətbiq Məqsədi
OperationResult<T>	Məntiq qatından gələn hər bir nəticənin (uğurlu/uğursuz, xəta mesajı) vahid və lokalizasiyaya uyğun şəkildə idarə edilməsi.
Repository & UoW	Verilənlər bazasına çıxışın (CRUD) abstaksiyası və transaction bütövlüyünün təmin edilməsi.
MVP	UI (View) ilə biznes məntiqinin (Manager) tamamilə ayrılması və kodun test edilə bilən olması.
Dependency Injection (DI)	Layihənin bütün qatlarında SOLID prinsiplərinin, xüsusən də Tək Məsuliyyət (SRP) və Asılılığın Tərs Çevrilməsi (DIP) prinsiplərinin təmin edilməsi.


III. ƏSAS FUNKSİONAL TƏLƏBLƏR (Core, Bazar, Premium)
3.1. Satış və Kassa Əməliyyatları (Faza 1 & 2)
Qarışıq Ödəniş (Mix Payment): Nağd, Kart, Nisyə və Bonusun eyni satışda birləşdirilməsi.

İadə və Dəyişmə: Stok/Maliyyə korreksiyası ilə məhsulun geri alınması və ya dəyişdirilməsi.

Kassa Bağlanışı (Shift Close): Növbənin sonu inventarizasiyası və Z-Hesabatının çıxarılması.

Endirimlər: Məhsula, Səbətə və Vaxta Bağlı (Happy Hours) endirim kampaniyaları.

POS Terminal İnteqrasiyası: Bank kartları üçün POS-Terminal API/SDK inteqrasiyası.

3.2. Anbar və İnventar (Faza 2 & 3)
Seriya və Partiya İzləmə: Seriya nömrəsi, Partiya və İstifadə Tarixi üzrə məhsul qeydiyyatı.

Komplekt (Bundle) Məhsul: Komplektin satışı zamanı tərkibindəki bütün məhsulların stokunun avtomatik azaldılması.

Stok Həyəcanı: Minimum stok səviyyəsi aşılarkən sistem xəbərdarlığı.

Anbarlararası Transfer: Filiallar və ya anbarlar arasında məhsul yerdəyişməsinin qeydiyyatı.

İnventarizasiya Jurnalı: Stok sayımının aparılması və fərqlərin sənədləşdirilməsi.

3.3. Müştəri, CRM və Loyallıq (Faza 3)
Müştəri Seqmentasiyası: VIP, Borclu, Aktiv kimi kateqoriyalara görə qruplaşdırma.

Loyallıq Sistemi: Bonus balları və endirim faizləri hesablama mexanizmi.

Nisyə İdarəsi: Borc balansı, hissəvi ödəniş tarixçəsi və SMS/Email borc bildirişləri.

Qəbz Email ilə Göndərmə: Satış qəbzinin müştərinin email ünvanına göndərilməsi.

3.4. Hesabat və Analitika (Faza 3 & 4)
Mənfəət Hesabatı: Satış – Alış Qiyməti (Cost) əsasında dəqiq qazancın hesablanması.

Xərclər Modulu: Əlavə xərclərin (icarə, maaş, vergi) qeydiyyatı və Gəlir-Xərc Balansı.

Analitik Qrafiklər: Satış həcmi, gəlir və ən çox/ən az satılan məhsullar üzrə vizual hesabatlar.

Export: Bütün hesabatların Excel, PDF və CSV formatında ixracı.

IV. TƏHLÜKƏSİZLİK VƏ İNFRASTRUKTUR TƏLƏBLƏRİ
4.1. Təhlükəsizlik və Audit
İcazələr Matrisi: Rol Əsaslı Giriş (Admin, Menecer, Kassir) və UI elementlərinin buna uyğun gizlədilməsi/görünməsi.

Parol Saxlanması: Parolların BCrypt/PBKDF2 kimi güclü heşləmə alqoritmləri ilə qorunması.

Audit Logu: Kritik əməliyyatların (Stok dəyişimi, Silinmə, İadə) işçi ID-si ilə tam izlənilməsi.

2FA (İki Faktorlu Autentifikasiya): Admin girişi üçün məcburi 2FA tətbiqi.

4.2. Genişlənmə və Texniki Hazırlıq (Faza 4)
Offline/Online Sinxronizasiya: İnternet kəsildikdə Local DB-də işləmə və bərpa olunduqda avtomatik mərkəzi DB ilə sinxronizasiya.

Çoxvalyuta Dəstəyi: AZN, USD, EUR, RUB və s. valyutaların dəstəklənməsi, Kurs Manageri ilə məzənnələrin idarəedilməsi.

REST API: Mobil və Web tətbiqlər üçün ASP.NET Core ilə mərkəzi API layihəsi.

Web Dashboard: Menecerlər üçün satış və analitika məlumatlarını izləmək üçün sadə web versiya.

V. KEYFİYYƏT TƏMİNATI VƏ BURAXILIŞ SİYAHISI
5.1. Keyfiyyət Tələbləri
Unit Testlər: Biznes məntiqini ehtiva edən bütün Manager-lər (Məhsul, Satış, Nisyə) üçün %80-dən az olmayaraq test əhatəliliyi.

İnteqrasiya Testləri: Bütün çox-cədvəlli əməliyyatların (Satış Transactionları, Transferlər) transaction bütövlüyü yoxlanılmalıdır.

Lokalizasiya Testi: Dil dəyişimi (az/en) bütün UI elementlərində və OperationResult mesajlarında tam işləməlidir.

5.2. Yekun Buraxılış Siyahısı (Release Checklist)
Bütün Unit Testlər və İnteqrasiya Testləri uğurla keçdi.

Kassa Bağlanışı və Z-Hesabatı real ssenaridə yoxlanıldı.

Qarışıq Ödəniş (Mix Payment) və İadə əməliyyatları sınaqdan keçdi.

Barkod Çapı və Çek Çıxışı real printerdə təsdiqləndi.

Multi-Branch və Seriya İzləmə funksiyaları stress-test edildi.

Offline Rejim və Sinxronizasiya prosesləri uğurla tamamlandı.

Təhlükəsizlik Auditi (Parol Heşlənməsi və 2FA) yerinə yetirildi.