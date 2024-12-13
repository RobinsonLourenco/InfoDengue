using InfoDisease.Domain.Models;

namespace InfoDisease.Interfaces
{
    public interface IAlertDiseaseService
    {
        Task<GenericResponse<Domain.Models.AlertDiseaseAPI>> GetDiseaseAsync(string disease, string geocode, string ew_start, string ew_end, string ey_start, string ey_end);
    }
}
