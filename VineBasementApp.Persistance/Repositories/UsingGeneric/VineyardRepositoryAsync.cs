using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VineBasementApp.Persistance.DataAccess;
using VineBasementApp.Persistance.Repositories.Generic;
using VineBasementHelpers.Interfaces;
using VineBasementHelpers.Models.VineyardModels.GET;

namespace VineBasementApp.Persistance.Repositories.UsingGeneric
{
    
    public class VineyardRepositoryAsync : GenericRepositoryAsync<Vineyard>, IVineyardRepositoryAsync
    {
        public VineyardRepositoryAsync(VineBasementContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Vineyard>> FilterVineyards(SearchVineyards filter) => await GetByCondition(c => (string.IsNullOrEmpty(filter.VineyardName) || c.VineyardName.StartsWith(filter.VineyardName.Trim()))
                                                                     && (string.IsNullOrEmpty(filter.VineyardRegion) || c.VineyardRegion.StartsWith(filter.VineyardRegion.Trim()))
                                                                     && (string.IsNullOrEmpty(filter.VineyardCity) || c.VineyardCity.StartsWith(filter.VineyardCity.Trim()))
                                                                     && (string.IsNullOrEmpty(filter.VineyardYearOfFoundation) || c.VineyardYearOfFoundation.StartsWith(filter.VineyardYearOfFoundation.Trim()))
                                                                     && (string.IsNullOrEmpty(filter.VineyardCountry) || c.VineyardCountry.StartsWith(filter.VineyardCountry.Trim())), null, null).ToListAsync().ConfigureAwait(false);
    }
}
