namespace InfoDashboard.Domain.Models.ExchangeCurrencyReport
{
	public class WorkplaceGroup
	{
		public string WorkplaceName { get; set; }
		public List<Item> Items { get; set; } = new();
	}
}
