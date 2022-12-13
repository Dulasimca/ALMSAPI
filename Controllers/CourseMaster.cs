using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ALMS_API.ManageSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseMaster : Controller
    {
        
           [HttpGet]
        public string GetCourseMaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetCourseMaster();
                return JsonConvert.SerializeObject(result);
            }
    }
    }
    public class CourseMasterEntity
{
    public int courseid { get; set; }
    public string coursename { get; set; }
    public bool flag { get; set; }

}
}