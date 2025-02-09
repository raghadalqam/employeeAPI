namespace employeeAPI.Application.Interfaces
{
    public interface IEmployeeProjectService
    {
        Task<bool> AssignEmployeeToProjectsAsync(Guid employeeId, List<Guid> projectIds);
        Task<bool> RemoveEmployeeFromProjectAsync(Guid employeeId, Guid projectId);
    }
}
