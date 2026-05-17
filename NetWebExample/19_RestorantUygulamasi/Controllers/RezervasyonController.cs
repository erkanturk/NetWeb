using _19_RestorantUygulamasi.DataContext;
using _19_RestorantUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _19_RestorantUygulamasi.Controllers
{
    public class RezervasyonController : Controller
    {
        //Duzenle Method post get Sil post get bunlar yazılacak viewleri ile birlikte ödev
        private readonly RestorantContext _context;
        public RezervasyonController(RestorantContext context)
        {
            _context = context;
        }
        public IActionResult Detay(int masaId)
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
            var rezervasyonlar = _context.Rezervasyonlar.Where(r => r.MasaId == masaId && r.RezervasyonTarihi >= DateTime.Today).ToList();
            ViewBag.MasaNumarasi = masa.MasaNumarasi;
            ViewBag.MasaId = masa.Id;
            return View(rezervasyonlar);
        }
        public IActionResult Ekle(int masaId)
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
            ViewBag.MasaId = masaId;
            ViewBag.MasaNumarasi=masa.MasaNumarasi;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(int masaId, string musteriAdi, DateTime rezervasyonTarihi)
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
            var mevcutRezervasyon = await _context.Rezervasyonlar.FirstOrDefaultAsync(r=>r.MasaId==masaId&&r.RezervasyonTarihi.Date==rezervasyonTarihi.Date);
            if (mevcutRezervasyon != null)
            {
                ViewBag.ErrorMessage = "Bu masada seçilen tarihte müsaitlik bulunmamaktadır";
                ViewBag.MasaId = masaId;
                ViewBag.MasaNumarasi = masa.MasaNumarasi;
                return View();
            }
            var rezervasyon = new Rezervasyon()
            {
                MasaId = masaId,
                MusteriAdi = musteriAdi,
                RezervasyonTarihi = rezervasyonTarihi,
            };
            var logTablosu = new LogTablosu()
            {
                MasaId = masaId,
                MusteriAdi = musteriAdi,
                RezervasyonTarihi = rezervasyonTarihi,
            };
             await _context.Rezervasyonlar.AddAsync(rezervasyon);
             await _context.LogTablosu.AddAsync(logTablosu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Detay",new {masaId=masaId});

        }
    }
}
