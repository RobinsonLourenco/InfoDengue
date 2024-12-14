namespace InfoDisease.Domain.Models
{
    public class AlertDiseaseParam
    {
        public string disease { get; set; }
        public string geoCode { get; set; }
        public required int ew_start { get; set; }
        public required int ew_end { get; set; }
        public required int ey_start { get; set; }
        public required int ey_end { get; set; }
    }
}
