Faza 2: Bazar Girişi – Detallı Plan
Bu faza, ödəniş çevikliyi (Mix Payment), təhlükəsizlik (İcazələr Matrisi) və kassa nəzarəti (Z-Report) kimi ən kritik funksionallıqları əlavə edəcək.
Məqsəd: Əsas satış prosesini Mix Payment və Endirim Kampaniyaları ilə genişləndirmək; sistemə Rol Əsaslı İcazələri və Kassa Bağlanışı (Z-Report) funksiyasını inteqrasiya edərək məhsulu bazara çıxarmaq üçün hazır vəziyyətə gətirmək.

1. Satış və Ödəniş Genişlənməsi
Faza 1-də qurulan SatisManager və Odenis entity-ləri üzərində əlavə funksionallıqlar qurulur.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Qarışıq Ödəniş (Mix Payment)	SatisManager tərəfindən Nağd, Kart və Nisyə ödənişlərinin eyni anda qəbul edilməsi. Odenis entity-sində ödəniş tipi ayrımı.	Məntiq / Verilənlər	Ödəniş balansının (Total - Ödənilən = Qalıq) düzgün hesablanması.
Satış İadəsi (Return)	İadə əməliyyatının qeydiyyatı və pulun müvafiq metodla (məsələn, Kart) geri ödənməsi.	Məntiq / Verilənlər	İadə zamanı stokun avtomatik artırılması və Maliyyə hesabatlarında (Faza 5) əks olunması.
Sadə Endirim Kampaniyaları	Məhsul üzərində və ya ümumi səbətə faiz/məbləğ əsaslı endirimlərin tətbiqi.	Məntiq	SatisDetali entity-sində endirim məbləği qeyd olunur.
POS Terminal Hazırlığı	Kart ödənişləri üçün OdenisManager daxilində POS-terminalı simulyasiya edən xidmət (Service) skeletinin yaradılması.	Məntiq	OdenisManager.KartOdenis() metodu mövcuddur.

E
2. Kassa İdarəetməsi və Növbə (Shift)
Isci (Employee) entity-si ilə kassa əməliyyatları əlaqələndirilir.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Növbə Başlat/Bitir	Novbe entity-si. İşçinin növbəyə başlama və bitirmə vaxtının qeydi.	Varlıqlar / Məntiq	Növbə başlayan kimi işçi tərəfindən yeni əməliyyatlara icazə verilir.
Kassa Bağlanışı (Shift Close)	NovbeManager tərəfindən növbə daxilindəki bütün satış, iadə və ödənişlərin yekunlaşdırılması.	Məntiq	Yekunlaşma zamanı kassa daxilindəki nəğd pul (kassa balansı) dəqiq hesablanır.
Z-Hesabatı (Z-Report)	Növbənin bağlanması zamanı yekun maliyyə məlumatlarını ehtiva edən hesabatın (sadə mətndə) hazırlanması.	Təqdimat	Z-Hesabatında Satış Totalı, İadə Totalı və Kassa Balansı göstərilir.


3. Təhlükəsizlik və İşçi İcazələri
Faza 1-də qurulan Isci entity-si üzərində rol əsaslı icazə sistemi tətbiq olunur.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Rol Əsaslı Giriş	Isci entity-sinə Rol (Admin, Kassir, Menecer) xüsusiyyətinin əlavə edilməsi. Login Formu hazırlanır.	Varlıqlar / Təqdimat	İstifadəçi Roluna görə fərqli ana menyu (UI) görür.
Parol Heşlənməsi	IsciManager daxilində parolların BCrypt və ya PBKDF2 ilə heşlənərək DB-də saxlanması.	Məntiq	DB-də heç bir plain-text parol yoxdur. Login zamanı heş yoxlaması işləyir.
İcazələr Matrisi (Təməl)	Kassirin məhsul silə bilməməsi və ya Menecerin yalnız Hesabatlara baxa bilməsi kimi təməl icazə qaydaları.	Təqdimat / Məntiq	MehsulİdarəetməFormu-nda Kassir üçün Sil (Delete) düyməsi gizlənir/deaktiv edilir.
Audit Logu (Təməl)	AuditLog entity-sinin yaradılması. Stok dəyişimi və İadə kimi kritik əməliyyatlar işçi ID-si ilə qeyd olunur.	Varlıqlar / Məntiq	AuditLog cədvəlində minimum 2 kritik əməliyyat qeydi mövcuddur.


4. Çap və Barkod Dəstəyi
Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Barkod Skanı	SatisFormu-nda Barkod inputu üzərindən məhsulun sürətli skan edilməsi və səbətə əlavə olunması.	Təqdimat / Məntiq	Skandan dərhal sonra məhsul səbətdə görünür.
Çek Çapı (Simulyasiya)	PrintService skeletinin yaradılması və satış təsdiqlənəndə sadə çek formatının (txt) çap simulyasiyası.	Məntiq / Təqdimat	Təsdiq zamanı çek məlumatları log-a yazılır və ya ekranda görünür.
Dil Resurslarının Tamamlanması	Bütün formlar və mesajlar üçün az / en açarları hazırlanır.	Təqdimat	Dil dəyişəndə bütün UI mətni avtomatik yenilənir.


5. Faza 2 Yekun Buraxılış Siyahısı
Faza 2 yalnız o halda uğurla tamamlanmış sayılır ki:

Satış Çevikliyi: Qarışıq Ödəniş (Mix Payment) və İadə əməliyyatları xətasız işləyir.

Təhlükəsizlik: Login funksiyası heşlənmiş parollarla işləyir və Rol əsasında UI elementləri gizlənir/görünür.

Kassa Nəzarəti: Növbə başlat/bitir və növbə sonunda Z-Hesabatı düzgün total göstərir.

Barkod: SatisFormu üzərində barkodla sürətli skan işləyir.

Test: SatisManagerTests sinfinə Mix Payment və İadə ssenariləri əlavə edilib.

