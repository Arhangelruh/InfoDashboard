using InfoDashboard.Infrastructure;
using InfoDashboard.Web.Components;
using InfoDashboard.Web.Models;
using InfoDashboard.Web.Services;
using NLog;
using NLog.Web;

var logger = LogManager.Setup()
	.LoadConfigurationFromAppSettings()
	.GetCurrentClassLogger();
try
{
	var builder = WebApplication.CreateBuilder(args);

	builder.Logging.ClearProviders();
	builder.Host.UseNLog();

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
