using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMS_API.ManageSQL;
using Newtonsoft.Json;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class updatelibrarienregister : Controller
    {
        [HttpPost]
        public string udatelibrarienregister(updatelibrarienregisterEntity updatelibrarienregisterEntity)
     
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.updatelibrarienregister(updatelibrarienregisterEntity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
    public class updatelibrarienregisterEntity
    {
        public int v_id { get; set; }
        public string v_username { get; set; }
        public string v_email { get; set; }
        public string v_password { get; set; }
        public string v_confirmpassword { get; set; }


    }
}
