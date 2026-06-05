using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.CashOnlineConversion
{
	[XmlRoot("Root")]
	public class Root
	{
		[XmlElement("Metadata")]
		public Metadata Metadata { get; set; }

		[XmlElement("Upload")]
		public Upload Upload { get; set; }
	}
}
