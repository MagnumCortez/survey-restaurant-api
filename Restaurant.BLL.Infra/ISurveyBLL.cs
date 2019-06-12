using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.BLL.Infra
{
    public interface ISurveyBLL
    {
        Task<Survey> GetSurveyAsync(long student_id);
        Task<Survey> PostSurveyAsync(Survey survey);
        Task<Survey> PutSurveyAsync(Survey survey);
        Task<List<Object>> GetSurveyResultPartialAsync();
    }
}
