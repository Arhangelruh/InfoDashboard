using InfoDashbord.Application.DTOModels;
using InfoDashbord.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfoDashbord.Application.Services
{
	public class BankService(IGreatCurrencyDbContext db) : IBankService
	{
		private readonly IGreatCurrencyDbContext _db = db ?? throw new ArgumentNullException(nameof(db));

		public async Task<List<BankDTO>> GetAllBanksAsync()
		{
			var allBanks = await _db.Banks
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
			var bank = await _db.Banks
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
			var bank = await _db.Banks
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
