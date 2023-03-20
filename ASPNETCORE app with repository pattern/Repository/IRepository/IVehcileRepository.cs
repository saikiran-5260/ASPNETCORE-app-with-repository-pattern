using ASPNETCORE_app_with_repository_pattern.Model;
using ASPNETCORE_app_with_repository_pattern.Model.DTO;

namespace ASPNETCORE_app_with_repository_pattern.Repository.IRepository
{
    public interface IVehcileRepository<T> where T : class
    {
        List<T> GetVehciles();  
        T GetVehcileById(int id);
        T CreateVehcile(Vehicle vehicle);
        T UpdateVehcile(Vehicle vehicle,int id);
        string DeleteVehcile(int id);
    }
}
