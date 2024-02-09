using Obilet.Core;
using Obilet.Infrastructure;
using Obilet.WebApp.Infrastructtures;
using Obilet.WebApp.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructureConfigureService(builder.Configuration, builder.Environment, builder.Logging);
builder.Services.AddCoreConfigureService(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Host.UseSerilog(LoggingService.ConfigureLogging);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{ 
    app.UseExceptionHandler();
    app.UseHsts(); //Bir web sitesini sadece https üzerinden erişim sağlama talimatı verir
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

app.UseHttpsRedirection();

// app.Use(async (context, next) =>          // Sadece örnek ve farklı kullanım gösterimi amaçlıdır.
// {
//     try 
//     {
//         await next.Invoke();
//     }
//     catch (Exception ex)
//     {
//         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//         await context.Response.WriteAsJsonAsync(new ProblemDetails());
//     }
// });

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<OpenTelemetryTraceIdMiddleware>(); // Her activity için traceid loga ekle.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();