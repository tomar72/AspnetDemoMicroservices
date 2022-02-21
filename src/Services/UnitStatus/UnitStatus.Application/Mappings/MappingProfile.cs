using AutoMapper;
using UnitStatus.Application.Features.UnitStatus.Commands.SetUnitStatus;
using UnitStatus.Application.Features.UnitStatus.Queries.GetUnitStatusesList;

namespace UnitStatus.Application.Mappings
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping profie to map UnitStatus and UnitStatusVm
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Domain.Entities.UnitStatus, UnitStatusesVm>().ReverseMap();
            CreateMap<Domain.Entities.UnitStatus, SetUnitStatusCommand>().ReverseMap();
        }
    }
}
