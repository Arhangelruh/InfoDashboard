using Microsoft.EntityFrameworkCore;

namespace InfoDashboard.Infrastructure.Data.ReportDB.Context
{
	public class ReportingDbContext(DbContextOptions<ReportingDbContext> options) : DbContext(options)
	{
	}
}
