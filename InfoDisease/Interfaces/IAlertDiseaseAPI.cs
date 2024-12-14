using InfoDisease.Domain.Models;

namespace InfoDiseases.Interfaces
{
    public interface IAlertDiseaseApi
    {
        Task<GenericResponse<AlertDiseaseApi>> GetDiseaseAsync(AlertDiseaseParam alertDiseaseParam);
    }
}
