using InfoDengue.Interfaces;
using InfoDisease.Domain.Models;
using System.Dynamic;
using System.Text.Json;

namespace InfoDisease.API
{
    public class AlertDiseaseAPI : IAlertDiseaseAPI
    {
        public async Task<GenericResponse<Domain.Models.AlertDiseaseAPI>> GetDiseaseAsync(string disease, string geocode, string ew_start, string ew_end, string ey_start, string ey_end)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://info.dengue.mat.br/api/alertcity?disease={disease}&geocode={geocode}&format=json&ew_start={ew_start}&ew_end={ew_end}&ey_start={ey_start}&ey_end={ey_end}");

            var response = new GenericResponse<Domain.Models.AlertDiseaseAPI>();

            using (var client = new HttpClient())
            {
                var responseAlertDisease = await client.SendAsync(request);
                var contentResponse = await responseAlertDisease.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Domain.Models.AlertDiseaseAPI>(contentResponse);

                response.HttpCode = responseAlertDisease.StatusCode;

                if (responseAlertDisease.IsSuccessStatusCode)
                {
                    response.Data = objResponse;
                }
                else
                {
                    response.Error = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }

            return response;
        }
    }
}
