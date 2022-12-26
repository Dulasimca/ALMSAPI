using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ALMS_API.AMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCount : Controller
    {
        [HttpGet]
        public string GetProductCount()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetProductCount();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
}
