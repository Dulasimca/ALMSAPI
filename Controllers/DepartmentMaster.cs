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
    public class DepartmentMaster : Controller
    {

        [HttpGet]
        public string GetCourseMaster()
        {
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();

                var result = manageSQL.GetDepartmentMaster();
                return JsonConvert.SerializeObject(result);
            }
        }
    }
    public class DepartmentMasterEntity
    {
        public int departmentid { get; set; }
        public string departmentname { get; set; }
        public bool flag { get; set; }

    }
}
