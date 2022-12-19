using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
namespace ALMS_API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class updateeditionmaster : Controller
    {
            [HttpPost("{id}")]
            public string Post(updateeditionmasterEntity updateeditionmaster)
            {
                try
                {
                    ManageSQLConnection manageSQL = new ManageSQLConnection();

                    var result = manageSQL.updateeditionmaster(updateeditionmaster);
                    return JsonConvert.SerializeObject(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return "false";
            }
        }
        public class updateeditionmasterEntity
        {
            public int editionid { get; set; }
            public string editionname { get; set; }
            public bool flag { get; set; }
        }
    }