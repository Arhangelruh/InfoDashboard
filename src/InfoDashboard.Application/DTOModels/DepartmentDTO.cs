namespace InfoDashboard.Application.DTOModels
{
	public class DepartmentDTO
	{
		/// <summary>
		/// Department Name.
		/// </summary>
		public string DepartmentName { get; set; }

		/// <summary>
		/// Department currency information.
		/// </summary>
		public List <DepartmentCurrencyDTO> DepartmentCurrency { get; set; }
	}
}
