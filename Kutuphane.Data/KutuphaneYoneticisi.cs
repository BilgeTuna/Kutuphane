using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data
{
    public class KutuphaneYoneticisi
    {
        public KutuphaneYoneticisi()
        {
            Kitaplar = new List<Kitap>
            {
                new Kitap()
                { 
                    Aciklama = "Biyografi Kitabı", 
                    Ad = "Tesla", 
                    BasımTarihi = DateTime.Now,
                    KitapTur = KitapTur.Biyografi, 
                    SayfaSayisi = 100,
                    YazarAd = "Tesla"
                }
            };
        }       

        public List<Kitap> Kitaplar { get; set; }

        public void KitapBagis(Kitap kitap, int adet)
        {
            for (int i = 0; i < adet; i++)
            {
                Kitaplar.Add(kitap);
            }
        }
        public void KitapTeslimEtme(Kitap kitap)
        {
            //Teslim edileceği zaman oduncAlmaTarihi null oluyor(hocanın notu)
            Kitaplar.Add(kitap);
        }
        public void KitapImhaEt(Kitap kitap)
        {
            Kitaplar.Remove(kitap);
        }
    }
}
