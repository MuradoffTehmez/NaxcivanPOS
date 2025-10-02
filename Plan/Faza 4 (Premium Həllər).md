Faza 4: Premium Həllər – Detallı Plan 
Bu faza Dayanıqlılıq (Offline Sync), Genişlənmə (API/Web Dashboard) və Maliyyə Çevikliyi (Çoxvalyuta) kimi tələbləri həll edir.

Faza 4: Premium Həllər – Detallı Plan
Məqsəd: POS sisteminin kəsilməz işləməsini (Offline), beynəlxalq əməliyyatları (Çoxvalyuta) və digər platformalarla inteqrasiyasını təmin etmək. Layihənin API və Web Dashboard ilə gələcək inkişafının təməlini qoymaq.

1. Dayanıqlılıq və Sinxronizasiya (Offline Rejim)
Sistemin internet bağlantısı olmadan da tam funksional işləməsini təmin edən kritik bir funksiyadır.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Local DB Hazırlığı	Lokal işləmə üçün yüngül Verilənlər Bazası (məsələn, SQLite və ya LocalDB) skeletinin qurulması.	Verilənlər	Təməl məhsul və satış məlumatları yerli DB-də saxlanılır.
Sinxronizasiya Mexanizmi	Mərkəzi DB və Lokal DB arasında məlumat transferi və yenilənməsi məntiqinin yaradılması.	Məntiq / Verilənlər	Yeni satışlar Lokal DB-də qeyd olunur; internet gələndə Batch Sync (toplu sinxronizasiya) ilə mərkəzə göndərilir.
Münaqişə (Conflict) Həlli	Lokal və Mərkəzi DB-də eyni məlumatın fərqli vaxtlarda dəyişdirilməsi halında münaqişəni həll edən siyasətin (məsələn, "sonuncu qeyd qalib gəlir") tətbiqi.	Məntiq	Sinxronizasiya zamanı heç bir məlumat itkisi olmur və xətalar loglanır.
Rejim Keçidi	UI üzərində "Offline Rejimdəsiniz" göstəricisi və rejim keçidi düyməsi.	Təqdimat	İnternet kəsildikdə sistem avtomatik Offline-a keçir.

2. Çoxvalyuta və Maliyyə İdarəetməsi
Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Valyuta Entity-si	Valyuta (AZN, USD, EUR) entity-si və ValyutaKuru cədvəli yaradılır.	Varlıqlar / Verilənlər	Bütün maliyyə əməliyyatları Əsas Valyuta (AZN) ilə yanaşı konvertasiya olunan valyutanın da dəyərini saxlayır.
Valyuta Kursu Manageri	Manual Kurs Girişi və Mərkəzi Bank API (və ya başqa bir mənbə) ilə kursların avtomatik yenilənməsi.	Məntiq	Satış zamanı, əgər ödəniş xarici valyuta ilə edilirsə, konvertasiya xətası olmadan hesablanır.
Xərclər Modulu	Xerc entity-si üçün CRUD əməliyyatları. Xərc Kateqoriyaları əlavə edilir.	Məntiq / Təqdimat	Bütün xərclər qeyd olunur və Gəlir-Xərc Balansı Hesabatı (Faza 3) dəqiqləşdirilir.

3. Genişlənmə və İnteqrasiya (API & Web)
Sistemi WinForms çərçivəsindən kənara çıxaracaq təməl addımlar.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
REST API Layihəsi	NaxcivanPOS.API layihəsi ASP.NET Core ilə yaradılır. Məhsul/Satış məlumatlarına giriş üçün CRUD endpointləri qurulur.	Yeni Layihə	API endpointləri üzərindən məhsul siyahısı JSON formatında uğurla çəkilir.
Web Dashboard Skeleti	ASP.NET Core Razor Pages/MVC ilə Menecerlər üçün sadə Web Dashboard (Ciro, Ən Çox Satılanlar) yaradılır.	Yeni Layihə	Menecerlər Web üzərindən real-time satış məlumatlarını görə bilir.
API Təhlükəsizliyi	REST API üçün Token Əsaslı Autentifikasiya (JWT) tətbiq olunur.	API / Təhlükəsizlik	Yalnız autentifikasiyadan keçmiş istifadəçilər API-dan məlumat çəkə bilir.


4. Premium Təhlükəsizlik və Keyfiyyət
Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
İki Faktorlu Autentifikasiya (2FA)	Admin/Menecer rolları üçün Login zamanı 2FA (məsələn, Google Authenticator) dəstəyi.	Təhlükəsizlik / Məntiq	2FA olmadan Admin hesabına giriş mümkün deyil.
Məlumat Şifrələnməsi	Həssas məlumatların (məsələn, Müştəri Kartının bir hissəsi) AES kimi alqoritmlərlə Verilənlər Bazası səviyyəsində şifrələnməsi.	Verilənlər	Şifrələnmiş məlumatlar DB-də oxunmaz formada saxlanır.
Avtomatik Backup Sistemi	Verilənlər Bazası üçün PowerShell/Bash ilə avtomatik, vaxtlı backup skriptlərinin hazırlanması.	İnfrastruktur	Backup faylları qeyd olunan lokal/bulud mənbəyinə müəyyən edilmiş intervalda göndərilir.


5. Faza 4 Yekun Buraxılış Siyahısı
Faza 4-ün tamamlanması layihənin tam şəkildə bazara çıxmağa hazır olduğunu göstərir.

Dayanıqlılıq: Offline Satış test edildi və Sinxronizasiya münaqişə (conflict) olmadan uğurla başa çatdı.

Maliyyə: Çoxvalyuta dəstəyi və Avtomatik Kurs Yenilənməsi işləyir.

Genişlənmə: REST API endpointləri qurulub və Web Dashboard üzərindən məlumatlar izlənilir.

Təhlükəsizlik: 2FA və Məlumat Şifrələnməsi tətbiq edilib.

Test: Offline/Sync məntiqi üçün xüsusi İnteqrasiya Testləri (Test DB-də) əlavə edilib.