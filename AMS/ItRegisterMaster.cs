using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItRegisterMaster : Controller
    {

        [HttpGet(nameof(GetItRegister))]
        public string GetItRegister()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetItRegister();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class GetItRegisterEntity
    {
        public int sno { get; set; }
        public string name { get; set; }
        public int employeeid { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }


    }
}
