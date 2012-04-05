using AutoMapper;
using Cabal.Core.Model;
using Cabal.Core.Shared.Model;

namespace Cabal.Core.Services
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<TerritoryState, TerritoryStateDto>()
                .ForMember(dest => dest.Armies, opt => opt.MapFrom(src => src.Armies.Values));

            Mapper.CreateMap<TerritoryStateArmy, TerritoryStateArmyDto>()
                .ForMember(dest => dest.ExtensionData, opt => opt.Ignore());

            Mapper.CreateMap<Game, GameDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => new GameStatusGenerator(src).ToString()));

            Mapper.AssertConfigurationIsValid();
        }
    }
}
