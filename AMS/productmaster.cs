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
    public class productmaster : ControllerBase

    {
        [HttpGet(nameof(Getproductmaster))]

        public string Getproductmaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.Getproductmaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class productmasterEntity
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public bool flag { get; set; }

    }
}




