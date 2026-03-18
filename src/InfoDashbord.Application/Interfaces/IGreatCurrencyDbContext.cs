using InfoDashbord.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoDashbord.Application.Interfaces
{
	public interface IGreatCurrencyDbContext
	{
		/// <summary>
		/// Cities.
		/// </summary>
		DbSet<City> Cities {  get; }

		/// <summary>
		/// Banks.
		/// </summary>
		DbSet<Bank> Banks { get; }

		/// <summary>
		/// Departments.
		/// </summary>
		DbSet<BankDepartment> BankDepartments { get; }

		/// <summary>
		/// Requests.
		/// </summary>
		DbSet<Request> Requests { get; }

		/// <summary>
		/// Currencies.
		/// </summary>
		DbSet<Currency> Currencies { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
