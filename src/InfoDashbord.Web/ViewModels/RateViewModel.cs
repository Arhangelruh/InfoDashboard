namespace InfoDashbord.Web.ViewModels
{
	public class RateViewModel
	{
		/// <summary>
		/// Name.
		/// </summary>
		public string Title { get; set; } = null!;

		/// <summary>
		/// Amount.
		/// </summary>
		public double Rate { get; set; }

		/// <summary>
		/// Best banks list.
		/// </summary>
		public List<DepartmentCurrencyViewModel> BestBanks { get; set; } = [];
	}
}
