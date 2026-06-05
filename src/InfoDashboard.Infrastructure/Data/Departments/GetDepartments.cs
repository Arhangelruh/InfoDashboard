using InfoDashboard.Application.Interfaces;
using InfoDashboard.Domain.Models.Departments;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace InfoDashboard.Infrastructure.Data.Departments
{
	public class GetDepartments(ILogger<GetDepartments> logger): IGetDepartments
	{
		private readonly ILogger<GetDepartments> _logger = logger;
		public async Task<List<Department>> GetAll()
		{
			string path = "Departments.json";
			try
			{
				string jsonString = await File.ReadAllTextAsync(path);
				var departments = JsonSerializer.Deserialize<List<Department>>(jsonString);
				
				return departments = departments ?? [];
			}
			catch(Exception ex)
			{
				_logger.LogWarning($"Problem with departments file: {ex.Message}");			
				return [];
			}
		}
	}
}
