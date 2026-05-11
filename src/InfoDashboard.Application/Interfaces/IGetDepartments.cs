using InfoDashboard.Domain.Models.Departments;

namespace InfoDashboard.Application.Interfaces
{
	public interface IGetDepartments
	{
		Task<List<Department>> GetAll();
	}
}
