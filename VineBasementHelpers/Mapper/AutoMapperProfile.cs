using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VineBasementHelpers.Models.VineModels.GET;
using VineBasementHelpers.Models.VineModels.POST;
using VineBasementHelpers.Models.VineModels.PUT;
using VineBasementHelpers.Models.VineyardModels.GET;
using VineBasementHelpers.Models.VineyardModels.POST;
using VineBasementHelpers.Models.VineyardModels.PUT;

namespace VineBasementHelpers.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vine, GetAllVines>()
               .ForMember(c => c.VineyardName, o => o.MapFrom(src => src.Vineyard.VineyardName));

            CreateMap<Vineyard, GetAllVineyards>();

            CreateMap<AddNewVineyard, Vineyard>();

            CreateMap<AddNewVine, Vine>();

            CreateMap<Vine, EditVine>()
              .ForMember(c => c.VineyardID, o => o.MapFrom(src => src.Vineyard.VineyardId));

            CreateMap<Vineyard, EditVineyard>();


            CreateMap<EditVineyardForApi, Vineyard>().BeforeMap((_, cDto, context) => cDto.VineyardId= (int)context.Items["VineyardId"]);
            CreateMap<EditVineApi, Vine>().BeforeMap((_, cDto, context) => cDto.VineId = (int)context.Items["VineId"]);

            CreateMap<EditVineyard, Vineyard>();

            CreateMap<EditVine, Vine>();
        }
    }
}
