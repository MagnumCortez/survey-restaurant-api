using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.UoW.Infra;
using Restaurant.Entities;
using Restaurant.Helpers;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private ISurveyUoW _surveyUoW;

        public SurveyController(ISurveyUoW surveyUoW)
        {
            _surveyUoW = surveyUoW;
        }

        /// <summary>
        /// RETORNA O VOTO DO ESTUDANTE NO DIA ATUAL
        /// </summary>
        /// <param name="ID">ID ESTUDANTE</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("api/[controller]/{id}"), HttpGet]
        public async Task<IActionResult> GetSurvey(long id)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _surveyUoW.surveyBLL.GetSurveyAsync(id);
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// COMPUTAR VOTO DO ESTUDANTE
        /// </summary>
        /// <param name="survey">OBJETO SURVEY</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("api/[controller]"), HttpPost]
        public async Task<IActionResult> PostSurvey([FromBody]Survey survey)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _surveyUoW.surveyBLL.PostSurveyAsync(survey);
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// ATUALIZAR VOTO DO ESTUDANTE
        /// </summary>
        /// <param name="survey">OBJETO SURVEY</param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("api/[controller]"), HttpPut]
        public async Task<IActionResult> PutSurvey([FromBody]Survey survey)
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _surveyUoW.surveyBLL.PutSurveyAsync(survey);
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }

        /// <summary>
        /// RETORNA O RESULTADO PARCIAL DO DIA ATUAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>OBJETO RESPONSE</returns>
        [Route("api/[controller]/day/partial"), HttpGet]
        public async Task<IActionResult> GetSurveyParcial()
        {
            var response = new ResponseContent();
            try
            {
                response.Object = await _surveyUoW.surveyBLL.GetSurveyResultPartialAsync();
                response.Message = "Requisição realizada com sucesso.";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return Ok(response);
        }
    }
}