using InfoDisease.Domain.Models;

namespace InfoDengue.Interfaces
{
    public interface IAlertDiseaseAPI
    {
        Task<GenericResponse<AlertDiseaseAPI>> GetDiseaseAsync(string disease, string geocode, string ew_start, string ew_end, string ey_start, string ey_end);
    }
}
