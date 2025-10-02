📐 NaxcivanPOS Layihəsi – Ümumi Kodlaşdırma Qaydaları

Bu sənəd NaxcivanPOS layihəsində bütün inkişafçılar üçün vahid standartı müəyyən edir. Məqsəd — oxunaqlı, təhlükəsiz, asan saxlanılan və peşəkar səviyyədə C# kod bazası təmin etməkdir.

1️⃣ Adlandırma Konvensiyaları (Naming Conventions)

Layihədə Azərbaycan dilində terminologiya istifadə ediləcək. Bütün elementlər üçün aşağıdakı qaydalar keçərlidir:

Element	Qayda	Nümunə
Siniflər (Classes)	PascalCase, tək halda	Mehsul, SatisManager, AuditLogService
İnterfeyslər (Interfaces)	"I" prefiksi + PascalCase	IRepository<T>, IUnitOfWork, IMehsulView
Metodlar (Methods)	PascalCase, fel formasında	MehsulYaratAsync(), StokDəyişdir(), KassaBagla()
Dəyişənlər (Local Vars)	camelCase	qiymetTotal, musteriKarti
Parametrlər (Parameters)	camelCase, fərqli ad	mehsulYaratAsync(Mehsul mehsulModel)
Field'lər (Private)	_ + camelCase	private readonly IUnitOfWork _unitOfWork;
Property'lər (Public)	PascalCase	public decimal Qiymet { get; set; }
Enum'lar (Enums)	PascalCase, tək halda	OdenisTipi.Nağd, Rol.Kassir
2️⃣ Asinxron Əməliyyatlar (Async/Await)

Bütün asinxron metodlar Async postfixi ilə bitməlidir.
✅ Task<OperationResult<T>> MehsulYaratAsync(Mehsul mehsul)

DB və Manager qatındakı bütün əməliyyatlar await ilə icra olunmalıdır.

UI-nı dondurmamaq üçün lazım olmayan yerlərdə:
await SomeTask.ConfigureAwait(false)

3️⃣ Kod Strukturu və Təmizlik

#region istifadəsindən qaçın – sinifləri kiçik saxla.

using direktivləri faylın yuxarı hissəsində olmalıdır.

İzolyasiya – bütün metodlar və dəyişənlər default olaraq private.

Bir sinif – bir fayl qaydası.

Kod qısa və oxunaqlı olmalıdır, uzun metodlar parçalanmalıdır.

4️⃣ Təhlükəsizlik və Xəta Emalı

OperationResult<T>: Bütün biznes əməliyyatları bu tip ilə nəticə qaytarır.
✅ OperationResult<Mehsul> netice = await _manager.MehsulYaratAsync(mehsul);

UI səviyyəsində try-catch: Xətalar yalnız təqdimat qatında tutulur və Serilog və ya başqa logger ilə loglanır.

Parollar heç vaxt plain-text saxlanmır, yalnız BCrypt/PBKDF2 ilə heşlənir.

5️⃣ Dependency Injection (DI)

Bütün asılılıqlar interfeys vasitəsilə inject edilməlidir (IRepository, IMehsulManager).

Konkret siniflərdən birbaşa istifadə qadağandır.

İnjeksiya olunan obyektlər sinif daxilində private readonly field-lərdə saxlanılır.

6️⃣ Verilənlər Bazası (EF Core) Qaydaları

DbContext-ə birbaşa çıxış yoxdur → Yalnız IRepository<T> və IUnitOfWork.

Transaction istifadə edilməlidir – Satış, Transfer, İadə əməliyyatları.

Lazy Loading qadağandır – yalnız Include() ilə ehtiyac olduqda yüklənir.

7️⃣ Qlobal Kod Prinsipləri

Bu layihədə ümumi proqramlaşdırma standartları da keçərlidir:

SOLID – obyekt yönümlü dizaynın əsası.

KISS – kod sadə olmalıdır.

DRY – kod təkrar yazılmamalıdır.

YAGNI – ehtiyac olmayan funksiyanı yazma.

SoC (Separation of Concerns) – UI, biznes və data qatları ayrıdır.

LoD (Law of Demeter) – obyektlər yalnız öz tanıdıqları ilə işləyir.

Convention over Configuration – mümkün olduqca konvensiyalara əməl edilir.

Fail Fast – səhvləri gizlətmə, dərhal göstər.

Testability – kod unit test-ə uyğun şəkildə yazılmalıdır.

8️⃣ Təmiz Kod Prinsipləri

Məzmunlu dəyişən adları → qiymet, stokSay, isAktiv

Qısa metodlar → hər metod yalnız bir iş görür

Comment az, aydın kod çox → izahı kodun özü verməlidir

Magic numbers qadağandır → constant və enum istifadə et

Sabitlər const və ya readonly ilə təyin olunmalıdır

✅ Bu standartlara əməl edilməsi NaxcivanPOS layihəsinin:

asılılıqlardan azad,

təhlükəsiz,

uzunmüddətli dəstəklənən
bir məhsul olmasını təmin edəcək.