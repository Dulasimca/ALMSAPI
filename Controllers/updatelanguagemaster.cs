using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class updatelanguagemaster : Controller
    {
        [HttpPost("{id}")]
        public string Post(updatelanguagemasterEntity updatelanguagemaster)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.updatelanguagemaster(updatelanguagemaster);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
    public class updatelanguagemasterEntity
    {
        public int languageid { get; set; }
        public string languagename { get; set; }
        public bool flag { get; set; }
    }
}