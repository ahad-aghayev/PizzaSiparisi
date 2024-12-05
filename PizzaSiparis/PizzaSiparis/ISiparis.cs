using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSiparis
{
    public interface ISiparis
    {
        string Boyut { get; set; }
        string KenarTipi { get; set; }
        string Içecek { get; set; }
        string Tatli { get; set; }
        string Malzemeler { get; set; }
        decimal Fiyat { get; set; }
        decimal Hesapla();
    }
}
