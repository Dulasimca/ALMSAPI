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
    public class employeeregister : ControllerBase
    {
        [HttpPost]
        public string Post(TestEntity entity)
        {
            try
            {
            ManageSQLConnection manageSQL = new ManageSQLConnection();
            var result = manageSQL.Inserttest(entity);
            return JsonConvert.SerializeObject(result);
        }
        catch (Exception ex)
        {
            //AuditLog.WriteError(ex.Message);
        }
        return "false";
    }
}
public class TestEntity
{
    public int sno { get; set; }
    public string countryname { get; set; }



}
}

