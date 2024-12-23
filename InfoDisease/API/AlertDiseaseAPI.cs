﻿using InfoDisease.Domain.Models;
using InfoDiseases.Interfaces;
using System.Dynamic;
using System.Text.Json;

namespace InfoDisease.API
{
    public class AlertDiseaseApi : IAlertDiseaseApi
    {
        public async Task<GenericResponse<Domain.Models.AlertDiseaseApi>> GetDiseaseAsync(AlertDiseaseParam alertDiseaseParam)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, @$"https://info.dengue.mat.br/api/alertcity?disease={alertDiseaseParam.Disease}" +
                                                                 $"&geocode={alertDiseaseParam.GeoCode}&format=json&ew_start={alertDiseaseParam.Ew_start}" +
                                                                 $"&ew_end={alertDiseaseParam.Ew_end}&ey_start={alertDiseaseParam.Ey_start}&ey_end={alertDiseaseParam.Ey_end}");

            var response = new GenericResponse<Domain.Models.AlertDiseaseApi>();

            using (var client = new HttpClient())
            {
                var responseAlertDisease = await client.SendAsync(request).ConfigureAwait(false);
                var contentResponse = await responseAlertDisease.Content.ReadAsStringAsync();

                var myDeserializedList = JsonSerializer.Deserialize<List<Domain.Models.AlertDiseaseApi>>(contentResponse);

                response.HttpCode = responseAlertDisease.StatusCode;

                if (responseAlertDisease.IsSuccessStatusCode)
                {
                    response.Data = myDeserializedList;
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
