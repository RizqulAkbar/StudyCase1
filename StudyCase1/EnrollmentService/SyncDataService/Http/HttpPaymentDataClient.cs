using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EnrollmentService.Dtos;
using Microsoft.Extensions.Configuration;

namespace EnrollmentService.SyncDataService.Http
{
    public class HttpCommandDataClient : IPaymentDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(EnrollmentReadDTO plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_configuration["PaymentService"],
                httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to CommandService was OK !");
            }
            else
            {
                Console.WriteLine("--> Sync POST to CommandService failed");
            }
        }
    }
}
