namespace InfoDisease.Domain.Models
{
    public class AlertDiseaseParam
    {
        public string? Disease { get; set; }
        public string? GeoCode { get; set; }
        public required int Ew_start { get; set; }
        public required int Ew_end { get; set; }
        public required int Ey_start { get; set; }
        public required int Ey_end { get; set; }
    }
}
