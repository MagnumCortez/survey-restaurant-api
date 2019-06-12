using Restaurant.BLL.Infra;

namespace Restaurant.Api.UoW.Infra
{
    public interface ISurveyUoW
    {
        ISurveyBLL surveyBLL { get; }
    }
}
