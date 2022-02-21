using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitStatus.Application.Contracts.Infrastructure;
using UnitStatus.Application.Contracts.Persistence;
using UnitStatus.Application.Models;

namespace UnitStatus.Application.Features.UnitStatus.Commands.SetUnitStatus
{
    public class SetUnitStatusCommandHandler : IRequestHandler<SetUnitStatusCommand, int>
    {
        private readonly IUnitStatusRepository _unitStatusRepository;

        private readonly IMapper _mapper;

        private readonly IEmailService _emailService;

        private readonly ILogger<SetUnitStatusCommandHandler> _logger;

        public SetUnitStatusCommandHandler(IUnitStatusRepository unitStatusRepository, IMapper mapper, IEmailService emailService, ILogger<SetUnitStatusCommandHandler> logger)
        {
            _unitStatusRepository = unitStatusRepository ?? throw new ArgumentNullException(nameof(unitStatusRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(SetUnitStatusCommand request, CancellationToken cancellationToken)
        {
            var unitStatusEntity = _mapper.Map<Domain.Entities.UnitStatus>(request);
            var newUnitStatus = await _unitStatusRepository.AddAsync(unitStatusEntity);

            _logger.LogInformation($"Unit Status {newUnitStatus.Id} is succesfully created.");

            await SendMailAsync(newUnitStatus);

            return newUnitStatus.Id;
        }

        private async Task SendMailAsync(Domain.Entities.UnitStatus newUnitStatus)
        {
            var email = new Email() { To = "tariqaliomar@hotmail.com", Body = $"Unit status {newUnitStatus.Id} was created.", Subject = "Unit status created." };
            try
            {
                await _emailService.SendEmailAsync(email);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Unit Status {newUnitStatus.Id} failed due to an error with mail service: {ex.Message}");
            }
        }
    }
}
