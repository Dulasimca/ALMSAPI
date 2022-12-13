using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class librarienregisterget : Controller
    {

        [HttpGet(nameof(GetLibrarienRegister))]
        public string GetLibrarienRegister()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.Getlibrarain();

                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class LibrarienRegisterEntity
    {
        public int sno { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
    }
}
 
