using Restaurant.BLL.Infra;

namespace Restaurant.Api.UoW.Infra
{
    public interface IStudentUoW
    {
        IStudentBLL studentBLL { get; }
    }
}
