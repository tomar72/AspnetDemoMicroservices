using AutoMapper;
using UnitStatus.Application.Features.UnitStatus.Queries.GetUnitStatusesList;

namespace UnitStatus.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.UnitStatus, UnitStatusesVm>().ReverseMap();
        }
    }
}
