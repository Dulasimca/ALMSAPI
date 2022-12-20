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
    public class updatebrandmaster : Controller
    {
        [HttpPost("{id}")]
        public string Post(updatebrandmasterEntity updatebrandmaster)

        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.updatebrandmaster(updatebrandmaster);
                return JsonConvert.SerializeObject(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
        public class updatebrandmasterEntity
        {
            public int brandid { get; set; }
            public string brandname { get; set; }
            public bool flag { get; set; }


        }
    }
