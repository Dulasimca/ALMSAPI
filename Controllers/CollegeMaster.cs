using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeMaster : Controller
    {
        [HttpGet]
        public string GetCollegeMaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetCollegeMaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class CollegeMasterrEntity
    {
        public int collegeid { get; set; }
        public string collegename { get; set; }
        public bool flag { get; set; }

    }
}