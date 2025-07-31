using System;

namespace Silaf_Hospital.Models
{
    public class Room
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int RoomNumber { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string RoomType { get; set; }
        public bool IsOccupied { get; set; } = false;

        public Room() { }

        public Room(int roomNumber, string branchId, string departmentId, string roomType)
        {
            Id = Guid.NewGuid().ToString();
            RoomNumber = roomNumber;
            BranchId = branchId;
            DepartmentId = departmentId;
            RoomType = roomType;
            IsOccupied = false;
        }

        public void AssignRoom()
        {
            if (!IsOccupied)
            {
                IsOccupied = true;
                Console.WriteLine($" Room {RoomNumber} has been assigned.");
            }
            else
            {
                Console.WriteLine($" Room {RoomNumber} is already occupied.");
            }
        }

        public void VacateRoom()
        {
            if (IsOccupied)
            {
                IsOccupied = false;
                Console.WriteLine($" Room {RoomNumber} has been vacated.");
            }
            else
            {
                Console.WriteLine($" Room {RoomNumber} is already available.");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($" Room #{RoomNumber} | Type: {RoomType}");
            Console.WriteLine($" Branch: {BranchId} | Department: {DepartmentId}");
            Console.WriteLine($" Status: {(IsOccupied ? "Occupied" : "Available")}");
        }
    }
}
