using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.ExchangeCurrencyReport
{
	[XmlRoot("Root")]
	public class Root
	{
		public Upload Upload { get; set; } = null!;
	}
}
