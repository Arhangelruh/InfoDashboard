namespace InfoDashboard.Domain.Models.Departments
{
	public class Department
	{
		/// <summary>
		/// Department id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Department code.
		/// </summary>
		public required string Code { get; set; }

		/// <summary>
		/// Department name.
		/// </summary>
		public required string Name { get; set; }

		/// <summary>
		/// Cash list.
		/// </summary>
		public List<Cash> Cashes { get; set; }
	}
}
