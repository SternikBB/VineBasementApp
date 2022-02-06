using Domain.Entities;
using System;
using VineBasementApp.Persistance.DataAccess;
using VineBasementApp.Persistance.Repositories.Generic;
using VineBasementHelpers.Interfaces;
using VineBasementHelpers.Models.VineModels.GET;

namespace VineBasementApp.Persistance.Repositories.UsingGeneric
{
    public class VineRepositoryAsync : GenericRepositoryAsync<Vine>, IVineRepositoryAsync
    {
        public VineRepositoryAsync(VineBasementContext dbContext) : base(dbContext)
        {


        }

        public Task<IReadOnlyList<Vine>> FilterVines(SearchVines filter)
        {
            throw new NotImplementedException();
        }
    }
}
