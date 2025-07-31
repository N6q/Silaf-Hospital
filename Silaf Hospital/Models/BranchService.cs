
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Silaf_Hospital.Services
{
    public class BranchService : IBranchService
    {
        private List<Branch> branches = new List<Branch>();
        private BranchFileHandler fileHandler = new BranchFileHandler();

        public BranchService()
        {
            LoadFromFile();
        }

        public void AddBranch(BranchInputDTO input)
        {
            var branch = new Branch
            {
                Name = input.Name,
                Address = input.Address,
                PhoneNumber = input.PhoneNumber,
                AdminId = input.AdminId
            };

            branches.Add(branch);
            SaveToFile();
        }

        public void UpdateBranch(BranchUpdateDTO input)
        {
            var branch = GetBranchById(input.Id);
            if (branch != null)
            {
                branch.PhoneNumber = input.PhoneNumber;
                branch.Address = input.Address;
                SaveToFile();
            }
        }

        public bool DeleteBranch(string id)
        {
            var branch = GetBranchById(id);
            if (branch != null)
            {
                branches.Remove(branch);
                SaveToFile();
                return true;
            }
            return false;
        }

        public List<Branch> GetAllBranches()
        {
            return branches;
        }

        public Branch GetBranchById(string id)
        {
            return branches.FirstOrDefault(b => b.Id == id);
        }

        public Branch GetBranchByName(string name)
        {
            return branches.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public BranchOutputDTO GetBranchData(string name, string id)
        {
            var branch = branches.FirstOrDefault(b =>
                b.Name.Equals(name, StringComparison.OrdinalIgnoreCase) || b.Id == id);

            if (branch == null) return null;

            return new BranchOutputDTO
            {
                Id = branch.Id,
                Name = branch.Name,
                PhoneNumber = branch.PhoneNumber,
                Address = branch.Address,
                AdminId = branch.AdminId
            };
        }

        public void SaveToFile()
        {
            fileHandler.SaveBranches(branches);
        }

        public void LoadFromFile()
        {
            branches = fileHandler.LoadBranches();
        }
    }
}
