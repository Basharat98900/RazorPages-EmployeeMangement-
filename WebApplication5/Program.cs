using Microsoft.EntityFrameworkCore;
using RazorPages.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager ConfigurationManager = builder.Configuration;
builder.Services.AddDbContextPool<AppDBContext>(options =>
options.UseSqlServer(ConfigurationManager.GetConnectionString("AppDBContext")));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmployeeRepository, RazorPages.Services.SQLEmployeeRepository>();
builder.Services.AddRouting(opt =>
{
    opt.LowercaseQueryStrings = true;
    opt.LowercaseUrls = true;
    opt.AppendTrailingSlash = true;
    //opt.ConstraintMap.Add("even", typeof(EvenConstraint));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
