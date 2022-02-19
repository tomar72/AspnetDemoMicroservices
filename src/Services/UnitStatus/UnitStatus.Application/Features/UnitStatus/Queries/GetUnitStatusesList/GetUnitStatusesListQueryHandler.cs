using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitStatus.Application.Contracts.Persistence;

namespace UnitStatus.Application.Features.UnitStatus.Queries.GetUnitStatusesList
{
    public class GetUnitStatusesListQueryHandler : IRequestHandler<GetUnitStatusesListQuery, List<UnitStatusesVm>>
    {
        private readonly IUnitStatusRepository _unitstatusRepository;

        private readonly IMapper _mapper;

        public GetUnitStatusesListQueryHandler(IUnitStatusRepository unitstatusRepository, IMapper mapper)
        {
            _unitstatusRepository = unitstatusRepository ?? throw new ArgumentNullException(nameof(unitstatusRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<UnitStatusesVm>> Handle(GetUnitStatusesListQuery request,
            CancellationToken cancellationToken)
        {
            var unitstatusesList = await _unitstatusRepository.GetUnitStatusesByUnitId(request.UnitId);
            return _mapper.Map<List<UnitStatusesVm>>(unitstatusesList);
        }
    }
}
