using AutoMapper;
using InfoDengue.Interfaces;
using InfoDisease.API;
using InfoDisease.Domain.Models;
using InfoDisease.Interfaces;

namespace InfoDisease.Services
{
    public class AlertDiseaseService :  IAlertDiseaseService
    {
        private readonly IAlertDiseaseApi _alertDiseaseAPI;
        private readonly IMapper _mapper;
        //public AlertDiseaseService(IAlertDiseaseAPI alertDiseaseAPI)
        //{
        //    _alertDiseaseAPI = alertDiseaseAPI;
        //}
        public async Task<GenericResponse<Domain.Models.AlertDiseaseApi>> GetDiseaseAsync(AlertDiseaseParam alertDiseaseParam)
        {
           var alertDisease = await _alertDiseaseAPI.GetDiseaseAsync(alertDiseaseParam);

           return _mapper.Map<GenericResponse<Domain.Models.AlertDiseaseApi>>(alertDisease);
        }
    }
}
