using _19_RestorantUygulamasi.Models;

namespace _19_RestorantUygulamasi.ViewModel
{
    public class MasaDetayViewModel
    {
        public Masa Masa { get; set; }
        public List<Rezervasyon> BugunRezervasyonlar { get; set; }
        public int? AktifRezervasyonId { get; set; }
    }
}
