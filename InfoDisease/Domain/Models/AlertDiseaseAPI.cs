using System.Text.Json.Serialization;

namespace InfoDisease.Domain.Models
{
    public class AlertDiseaseApi
    {
        [JsonPropertyName("data_iniSE")]
        public object? DataIniSE { get; set; }

        [JsonPropertyName("SE")]
        public int SE { get; set; }

        [JsonPropertyName("casos_est")]
        public double CasosEst { get; set; }

        [JsonPropertyName("casos_est_min")]
        public int CasosEstMin { get; set; }

        [JsonPropertyName("casos_est_max")]
        public double? CasosEstMax { get; set; }

        [JsonPropertyName("casos")]
        public int Casos { get; set; }

        [JsonPropertyName("p_rt1")]
        public double PRt1 { get; set; }

        [JsonPropertyName("p_inc100k")]
        public double PInc100k { get; set; }

        [JsonPropertyName("Localidade_id")]
        public int LocalidadeId { get; set; }

        [JsonPropertyName("nivel")]
        public int Nivel { get; set; }

        [JsonPropertyName("id")]
        public object? Id { get; set; }

        [JsonPropertyName("versao_modelo")]
        public string? VersaoModelo { get; set; }

        [JsonPropertyName("tweet")]
        public object? Tweet { get; set; }

        [JsonPropertyName("Rt")]
        public double? Rt { get; set; }

        [JsonPropertyName("pop")]
        public double? Pop { get; set; }

        [JsonPropertyName("tempmin")]
        public double Tempmin { get; set; }

        [JsonPropertyName("umidmax")]
        public double Umidmax { get; set; }

        [JsonPropertyName("receptivo")]
        public int Receptivo { get; set; }

        [JsonPropertyName("transmissao")]
        public int Transmissao { get; set; }

        [JsonPropertyName("nivel_inc")]
        public int NivelInc { get; set; }

        [JsonPropertyName("umidmed")]
        public double? Umidmed { get; set; }

        [JsonPropertyName("umidmin")]
        public double? Umidmin { get; set; }

        [JsonPropertyName("tempmed")]
        public double? Tempmed { get; set; }

        [JsonPropertyName("tempmax")]
        public double? Tempmax { get; set; }

        [JsonPropertyName("casprov")]
        public double? Casprov { get; set; }

        [JsonPropertyName("casprov_est")]
        public object? CasprovEst { get; set; }

        [JsonPropertyName("casprov_est_min")]
        public object? CasprovEstMin { get; set; }

        [JsonPropertyName("casprov_est_max")]
        public object? CasprovEstMax { get; set; }

        [JsonPropertyName("casconf")]
        public object? Casconf { get; set; }

        [JsonPropertyName("notif_accum_year")]
        public int? NotifAccumYear { get; set; }
    }
}
