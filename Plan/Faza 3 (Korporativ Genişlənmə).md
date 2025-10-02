Faza 3: Korporativ Genişlənmə – Detallı Plan
Bu faza, layihəyə Çox-Filiallıq (Multi-Branch) dəstəyi, Seriya/Partiya İzləmə kimi mürəkkəb inventar idarəetmə funksiyalarını, eləcə də Geniş CRM və Ətraflı Analitika modullarını əlavə edəcək.
Məqsəd: Layihəni böyük və ya şəbəkə bizneslərinə uyğunlaşdırmaq. Çoxlu anbar və filialları, mürəkkəb məhsul növlərini (seriyalı, partiyalı) və dərin müştəri əlaqələrini (CRM) idarə etmək üçün tələb olunan funksionallıqları əlavə etmək.

1. Çox-Filiallıq və Mərkəzi İdarəetmə
Bütün sistemin mərkəzi verilənlər bazası (DB) üzərindən filialları və anbarları idarə etməsini təmin edir.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Filial və Anbar Entity-ləri	Filial və Anbar sinifləri yaradılır. MehsulStoku cədvəlində Anbar ID-si əlavə edilir.	Varlıqlar / Verilənlər	Hər bir məhsulun stoku konkret anbar ilə əlaqələndirilir.
İşçi-Filial Əlaqəsi	Isci entity-sinə hansı filialda işlədiyi qeyd olunur. Login zamanı işçinin filial məlumatları avtomatik gəlir.	Varlıqlar / Məntiq	Kassir rolu yalnız öz filialının əməliyyatlarını görə bilir (Məntiq qatında filtrasiya).
Anbarlararası Transfer	Məhsulun bir anbardan (filialdan) digərinə köçürülməsi əməliyyatı. Transfer entity-si yaradılır.	Məntiq	Transfer təsdiq edildikdə, çıxan anbarın stoku azalır və gələn anbarın stoku artır.


2. Mürəkkəb Məhsul və İnventar İdarəetməsi
Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Seriya Nömrəsi İzləmə	MehsulSeriya entity-si yaradılır. Texniki mallar kimi seriyası izlənməli olan məhsullar üçün qeydiyyat.	Varlıqlar / Məntiq	Satış və İadə zamanı seriya nömrəsinin seçilməsi məcburidir.
Partiya və İstifadə Tarixi (Expiry Date)	Ərzaq və dərmanlar üçün MehsulPartiya sinfi. FIFO (First-In, First-Out) prinsipi tətbiq edilir.	Varlıqlar / Məntiq	Satış zamanı istifadə müddəti ən yaxın olan partiya seçilir.
Komplekt Məhsul (Bundle)	Komplekt entity-si. Birdən çox Mehsul-u birləşdirir.	Varlıqlar / Məntiq	Komplekt satıldıqda, SatisManager tərəfindən tərkibindəki bütün məhsulların stoku azaldılır.
Anbar İnventarizasiyası	Fiziki sayımla sistem stoku arasındakı fərqin qeyd edilməsi və MehsulManager vasitəsilə stok düzəlişi.	Məntiq / Təqdimat	InventarizasiyaFormu ilə fərqlərin qeydiyyatı.


3. Geniş CRM və Loyallıq
Müştəri ilə əlaqələrin dərinləşdirilməsi və loyallıq proqramının tətbiqi.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Loyallıq Sistemi	Musteri entity-sinə Bonus Balansı və Endirim Faizi sahələrinin əlavə edilməsi.	Varlıqlar / Məntiq	Satış zamanı bonus balı tətbiq olunur və qalıq bal yenidən hesablanır.
Müştəri Seqmentasiyası	Müştəri tipinə görə (məsələn, VIP, Borclu) avtomatik təsnifat.	Məntiq	Seqmentasiyaya görə fərqli endirim qaydaları işə düşür.
Nisyə Borc Xəbərdarlığı	NisyeManager daxilində qalıq borc üçün tarixə bağlı xəbərdarlıq sistemi.	Məntiq	Borc müddəti bitməyə yaxın olan müştərilərin siyahısı görünür.
Müştəri Kartı Dəstəyi	MusteriFormu-nda kart nömrəsinin qeydiyyatı. SatisFormu-nda kartla axtarış.	Təqdimat	Müştəri kartı skan edilərkən müştəri məlumatları avtomatik gəlir.


4. Ətraflı Analitika və Hesabatlar
Faza 2-də qurulan sadə hesabatlar maliyyə dərinliyi ilə genişləndirilir.

Tapşırıq	Təsvir	Təsir Edən Qat	Qəbul Meyarı (AC)
Mənfəət Hesabatı	Satış qiyməti – Orta Alış Qiyməti (AVG Cost) əsasında dəqiq Qazanc hesabatının hazırlanması.	Məntiq	Hesabat Total Satışdan əlavə, Ümumi Xərc və Net Qazanc göstərir.
Xərclər Modulu	Xerc entity-si və XercManager. Əlavə xərclərin (icarə, maaş, s.) qeydiyyatı.	Varlıqlar / Məntiq	Gəlir-Xərc Balansı hesabatı mövcuddur.
Top Məhsullar və Filial Müqayisəsi	Ən çox satılan məhsullar, ən çox qazanc gətirən məhsullar. Filialların satışlarının müqayisə cədvəli.	Məntiq / Təqdimat	Hesabatlar modulunda vizual qrafiklər (sadə MaterialSkin-ə uyğun) görünür.
Hesabat İxracı	Bütün analitik hesabatların Excel və PDF formatında ixrac (Export) olunması.	Təqdimat / Yardımçı Servis	ExportService sinfi yaradılır və .NET-in daxili export kitabxanalarından istifadə edir.

5. Faza 3 Yekun Buraxılış Siyahısı
Faza 3 o zaman uğurla tamamlanmış sayılır ki:

Multi-Branch İşləkliyi: Anbarlararası Transfer əməliyyatı stoku düzgün idarə edir və hər işçi öz filialının məlumatlarını görür.

Mürəkkəb Stok: Seriya/Partiya İzləmə tələb edən məhsulların satışı və stoku xətasız işləyir.

Loyallıq Tamamlanması: Bonus Balansı və Endirim Faizi real satışda tətbiq olunur.

Maliyyə Dərinliyi: Mənfəət Hesabatı (alış qiyməti əsasında) və Xərclər Modulu düzgün işləyir.

Test: Anbar Transferi və Komplekt Məhsul əməliyyatları üçün İnteqrasiya Testləri əlavə edilib.
