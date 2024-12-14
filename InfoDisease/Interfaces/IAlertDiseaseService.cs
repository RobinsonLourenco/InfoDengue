using InfoDisease.Domain.Models;

namespace InfoDisease.Interfaces
{
    public interface IAlertDiseaseService
    {
        Task<GenericResponse<Domain.Models.AlertDiseaseApi>> GetDiseaseAsync(AlertDiseaseParam alertDiseaseParam);
    }
}
