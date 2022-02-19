using System.Threading.Tasks;
using UnitStatus.Application.Models;

namespace UnitStatus.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
