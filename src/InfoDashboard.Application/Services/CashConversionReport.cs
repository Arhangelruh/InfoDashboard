using InfoDashboard.Application.Interfaces;
using InfoDashboard.Domain.Models.CashOnlineConversion;
using System.Xml.Serialization;

namespace InfoDashboard.Application.Services
{
	public class CashConversionReport(IGetDepartments getDepartments, IGetConversionReport getReport) : ICashConversionReport
	{
		private readonly IGetConversionReport _getReport = getReport ?? throw new ArgumentNullException(nameof(getReport));

		public async Task<List<Item>> GetConversionReport()
		{
			var xml = await _getReport.GetReport();

			var itemList = Parse(xml);
			if (itemList != null)
			{

				return itemList;
			}
			else
			{
				return [];
			}
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
