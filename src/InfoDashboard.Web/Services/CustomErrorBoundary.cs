using Microsoft.AspNetCore.Components.Web;

namespace InfoDashboard.Web.Services
{
	public class CustomErrorBoundary(ILogger<CustomErrorBoundary> logger) : ErrorBoundary
	{
		private readonly ILogger<CustomErrorBoundary> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

		protected override Task OnErrorAsync(Exception exception)
		{
			_logger.LogError(exception, "Unhandled exception in UI");
			return Task.CompletedTask;
		}

		public void RecoverManually()
		{
			Recover();
		}
	}
}
