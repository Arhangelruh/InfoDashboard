using System.Globalization;
using System.Xml.Serialization;

namespace InfoDashboard.Domain.Models.ExchangeCurrencyReport
{
	public class Item
	{
		[XmlAttribute] public string WorkplaceName { get; set; }
		[XmlAttribute] public string Currency { get; set; }

		[XmlAttribute("Advance")] public string AdvanceRaw { get; set; }
		[XmlIgnore] public decimal? Advance => ParseDecimal(AdvanceRaw);

		[XmlAttribute("CashBuy")] public string CashBuyRaw { get; set; }
		[XmlIgnore] public decimal? CashBuy => ParseDecimal(CashBuyRaw);

		[XmlAttribute("CashSell")] public string CashSellRaw { get; set; }
		[XmlIgnore] public decimal? CashSell => ParseDecimal(CashSellRaw);

		[XmlAttribute("CashlessBuy")] public string CashlessBuyRaw { get; set; }
		[XmlIgnore] public decimal? CashlessBuy => ParseDecimal(CashlessBuyRaw);

		[XmlAttribute("CashlessBuyRate")] public string CashlessBuyRateRaw { get; set; }
		[XmlIgnore] public decimal? CashlessBuyRate => ParseDecimal(CashlessBuyRateRaw);

		[XmlAttribute("ExchangeBuy")] public string ExchangeBuyRaw { get; set; }
		[XmlIgnore] public decimal? ExchangeBuy => ParseDecimal(ExchangeBuyRaw);

		[XmlAttribute("ExchangeSell")] public string ExchangeSellRaw { get; set; }
		[XmlIgnore] public decimal? ExchangeSell => ParseDecimal(ExchangeSellRaw);

		[XmlAttribute("Income")] public string IncomeRaw { get; set; }
		[XmlIgnore] public decimal? Income => ParseDecimal(IncomeRaw);

		[XmlAttribute("Outcome")] public string OutcomeRaw { get; set; }
		[XmlIgnore] public decimal? Outcome => ParseDecimal(OutcomeRaw);

		[XmlAttribute("Balance")] public string BalanceRaw { get; set; }
		[XmlIgnore] public decimal? Balance => ParseDecimal(BalanceRaw);

		[XmlAttribute("ChangeCur")] public string ChangeCurRaw { get; set; }
		[XmlIgnore] public decimal? ChangeCur => ParseDecimal(ChangeCurRaw);

		[XmlAttribute("CashBuyRate")] public string CashBuyRateRaw { get; set; }
		[XmlIgnore] public decimal? CashBuyRate => ParseDecimal(CashBuyRateRaw);

		[XmlAttribute("CashSellRate")] public string CashSellRateRaw { get; set; }
		[XmlIgnore] public decimal? CashSellRate => ParseDecimal(CashSellRateRaw);

		[XmlAttribute("Margin")] public string MarginRaw { get; set; }
		[XmlIgnore] public decimal? Margin => ParseDecimal(MarginRaw);

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
