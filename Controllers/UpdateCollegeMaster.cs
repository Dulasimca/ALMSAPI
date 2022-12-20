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
    public class UpdateCollegeMaster : Controller
    {
        [HttpPost("{id}")]
        public string Post(updatecollegemasterEntity updatecollegemaster)
        {
            try
            {
                ManageSQLConnection manageSQL = new ManageSQLConnection();
                var result = manageSQL.updatecollegemaster(updatecollegemaster);
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "false";
        }
    }
    public class updatecollegemasterEntity
    {
        public int collegeid { get; set; }
        public string collegename { get; set; }
        public bool flag { get; set; }
    }
}