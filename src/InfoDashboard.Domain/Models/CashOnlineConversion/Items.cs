using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.CashOnlineConversion
{
	public class Items
	{
		[XmlElement("Item")]
		public List<Item> ItemList { get; set; } = null!;
	}
}
