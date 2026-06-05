using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.ExchangeCurrencyReport
{
	public class Items
	{
		[XmlElement("Item")]
		public List<Item> ItemList { get; set; } = null!;
	}
}
