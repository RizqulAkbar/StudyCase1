using EnrollmentService.Dtos;
using System.Threading.Tasks;

namespace EnrollmentService.SyncDataService.Http
{
    public interface IPaymentDataClient
    {
        Task SendPlatformToCommand(EnrollmentReadDTO plat);
    }
}
