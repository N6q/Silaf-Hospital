using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IRoomService
    {
        void AddRoom(RoomInputDTO input);
        void UpdateRoom(string roomId, RoomInputDTO input);
        void DeleteRoom(string roomId);

        Room GetRoomById(string roomId);
        IEnumerable<RoomOutputDTO> GetAllRooms();
        IEnumerable<RoomOutputDTO> GetAvailableRooms();
        IEnumerable<Room> GetRoomsByBranchId(string branchId);
        IEnumerable<Room> GetRoomsByDepartmentId(string departmentId);

        void SetRoomOccupancy(string roomId, bool occupied);

        void SaveToFile();
        void LoadFromFile();
    }
}
