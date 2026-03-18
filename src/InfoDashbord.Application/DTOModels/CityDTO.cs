namespace InfoDashbord.Application.DTOModels
{
	public class CityDTO
	{
		/// <summary>
		/// City id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// City name.
		/// </summary>
		public required string CityName { get; set; }
	}
}
