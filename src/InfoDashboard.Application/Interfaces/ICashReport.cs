using InfoDashboard.Application.DTOModels;
using InfoDashboard.Domain.Models.ExchangeCurrencyReport;

namespace InfoDashboard.Application.Interfaces
{
	public interface ICashReport
	{
		/// <summary>
		/// Parse xml from database.
		/// </summary>
		/// <param name="xml">Xml from database.</param>
		/// <returns></returns>
		List<Item> Parse(string xml);

		/// <summary>
		/// Get info.
		/// </summary>
		/// <returns></returns>
		Task<List<WorkplaceGroup>> GetReport();

		/// <summary>
		/// Get information with branch filter.
		/// </summary>
		/// <returns></returns>
		Task<List<DepartmentDTO>> CollectDepartmentInformation();
	}
}
