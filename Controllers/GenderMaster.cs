using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderMaster : Controller
    {

        [HttpGet]
        public string GetGenderMaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetGenderMaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class GenderMasterEntity
    {
        public int languageid { get; set; }
        public string languagename { get; set; }
        public bool flag { get; set; }

    }
}
