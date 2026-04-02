using InfoDashbord.Application.DTOModels;
using InfoDashbord.Application.Interfaces;
using InfoDashbord.Infrastructure.Data.PgDB.Context;
using Microsoft.EntityFrameworkCore;

namespace InfoDashbord.Infrastructure.Services
{
	public class BankService(IDbContextFactory<GreatCurrencyContext> factory) : IBankService
	{
		private readonly IDbContextFactory<GreatCurrencyContext> _factory = factory ?? throw new ArgumentNullException(nameof(factory));

		public async Task<List<BankDTO>> GetAllBanksAsync()
		{
			var db = await _factory.CreateDbContextAsync();
			var allBanks = await db.Banks
				.AsNoTracking()
				.Select(c => new BankDTO
				{
					Id = c.Id,
					BankName = c.BankName
				})
				.ToListAsync();

			return allBanks;
		}

		public async Task<BankDTO?> GetBankByIdAsync(int bankid)
		{
			var db = await _factory.CreateDbContextAsync();
			var bank = await db.Banks
				.AsNoTracking()
				.Where(c => c.Id == bankid)
				.Select(c => new BankDTO
				{
					Id = c.Id,
					BankName = c.BankName
				})
				.FirstOrDefaultAsync();

			return bank;
		}

		public async Task<BankDTO?> GetBankByNameAsync(string bankName)
		{
			var db = await _factory.CreateDbContextAsync();
			var bank = await db.Banks
				.AsNoTracking()
				.Where(c => c.BankName == bankName)
				.Select(c => new BankDTO
				{
					Id = c.Id,
					BankName = c.BankName
				})
				.FirstOrDefaultAsync();

			return bank;
		}
	}
}
