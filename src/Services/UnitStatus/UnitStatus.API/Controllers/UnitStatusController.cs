using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using UnitStatus.Application.Features.UnitStatus.Commands.SetUnitStatus;
using UnitStatus.Application.Features.UnitStatus.Queries.GetUnitStatusesList;

namespace UnitStatus.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UnitStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<UnitStatusController> _logger;

        public UnitStatusController(IMediator mediator, ILogger<UnitStatusController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _logger.LogInformation("Unit status controller constructed.");
        }

        [HttpGet("{unitId}", Name ="GetStatuses")]
        [ProducesResponseType(typeof(IEnumerable<UnitStatusesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UnitStatusesVm>>> GetUnitStatusesByUnitIdAsync(string unitId)
        {
            _logger.LogInformation($"Get Unit {unitId} statuses query called.");

            var query = new GetUnitStatusesListQuery(unitId);
            var unitstatuses = await _mediator.Send(query);

            _logger.LogInformation($"Get Unit {unitId} statuses query completed.");

            return Ok(unitstatuses);
        }

        [HttpPost(Name = "SetUnitStatus")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> SetUnitStatus([FromBody] SetUnitStatusCommand command)
        {
            _logger.LogInformation($"Set Unit status {@command} command called.");

            var result = await _mediator.Send(command);

            _logger.LogInformation($"Set Unit status {@command} command completed.");
            return Ok(result);
        }
    }
}
