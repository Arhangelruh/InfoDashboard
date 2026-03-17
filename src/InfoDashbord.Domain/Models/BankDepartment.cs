namespace InfoDashbord.Domain.Models
{
	public class BankDepartment
	{
		/// <summary>
		/// Id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Department adress.
		/// </summary>
		public string DepartmentAddress { get; set; } = null!;

		/// <summary>
		/// Bank id.
		/// </summary>
		public int BankId { get; set; }

		/// <summary>
		/// Navigation to Bank.
		/// </summary>

		/// <summary>
		/// </summary>

		/// <summary>
		/// City id.
		/// </summary>
		public int CityId { get; set; }

		/// <summary>
		/// Navigation to City.
		/// </summary>
	}
}
