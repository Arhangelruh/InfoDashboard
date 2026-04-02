namespace InfoDashbord.Web.ViewModels
{
	public class DashbordViewModel
	{
		/// <summary>
		/// Best currency and banks.
		/// </summary>
		public List<RateViewModel> BestCurrencies { get; set; } = [];

		/// <summary>
		/// Our currency.
		/// </summary>
		public List<DepartmentCurrencyViewModel> OurCurrency { get; set; } = [];
	}
}
