//using ASPNETCORE_app_with_repository_pattern.Filters;
using ASPNETCORE_app_with_repository_pattern.Model;
using ASPNETCORE_app_with_repository_pattern.Model.DTO;
using ASPNETCORE_app_with_repository_pattern.Repository;
using ASPNETCORE_app_with_repository_pattern.Repository.IRepository;
using ASPNETCORE_app_with_repository_pattern.VehcileService.IVehcileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETCORE_app_with_repository_pattern.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class VehcileController : Controller
    {
        private readonly IVehcileService<VehcileDto> _vehcile;

        public VehcileController(IVehcileService<VehcileDto> vehcile)
        {
            _vehcile = vehcile;
        }

        [HttpGet]
        [Route("Get")]

        public ActionResult<List<VehcileDto>> Get()
        {
            return Ok(_vehcile.GetVehcilesService());
        }
        [HttpPost]
        [Route("Post")]
        public ActionResult<VehcileDto> Post(VehcileDto newV)
        {

            return Ok(_vehcile.CreateVehcileService(newV));
        }
        [HttpPut]
        [Route("Put")]
        public ActionResult<VehcileDto> Put(VehcileDto newV, int id)
        {

            _vehcile.UpdateVehcileService(newV, id);
            return Ok(_vehcile.GetVehcilesService());
        }
        [HttpDelete]
        [Route("Delete")]
        public ActionResult<Vehicle> Delete(int id)
        {

            return Ok(_vehcile.DeleteVehcileService(id));
        }
    }
}
