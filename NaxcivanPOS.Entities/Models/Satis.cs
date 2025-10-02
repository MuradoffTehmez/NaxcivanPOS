using System;

namespace NaxcivanPOS.Entities.Models
{
    /// <summary>
    /// Satış sinfi - həyata keçirilən satışları təmsil edir
    /// </summary>
    public class Satis
    {
        public int Id { get; set; }
        public int MehsulId { get; set; }
        public Mehsul Mehsul { get; set; }
        public int Say { get; set; }
        public decimal ToplamQiymet { get; set; }
        public DateTime Tarix { get; set; }
        public string? IsciAdi { get; set; }
    }
}