namespace _19_RestorantUygulamasi.Models
{
    public class Masa
    {
        public int Id { get; set; }
        public int MasaNumarasi { get; set; }
        public bool DoluMu { get; set; }
        public List<Rezervasyon> Rezervasyonlar { get; set; } = new List<Rezervasyon>();
    }
}
