using AutoMapper;
using InfoDengue.Interfaces;
using InfoDisease.API;
using InfoDisease.Domain.Models;
using InfoDisease.Interfaces;

namespace InfoDisease.Services
{
    public class AlertDiseaseService :  IAlertDiseaseService
    {
        private readonly IAlertDiseaseAPI _alertDiseaseAPI;
        private readonly IMapper _mapper;
        //public AlertDiseaseService(IAlertDiseaseAPI alertDiseaseAPI)
        //{
        //    _alertDiseaseAPI = alertDiseaseAPI;
        //}
        public async Task<GenericResponse<Domain.Models.AlertDiseaseAPI>> GetDiseaseAsync(string disease, string geocode, string ew_start, string ew_end, string ey_start, string ey_end)
        {
           var alertDisease = await _alertDiseaseAPI.GetDiseaseAsync(disease, geocode, ew_start, ew_end, ey_start, ey_end);

            return _mapper.Map<GenericResponse<Domain.Models.AlertDiseaseAPI>>(alertDisease);
        }
    }
}
