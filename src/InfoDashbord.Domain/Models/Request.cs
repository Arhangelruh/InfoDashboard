namespace InfoDashbord.Domain.Models
{
	public class Request
	{
		/// <summary>
		/// Currency Id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Incoming date.
		/// </summary>
		public DateTime IncomingDate { get; set; }

		/// <summary>
		/// Request status.
		/// </summary>
		public bool IsCompleted { get; set; }

		/// <summary>
		/// Navigation to Currency.
		/// </summary>
		public ICollection<Currency> Currencies { get; set; } = null!;
	}
}
