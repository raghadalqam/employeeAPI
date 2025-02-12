using employeeAPI.Domain;
using System.ComponentModel.DataAnnotations;

public class Department
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid(); 
    [Required]
    public string Name { get; set; }

    // relationship 
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
