Faza 1: Təməl Sistem (Core Versiya) – Detallı Plan
Bu faza, bütün sistemin gələcək genişlənmələrini dəstəkləyəcək möhkəm memarlıq, verilənlər bazası və əsas biznes məntiqinin təməlini qoyur.
Məqsəd: Layihənin çoxlaylı memarlıq skeletini qurmaq, EF Core Data Access qatını tamamlamaq və Məhsul, Satış, Nisyə kimi əsas əməliyyatların MVP-sini təmin etmək.

1. Layihə Təməli və Memarlıq Skeleti (Faza A)
Tapşırıq	Təsvir	Qəbul Meyarı (AC)
Solution Yaratmaq	NaxcivanPOS.sln faylı və dörd əsas qatın layihələri yaradılır.	dotnet build xətasız başa çatır. Layihələr arasında müvafiq referenslər (məsələn, Məntiq -> Verilənlər -> Varlıqlar) düzgün qurulur.
Qlobal Paketlər	NuGet paketləri (EF Core, DI, Logging) bütün layihələrə əlavə olunur.	dotnet restore xətasız işləyir. NaxcivanPOS.Təqdimat layihəsinə MaterialSkin.2 paketi əlavə edilir.
DI Konfiqurasiyası	Program.cs faylında (və ya Startup sinfində) Dependency Injection konteynerinin ilkin quraşdırılması.	Əsas servislər (Logging, DbContext) konteynerə uğurla qeyd olunur.
Qlobal Konfiqurasiya	appsettings.json faylı Connection String şablonu, Logging Level və digər təməl parametrləri ehtiva edir.	Konfiqurasiya məlumatları Program.cs tərəfindən oxunur.

Verilənlər Qatı (Data Access Layer) (Faza B)
Bu qat, verilənlər bazası əməliyyatlarının izolyasiyasını və test edilə bilməsini təmin edir.

Tapşırıq	Təsvir	Fayl Yolu
Varlıqlar (Entities) Sinifləri	Əsas entity-lər: Mehsul, Musteri, Satis, SatisDetali, Odenis, Nisye, Isci.	NaxcivanPOS.Varlıqlar/Mehsul.cs
DbContext	NaxcivanPOSDbContext sinfi EF Core üçün yaradılır.	NaxcivanPOS.Verilənlər/NaxcivanPOSDbContext.cs
Repository Pattern	Generic IRepository<T> və GenericRepository<T> interfeys və implementasiyası. Asinxron CRUD metodları daxil edilməlidir.	NaxcivanPOS.Verilənlər/Repositories/IRepository.cs
UnitOfWork Pattern	IUnitOfWork interfeysi CommitAsync() metodu və bütün konkret Repozitorilər üçün propertyləri ehtiva edir.	NaxcivanPOS.Verilənlər/UnitOfWork/IUnitOfWork.cs
Miqrasiya və Seed	InitialCreate miqrasiyası yaradılır. Admin istifadəçi və bir neçə nümunə Mehsul Seed Data kimi əlavə edilir.	dotnet ef migrations add InitialCreate


Qəbul Meyarı (AC): dotnet ef database update komandası ilə verilənlər bazası uğurla yaranır və Seed Data məlumatları görünür. Repository vasitəsilə Mehsul entity-si əlavə edilə bilir.

3. Biznes Məntiqi Qatı (Business Logic) (Faza C)
İş qaydaları bu qatda həyata keçirilir. Hər bir manager metodu OperationResult qaytarır.

Tapşırıq	Təsvir	Qeyd
OperationResult Tipinin Yaradılması	OperationResult<T> sinfi yaradılır (Uğurlu, MesajKey, Data, Hatalar).	MesajKeys gələcəkdə lokalizasiya üçün resx fayllarına işarə edir.
MehsulManager	Məhsulun CRUD əməliyyatları, stokun dəyişdirilməsi və barkod/SKU unikal yoxlaması.	Məntiq: Stok neqativ ola bilməz. Hər manager IUnitOfWork injekt edir.
SatisManager	Satışın qeydiyyatı (Satis və SatisDetali). Nağd/Kart/Nisyə ilkin ödəniş metodlarının idarəsi.	Bütün Satış əməliyyatı bir transaction daxilində olmalıdır (UoW).
NisyeManager	Müştəri üçün Nisyə borcunun qeydiyyatı və qismən/tam ödənişin tətbiqi.	Borc qalıq məbləğinin düzgün hesablanması.
Servis Qeydiyyatı	Bütün Manager-lər və Repository-lər Scoped servislər kimi DI konteynerə əlavə edilir.	services.AddScoped<IMehsulManager, MehsulManager>()


Qəbul Meyarı (AC): Bütün Manager metodları Task<OperationResult<T>> qaytarır. MehsulManager üzərindəki stok azalması əməliyyatı xəta olmadan işləyir.

4. Təqdimat Qatı (Minimal MVP) (Faza D)
Minimal işlək istifadəçi interfeysi (UI) MaterialSkin stilində qurulur.

Tapşırıq	Təsvir	Qeyd
BaseForm və Stil	BaseForm sinfi MaterialSkin.2-dən miras alır və Tema dəyişmə (Light/Dark) funksiyasını ehtiva edir.	Bütün formalar BaseForm-dan miras almalıdır.
Lokalizasiya Təməli	Lang.az.resx və Lang.en.resx faylları yaradılır. Dil dəyişmə funksiyası tətbiq edilir.	UIService sinfi tərəfindən resx açarları runtime-da yenilənir.
MVP Sənədləşməsi	IMehsulView və MehsulPresenter skeleti yaradılır.	Presenter-lər Manager-ləri istifadə edir və UI (View)-u yeniləyir.
Mehsulİdarəetmə Formu	Məhsulların siyahısını göstərən Grid, Əlavə et/Redaktə et/Sil düymələri.	DataGridView üzərində dinamik axtarış (SKU/Ad) funksiyası.
SatisFormu	Barkod inputu, səbət (cart) göstəricisi, ödəniş seçimi və Təsdiqləmə düyməsi.	Minimal, işlək interfeys. Təsdiq zamanı SatisManager çağırılmalıdır.


Qəbul Meyarı (AC): MehsulİdarəetməFormu üzərindən əlavə edilən yeni məhsul DB-də qeyd olunur və griddə görünür. Dil dəyişmə form başlığını yeniləyir.

5. Testlər və Keyfiyyət Təminatı (Faza F - Qismən)
Faza 1-in məhsullarını yoxlamaq üçün testlər hazırlanır.

Tapşırıq	Təsvir	Qəbul Meyarı (AC)
Unit Testlər	MehsulManagerTests.cs sinfi. CRUD və Stok Qaydaları test edilir (Mock Repositories ilə).	dotnet test zamanı uğurlu və uğursuz ssenarilər testdən keçməlidir.
İnteqrasiya Testi (Təməl)	Test DB-də SatisManager metodunun IUnitOfWork vasitəsilə transaction-da işləməsi yoxlanılır.	Satış zamanı həm satış, həm də stok update-nin birgə baş tutması/geri alınması (rollback).
Təməl Dokumentasiya	README.md faylında build, run, migration və seed addımları izah edilir.	README repoda mövcuddur və addımlar işləyir.


🚀 Faza 1 Yekun Buraxılış Siyahısı
Faza 1 o zaman tamamlanmış sayılır ki:

Memarlıq Təməli: Solution, layihələr, referenslər və DI konfiqurasiyası qurulub.

Data Access Qatı: DbContext, IRepository, IUnitOfWork və Miqrasiya/Seed tam işləkdir.

Biznes Məntiqi: MehsulManager, SatisManager, NisyeManager və OperationResult<T> tətbiq olunub.

MVP UI: Mehsulİdarəetmə və Satis formaları əsas CRUD və Satış funksiyaları ilə işləyir.

Keyfiyyət: Əsas Unit Testlər və Transaction Testləri keçib.