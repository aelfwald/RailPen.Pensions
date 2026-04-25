using RailPen.Pensions.Application.Builders;
using RailPen.Pensions.Application.Repositories;
using RailPen.Pensions.Application.Services;
using RailPen.Pensions.Domain.Factories;
using RailPen.Pensions.Infrastructure.Repositories;
using RailPen.Pensions.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register UI services
builder.Services.AddSingleton<IModelBuilder, ModelBuilder>();

// Register application services
builder.Services.AddSingleton<IMemberService, MemberService>();
builder.Services.AddSingleton<IPensionService, PensionService>();
builder.Services.AddSingleton<IPensionDomainObjectBuilder, PensionDomainObjectBuilder>();

// Register domain services
builder.Services.AddSingleton<IPensionFactory, PensionFactory>();

// Register repositories
builder.Services.AddSingleton<IMemberRepository, MemberRepository>();
builder.Services.AddSingleton<IFundRepository, FundRepository>();
builder.Services.AddSingleton<IMemberFundRepository, MemberFundRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
