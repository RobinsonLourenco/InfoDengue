using InfoDisease.Domain.Enums;
using InfoDisease.Domain.Models;
using InfoDisease.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InfoDisease.Controllers
{

    public class InfoDiseaseController(IReportRepository reportRepository, IRequestorRepository requestorRepository, IMunicipioRepository municipioRepository) : BaseApiController
    {
        private readonly IReportRepository _reportRepository = reportRepository;

        private readonly IRequestorRepository _requestorRepository = requestorRepository;

        private readonly IMunicipioRepository _municipioRepository = municipioRepository;
        /// <summary>
        /// Lista todas as Arboviroses dos municípios do RJ e SP.
        /// </summary>
        /// <param name="requestorName">Nome do solicitante</param>
        /// <param name="requestorCpf">Nome do solicitante</param>
        /// <param name="ew_start">semana epidemiológica de início da consulta (int:1-53).</param>
        /// <param name="ew_start">semana epidemiológica de início da consulta (int:1-53).</param>
        /// <param name="ew_end">semana epidemiológica de término da consulta (int:1-53).</param>
        /// <param name="ey_start">ano de início da consulta (int:0-9999)</param>
        /// <param name="ey_end">ano de término da consulta (int:0-9999)</param>
        /// <returns>
        /// data_ini_SE : Primeiro dia da semana epidemiológica (Domingo)
        /// SE: Semana epidemiológica
        /// casos_est : Número estimado de casos por semana usando o modelo de nowcasting(nota: Os valores são atualizados retrospectivamente a cada semana)
        /// cases_est_min and cases_est_max: Intervalo de credibilidade de 95% do número estimado de casos
        /// casos: Número de casos notificados por semana(Os valores são atualizados retrospectivamente todas as semanas)
        /// p_rt1: Probabilidade de(Rt> 1). Para emitir o alerta laranja, usamos o critério p_rt1> 0,95 por 3 semanas ou mais.
        /// p_inc100k: Taxa de incidência estimada por 100.000
        /// Localidade_id: Divisão submunicipal(atualmente implementada apenas no Rio de Janeiro)
        /// nivel: Nível de alerta(1 = verde, 2 = amarelo, 3 = laranja, 4 = vermelho), mais detalhes, consulte (Saiba mais)
        /// id: Índice numérico
        /// versao_modelo: Versão do modelo(uso interno)
        /// Rt: Estimativa pontual do número reprodutivo de casos, ver Saiba Mais
        /// pop: População estimada(IBGE)
        /// tempmin: Média das temperaturas mínimas diárias ao longo da semana
        /// tempmed: Média das temperaturas diárias ao longo da semana
        /// tempmax: Média das temperaturas máximas diárias ao longo da semana
        /// umidmin: Média da umidade relativa mínima diária do ar ao longo da semana
        /// umidmed: Média da umidade relativa diária do ar ao longo da semana
        /// umidmax: Média da umidade relativa máxima diária do ar ao longo da semana
        /// receptivo: Indica receptividade climática, ou seja, condições para alta capacidade vetorial. 0 = desfavorável, 1 = favorável, 2 = favorável nesta semana e na semana passada, 3 = favorável por pelo menos três semanas (suficiente para completar um ciclo de transmissão)
        /// transmissao: Evidência de transmissão sustentada: 0 = nenhuma evidência, 1 = possível, 2 = provável, 3 = altamente provável
        /// nivel_inc: Incidência estimada abaixo do limiar pré-epidemia, 1 = acima do limiar pré-epidemia, mas abaixo do limiar epidêmico, 2 = acima do limiar epidêmico
        /// notif_accum_year: Número acumulado de casos no ano
        /// </returns>
        [HttpGet, Route("GetALLDiseaseSPRJ")]
        //public IEnumerable<Domain.Models.AlertDiseaseAPI> GetALLDiseaseSPRJ(string requestorName, string requestorCpf, int ew_start, int ew_end, int ey_start, int ey_end)
        public IEnumerable<Domain.Models.AlertDiseaseApi> GetALLDiseaseSPRJ(string requestorName, string requestorCpf, int ew_start, int ew_end, int ey_start, int ey_end)
        {
            var solicitanteDb = SaveChangesRequestor(requestorName, requestorCpf).GetAwaiter().GetResult();
            var diseaseList = new List<Domain.Models.AlertDiseaseApi>();
            var alert = new API.AlertDiseaseApi();

            foreach (Disease diseaseEnum in Enum.GetValues(typeof(Disease)))
            {
                var disease = Enum.GetName(typeof(Disease), diseaseEnum) ?? string.Empty;
                var alertDiseaseParam = new AlertDiseaseParam
                {
                    Disease = disease,
                    GeoCode = "3304557",
                    Ew_start = ew_start,
                    Ew_end = ew_end,
                    Ey_start = ey_start,
                    Ey_end = ey_end
                };
                var message = alert.GetDiseaseAsync(alertDiseaseParam);
                var response = message.Result;

                if (response.Data != null)
                    diseaseList.AddRange(response.Data);

                var reportRJ = new Report()
                {
                    DataSolicitacao = DateTime.Now,
                    Arbovirose = disease,
                    SemanaInicio = alertDiseaseParam.Ew_start,
                    SemanaTermino = alertDiseaseParam.Ew_end,
                    CodigoIBGE = alertDiseaseParam.GeoCode,
                    Municipio = GetMunicipio(alertDiseaseParam.GeoCode).GetAwaiter().GetResult(),
                    SolicitanteId = solicitanteDb.SolicitanteId
                };


                SaveChangesReport(reportRJ).GetAwaiter().GetResult();

                alertDiseaseParam.GeoCode = "3550308";
                message = alert.GetDiseaseAsync(alertDiseaseParam);
                response = message.Result;

                if (response.Data != null)
                    diseaseList.AddRange(response.Data);

                var reportSP = new Report()
                {
                    DataSolicitacao = DateTime.Now,
                    Arbovirose = disease,
                    SemanaInicio = alertDiseaseParam.Ew_start,
                    SemanaTermino = alertDiseaseParam.Ew_end,
                    CodigoIBGE = alertDiseaseParam.GeoCode,
                    Municipio = GetMunicipio(alertDiseaseParam.GeoCode).GetAwaiter().GetResult(),
                    SolicitanteId = solicitanteDb.SolicitanteId
                };

                SaveChangesReport(reportSP).GetAwaiter().GetResult();
            }

            return (IEnumerable<Domain.Models.AlertDiseaseApi>)diseaseList;
        }

        /// <summary>
        /// Lista os dados epidemiológicos pelo código IBGE do município.
        /// </summary>
        /// <param name="requestorName">Nome do solicitante</param>
        /// <param name="requestorCpf">Nome do solicitante</param>
        /// <param name="disease">tipo de arbovirose a ser consultado (str:dengue|chikungunya|zika)</param>
        /// <param name="geoCode">código IBGE do município.</param>
        /// <param name="ew_start">semana epidemiológica de início da consulta (int:1-53).</param>
        /// <param name="ew_end">semana epidemiológica de término da consulta (int:1-53).</param>
        /// <param name="ey_start">ano de início da consulta (int:0-9999)</param>
        /// <param name="ey_end">ano de término da consulta (int:0-9999)</param>
        /// <returns>
        /// data_ini_SE : Primeiro dia da semana epidemiológica (Domingo)
        /// SE: Semana epidemiológica
        /// casos_est : Número estimado de casos por semana usando o modelo de nowcasting(nota: Os valores são atualizados retrospectivamente a cada semana)
        /// cases_est_min and cases_est_max: Intervalo de credibilidade de 95% do número estimado de casos
        /// casos: Número de casos notificados por semana(Os valores são atualizados retrospectivamente todas as semanas)
        /// p_rt1: Probabilidade de(Rt> 1). Para emitir o alerta laranja, usamos o critério p_rt1> 0,95 por 3 semanas ou mais.
        /// p_inc100k: Taxa de incidência estimada por 100.000
        /// Localidade_id: Divisão submunicipal(atualmente implementada apenas no Rio de Janeiro)
        /// nivel: Nível de alerta(1 = verde, 2 = amarelo, 3 = laranja, 4 = vermelho), mais detalhes, consulte (Saiba mais)
        /// id: Índice numérico
        /// versao_modelo: Versão do modelo(uso interno)
        /// Rt: Estimativa pontual do número reprodutivo de casos, ver Saiba Mais
        /// pop: População estimada(IBGE)
        /// tempmin: Média das temperaturas mínimas diárias ao longo da semana
        /// tempmed: Média das temperaturas diárias ao longo da semana
        /// tempmax: Média das temperaturas máximas diárias ao longo da semana
        /// umidmin: Média da umidade relativa mínima diária do ar ao longo da semana
        /// umidmed: Média da umidade relativa diária do ar ao longo da semana
        /// umidmax: Média da umidade relativa máxima diária do ar ao longo da semana
        /// receptivo: Indica receptividade climática, ou seja, condições para alta capacidade vetorial. 0 = desfavorável, 1 = favorável, 2 = favorável nesta semana e na semana passada, 3 = favorável por pelo menos três semanas (suficiente para completar um ciclo de transmissão)
        /// transmissao: Evidência de transmissão sustentada: 0 = nenhuma evidência, 1 = possível, 2 = provável, 3 = altamente provável
        /// nivel_inc: Incidência estimada abaixo do limiar pré-epidemia, 1 = acima do limiar pré-epidemia, mas abaixo do limiar epidêmico, 2 = acima do limiar epidêmico
        /// notif_accum_year: Número acumulado de casos no ano
        /// </returns>
        [HttpGet(), Route("GetDiseaseGeoCode")]
        public IEnumerable<Domain.Models.AlertDiseaseApi> GetDiseaseGeoCode(string requestorName, string requestorCpf, string disease, string geoCode, int ew_start, int ew_end, int ey_start, int ey_end)
        {//disease=dengue&geocode=3304557&format=json&ew_start=1&ew_end=10&ey_start=2024&ey_end=2024

            var solicitanteDb = SaveChangesRequestor(requestorName, requestorCpf).GetAwaiter().GetResult();
            var diseaseList = new List<Domain.Models.AlertDiseaseApi>();
            var alert = new API.AlertDiseaseApi();
            var alertDiseaseParam = new AlertDiseaseParam
            {
                Disease = disease,
                GeoCode = geoCode,
                Ew_start = ew_start,
                Ew_end = ew_end,
                Ey_start = ey_start,
                Ey_end = ey_end
            };
            var message = alert.GetDiseaseAsync(alertDiseaseParam);
            var response = message.Result;

            if (response.Data != null)
                diseaseList.AddRange(response.Data);

            var report = new Report()
            {
                DataSolicitacao = DateTime.Now,
                Arbovirose = disease,
                SemanaInicio = alertDiseaseParam.Ew_start,
                SemanaTermino = alertDiseaseParam.Ew_end,
                CodigoIBGE = alertDiseaseParam.GeoCode,
                Municipio = GetMunicipio(alertDiseaseParam.GeoCode).GetAwaiter().GetResult(),
                SolicitanteId = solicitanteDb.SolicitanteId
            };

            SaveChangesReport(report).GetAwaiter().GetResult();

            return (IEnumerable<Domain.Models.AlertDiseaseApi>)diseaseList;
        }

        /// <summary>
        /// Consulta o total de casos epidemiológicos dos municípios do RJ e SP.
        /// </summary>
        /// <param name="requestorName">Nome do solicitante</param>
        /// <param name="requestorCpf">Nome do solicitante</param>
        /// <param name="ew_start">semana epidemiológica de início da consulta (int:1-53).</param>
        /// <param name="ew_end">semana epidemiológica de término da consulta (int:1-53).</param>
        /// <param name="ey_start">ano de início da consulta (int:0-9999)</param>
        /// <param name="ey_end">ano de término da consulta (int:0-9999)</param>
        /// <returns>
        /// Número total de casos notificados de todos as arboviroses no período 
        /// </returns>
        [HttpGet, Route("GetCountDiseaseSPRJ")]
        public int GetCountDiseaseSPRJ(string requestorName, string requestorCpf, int ew_start, int ew_end, int ey_start, int ey_end)
        {
            int diseaseCount = 0;

            var solicitanteDb = SaveChangesRequestor(requestorName, requestorCpf).GetAwaiter().GetResult();
            var alert = new API.AlertDiseaseApi();

            foreach (Disease diseaseEnum in Enum.GetValues(typeof(Disease)))
            {
                var disease = Enum.GetName(typeof(Disease), diseaseEnum) ?? string.Empty;
                var alertDiseaseParam = new AlertDiseaseParam
                {
                    Disease = disease,
                    GeoCode = "3304557",
                    Ew_start = ew_start,
                    Ew_end = ew_end,
                    Ey_start = ey_start,
                    Ey_end = ey_end
                };
                var message = alert.GetDiseaseAsync(alertDiseaseParam);
                var response = message.Result;

                if (response.Data != null)
                    diseaseCount += response.Data.Count;

                var reportRJ = new Report()
                {
                    DataSolicitacao = DateTime.Now,
                    Arbovirose = disease,
                    SemanaInicio = alertDiseaseParam.Ew_start,
                    SemanaTermino = alertDiseaseParam.Ew_end,
                    CodigoIBGE = alertDiseaseParam.GeoCode,
                    Municipio = GetMunicipio(alertDiseaseParam.GeoCode).GetAwaiter().GetResult(),
                    SolicitanteId = solicitanteDb.SolicitanteId
                };

                SaveChangesReport(reportRJ).GetAwaiter().GetResult();

                alertDiseaseParam.GeoCode = "3550308";
                message = alert.GetDiseaseAsync(alertDiseaseParam);
                response = message.Result;

                if (response.Data != null)
                    diseaseCount += response.Data.Count;

                var reportSP = new Report()
                {
                    DataSolicitacao = DateTime.Now,
                    Arbovirose = disease,
                    SemanaInicio = alertDiseaseParam.Ew_start,
                    SemanaTermino = alertDiseaseParam.Ew_end,
                    CodigoIBGE = alertDiseaseParam.GeoCode,
                    Municipio = GetMunicipio(alertDiseaseParam.GeoCode).GetAwaiter().GetResult(),
                    SolicitanteId = solicitanteDb.SolicitanteId
                };

                SaveChangesReport(reportSP).GetAwaiter().GetResult();
            }

            return diseaseCount;
        }

        /// <summary>
        /// Consultar o total de uma arbovirose pelo código IBGE do município.
        /// </summary>        /// 
        /// <param name="requestorName">Nome do solicitante</param>
        /// <param name="requestorCpf">Nome do solicitante</param>
        /// <param name="disease">tipo de arbovirose a ser consultado (str:dengue|chikungunya|zika)</param>
        /// <param name="geoCode">código IBGE do município.</param>
        /// <param name="ew_start">semana epidemiológica de início da consulta (int:1-53).</param>
        /// <param name="ew_end">semana epidemiológica de término da consulta (int:1-53).</param>
        /// <param name="ey_start">ano de início da consulta (int:0-9999)</param>
        /// <param name="ey_end">ano de término da consulta (int:0-9999)</param>
        /// <returns>
        /// Total de casos notificados de uma arbovirose no período de um município
        /// </returns>
        [HttpGet(), Route("GetCountDiseaseGeoCode")]
        public int GetCountDiseaseGeoCode(string requestorName, string requestorCpf, string disease, string geoCode, int ew_start, int ew_end, int ey_start, int ey_end)
        {//disease=dengue&geocode=3304557&format=json&ew_start=1&ew_end=10&ey_start=2024&ey_end=2024

            var solicitanteDb = SaveChangesRequestor(requestorName, requestorCpf).GetAwaiter().GetResult();
            var alert = new API.AlertDiseaseApi();
            var alertDiseaseParam = new AlertDiseaseParam
            {
                Disease = disease,
                GeoCode = geoCode,
                Ew_start = ew_start,
                Ew_end = ew_end,
                Ey_start = ey_start,
                Ey_end = ey_end
            };
            var message = alert.GetDiseaseAsync(alertDiseaseParam);
            var response = message.Result;
            var report = new Report()
            {
                DataSolicitacao = DateTime.Now,
                Arbovirose = disease,
                SemanaInicio = alertDiseaseParam.Ew_start,
                SemanaTermino = alertDiseaseParam.Ew_end,
                CodigoIBGE = alertDiseaseParam.GeoCode,
                Municipio = GetMunicipio(alertDiseaseParam.GeoCode).GetAwaiter().GetResult(),
                SolicitanteId = solicitanteDb.SolicitanteId
            };

            SaveChangesReport(report).GetAwaiter().GetResult();

            return response.Data != null ? response.Data.Count : 0;
        }

        /// <summary>
        /// Listar todos os solicitantes.
        /// </summary> 
        /// <returns>
        /// Lista com todos os solicitantes
        /// </returns>
        [HttpGet(), Route("GetAllRequestor")]
        public IEnumerable<Domain.Models.Requestor> GetAllRequestor()
        {
            return _requestorRepository.ListAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Listar todos os relatórios solicitados.
        /// </summary> 
        /// <returns>
        /// Lista com todos os relatórios solicitados
        /// </returns>
        [HttpGet(), Route("GetAllReport")]
        public IEnumerable<Domain.Models.Report> GetAllReport()
        {
            return _reportRepository.ListAsync().GetAwaiter().GetResult();
        }
        private async Task<Requestor?> SaveChangesRequestor(string requestorName, string requestorCpf)
        {
            var solicitanteDb = await _requestorRepository.FindByCpfAsync(requestorCpf).ConfigureAwait(false);

            if (solicitanteDb == null)
            {
                await _requestorRepository.AddAsync(new Requestor() { Cpf = requestorCpf, Nome = requestorName });
                _requestorRepository.SaveChanges();

                solicitanteDb = await _requestorRepository.FindByCpfAsync(requestorCpf);
            }

            return solicitanteDb;
        }

        private async Task SaveChangesReport(Report report)
        {
            await _reportRepository.AddAsync(report);

            _reportRepository.SaveChanges();
        }

        private async Task<string> GetMunicipio(string codIbge)
        {
            var municipio = await _municipioRepository.FindByCodIbgeAsync(codIbge).ConfigureAwait(false);

            return municipio != null ? municipio.Nome : string.Empty;
        }
    }
}
