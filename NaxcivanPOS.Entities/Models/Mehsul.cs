using System;

namespace NaxcivanPOS.Entities.Models
{
    /// <summary>
    /// Məhsul sinfi - sistemdəki məhsulları təmsil edir
    /// </summary>
    public class Mehsul
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Qiymet { get; set; }
        public int Miqdar { get; set; }
        public DateTime YaradilmaTarixi { get; set; }
        public DateTime SonGuncellemeTarixi { get; set; }
    }
}