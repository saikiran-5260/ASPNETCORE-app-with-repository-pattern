using ASPNETCORE_app_with_repository_pattern.Data;
using ASPNETCORE_app_with_repository_pattern.Model;
using ASPNETCORE_app_with_repository_pattern.Model.DTO;
using ASPNETCORE_app_with_repository_pattern.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_app_with_repository_pattern.Repository
{
    public class VehcileRepository : IVehcileRepository<Vehicle>
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        public VehcileRepository(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;   
        }
        public Vehicle CreateVehcile(Vehicle vehicle)
        {
            //Vehicle v = new()
            //{
            //    VehicleId = vehicle.VehicleId,
            //    VehicleName = vehicle.VehicleName,
            //    VehicleBrand = vehicle.VehicleBrand,
            //    VehicleDescription = vehicle.VehicleDescription,
            //    VehicleType = vehicle.VehicleType,
            //};
            _db.Add(vehicle);
            _db.SaveChanges();
            return vehicle;
        }

        

        public string DeleteVehcile(int id)
        {
            if (id != null)
            {
                Vehicle v = _db.Vehicles.FirstOrDefault(x => x.VehicleId == id);
                _db.Remove(v);
            }
            _db.SaveChanges();
            return "Delete Successfully";
        }

        public Vehicle GetVehcileById(int id)
        {
            
            Vehicle v = _db.Vehicles.FirstOrDefault(x => x.VehicleId == id);
            return v;
        }

        public List<Vehicle> GetVehciles()
        {
            List<Vehicle> v = _db.Vehicles.ToList();
            return v;
        }

        public Vehicle UpdateVehcile(Vehicle vehicle, int id)
        {
            Vehicle V = _db.Vehicles.FirstOrDefault(x => x.VehicleId == id);
            V.VehicleBrand = vehicle.VehicleBrand;
            V.VehicleDescription = vehicle.VehicleDescription;
            V.VehicleType = vehicle.VehicleType;
            V.VehicleName = vehicle.VehicleName;
            _db.Vehicles.Update(V);
            _db.SaveChanges();
            return V;
        }
    }
}
