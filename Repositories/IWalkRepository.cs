using DogGo.Models;
using DogGo.Models.ViewModels;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetWalksByWalkerId(int id);
        void AddWalk(Walk walk);
    }
}
