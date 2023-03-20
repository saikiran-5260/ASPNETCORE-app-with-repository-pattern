using System.ComponentModel.DataAnnotations;

namespace ASPNETCORE_app_with_repository_pattern.Model
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set;}
        public string VehicleDescription { get; set;}

    }
    
}
