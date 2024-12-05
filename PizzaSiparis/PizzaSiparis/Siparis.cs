using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSiparis
{
    internal class Siparis : ISiparis
    {
        public string Boyut { get; set; }
        public string KenarTipi { get; set; }
        public string Içecek { get; set; }
        public string Tatli { get; set; }
        public string Malzemeler { get; set; }
        public decimal Fiyat { get; set; }

        public void MalzemeEkle(string malzeme)
        {
            if (!string.IsNullOrEmpty(malzeme))
            {
                if (!string.IsNullOrEmpty(Malzemeler))
                {
                    Malzemeler += ", "; // Seçilen malzeme varsa araya virgül koyar
                }
                Malzemeler += malzeme;
            }
        }
        public decimal Hesapla() //konu para olduğu için decimal kullanmalı :)
        {
            try
            {
                Fiyat = 0;
                // Boyut fiyatı alınacak
                if (Boyut == "Küçük 150 Tl")
                {
                    Fiyat += 150;
                }
                else if (Boyut == "Orta 200 Tl")
                {
                    Fiyat += 200;
                }
                else if (Boyut == "Büyük 250 Tl")
                {
                    Fiyat += 250;
                }

                // Kenar tipi fiyatı alınacak
                if (KenarTipi == "İnce ")
                {
                    //ek ücret alınmadığı için işlem yapılmıyor 
                }
                else if (KenarTipi == "Normal +20 Tl")
                {
                    Fiyat += 20;
                }
                else if (KenarTipi == "Kalın +30 TL")
                {
                    Fiyat += 30;
                }

                // İçecek alınacaksa 
                if (Içecek == "Pepsi +75 Tl" || Içecek == "Pepsi Zero +75 Tl" || Içecek == "Yedigün +75 Tl")
                {
                    Fiyat += 75;
                }
                // İçecek alınmayacaksa 
                else if (Içecek == "İçecek İstemiyorum")
                {
                    Fiyat += 0;
                }

                // Tatlı alınacaksa
                if (Tatli == "Pastel de Nata +200 Tl" || Tatli == "Suffle +200 Tl" || Tatli == "Lazza +200 Tl")
                {
                    Fiyat += 200;
                }
                // Tatlı alınmayacaksa
                else if (Tatli == "Tatlı İstemiyorum")
                {
                    Fiyat += 0;
                }

                // Malzeme seçimi  

                if (!string.IsNullOrEmpty(Malzemeler))
                //Eğer Malzemeler  tanımlanmamışsa (null) veya boş (Empty) bir değer içeriyorsa true döner.
                {
                    int malzemeSayisi = Malzemeler.Split(',').Length;
                    Fiyat += malzemeSayisi * 10; // Her malzeme için 10 TL
                }

                if (Fiyat < 300)
                {
                    throw new Exception("Minimum sipariş tutarı 300 ₺ olmalıdır.");
                }
                return Fiyat;
            }
            catch (Exception ex)
            {
                throw new Exception("Üzügünüz hata oluştu:" + ex.Message);
            }
        }
    }
}
