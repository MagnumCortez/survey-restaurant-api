using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.BLL.Infra;
using Restaurant.DAL.Infra;
using Restaurant.Entities;

namespace Restaurant.BLL
{
    public class SurveyBLL : ISurveyBLL
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyBLL(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA CONSULTA DE ENQUETE
        /// </summary>
        /// <param name="ID">ID STUDENT</param>
        /// <returns>OBJETO ENQUETE</returns>
        public async Task<Survey> GetSurveyAsync(long student_id)
        {
            try
            {
                ValidateSurveyTime();

                if (student_id <= 0)
                {
                    throw new Exception("Preencha o ID do estaudante");
                }

                var survey = await _surveyRepository.GetSurveyAsync(student_id);

                if (survey == null)
                {
                    throw new Exception("Nenhum voto computado para esse estaudante");
                }

                return survey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA A INCLUSÃO DE ENQUETE
        /// </summary>
        /// <param name="Survey">OBJECT SURVEY</param>
        /// <returns>OBJETO ENQUETE</returns>
        public async Task<Survey> PostSurveyAsync(Survey survey)
        {
            try
            {

                ValidateSurvey(survey);

                Survey voted = await _surveyRepository.GetSurveyAsync(survey.SRV_STUDENT_ID);
                if (voted != null)
                {
                    throw new Exception("Voto já computado para esse estudante");
                }

                survey.SRV_DATE = DateTime.Now;

                return await _surveyRepository.PostSurveyAsync(survey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTODO RESPONSÁVEL PELA VALIDAÇÃO DOS DADOS UTILIZADOS PARA ALTERAÇÃO DO ENQUETE
        /// </summary>
        /// <param name="Survey">OBJECT SURVEY</param>
        /// <returns>OBJETO ENQUETE</returns>
        public async Task<Survey> PutSurveyAsync(Survey survey)
        {
            try
            {
                ValidateSurvey(survey);

                var voted = await _surveyRepository.GetSurveyAsync(survey.SRV_STUDENT_ID);
                if (voted == null)
                {
                    throw new Exception("Voto não encontrado para esse estudante");
                }

                survey.SRV_IDENTI = voted.SRV_IDENTI;
                survey.SRV_DATE = DateTime.Now;

                return await _surveyRepository.PutSurveyAsync(survey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA RETORNO DA LISTA DE VOTOS DO RESULTADO PARCIAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>LIST OBJECT</returns>
        public async Task<List<Object>> GetSurveyResultPartialAsync()
        {
            try
            {
                ValidateSurveyTime();

                return await _surveyRepository.GetSurveyResultPartialAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA VALIDAÇÃO PARA RETORNO DE RESTAURANTE VENCEDOR DO DIA ATUAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>OBJETO</returns>
        public async Task<Object> GetSurveyWinnerAsync()
        {
            try
            {
                var surveyWinner = await _surveyRepository.GetSurveyWinnerAsync();

                if (surveyWinner  == null)
                {
                    throw new Exception("Enquente ainda não foi finalizada");
                }

                return surveyWinner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MÉTDODO RESPONSÁVEL PELA VALIDAÇÃO PARA FINALIZAÇÃO DE ENQUETE DO DIA ATUAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>OBJETO</returns>
        public async Task<SurveyWinners> PostSurveyFinishAsync()
        {
            try
            {
                var surveyfinished = await _surveyRepository.PostSurveyFinishAsync();

                if (surveyfinished == null)
                {
                    throw new Exception("Não foi possível finalizar Enquente");
                }

                return surveyfinished;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ValidateSurveyTime()
        {
            //Setando Atributos de debugar em outro período
            int HourOpenning = 10;
            int HourClosing = 23;

            if (DateTime.Now.TimeOfDay < new TimeSpan(HourOpenning, 00, 00))
            {
                throw new Exception("A votação ainda não foi iniciada!");
            }

            if (DateTime.Now.TimeOfDay > new TimeSpan(HourClosing, 00, 00))
            {
                //throw new Exception("Votação encerrada!");
            }
        }

        private void ValidateSurvey(Survey survey)
        {
            ValidateSurveyTime();

            if (survey.SRV_STUDENT_ID <= 0)
            {
                throw new Exception("Preencha o ID do estudante com um valor superior a zero");
            }

            if (survey.SRV_RESTAURANT_ID <= 0)
            {
                throw new Exception("Preencha o ID do restaurante com um valor superior a zero");
            }
        }
    }
}
