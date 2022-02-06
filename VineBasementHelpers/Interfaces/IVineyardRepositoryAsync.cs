using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using VineBasementHelpers.Models.VineyardModels.GET;

namespace VineBasementHelpers.Interfaces
{
    [TransientService]
    public interface IVineyardRepositoryAsync: IGenericRepositoryAsync<Vineyard>
    {
        Task<IReadOnlyList<Vineyard>> FilterVineyards(SearchVineyards filter);
    }
}
