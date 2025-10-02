using NaxcivanPOS.Business.Interfaces;
using NaxcivanPOS.Business.Services;
using NaxcivanPOS.Data;
using NaxcivanPOS.Data.Contexts;
using NaxcivanPOS.Data.Interfaces;
using NaxcivanPOS.Data.Repositories;
using NaxcivanPOS.Entities.Models;
using System;
using System.Threading.Tasks;

namespace NaxcivanPOS.TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("NaxcivanPOS Test Console");

            // DbContext yarat
            var context = new NaxcivanPOSContext();
            
            // Ensure database is created
            context.Database.EnsureCreated();
            
            // Unit of Work yarat
            var unitOfWork = new UnitOfWork(context);
            
            // İş məntiqi siniflərini yarat
            IMehsulYonetimi mehsulYonetimi = new MehsulYonetimi(unitOfWork);
            
            Console.WriteLine("Məhsul idarəetmə sistemi işə salındı.");
            
            // Test məhsulu əlavə et
            Console.WriteLine("Test məhsulu əlavə olunur...");
            var testMehsul = await mehsulYonetimi.CreateMehsulAsync("Alma", 2.50m, 100);
            Console.WriteLine($"Məhsul əlavə olundu: {testMehsul.Ad}, Qiymət: {testMehsul.Qiymet}, Say: {testMehsul.Miqdar}");
            
            // Bütün məhsulları göstər
            Console.WriteLine("Bütün məhsullar:");
            var mehsullar = await mehsulYonetimi.GetAllMehsullarAsync();
            foreach (var mehsul in mehsullar)
            {
                Console.WriteLine($"- {mehsul.Ad}: {mehsul.Qiymet} AZN, Say: {mehsul.Miqdar}");
            }
            
            Console.WriteLine("Test uğurla tamamlandı!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}