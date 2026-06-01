using System.Globalization;
using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.CashOnlineConversion
{
	public class Item
	{
		[XmlAttribute("WorkplaceID")]
		public int WorkplaceID { get; set; }

		[XmlAttribute("WorkplaceName")]
		public string WorkplaceName { get; set; }

		[XmlAttribute("CurrentName")]
		public string CurrentName { get; set; }

		[XmlAttribute("ConversionBuySumma")] public string ConversionBuySummaRaw { get; set; }
		[XmlIgnore] public decimal? ConversionBuySumma => ParseDecimal(ConversionBuySummaRaw);

		[XmlAttribute("ConversionBuyRate")] public string ConversionBuyRateRaw { get; set; }
		[XmlIgnore] public decimal? ConversionBuyRate => ParseDecimal(ConversionBuyRateRaw);

		[XmlAttribute("ConversionSellSumma")] public string ConversionSellSummaRaw { get; set; }
		[XmlIgnore] public decimal? ConversionSellSumma => ParseDecimal(ConversionSellSummaRaw);

		[XmlAttribute("ConversionSellRate")] public string ConversionSellRateRaw { get; set; }
		[XmlIgnore] public decimal? ConversionSellRate => ParseDecimal(ConversionSellRateRaw);

		[XmlAttribute("TransferCNYBuySumma")] public string TransferCNYBuySummaRaw { get; set; }
		[XmlIgnore] public decimal? TransferCNYBuySumma => ParseDecimal(TransferCNYBuySummaRaw);

		[XmlAttribute("TransferCNYBuyRate")] public string TransferCNYBuyRateRaw { get; set; }
		[XmlIgnore] public decimal? TransferCNYBuyRate => ParseDecimal(TransferCNYBuyRateRaw);

		[XmlAttribute("TransferCNYSellSumma")] public string TransferCNYSellSummaRaw { get; set; }
		[XmlIgnore] public decimal? TransferCNYSellSumma => ParseDecimal(TransferCNYSellSummaRaw);

		[XmlAttribute("TransferCNYSellRate")] public string TransferCNYSellRateRaw { get; set; }
		[XmlIgnore] public decimal? TransferCNYSellRate => ParseDecimal(TransferCNYSellRateRaw);

		private static decimal? ParseDecimal(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				return null;

			return decimal.TryParse(
				value,
				NumberStyles.Any,
				CultureInfo.InvariantCulture,
				out var result)
				? result
				: null;
		}
	}
}
