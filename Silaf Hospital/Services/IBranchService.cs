
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IBranchService
    {
        void AddBranch(BranchInputDTO input);
        void UpdateBranch(BranchUpdateDTO input);
        bool DeleteBranch(string id);
        List<Branch> GetAllBranches();
        Branch GetBranchById(string id);
        Branch GetBranchByName(string name);
        BranchOutputDTO GetBranchData(string name, string id);
        void SaveToFile();
        void LoadFromFile();
    }
}
