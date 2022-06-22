using System;
using System.Collections.Generic;
using DogGo.Models;
using DogGo.Repositories;

namespace DogGo.Repositories
{
    public interface INeighborhoodRepository
    {
        List<Neighborhood> GetAll();
    }
}
