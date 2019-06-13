using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Infra;
using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.DAL
{
    public class SurveryRepository : RepositoryBase<IRestaurantDbContext>, ISurveyRepository
    {
        public SurveryRepository(IRestaurantDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR RETORNAR OS DADOS DE ENQUETE
        /// </summary>
        /// <param name="ID">ID STUDENT</param>
        /// <returns>OBJETO ENQUETE</returns>
        public async Task<Survey> GetSurveyAsync(long student_id)
        {
            try
            {
                return await _dbContext.QuerySurvey.Where(x => x.SRV_STUDENT_ID.Equals(student_id) 
                                                            && x.SRV_DATE.Date == DateTime.Now.Date).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR PERSISTIR OS DADOS DE ENQUETE
        /// </summary>
        /// <param name="Survey">INSTANCIA DE ENQUETE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO ENQUETE</returns>
        public async Task<Survey> PostSurveyAsync(Survey survey)
        {
            try
            {
                _dbContext.Add(survey);
                await _dbContext.SaveChangesAsync();

                return survey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR ATUALIZAR O DADOS DE ENQUETE
        /// </summary>
        /// <param name="Survey">INSTANCIA DE ENQUETE</param>
        /// <returns>EM CASO DE SUCESSO RETORNA O OBJETO ENQUETE</returns>
        public async Task<Survey> PutSurveyAsync(Survey survey)
        {
            try
            {
                _dbContext.SetModified(survey);
                await _dbContext.SaveChangesAsync();

                return survey;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR UMA LISTA COM O RESULTADO PARCIAL DA ENQUETE
        /// </summary>
        /// <param name=""></param>
        /// <returns>RETORNA UMA LISTA DE VOTO</returns>
        public async Task<List<Object>> GetSurveyResultPartialAsync()
        {
            try
            {
                int totalVotes = await GetTotalVotesAsync();

                return await _dbContext.QuerySurvey.Where(x => x.SRV_DATE.Date == DateTime.Now.Date).GroupBy(x => x.SRV_RESTAURANT_ID).Select(x => new { SRV_RESTAURANT_ID = x.Key, VOTES = x.Count(), total = totalVotes }).AsNoTracking().ToListAsync<Object>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR RETORNAR O RESTAURANTE VENCEDOR DO DIA ATUAL
        /// </summary>
        /// <param name="ID">ID STUDENT</param>
        /// <returns>OBJETO ENQUETE</returns>
        public async Task<Object> GetSurveyWinnerAsync()
        {
            try
            {
                SurveyWinners sw = await _dbContext.QuerySurveyWinners.Where(x => x.SVW_DATE.Date == DateTime.Now.Date).AsNoTracking().FirstOrDefaultAsync();
                Entities.Restaurant rest = await _dbContext.QueryRestaurant.Where(x => x.RES_IDENTI == sw.SVW_RESTAURANT_ID).AsNoTracking().FirstOrDefaultAsync();

                return new
                {
                    RESTAURANT_ID = sw.SVW_RESTAURANT_ID,
                    DATE = sw.SVW_DATE,
                    VOTES = sw.SVW_VOTES,
                    TOTAL_VOTES = sw.SVW_TOTAL_VOTES,
                    RESTAURANT = rest,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSÁVEL POR PERSISTIR OS DADOS DO RESTAURANTE VENCEDOR
        /// </summary>
        /// <param name=""></param>
        /// <returns>BOOLEAN</returns>
        public async Task<SurveyWinners> PostSurveyFinishAsync()
        {
            try
            {
                //var winner = await _dbContext.QuerySurvey.Where(x => x.SRV_DATE.Date == DateTime.Now.Date).GroupBy(x => x.SRV_RESTAURANT_ID).Select(x => new { SRV_RESTAURANT_ID = x.Key, SRV_VOTES = x.Count() }).Max(x => x.SRV_VOTES);
                var surveyPartial = await GetSurveyResultPartialAsync();

                var winner = surveyPartial.Max();

                SurveyWinners sw = new SurveyWinners();

                //sw.SVW_RESTAURANT_ID = winner.SRV_RESTAURANT_ID;
                sw.SVW_DATE = DateTime.Now;
                //sw.SVW_VOTES = winner.SRV_VOTES;
                sw.SVW_TOTAL_VOTES = await GetTotalVotesAsync();

                _dbContext.Add(sw);
                await _dbContext.SaveChangesAsync();

                return sw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// METODO RESPONSAVEL POR RETORNAR A TOTALIZAÇÃO DE VOTOS DO DIA ATUAL
        /// </summary>
        /// <param name=""></param>
        /// <returns>TOTAL DE VOTOS</returns>
        private async Task<int> GetTotalVotesAsync()
        {
            try
            {
                return await _dbContext.QuerySurvey.Where(x => x.SRV_DATE.Date == DateTime.Now.Date).AsNoTracking().CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
