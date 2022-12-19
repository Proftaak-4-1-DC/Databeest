using Microsoft.AspNetCore.HttpOverrides;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else
{
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{action=Index}", defaults: new { controller = "Main", action = "Index" });
app.MapControllerRoute(name: "login", pattern: "{action=Login}", defaults: new { controller = "Main", action = "Login" });
app.MapControllerRoute(name: "register", pattern: "{action=Register}", defaults: new { controller = "Main", action = "Register" });
app.MapControllerRoute(name: "policy", pattern: "{action=AlgemeneVoorwaarden}", defaults: new { controller = "Main", action = "AlgemeneVoorwaarden" });
app.MapControllerRoute(name: "virus", pattern: "{controller=Main}/{action=Virus}");

app.Run();
