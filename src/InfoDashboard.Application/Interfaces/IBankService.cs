using InfoDashboard.Application.DTOModels;

namespace InfoDashboard.Application.Interfaces
{
	public interface IBankService
	{
		/// <summary>
		/// Get all banks.
		/// </summary>
		/// <returns>Bank list.</returns>
		Task<List<BankDTO>> GetAllBanksAsync();

		/// <summary>
		/// Get bank by id.
		/// </summary>
		/// <param name="bankid">Bank id.</param>
		/// <returns>Bank dto.</returns>
		Task<BankDTO?> GetBankByIdAsync(int bankid);

		/// <summary>
		/// Get bank by name.
		/// </summary>
		/// <param name="bankName">bank name</param>
		/// <returns>Bank dto.</returns>
		Task<BankDTO?> GetBankByNameAsync(string bankName);
	}
}
