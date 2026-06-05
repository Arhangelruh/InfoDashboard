using InfoDashboard.Application.DTOModels;
using InfoDashboard.Application.Interfaces;
using InfoDashboard.Domain.Models.ExchangeCurrencyReport;
using System.Xml.Serialization;

namespace InfoDashboard.Application.Services
{
	public class CashReport(IGetExchangeReportInfo getCashReport, IGetDepartments getDepartments, ICashConversionReport getConversion) : ICashReport
	{
		private readonly IGetExchangeReportInfo _getCashReport = getCashReport ?? throw new ArgumentNullException(nameof(getCashReport));
		private readonly IGetDepartments _getDepartments = getDepartments ?? throw new ArgumentNullException(nameof(getDepartments));
		private readonly ICashConversionReport _getConvertion = getConversion ?? throw new ArgumentNullException(nameof(getConversion));

		public async Task<List<DepartmentDTO>> CollectDepartmentInformation()
		{
			var departments = await _getDepartments.GetAll();

			List<WorkplaceGroup> baseReport = [];
			List<Domain.Models.CashOnlineConversion.Item> conversionReport = [];

			try
			{
				baseReport = await GetReport();
			}
			catch { }

			try
			{
				conversionReport = await _getConvertion.GetConversionReport();
			}
			catch { }

			List<DepartmentDTO> result = [];

			if (departments.Count == 0)
				return result;

			foreach (var department in departments)
			{

				DepartmentDTO departmentInfo = new()
				{
					DepartmentName = department.Name,
					DepartmentCurrency = []
				};

				Dictionary<string, int> cashesWithMargine = [];

				foreach (var workplace in department.Cashes)
				{
					var currentInformation = baseReport.FirstOrDefault(d => d.WorkplaceName == workplace.Name);

					if (currentInformation != null)
					{
						foreach (var currency in currentInformation.Items)
						{
							var checkCurrency = departmentInfo.DepartmentCurrency.FirstOrDefault(c => c.Currency == currency.Currency);

							if (checkCurrency == null)
							{
								if (currency.Margin != null)
								{
									cashesWithMargine.Add(currency.Currency, 1);
								}
								else
								{
									cashesWithMargine.Add(currency.Currency, 0);
								}

								departmentInfo.DepartmentCurrency.Add(new DepartmentCurrencyDTO
								{
									Currency = currency.Currency,
									CashBuy = currency.CashBuy ?? 0,
									CashSell = currency.CashSell ?? 0,
									Margin = currency.Margin ?? 0
								});
							}
							else
							{
								if (currency.Margin != null)
									cashesWithMargine[currency.Currency]++;

								checkCurrency.CashBuy = checkCurrency.CashBuy + currency.CashBuy ?? 0;
								checkCurrency.CashSell = checkCurrency.CashSell + currency.CashSell ?? 0;
								checkCurrency.Margin = checkCurrency.Margin + currency.Margin ?? 0;
							}
						}
					}

					var conversionInformation = conversionReport.Where(x => x.WorkplaceName == workplace.Name).ToList();

					if (conversionInformation.Any())
					{
						foreach (var currency in conversionInformation)
						{
							var checkCurrency = departmentInfo.DepartmentCurrency.FirstOrDefault(c => c.Currency == currency.CurrentName);

							if (checkCurrency == null)
							{
								departmentInfo.DepartmentCurrency.Add(new DepartmentCurrencyDTO
								{
									Currency = currency.CurrentName,
									CashBuy = currency.ConversionBuySumma ?? 0,
									CashSell = currency.ConversionSellSumma ?? 0,
								});
							}
							else
							{
								checkCurrency.CashBuy = checkCurrency.CashBuy + currency.ConversionBuySumma ?? 0;
								checkCurrency.CashSell = checkCurrency.CashSell + currency.ConversionSellSumma ?? 0;
							}
						}
					}
				}

				foreach (var currentdepartment in departmentInfo.DepartmentCurrency)
				{
					if (currentdepartment.Margin != null)
						currentdepartment.Margin = Math.Round(currentdepartment.Margin / (cashesWithMargine[currentdepartment.Currency] != 0 ? cashesWithMargine[currentdepartment.Currency] : 1) ?? 0, 6);
				}

				result.Add(departmentInfo);
			}

			return result;
		}

		public async Task<List<WorkplaceGroup>> GetReport()
		{
			var xml = await _getCashReport.GetReport();
			var result = new List<WorkplaceGroup>();

			if (xml != null)
			{

				var itemList = Parse(xml);

				WorkplaceGroup? current = null;

				foreach (var item in itemList)
				{
					if (!string.IsNullOrEmpty(item.WorkplaceName))
					{
						current = new WorkplaceGroup
						{
							WorkplaceName = item.WorkplaceName
						};

						result.Add(current);
					}

					current?.Items.Add(item);
				}
			}
			return result;
		}


		public List<Item> Parse(string xml)
		{
			var serializer = new XmlSerializer(typeof(Root));
			using var reader = new StringReader(xml);

			if (serializer.Deserialize(reader) is Root root)
				if (root.Upload != null)
					return root.Upload.Items.ItemList;

			return [];
		}
	}
}
