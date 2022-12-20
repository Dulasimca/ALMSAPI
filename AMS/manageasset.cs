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
    public class manageasset : ControllerBase
    {
        [HttpPost("{id}")]

        public string Manageasset(manageassetEntity manageassetEntity)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.insertmanageasset(manageassetEntity);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
        [HttpGet]
        public string getmanageasset()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.getmanageasset();
                return JsonConvert.SerializeObject(result);
            }
        }
    }

    public class manageassetEntity
    {
        public int assetid { get; set; }
        public int productid { get; set; }
        public int brandid { get; set; }
        public string currentuser { get; set; }
        public string lastuser { get; set; }

    }
}
