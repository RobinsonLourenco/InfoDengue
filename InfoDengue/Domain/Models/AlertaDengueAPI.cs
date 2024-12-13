using Newtonsoft.Json;

namespace InfoDengue.Domain.Models
{
    public class AlertaDengueAPI
    {
        [JsonProperty("data_iniSE")]
        public DateTime DataIniSE { get; set; }

        [JsonProperty("SE")]
        public int SE { get; set; }

        [JsonProperty("casos_est")]
        public double CasosEst { get; set; }

        [JsonProperty("casos_est_min")]
        public int CasosEstMin { get; set; }

        [JsonProperty("casos_est_max")]
        public int? CasosEstMax { get; set; }

        [JsonProperty("casos")]
        public int Casos { get; set; }

        [JsonProperty("p_rt1")]
        public double PRt1 { get; set; }

        [JsonProperty("p_inc100k")]
        public double PInc100k { get; set; }

        [JsonProperty("Localidade_id")]
        public int LocalidadeId { get; set; }

        [JsonProperty("nivel")]
        public int Nivel { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("versao_modelo")]
        public DateTime VersaoModelo { get; set; }

        [JsonProperty("tweet")]
        public long Tweet { get; set; }

        [JsonProperty("Rt")]
        public double Rt { get; set; }

        [JsonProperty("pop")]
        public long Pop { get; set; }

        [JsonProperty("tempmin")]
        public double Tempmin { get; set; }

        [JsonProperty("umidmax")]
        public double Umidmax { get; set; }

        [JsonProperty("receptivo")]
        public int Receptivo { get; set; }

        [JsonProperty("transmissao")]
        public int Transmissao { get; set; }

        [JsonProperty("nivel_inc")]
        public int NivelInc { get; set; }

        [JsonProperty("umidmed")]
        public double Umidmed { get; set; }

        [JsonProperty("umidmin")]
        public double Umidmin { get; set; }

        [JsonProperty("tempmed")]
        public double Tempmed { get; set; }

        [JsonProperty("tempmax")]
        public double Tempmax { get; set; }

        [JsonProperty("casprov")]
        public int Casprov { get; set; }

        [JsonProperty("casprov_est")]
        public double CasprovEst { get; set; }

        [JsonProperty("casprov_est_min")]
        public double CasprovEstMin { get; set; }

        [JsonProperty("casprov_est_max")]
        public double CasprovEstMax { get; set; }

        [JsonProperty("casconf")]
        public double Casconf { get; set; }

        [JsonProperty("notif_accum_year")]
        public int NotifAccumYear { get; set; }
        //public DateTime data_iniSE { get; set; }
        //public int SE { get; set; }
        //public double casos_est { get; set; }
        //public int casos_est_min { get; set; }
        //public object casos_est_max { get; set; }
        //public int casos { get; set; }
        //public double p_rt1 { get; set; }
        //public double p_inc100k { get; set; }
        //public int Localidade_id { get; set; }
        //public int nivel { get; set; }
        //public object id { get; set; }
        //public string versao_modelo { get; set; }
        //public object tweet { get; set; }
        //public double Rt { get; set; }
        //public double pop { get; set; }
        //public double tempmin { get; set; }
        //public double umidmax { get; set; }
        //public int receptivo { get; set; }
        //public int transmissao { get; set; }
        //public int nivel_inc { get; set; }
        //public double umidmed { get; set; }
        //public double umidmin { get; set; }
        //public double tempmed { get; set; }
        //public double tempmax { get; set; }
        //public int casprov { get; set; }
        //public object casprov_est { get; set; }
        //public object casprov_est_min { get; set; }
        //public object casprov_est_max { get; set; }
        //public object casconf { get; set; }
        //public int notif_accum_year { get; set; }
    }
}
