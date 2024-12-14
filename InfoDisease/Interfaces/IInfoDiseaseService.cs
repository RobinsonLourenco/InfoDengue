namespace InfoDisease.Interfaces
{
    public interface IInfoDiseaseService
    {
        IEnumerable<Domain.Models.AlertDiseaseApi> GetALLDiseaseSPRJ(int ew_start, int ew_end, int ey_start, int ey_end);
    }
}
