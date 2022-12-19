using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
namespace ALMS_API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class updatecoursemaster : Controller
    {
        [HttpPost("{id}")]
        public string Post(updatecoursemasterEntity updatecoursemaster)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.updatecoursemaster(updatecoursemaster);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
    public class updatecoursemasterEntity
    {
        public int courseid { get; set; }
        public string coursename { get; set; }
        public bool flag { get; set; }
    }
}
