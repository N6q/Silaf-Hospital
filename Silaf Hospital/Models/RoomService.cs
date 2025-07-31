using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class RoomService : IRoomService
    {
        private List<Room> rooms = new List<Room>();
        private readonly RoomFileHandler fileHandler = new RoomFileHandler();

        public RoomService()
        {
            LoadFromFile();
        }

        public void AddRoom(RoomInputDTO input)
        {
            var room = new Room
            {
                Id = Guid.NewGuid().ToString(),
                RoomNumber = input.RoomNumber,
                BranchId = input.BranchId,
                DepartmentId = input.DepartmentId,
                RoomType = input.RoomType,
                IsOccupied = false
            };

            rooms.Add(room);
            SaveToFile();
            Console.WriteLine(" Room added.");
        }

        public void UpdateRoom(string roomId, RoomInputDTO input)
        {
            var room = GetRoomById(roomId);
            if (room != null)
            {
                room.RoomNumber = input.RoomNumber;
                room.BranchId = input.BranchId;
                room.DepartmentId = input.DepartmentId;
                room.RoomType = input.RoomType;
                SaveToFile();
                Console.WriteLine(" Room updated.");
            }
        }

        public void DeleteRoom(string roomId)
        {
            var r = GetRoomById(roomId);
            if (r != null)
            {
                rooms.Remove(r);
                SaveToFile();
                Console.WriteLine(" Room deleted.");
            }
        }

        public Room GetRoomById(string roomId)
        {
            return rooms.Find(r => r.Id == roomId);
        }

        public IEnumerable<RoomOutputDTO> GetAllRooms()
        {
            var result = new List<RoomOutputDTO>();

            foreach (var r in rooms)
            {
                result.Add(ToOutputDTO(r));
            }

            return result;
        }

        public IEnumerable<RoomOutputDTO> GetAvailableRooms()
        {
            var result = new List<RoomOutputDTO>();

            foreach (var r in rooms)
            {
                if (!r.IsOccupied)
                {
                    result.Add(ToOutputDTO(r));
                }
            }

            return result;
        }

        public IEnumerable<Room> GetRoomsByBranchId(string branchId)
        {
            return rooms.FindAll(r => r.BranchId == branchId);
        }

        public IEnumerable<Room> GetRoomsByDepartmentId(string departmentId)
        {
            return rooms.FindAll(r => r.DepartmentId == departmentId);
        }

        public void SetRoomOccupancy(string roomId, bool occupied)
        {
            var room = GetRoomById(roomId);
            if (room != null)
            {
                room.IsOccupied = occupied;
                SaveToFile();
            }
        }

        public void SaveToFile()
        {
            fileHandler.SaveRooms(rooms);
        }

        public void LoadFromFile()
        {
            rooms = fileHandler.LoadRooms();
        }

        private RoomOutputDTO ToOutputDTO(Room r)
        {
            return new RoomOutputDTO
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                BranchId = r.BranchId,
                DepartmentId = r.DepartmentId,
                RoomType = r.RoomType,
                IsOccupied = r.IsOccupied
            };
        }
    }
}
