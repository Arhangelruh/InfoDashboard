using InfoDashboard.Application.DTOModels;
using InfoDashboard.Application.Interfaces;
using InfoDashboard.Domain.Models.ExchangeCurrencyReport;
using System.Xml.Serialization;

namespace InfoDashboard.Application.Services
{
	public class CashReport(IGetExchangeReportInfo getCashReport, IGetDepartments getDepartments) : ICashReport
	{
		private readonly IGetExchangeReportInfo _getCashReport = getCashReport ?? throw new ArgumentNullException(nameof(getCashReport));
		private readonly IGetDepartments _getDepartments = getDepartments ?? throw new ArgumentNullException(nameof(getDepartments));
		
		public async Task<List<DepartmentDTO>> CollectDepartmentInformation()
		{
			var departments = await _getDepartments.GetAll();
			var baseReport = await GetReport();
			List<DepartmentDTO> result = [];

			if (departments.Count == 0 || baseReport.Count == 0)
				return result;			

			foreach (var department in departments) {

				DepartmentDTO departmentInfo = new()
				{
					DepartmentName = department.Name,
					DepartmentCurrency = []
				};

				Dictionary<string,int> cashesWithMargine = [];				

				foreach (var workplace in department.Cashes)
				{					
					var currentInformation = baseReport.FirstOrDefault(d => d.WorkplaceName == workplace.Name);

					if (currentInformation != null)
					{						
						foreach (var currency in currentInformation.Items)
						{
							var checkCurrency = departmentInfo.DepartmentCurrency.FirstOrDefault(c => c.Currency == currency.Currency);
							
							if ( checkCurrency == null)
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
									cashesWithMargine[currency.Currency] ++;

								checkCurrency.CashBuy = checkCurrency.CashBuy + currency.CashBuy ?? 0;
								checkCurrency.CashSell = checkCurrency.CashSell + currency.CashSell ?? 0;
								checkCurrency.Margin = checkCurrency.Margin + currency.Margin ?? 0;
							}
						}						
					}					
				}

				Console.WriteLine(cashesWithMargine.Keys);
				foreach (var reducemargin in departmentInfo.DepartmentCurrency)
				{
					reducemargin.Margin = Math.Round(reducemargin.Margin / (cashesWithMargine[reducemargin.Currency] !=0? cashesWithMargine[reducemargin.Currency]:1 ), 6);
				}

				result.Add(departmentInfo);
			}

			return result;
		}
		
		public async Task<List<WorkplaceGroup>> GetReport()
		{
			var xml = await _getCashReport.GetReport();

			var itemList = Parse(xml);

			var result = new List<WorkplaceGroup>();
			
			WorkplaceGroup current = null;

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
			return result;
		}


		public List<Item> Parse(string xml)
		{
			var serializer = new XmlSerializer(typeof(Root));
			using var reader = new StringReader(xml);

			var root = serializer.Deserialize(reader) as Root;

			if (root != null)
			{
				return root.Upload.Items.ItemList;
			}
			else
			{
				return [];
			}
		}
	}
}
