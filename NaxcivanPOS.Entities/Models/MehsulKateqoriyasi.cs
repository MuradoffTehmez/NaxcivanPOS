using System;

namespace NaxcivanPOS.Entities.Models
{
    /// <summary>
    /// Məhsul Kateqoriyası sinfi
    /// </summary>
    public class MehsulKateqoriyasi
    {
        public int Id { get; set; }
        public required string Ad { get; set; }
        public string? Tanim { get; set; }
        public DateTime YaradilmaTarixi { get; set; }
        public DateTime SonGuncellemeTarixi { get; set; }
    }
}