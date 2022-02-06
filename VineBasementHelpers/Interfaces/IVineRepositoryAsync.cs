using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using VineBasementHelpers.Models.VineModels.GET;

namespace VineBasementHelpers.Interfaces
{
    [TransientService]
    public interface IVineRepositoryAsync:IGenericRepositoryAsync<Vine>
    {
        Task<IReadOnlyList<Vine>> FilterVines(SearchVines filter);
    }
}
