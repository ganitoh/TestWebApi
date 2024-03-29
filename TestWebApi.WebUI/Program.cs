using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using TestWebApi.Persistance;
using TestWebApi.WebUI.Middleware;
using TestWebApi.Application;

var builder = WebApplication.CreateBuilder(args);


#region services
builder.Services.AddApplicationService();
builder.Services.AddCQRS();
builder.Services.AddMSSQL(builder.Configuration["ConnectionString:MSSQL"]!);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(configuration =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    configuration.IncludeXmlComments(filePath);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthorization();
#endregion

var app = builder.Build();

#region middleware
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseMiddleware<ExceptionHandlerMIddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");
#endregion


app.Run();
