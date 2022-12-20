using ALMS_API.ManageSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;


namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class updatedepartmentmaster : Controller
    {

        [HttpPost("{id}")]
        public string Post(updatedepartmentmasterEntity updatedepartmentmaster)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.updatedepartmentmaster(updatedepartmentmaster);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
    public class updatedepartmentmasterEntity
    {
        public int departmentid { get; set; }
        public string departmentname { get; set; }
        public bool flag { get; set; }
    }
}
