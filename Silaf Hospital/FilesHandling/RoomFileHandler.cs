using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class RoomFileHandler
    {
        private readonly string filePath = "data/rooms.txt";

        public void SaveRooms(List<Room> rooms)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Room room in rooms)
                {
                    writer.WriteLine($"{room.Id},{room.RoomNumber},{room.BranchId},{room.DepartmentId},{room.RoomType},{room.IsOccupied}");
                }
            }

            Console.WriteLine(" Room data saved.");
        }

        public List<Room> LoadRooms()
        {
            List<Room> rooms = new List<Room>();

            if (!File.Exists(filePath))
                return rooms;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 6)
                {
                    Room room = new Room
                    {
                        Id = parts[0],
                        RoomNumber = int.TryParse(parts[1], out var num) ? num : 0,
                        BranchId = parts[2],
                        DepartmentId = parts[3],
                        RoomType = parts[4],
                        IsOccupied = bool.TryParse(parts[5], out var occ) && occ
                    };

                    rooms.Add(room);
                }
            }

            Console.WriteLine(" Room data loaded.");
            return rooms;
        }
    }
}
