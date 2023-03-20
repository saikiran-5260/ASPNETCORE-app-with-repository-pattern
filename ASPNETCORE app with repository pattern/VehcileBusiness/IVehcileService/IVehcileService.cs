using ASPNETCORE_app_with_repository_pattern.Model;
using ASPNETCORE_app_with_repository_pattern.Model.DTO;
using ASPNETCORE_app_with_repository_pattern.Repository.IRepository;

namespace ASPNETCORE_app_with_repository_pattern.VehcileService.IVehcileService
{
    public interface IVehcileService<T> 
    {
        List<T> GetVehcilesService();
        T GetVehcileByIdService(int id);
        T CreateVehcileService(VehcileDto vehicle);
        T UpdateVehcileService(VehcileDto vehicle, int id);
        string DeleteVehcileService(int id);
    }
}
