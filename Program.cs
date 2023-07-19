var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Detalhes de exceções não tratadas
// Como é uma aplicação que não será publica num servidor real, sempre mostrará os erros
app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Mesmo resultado que acima
//app.MapDefaultControllerRoute();


app.Run();
