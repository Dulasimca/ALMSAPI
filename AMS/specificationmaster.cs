using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMS_API.AMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class specificationmaster : Controller
    {
        [HttpPost("{id}")]

        public string Specificationmaster(specificationmasterEntity specificationmasterEntity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.insertspecificationmaster(specificationmasterEntity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Getspecificationmaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.Getspecificationmaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class specificationmasterEntity
    {
        public int id { get; set; }
        public int productid { get; set; }
        public int brandid { get; set; }
        public string name { get; set; }
        public string specification { get; set; }
        public bool flag { get; set; }


    }
}
