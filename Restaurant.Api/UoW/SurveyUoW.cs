using Restaurant.Api.UoW.Infra;
using Restaurant.BLL.Infra;

namespace Restaurant.Api.UoW
{
    public class SurveyUoW : ISurveyUoW
    {
        public ISurveyBLL surveyBLL { get; }

        public SurveyUoW(ISurveyBLL surveyBLL)
        {
            this.surveyBLL = surveyBLL;
        }
    }
}
