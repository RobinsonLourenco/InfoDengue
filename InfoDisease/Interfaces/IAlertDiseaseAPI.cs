using InfoDisease.Domain.Models;

namespace InfoDengue.Interfaces
{
    public interface IAlertDiseaseApi
    {
        Task<GenericResponse<AlertDiseaseApi>> GetDiseaseAsync(AlertDiseaseParam alertDiseaseParam);
    }
}
