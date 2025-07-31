
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class BranchService
    {
        private List<Branch> branches = new List<Branch>();
        private readonly BranchFileHandler fileHandler = new BranchFileHandler();

        public BranchService()
        {
            LoadBranches();
        }

        public void AddBranch(BranchInputDTO input)
        {
            Branch newBranch = new Branch();
            newBranch.Id = Guid.NewGuid().ToString();
            newBranch.Name = input.Name;
            newBranch.Location = input.Location;

            branches.Add(newBranch);
            SaveBranches();
            Console.WriteLine("Branch added.");
        }

        public List<Branch> GetAllBranches()
        {
            return branches;
        }

        public Branch GetBranchById(string id)
        {
            for (int i = 0; i < branches.Count; i++)
            {
                if (branches[i].Id == id)
                {
                    return branches[i];
                }
            }
            return null;
        }

        public Branch GetBranchByName(string name)
        {
            for (int i = 0; i < branches.Count; i++)
            {
                if (branches[i].Name == name)
                {
                    return branches[i];
                }
            }
            return null;
        }

        public void UpdateBranch(BranchUpdateDTO input)
        {
            for (int i = 0; i < branches.Count; i++)
            {
                if (branches[i].Id == input.Id)
                {
                    branches[i].Name = input.Name;
                    branches[i].Location = input.Location;
                    SaveBranches();
                    Console.WriteLine("Branch updated.");
                    return;
                }
            }
            Console.WriteLine("Branch not found.");
        }

        public void DeleteBranch(string id)
        {
            Branch target = null;
            for (int i = 0; i < branches.Count; i++)
            {
                if (branches[i].Id == id)
                {
                    target = branches[i];
                    break;
                }
            }

            if (target != null)
            {
                branches.Remove(target);
                SaveBranches();
                Console.WriteLine("Branch deleted.");
            }
            else
            {
                Console.WriteLine("Branch not found.");
            }
        }

        public void SaveBranches()
        {
            fileHandler.SaveBranches(branches);
        }

        public void LoadBranches()
        {
            branches = fileHandler.LoadBranches();
            if (branches == null)
            {
                branches = new List<Branch>();
            }
        }
    }
}
