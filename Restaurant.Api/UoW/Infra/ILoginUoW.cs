using Restaurant.BLL.Infra;

namespace Restaurant.Api.UoW.Infra
{
    public interface ILoginUoW
    {
        ILoginBLL loginBLL { get; }
    }
}
