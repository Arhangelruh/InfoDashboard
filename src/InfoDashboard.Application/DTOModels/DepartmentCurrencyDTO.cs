namespace InfoDashboard.Application.DTOModels
{
	public class DepartmentCurrencyDTO
	{
		/// <summary>
		/// Currency name.
		/// </summary>
		public string Currency { get; set; } = null!;

		/// <summary>
		/// Common cash bying summ.
		/// </summary>
		public decimal CashBuy {  get; set; }

		/// <summary>
		/// Common cash selling summ.
		/// </summary>
		public decimal CashSell { get; set; }

		/// <summary>
		/// Margin.
		/// </summary>
		public decimal Margin {  get; set; }
	}
}
