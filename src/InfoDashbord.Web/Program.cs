using InfoDashbord.Application;
using InfoDashbord.Infrastructure;
using InfoDashbord.Web.Components;
using InfoDashbord.Web.Models;
using InfoDashbord.Web.Services;
using NLog;
using NLog.Web;

var logger = LogManager.Setup()
	.LoadConfigurationFromAppSettings()
	.GetCurrentClassLogger();
try
{
	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.
	builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();

	builder.Services.AddInfrastructure(builder.Configuration);
	builder.Services.Configure<BankSettings>(builder.Configuration.GetSection("BankSettings"));
	builder.Services.AddScoped<GetCurrencyService>();

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Error", createScopeForErrors: true);
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	}
	app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
	app.UseHttpsRedirection();

	app.UseAntiforgery();

	app.MapStaticAssets();
	app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode();

	app.Run();
}
catch (Exception ex)
{
	logger.Error(ex, "Application stopped due to exception");
	throw;
}
finally
{ LogManager.Shutdown(); }
