using _19_RestorantUygulamasi.DataContext;
using _19_RestorantUygulamasi.Models;
using _19_RestorantUygulamasi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace _19_RestorantUygulamasi.Controllers
{
    public class GarsonController : Controller
    {
        private readonly RestorantContext _context;
        public GarsonController(RestorantContext context)
        {
                _context= context;
        }
        public IActionResult Index()
        {
           
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("KullaniciAdi")))
            {
                return RedirectToAction("Login", "Account");
            }
            var masalar = _context.Masalar.ToList();
            var masaDetaylari = masalar.Select(masa => new MasaListeViewModel()
            {
                Masa = masa,
                AktifRezervasyon = GetAktifRezervasyon(masa.Id)
            }).ToList();

            return View(masaDetaylari);
        }
        private Rezervasyon GetAktifRezervasyon(int masaId)
        {
            var aktifRezervasyonId = HttpContext.Session.GetInt32($"AktifRezervasyonId_ {masaId}");
            if (aktifRezervasyonId.HasValue)
            {
                return _context.Rezervasyonlar.Find(aktifRezervasyonId.Value);
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<Masa>> DurumDegistir(int masaId)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("KullaniciAdi")))
            {
                return RedirectToAction("Login", "Account");
            }
            var masa = await _context.Masalar.FindAsync(masaId);
            if (masa == null)
            {
                return NotFound("Masa Bulunamadı");
            }
            masa.DoluMu = !masa.DoluMu;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult<Rezervasyon>> RezervasyonAktifEt(int rezervasyonId)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("KullaniciAdi")))
            {
                return RedirectToAction("Login", "Account");
            }
            var rezervasyon = _context.Rezervasyonlar.Find(rezervasyonId);
            if (rezervasyon == null)
            {
                return NotFound();
            }
            var masa = _context.Masalar.Find(rezervasyon.MasaId);
            if (masa is null)
            {
                return NotFound("Masa bulunamadı");
            }
            masa.DoluMu = true;
            HttpContext.Session.SetInt32($"AktifRezervasyonId_ {masa.Id}",rezervasyonId);
            await _context.SaveChangesAsync();
            return RedirectToAction("MasaDetay", new { masaId = masa.Id });
        }
        public IActionResult MasaDetay(int masaId)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("KullaniciAdi")))
            {
                return RedirectToAction("Login", "Account");
            }
            var masa =_context.Masalar.Find(masaId);
            if (masa == null)
            {
                return NotFound("Masa Bulunamadı");
            }
            var bugunRezervasyonlar=
                _context.Rezervasyonlar.Where(r=>r.MasaId==masaId&&r.RezervasyonTarihi.Date==DateTime.Today).ToList();
            int? aktifRezervasyonId = HttpContext.Session.GetInt32($"AktifRezervasyonId_{masaId}");
            var viewModel = new MasaDetayViewModel()
            {
                Masa=masa,
                BugunRezervasyonlar = bugunRezervasyonlar,
                AktifRezervasyonId=aktifRezervasyonId
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult MasayiBosalt(int masaId)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("KullaniciAdi")))
            {
                return RedirectToAction("Login", "Account");
            }
            var masa = _context.Masalar.Find(masaId);
            if (masa == null)
            {
                return NotFound("Masa Bulunamadı");
            }
            int? aktifRezervasyonId = HttpContext.Session.GetInt32($"AktifRezervasyonId_{masaId}");
            if (aktifRezervasyonId.HasValue)
            {
                var aktifRezervasyon = _context.Rezervasyonlar.Find(aktifRezervasyonId.Value);
                if (aktifRezervasyonId != null)
                {
                    _context.Rezervasyonlar.Remove(aktifRezervasyon);
                }
            }
            masa.DoluMu = false;
            HttpContext.Session.Remove($"AktifRezervasyonId_{masaId}");
            _context.SaveChanges();
            return RedirectToAction("MasaDetay", new { masaId = masaId });
        }
    }
}
