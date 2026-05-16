namespace _19_RestorantUygulamasi.Models
{
    public class LogTablosu
    {
        public int Id { get; set; }
        public int MasaId { get; set; }
        public Masa Masa { get; set; }
        public string MusteriAdi { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}
