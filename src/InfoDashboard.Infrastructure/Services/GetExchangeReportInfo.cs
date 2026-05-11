using InfoDashboard.Application.Interfaces;
using InfoDashboard.Infrastructure.Data.ReportDB.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace InfoDashboard.Infrastructure.Services
{
	public class GetExchangeReportInfo(IDbContextFactory<ReportingDbContext> factory) : IGetExchangeReportInfo
	{
		private readonly IDbContextFactory<ReportingDbContext> _factory = factory ?? throw new ArgumentNullException(nameof(factory));

		public async Task<string?> GetReport()
		{
			var db = await _factory.CreateDbContextAsync();

			var conn = db.Database.GetDbConnection();
			await conn.OpenAsync();

			using var cmd = conn.CreateCommand();
			cmd.CommandText = "dbo.rep_CashOnlineTurnover";
			cmd.CommandType = CommandType.StoredProcedure;

			var date = DateTime.Now;
			var formatDate = date.ToString("yyyy-MM-dd");

			cmd.Parameters.Add(new SqlParameter("@dateFrom", DateTime.Parse(formatDate)));
			cmd.Parameters.Add(new SqlParameter("@dateTo", DateTime.Parse(formatDate)));

			using var reader = await cmd.ExecuteReaderAsync();

			var sb = new StringBuilder();

			while (await reader.ReadAsync())
			{
				sb.Append(reader.GetString(0));
			}

			return sb.Length > 0 ? sb.ToString() : null;
		}
	}
}
