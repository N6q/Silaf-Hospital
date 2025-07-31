using Silaf_Hospital.Models;

public class Departments
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string BranchId { get; set; }

    public string? Specialty { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    public ICollection<BranchDepartments> LinkedBranches { get; set; } = new List<BranchDepartments>();

    public void DisplayInfo()
    {
        Console.WriteLine($" Department: {Name} (ID: {Id})");
        Console.WriteLine($" Doctors Count: {Doctors.Count} | Created At: {CreatedAt}");
        if (!string.IsNullOrWhiteSpace(Specialty))
            Console.WriteLine($" Specialty: {Specialty}"); 
    }
}
