namespace InfoDashbord.Domain.Models
{
	public class BankDepartment
	{
		/// <summary>
		/// Id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Department name
		/// </summary>
		public string DepartmentName { get; set; } = null!;

		/// <summary>
		/// Department adress.
		/// </summary>
		public string DepartmentAddress { get; set; } = null!;
		
		/// <summary>
		/// Department Id for myfin.
		/// </summary>
		public int? ExternalDepartmentId { get; set; }

		/// <summary>
		/// Bank id.
		/// </summary>
		public int BankId { get; set; }

		/// <summary>
		/// Navigation to Bank.
		/// </summary>
		public Bank Bank { get; set; } = null!;

		/// <summary>
		/// Navigation to Currency.
		/// </summary>
		public ICollection<Currency> Currencies { get; set; } = null!;

		/// <summary>
		/// City id.
		/// </summary>
		public int CityId { get; set; }

		/// <summary>
		/// Navigation to City.
		/// </summary>
		public City City { get; set; } = null!;
	}
}
