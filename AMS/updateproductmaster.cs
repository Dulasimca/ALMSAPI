using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMS_API.AMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class updateproductmaster : Controller
    {
        [HttpPost("{id}")]
        public string Post(updateproductmasterEntity updateproductmaster)

        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.updateproductmaster(updateproductmaster);
                return JsonConvert.SerializeObject(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
    public class updateproductmasterEntity
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public bool flag { get; set; }


    }
}


