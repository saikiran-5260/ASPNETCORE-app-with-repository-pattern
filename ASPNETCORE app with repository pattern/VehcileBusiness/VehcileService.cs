using ASPNETCORE_app_with_repository_pattern.Model;
using ASPNETCORE_app_with_repository_pattern.Model.DTO;
using ASPNETCORE_app_with_repository_pattern.Repository.IRepository;
using ASPNETCORE_app_with_repository_pattern.VehcileService.IVehcileService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_app_with_repository_pattern.VehcileService
{
    public class VehcileService : IVehcileService<VehcileDto>
    {
        private readonly IVehcileRepository<Vehicle> _vehcileRepository;
        private IMapper _mapper;
        public VehcileService(IVehcileRepository<Vehicle> vehcileRepository, IMapper mapper)
        {
            _vehcileRepository= vehcileRepository;
            _mapper= mapper;
        }
        public VehcileDto CreateVehcileService(VehcileDto vehicle)
        {
            
            Vehicle vehicle1 = _mapper.Map<VehcileDto, Vehicle>(vehicle);
            vehicle1 = new()
            {
                VehicleId = vehicle.VehicleId,
                VehicleType= vehicle.VehicleType,
                VehicleDescription= vehicle.VehicleDescription,
                VehicleName= vehicle.VehicleName,
                VehicleBrand= vehicle.VehicleBrand,

            };
            vehicle1 = _vehcileRepository.CreateVehcile(vehicle1);
            return _mapper.Map<Vehicle, VehcileDto>(vehicle1);
        }

        

        public string DeleteVehcileService(int id)
        {
            string result = _vehcileRepository.DeleteVehcile(id);
            return result;
        }

        public VehcileDto GetVehcileByIdService(int id)
        {
            var vehcile1 = _vehcileRepository.GetVehcileById(id);
            return _mapper.Map<VehcileDto>(vehcile1);
        }

        public List<VehcileDto> GetVehcilesService()
        {
            List<Vehicle> vehcile3 = _vehcileRepository.GetVehciles();
            return _mapper.Map<List<VehcileDto>>(vehcile3);
        }

        public VehcileDto UpdateVehcileService(VehcileDto vehicle, int id)
        {
            Vehicle vehcile4 = _mapper.Map<VehcileDto, Vehicle>(vehicle);
            //if (vehcile4 != null)
            //{

            //    vehcile4.vehiclebrand = vehicle.vehiclebrand;
            //    vehcile4.vehicledescription = vehicle.vehicledescription;
            //    vehcile4.vehicletype = vehicle.vehicletype;
            //    vehcile4.vehiclename = vehicle.vehiclename;
            //}
            vehcile4 = _vehcileRepository.UpdateVehcile(vehcile4,id);
            return _mapper.Map<Vehicle, VehcileDto>(vehcile4);
        }
    }
}
