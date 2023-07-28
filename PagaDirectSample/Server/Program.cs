using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddHttpContextAccessor();


// Add Swagger --> http://localhost:7025/swagger
// builder.Services.AddSwaggerGen();
// Add ResolveCOnflict / IgnoreObsolete / CustomSchemaIDs for buggy Telerik ReportDesigner
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PagaDirect", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.CustomSchemaIds(x => x.FullName);
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

/// Init swagger --> https://localhost:7025/swagger
app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SAAR API V1");
    c.RoutePrefix = "swagger";
    c.DocExpansion(DocExpansion.None);
});


app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
