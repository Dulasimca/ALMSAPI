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
    public class brandmaster : ControllerBase
    {
        [HttpPost("{id}")]

        public string Brandmaster(brandmasterEntity brandmasterEntity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.insertbrandmaster(brandmasterEntity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string Getbrandmaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.Getbrandmaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class brandmasterEntity
    {
        public int brandid { get; set; }
        public string brandname { get; set; }
        public bool flag { get; set; }


    }
}






