using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.CashOnlineConversion
{
	public class Metadata
	{
		[XmlArray("Columns")]
		[XmlArrayItem("Column")]
		public List<Column> Columns { get; set; }
	}
}
