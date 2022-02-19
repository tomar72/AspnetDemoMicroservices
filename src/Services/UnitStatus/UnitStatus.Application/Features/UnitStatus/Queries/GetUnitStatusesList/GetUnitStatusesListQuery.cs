using MediatR;
using System;
using System.Collections.Generic;

namespace UnitStatus.Application.Features.UnitStatus.Queries.GetUnitStatusesList
{
    public class GetUnitStatusesListQuery : IRequest<List<UnitStatusesVm>>
    {
        public string UnitId { get; set; }

        public GetUnitStatusesListQuery(string unitId)
        {
            UnitId = unitId ?? throw new ArgumentNullException(nameof(unitId));
        }
    }
}
