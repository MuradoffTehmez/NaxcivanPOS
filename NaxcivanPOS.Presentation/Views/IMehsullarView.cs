using NaxcivanPOS.Entities.Models;
using System;
using System.Collections.Generic;

namespace NaxcivanPOS.Presentation.Views
{
    /// <summary>
    /// Məhsullar görünüşü interfeysi (MVP nümunəsi üçün)
    /// </summary>
    public interface IMehsullarView
    {
        IList<Mehsul> Mehsullar { get; set; }
        event Action LoadMehsullar;
        event Action<Mehsul> MehsulElaveEt;
        event Action<Mehsul> MehsulDuzelt;
        event Action<int> MehsulSil;
        event Action<string> MehsulAxtar;
        Action<string> MesajGoster { get; set; }
    }
}