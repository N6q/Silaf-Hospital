using Silaf_Hospital.Models;

public class Branch
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string AdminId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsOpen { get; set; } = true;

    public ICollection<BranchDepartments> LinkedDepartments { get; set; } = new List<BranchDepartments>();

    public void ToggleStatus()
    {
        IsOpen = !IsOpen;
        Console.WriteLine($"Branch {Name} is now {(IsOpen ? "Open" : "Closed")}");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($" Branch: {Name} (ID: {Id})");
        Console.WriteLine($" Address: {Address} |  Phone: {PhoneNumber} | Admin ID: {AdminId}");
        Console.WriteLine($" Created At: {CreatedAt} | Status: {(IsOpen ? "Open" : "Closed")}");
    }
}
