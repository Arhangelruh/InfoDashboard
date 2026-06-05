using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.CashOnlineConversion
{
	public class Column
	{
		[XmlAttribute("FieldName")]
		public string FieldName { get; set; }

		[XmlElement("Caption")]
		public string Caption { get; set; }
	}
}
