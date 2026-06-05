namespace InfoDashboard.Application.Interfaces
{
	public interface IGetConversionReport
	{
		/// <summary>
		/// Get report from database.
		/// </summary>
		/// <returns></returns>
		Task<string?> GetReport();
	}
}
