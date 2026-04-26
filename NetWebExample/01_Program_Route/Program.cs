var builder = WebApplication.CreateBuilder(args);//WebUygulamasý olduðunu ve bu yapýnýn oluþturulduðu arguman yapýsý.

// Add services to the container.
builder.Services.AddControllersWithViews();//Controller ve view haberleþme mekanizmasý

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//Middleware aracýlýðý ile istek yönlendirmesi
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//Https Yönlendirmesi SSL yapýlarý 
app.UseRouting();//Yol haritasý ayaða kaldýrma

app.UseAuthorization();//Yetkilendirme yapýsý

app.MapStaticAssets();//Fiziksel dosyalarý yakalama

app.MapControllerRoute(//Route yapýsý ile baþlangýçta açýlacak sayfa yada isteðe baðlý sayfa yapýlarý kullanma yeri
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "about",
    pattern: "Hakkýmýzda",
    defaults: new { controller = "Home", action = "About" }

    );

app.MapControllerRoute(
    name:"blogDetails",//Bu route'a verilen isim (isteðe baðlý ama faydalýdýr)
    pattern:"blog/details/{id}",//Eþleþmesi gereken Url deseni
    defaults: new {controller="Blog",action="Details" },//Bu Url deseniyle eþleþirse çalýþacak controller
    constraints: new {id=@"\d+" }//id parametresi sadece sayýlardan oluþmalý
    
    );

app.Run();//Uygulamanýn ayaða kalktýðý yapý
