Faza 5: Keyfiyyət Təminatı, Yerləşdirmə və Davamlılıq
Məqsəd: Bütün dörd fazada qurulan funksionallıqların istehsalat (production) mühitində problemsiz və dayanıqlı işləməsini təmin etmək. Qalan texniki borcları (technical debt) bağlamaq, avtomatlaşdırmaq və istifadəçi/developer sənədləşməsini tamamlamaq.

1. Kod Bazasının Yekun Optimallaşdırılması
Bu mərhələdə bütün layihənin kod keyfiyyəti və performansı yoxlanılır.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Performans Tənzimlənməsi	Lazy Loading və ya Eager Loading optimallaşdırılmasının tətbiqi. Ən çox istifadə olunan sorğulara (məsələn, SatisFormu-nda məhsul axtarışı) indekslərin əlavə edilməsi.	Verilənlər	Ən kritik 5 sorğu 100 ms-dən az vaxtda icra olunur.
Texniki Borcun Bağlanması	Kodda qalan TODO qeydlərinin, komment edilmiş kodların və ya "quick fix" həllərinin aradan qaldırılması.	Bütün Qatlar	Code Review-dan sonra kritik bir texniki borc qalmaması.
Məntiq Qatının Yenidən Yoxlanılması	SOLID prinsiplərindən sapmaların (xüsusən Manager-lərdə) yoxlanılması.	Məntiq	SatisManager təkrar yoxlanılır, bütün metodlar SRP-yə uyğundur.


2. Testlərin Genişləndirilməsi və Avtomatlaşdırma
Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
End-to-End (E2E) Test Ssenariləri	WinForms UI-da real istifadəçi yolunu təqlid edən testlərin (məsələn, Mix Payment ilə Satış -> Z-Report) yazılması.	Testlər	Testlər real şəkildə UI üzərindən yoxlama aparır.
Keyfiyyət Təminatı (QA) Checklist	Quraşdırma, istifadəçi login, offline/online keçidi kimi bütün funksiyaları əhatə edən ətraflı manual test sənədi.	Sənədləşmə	Sənəddə gözlənilən nəticə və test addımları tam göstərilir.
CI/CD Pipeline-ın Final Tənzimlənməsi	Hər kod dəyişikliyindən sonra Testlərin Avtomatik İcrası (CI) və Quraşdırma Paketinin Yaradılması (CD) mexanizmi.	İnfrastruktur	CI/CD pipeline xətasız işləyir və Release Artifact avtomatik yaranır.


3. Sənədləşmə (Documentation)
Layihənin gələcək inkişafı və istifadəsi üçün vacibdir.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
İstifadəçi Təlimatı	Son istifadəçilər (Kassirlər, Menecerlər) üçün bütün funksiyaları (Mix Payment, Z-Report, İadə) izah edən rəsmi təlimat.	Sənədləşmə	Təlimatda ekran görüntüləri və addım-addım təlimatlar mövcuddur.
Developer Sənədləşməsi (Architecture)	Layihənin Çoxlaylı Memarlığını, DI Strukturunu, OperationResult tipinin istifadəsini izah edən sənəd.	Sənədləşmə	Yeni developer üçün kod bazasına daxil olma müddəti minimuma enir.
API Sənədləşməsi	Swagger/OpenAPI və ya sadə README.md faylında bütün REST API endpointlərinin (Faza 4) izahı.	Sənədləşmə	API-dan istifadə etmək istəyən hər hansı üçüncü tərəf sənədləşməni anlaya bilir.


4. Yerləşdirmə (Deployment) və Quraşdırma
Məhsulun müştərilərin sistemlərində asanlıqla quraşdırılmasını təmin edir.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Quraşdırma Paketi (Installer)	MSI və ya Squirrel kimi texnologiyalarla tək kliklə quraşdırıla bilən paket hazırlanması.	İnfrastruktur	Paket proqramı avtomatik olaraq Desktop ikonunu və Menyu elementini yaradır.
İlk Konfiqurasiya Avtomatlaşdırması	Quraşdırmadan dərhal sonra Connection String-in daxil edilməsi və DB Miqrasiyasının avtomatik işə salınması (ilk dəfə).	İnfrastruktur	Müştəri əl ilə heç bir dotnet ef əmri daxil etmədən sistemi işə salır.
Təhlükəsizlik Siyasəti	Parol Dəyişməyi Tələb Etmə (ilk girişdə) və Qeyri-Aktiv Session-un Bağlanması kimi funksiyaların tətbiqi.	Təhlükəsizlik	Proqram 15 dəqiqə fəaliyyətsiz qalanda avtomatik olaraq kilidlənir (lock).


5. Faza 5 Yekun Buraxılış Siyahısı
Faza 5-in tamamlanması, NaxcivanPOS-un tam şəkildə dayanıqlı, sənədləşdirilmiş və korporativ standartlara uyğun olduğunu göstərir.

Kod Təmizliyi: Əsas sorğular (Query-lər) və kod strukturu performans tənzimlənməsindən keçib.

Test Əhatəliliyi: Bütün Unit Testlər, İnteqrasiya Testləri və E2E Testləri uğurla keçib.

Sənədləşmə Tamamlanması: İstifadəçi Təlimatı və Developer Sənədləşməsi (Architecture) rəsmiləşdirilib.

Avtomatlaşdırma: CI/CD pipeline final olaraq tənzimlənib və avtomatik quraşdırma paketi yaradılıb.